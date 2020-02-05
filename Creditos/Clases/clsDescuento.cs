using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsDescuento{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mDescuento> lista_descuentos = new List<mDescuento>();
        public List<mDescuento> mostrar(){
            foreach (var item in db.spConsultarDescuento()){
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.valor), item.cabecera, item.mes, Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
        public void ingresar(mDescuento datos){
            db.spInsertarDescuento(datos.valor, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha);
        }
        public void eliminar(int id){
            db.spEliminarDescuento(id);
        }
        public Boolean modificar(mDescuento datos){
            Boolean result = false;
            try{
                db.spModificarDescuento(datos.id_descuento, datos.valor, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mDescuento> mostrarById(int id){
            foreach (var item in db.spConsultarDescuentoById(id)){
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.valor), item.Id_Persona, item.id_cabecera_descuento, item.id_mes, Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
    }
}