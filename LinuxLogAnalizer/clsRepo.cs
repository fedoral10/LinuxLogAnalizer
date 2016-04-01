using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LinuxLogAnalizer
{
    class clsRepo
    {
        #region Genericos
        public void Insertar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void Eliminar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void Actualizar<TClase>(TClase Objeto)
        {
            try
            {
                using (ISession session = NHelper.GetCurrentSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Objeto);
                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public IList<TClase> Seleccionar<TClase>() where TClase : class
        {
            using (ISession session = NHelper.GetCurrentSession())
            {
                return session.CreateCriteria<TClase>().List<TClase>();
            }
        }
        public DataTable Seleccionar(string sql)
        {
            DataTable dt;
            using (ISession session = NHelper.GetCurrentSession())
            {

                using (IDbConnection sql_con = session.Connection)
                {
                    dt = new DataTable();
                    IDbCommand cmd = sql_con.CreateCommand();

                    cmd.CommandText = sql;

                    var reader = cmd.ExecuteReader();

                    dt = GetDataTableFromDataReader(reader);
                }
            }
            return dt;
        }
        public DataTable GetDataTableFromDataReader(IDataReader dataReader)
        {
            DataTable schemaTable = dataReader.GetSchemaTable();
            DataTable resultTable = new DataTable();

            foreach (DataRow dataRow in schemaTable.Rows)
            {
                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = dataRow["ColumnName"].ToString().ToUpper();
                dataColumn.DataType = Type.GetType(dataRow["DataType"].ToString());
                //dataColumn.ReadOnly = (bool)dataRow["IsReadOnly"];
                //dataColumn.AutoIncrement = (bool)dataRow["IsAutoIncrement"];
                //dataColumn.Unique = (bool)dataRow["IsUnique"];

                resultTable.Columns.Add(dataColumn);
            }

            while (dataReader.Read())
            {
                DataRow dataRow = resultTable.NewRow();
                for (int i = 0; i < resultTable.Columns.Count; i++)
                {
                    dataRow[i] = dataReader[i];
                }
                resultTable.Rows.Add(dataRow);
            }

            return resultTable;
        }
        public int Actualizacion(string sql)
        {

            int i = 0;
            using (ISession session = NHelper.GetCurrentSession())
            {

                using (IDbConnection sql_con = session.Connection)
                {

                    IDbCommand cmd = sql_con.CreateCommand();

                    cmd.CommandText = sql;

                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }
        public int ContadorRows<TClase>() where TClase : class
        {
            int rows = 0;
            using (ISession session = NHelper.GetCurrentSession())
            {

                rows = session.QueryOver<TClase>()
                       .Select(Projections.RowCount())
                       .FutureValue<int>()
                       .Value;


            }

            return rows;
        }
        #endregion
        
    }
    static class clsRepoConvertidor
    {
        public static DataTable Seleccionar_Datatable<TClase>() where TClase : class
        {
            clsRepo repo = new clsRepo();
            return ToDataTable<TClase>(repo.Seleccionar<TClase>());
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static DataTable ToDataTable<T>(this List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
