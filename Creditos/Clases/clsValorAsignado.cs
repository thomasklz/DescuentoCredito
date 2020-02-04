using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsValorAsignado{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        List<mValorAsignado> lista_valor_asignado = new List<mValorAsignado>();
        public List<mValorAsignado> mostrar(){
            foreach (var item in db.spConsultarValorAsignado()){
                lista_valor_asignado.Add(new mValorAsignado(item.id_valor_asig, item.proveedor, item.persona, Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_asignado;
        }
        public void ingresar(mValorAsignado datos){
            db.spInsertarValorAsignado( datos.proveedor_id, datos.aso_id, datos.empleado_id, datos.monto_aprobado);
        }
        public void eliminar(int id){
            db.spEliminarValorAsignado(id);
        }
        public Boolean modificar(mValorAsignado datos)
        {
            Boolean result = false;
            try
            {
                db.spModificarValorAsignado(datos.id_valor_asig, datos.proveedor_id, datos.aso_id, datos.empleado_id, datos.monto_aprobado);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mValorAsignado> mostrarById(int id)
        {
            foreach (var item in db.spConsultarValorAsignadoById(id))
            {
                lista_valor_asignado.Add(new mValorAsignado(item.id_valor_asig, item.proveedor, item.persona, Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_asignado;
        }
    }
}