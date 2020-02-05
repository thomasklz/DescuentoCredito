using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsTipoIngreso{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mTipoIngreso> lista_t_ingreso = new List<mTipoIngreso>();

        public List<mTipoIngreso> mostrar(){
           
            foreach (var item in db.spConsultarTipoIngreso())
            {
                lista_t_ingreso.Add(new mTipoIngreso(item.id_tipo_ingreso, item.descripcion));
            }
            return lista_t_ingreso;
        }
        public void ingresar(mTipoIngreso datos){
            db.spInsertarTipoIngreso(datos.descripcion);
        }
        public void eliminar(mTipoIngreso datos){
            db.spEliminarTipoIngreso(datos.id_tipo_ingreso);

        }
        public void modificar(mTipoIngreso datos){
            db.spModificarTipoIngreso(datos.id_tipo_ingreso, datos.descripcion);
        }
    }
}