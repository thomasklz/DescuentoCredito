using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsMes{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mMes> mostrarMeses(){
            List<mMes> lista_mes = new List<mMes>();
            foreach (var item in db.spConsultarMes()){
                lista_mes.Add(new mMes(item.id_mes, item.descripcion));
            }
            return lista_mes;
        }
        public void ingresarMes(mMes datos){
            db.spInsertarMes(datos.descripcion);
        }
        public void eliminar(mMes datos){
            db.spEliminarMes(datos.id_mes);
        }
        public void modificar(mMes datos){
            db.spModificarMes(datos.id_mes, datos.descripcion);
        }

    }
}