using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsCabeceraDescuento{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        List<mCabeceraDescuento> lista_cabecera_descuento = new List<mCabeceraDescuento>();
        public List<mCabeceraDescuento> mostrar(){
            foreach (var item in db.spConsultarCabeceraDescuento()){
                lista_cabecera_descuento.Add(new mCabeceraDescuento(item.id_cabecera_descuento, item.descripcion, item.subdescuento));
            }
            return lista_cabecera_descuento;
        }
        public void ingresar(mCabeceraDescuento datos){
            db.spInsertarCabeceraDescuento(datos.descripcion, datos.subdescuento_id);
        }
        public void eliminar(int id){
            db.spEliminarCabeceraDescuento(id);
        }
        public Boolean modificar(mCabeceraDescuento datos){
            Boolean result = false;
            try{
                db.spModificarCabeceraDescuento(datos.id_cabecera_descuento, datos.descripcion, datos.subdescuento_id);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mCabeceraDescuento> mostrarById(int id){
            foreach (var item in db.spConsultarCabeceraDescuentoById(id)){
                lista_cabecera_descuento.Add(new mCabeceraDescuento(item.id_cabecera_descuento, item.descripcion, item.id_subdescuento));
            }
            return lista_cabecera_descuento;
        }
    }
}