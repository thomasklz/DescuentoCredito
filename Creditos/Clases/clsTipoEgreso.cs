using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsTipoEgreso{
        Roles_Creditos_BDEntities1 db = new Roles_Creditos_BDEntities1();
        public List<mTipoEgreso> mostrar(){
            List<mTipoEgreso> lista_t_egreso = new List<mTipoEgreso>();
            foreach (var item in db.spConsultarTipoEgreso()){
                lista_t_egreso.Add(new mTipoEgreso(item.id_tipo_egreso, item.descripcion));
            }
            return lista_t_egreso;
        }
        public void ingresar(mTipoEgreso datos){
            db.spInsertarTipoEgreso(datos.descripcion, datos.est_delete);
        }
        public void eliminar(mTipoEgreso datos){
            db.spEliminarTipoEgreso(datos.id_tipo_egreso);

        }
        public void modificar(mTipoEgreso datos)
        {
            db.spModificarTipoEgreso(datos.id_tipo_egreso, datos.descripcion);
        }
    }
}