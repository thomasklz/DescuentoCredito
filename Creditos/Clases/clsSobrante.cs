using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsSobrante{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mSobrante> mostrar(){
            List<mSobrante> lista_sobrantes = new List<mSobrante>();
            foreach (var item in db.spConsultarSobrante()){
                lista_sobrantes.Add(new mSobrante(item.id_sobrante, Convert.ToInt32(item.descuento_id), Convert.ToDouble(item.valor), Convert.ToBoolean(item.estado)));
            }
            return lista_sobrantes;
        }
        public void ingresar(mSobrante datos){
            db.spInsertarSobrante(datos.descuento_id, datos.valor, datos.estado);
        }
        public void eliminar(mSobrante datos){
            db.spEliminarSobrante(datos.id_sobrante);
        }
        public void modificar(mSobrante datos){
            db.spModificarSobrante(datos.id_sobrante, datos.descuento_id, datos.valor, datos.estado);
        }
    }
}