using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinuxLogAnalizer
{
        class NHelper
        {

            private static string connection_string;

            public static string BaseDatos { get; set; }

            public static int createDatabase(string user, string pass,string dbname, string host, string port)
            {
                string texto = "Server={0};Port={1};user id={2};password={3}";
                string cadena_conexion = String.Format(texto, host, port,user, pass);

                var m_conn = new NpgsqlConnection(cadena_conexion);

                // creating a database in Postgresql
                var m_createdb_cmd = new NpgsqlCommand("CREATE DATABASE IF NOT EXISTS  \"" + dbname + "\" " +
                                       "WITH OWNER = \"postgres\" " +
                                       "ENCODING = 'UTF8' " +
                                       "CONNECTION LIMIT = -1;", m_conn);

                // creating a table in Postgresql
                m_conn.Open();
                int retorno = m_createdb_cmd.ExecuteNonQuery();
                m_conn.Close();

                return retorno;
            }

            public static void setConnectionString(string user, string pass, string db, string host, string port)
            {
                string texto = "Server={0};Port={1};database={2};user id={3};password={4};timeout=1000;";
                connection_string = String.Format(texto, host, port, db, user, pass);
                BaseDatos = db;
            }

            private static void ExportarEsquema(Configuration cfg)
            {

                var lol = new SchemaUpdate(cfg);
                lol.Execute(false, true);
                //lol.Execute(true, false);

            }


            public static ISession GetCurrentSession()
            {
                if (SessionFactory == null)
                    NHelper.OpenSession();


                return SessionFactory.OpenSession();
            }


            public static void CloseSessionFactory()
            {
                if (SessionFactory != null)
                    SessionFactory.Close();
            }



            private static ISessionFactory _sessionFactory;
            //private static ISession _sesion;
            private static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory == null)
                    {
                        var configuration = new Configuration();
                        //configuration.Configure();
                        Dictionary<string, string> propiedades = new Dictionary<string, string>();

                        propiedades.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
                        propiedades.Add("connection.driver_class", "NHibernate.Driver.NpgsqlDriver");
                        propiedades.Add("connection.connection_string", connection_string);
                        propiedades.Add("dialect", "NHibernate.Dialect.PostgreSQLDialect");
                        propiedades.Add("hibernate.hbm2ddl.auto", "create");

                        //<property name="hibernate.hbm2ddl.auto">create</property>
                        //propiedades.Add("adonet.batch_size", "0");
                        //propiedades.Add("show_sql", "true");

                        configuration.AddProperties(propiedades);
                        //configuration.AddAssembly(typeof(EntidadAplicacion).Assembly);
                        configuration.AddAssembly(typeof(Dominio.Group).Assembly);
                        _sessionFactory = configuration.BuildSessionFactory();
                        ExportarEsquema(configuration);
                    }
                    return _sessionFactory;
                }
            }

            public static ISession OpenSession()
            {
                return SessionFactory.OpenSession();
            }
        }

    
}
