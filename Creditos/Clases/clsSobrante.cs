using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsSobrante{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mSobrante> lista_sobrantes = new List<mSobrante>();

        public List<mSobrante> mostrar(){
            foreach (var item in db.spConsultarSobrante()){
                lista_sobrantes.Add(new mSobrante(item.id_sobrante, Convert.ToDouble(item.valor), item.descuento, Convert.ToBoolean(item.estado)));
            }
            return lista_sobrantes;
        }
        public void ingresar(mSobrante datos){
            db.spInsertarSobrante(datos.descuento_id, datos.valor, datos.estado);
        }
        public void eliminar(int id){
            db.spEliminarSobrante(id);
        }
        public Boolean modificar(mSobrante datos){
            Boolean result = false;
            try{
                db.spModificarSobrante(datos.id_sobrante, datos.descuento_id, datos.valor, datos.estado);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mSobrante> mostrarById(int id){
            foreach (var item in db.spConsultarSobranteById(id)){
                lista_sobrantes.Add(new mSobrante(item.id_sobrante, Convert.ToDouble(item.valor), item.id_descuento, Convert.ToBoolean(item.estado)));
            }
            return lista_sobrantes;
        }
    }
}