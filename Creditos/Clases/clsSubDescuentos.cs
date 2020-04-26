using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases
{
    public class clsSubDescuentos
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mSubDescuentos> listasubd = new List<mSubDescuentos>();
        public List<mSubDescuentos> mostrar()
        {
            foreach (var item in db.spConsultarSubDescuento())
            {
                listasubd.Add(new mSubDescuentos(item.id_subdescuento, item.descripcion));
            }
            return listasubd;
        }
        public void ingresar(mSubDescuentos datos)
        {
            db.spInsertarSubDescuento(datos.descripcion);
        }
        public void eliminar(int id)
        {
            db.spEliminarSubDescuento(id);
        }
        public Boolean modificar(mSubDescuentos datos)
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
        public List<mSubDescuentos> mostrarById(int id)
        {
            foreach (var item in db.spConsultarSubdescuentoById(id))
            {
                listasubd.Add(new mSubDescuentos(item.id_subdescuento, item.descripcion));
            }
            return listasubd;
        }
    }
}