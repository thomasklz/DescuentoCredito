using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsValorAsignado{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mValorAsignado> mostrar(){
            List<mValorAsignado> lista_valor_asignado = new List<mValorAsignado>();
            foreach (var item in db.spConsultarValorAsignado()){
                lista_valor_asignado.Add(new mValorAsignado(item.id_valor_asig, Convert.ToInt32(item.proveedor_id), Convert.ToInt32(item.aso_id), Convert.ToInt32(item.empleado_id), Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_asignado;
        }
        public void ingresar(mValorAsignado datos){
            db.spInsertarValorAsignado( datos.proveedor_id, datos.aso_id, datos.empleado_id, datos.monto_aprobado);
        }
        public void eliminar(mValorAsignado datos){
            db.spEliminarValorAsignado(datos.id_valor_asig);
        }
        public void modificar(mValorAsignado datos){
            db.spModificarValorAsignado(datos.id_valor_asig, datos.proveedor_id, datos.aso_id, datos.empleado_id, datos.monto_aprobado);
        }
    }
}