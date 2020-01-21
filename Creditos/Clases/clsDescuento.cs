using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsDescuento{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mDescuento> mostrar(){
            List<mDescuento> lista_descuentos = new List<mDescuento>();
            foreach (var item in db.spConsultarDescuento()){
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.valor), Convert.ToInt32(item.empleado_id), Convert.ToInt32(item.cab_desc_id), Convert.ToInt32(item.mes_id), Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
        public void ingresar(mDescuento datos){
            db.spInsertarDescuento(datos.valor, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha);
        }
        public void eliminar(mDescuento datos){
            db.spEliminarDescuento(datos.id_descuento);
        }
        public void modificar(mDescuento datos){
            db.spModificarDescuento(datos.id_descuento, datos.valor, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha);
        }
    }
}