using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases
{
    public class clsSubDescuento
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsSubDescuento clssubd = new clsSubDescuento();
        List<mSubDesuento> lista_subdescuento = new List<mSubDesuento>();
        public List<mSubDesuento> mostrar()
        {

            foreach (var item in db.spConsultarSubDescuento())
            {
                lista_subdescuento.Add(new mSubDesuento(item.id_subdescuento, item.descripcion));
            }
            return lista_subdescuento;
        }
        public void ingresar(mSubDesuento datos)
        {
            db.spInsertarSubDescuento(datos.descripcion);
        }
        public void eliminar(int id)
        {
            db.spEliminarSubDescuento(id);
        }

        public Boolean modificar(mSubDesuento datos)
        {
            Boolean result = false;
            try
            {
                db.spModificarSubDescuento(datos.id_subdescuento, datos.descripcion);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mSubDesuento> mostrarById(int id)
        {
            foreach (var item in db.spConsultarSubdescuentoById(id))
            {
                lista_subdescuento.Add(new mSubDesuento(item.id_subdescuento, item.descripcion));
            }
            return lista_subdescuento;
        }
    }
}