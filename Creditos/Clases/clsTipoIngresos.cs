using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;
namespace Creditos.Clases
{
    public class clsTipoIngresos
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mTipoIngreso> tipoi = new List<mTipoIngreso>();
        public List<mTipoIngreso> mostrar()
        {
            foreach (var item in db.spConsultarTipoIngreso())
            {
                tipoi.Add(new mTipoIngreso(item.id_tipo_ingreso, item.descripcion));
            }
            return tipoi;
        }
        public void ingresar(mTipoIngreso datos)
        {
            db.spInsertarTipoIngreso(datos.descripcion);
        }
        public void eliminar(int id)
        {
            db.spEliminarTipoIngreso(id);
        }
        public Boolean modificar(mTipoIngreso datos)
        {
            Boolean result = false;
            try
            {
                db.spModificarTipoIngreso(datos.id_tipo_ingreso, datos.descripcion);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mTipoIngreso> mostrarById(int id)
        {
            foreach (var item in db.spConsultarTipoIngresoById(id))
            {
                tipoi.Add(new mTipoIngreso(item.id_tipo_ingreso, item.descripcion));
            }
            return tipoi;
        }
    }
}