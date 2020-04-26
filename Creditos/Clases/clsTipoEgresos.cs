using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;
namespace Creditos.Clases
{
    public class clsTipoEgresos
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mTipoEgreso> tipoe = new List<mTipoEgreso>();
        public List<mTipoEgreso> mostrar()
        {
            foreach (var item in db.spConsultarTipoEgreso())
            {
                tipoe.Add(new mTipoEgreso(item.id_tipo_egreso, item.descripcion));
            }
            return tipoe;
        }
        public void ingresar(mTipoEgreso datos)
        {
            db.spInsertarTipoEgreso(datos.descripcion);
        }
        public void eliminar(int id)
        {
            db.spEliminarTipoEgreso(id);
        }
        public Boolean modificar(mTipoEgreso datos)
        {
            Boolean result = false;
            try
            {
                db.spModificarTipoEgreso(datos.id_tipo_egreso, datos.descripcion);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mTipoEgreso> mostrarById(int id)
        {
            foreach (var item in db.spConsultarTipoEgresoById(id))
            {
                tipoe.Add(new mTipoEgreso(item.id_tipo_egreso, item.descripcion));
            }
            return tipoe;
        }
    }
}