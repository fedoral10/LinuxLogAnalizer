using SimpleExcelImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinuxLogAnalizer.Excel
{
    class Ip
    {
        [ExcelImport("ip", order = 1)]
        public string ip { get; set; }

        [ExcelImport("descripcion", order = 2)]
        public string descripcion { get; set; }

        [ExcelImport("samaccountname", order = 3)]
        public string samaccountname { get; set; }

        public Dominio.Ip getDBip()
        {
            Dominio.Ip ip = new Dominio.Ip();
            ip.ip = this.ip;
            ip.descripcion = this.descripcion;
            ip.samaccountname = this.samaccountname;
            return ip;
        }
    }
}
