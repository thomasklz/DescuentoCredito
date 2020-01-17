using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsCabeceraDescuento{
        Entities db = new Entities();
        public List<mCabeceraDescuento> mostrar(){
            List<mCabeceraDescuento> lista_cabecera_descuento = new List<mCabeceraDescuento>();
            foreach (var item in db.spConsultarCabeceraDescuento()){
                lista_cabecera_descuento.Add(new mCabeceraDescuento(item.id_cabecera_descuento, item.descripcion, item.subdescuento_id));
            }
            return lista_cabecera_descuento;
        }
        public void ingresar(mCabeceraDescuento datos){
            db.spInsertarCabeceraDescuento(datos.descripcion, datos.subdescuento_id);
        }
        public void eliminar(mCabeceraDescuento datos){
            db.spEliminarCabeceraDescuento(datos.id_cabecera_descuento);
        }
        public void modificar(mCabeceraDescuento datos){
            db.spModificarCabeceraDescuento(datos.id_cabecera_descuento, datos.descripcion, datos.subdescuento_id);
        }
    }
}