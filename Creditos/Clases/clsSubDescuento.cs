using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsSubDescuento{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        public List<mSubDesuento> mostrar(){
            List<mSubDesuento> lista_subdescuento = new List<mSubDesuento>();
            foreach (var item in db.spConsultarSubDescuento())
            {
                lista_subdescuento.Add(new mSubDesuento(item.id_subdescuento, item.descripcion));
            }
            return lista_subdescuento;
        }
        public void ingresar(mSubDesuento datos){
            db.spInsertarSubDescuento(datos.descripcion);
        }
        public void eliminar(mSubDesuento datos){
            db.spEliminarSubDescuento(datos.id_subdescuento);
        }
        public void modificar(mSubDesuento datos){
            db.spModificarSubDescuento(datos.id_subdescuento, datos.descripcion);
        }
    }
}