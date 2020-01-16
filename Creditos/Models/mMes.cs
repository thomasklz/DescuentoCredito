using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mMes{
        public int id_mes { get; set; }
        public string descripcion { get; set; }
        public Boolean est_delete { get; set; }

        public mMes() { }
        public mMes(int id_mes, string descripcion){
            this.id_mes = id_mes;
            this.descripcion = descripcion;
        }
    }
}