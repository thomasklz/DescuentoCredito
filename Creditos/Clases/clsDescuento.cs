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
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.valor), item.persona, item.cabecera, item.mes, Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
        public void ingresar(mDescuento datos){
            db.spInsertarDescuento(datos.valor, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha.Date);
        }
        public void ingresarxAjuste(mDescuento datos){
            db.spInsertarDescuentoxAjuste(datos.val_asig,datos.valor,datos.sumatoria, datos.empleado_id, datos.cab_desc_id, datos.mes_id, datos.fecha.Date);
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
        public List<mDescuento> mostrarxEmpleado(int id){
            foreach (var item in db.spConsultarDescuentoxEmpleado(id)){
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.valor), item.persona, item.cabecera, item.mes, Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
        
        public List<mDescuento> mostrarValoresAso(){
            foreach (var item in db.spConsultarValoresAsoc())
            {
                lista_descuentos.Add(new mDescuento(item.id_valor_asig,Convert.ToDouble(item.sumatoria), item.Id_Persona, item.persona, item.id_asociacion, item.aso, item.mes, Convert.ToInt32(item.mes_id), item.Cedula));
            }
            return lista_descuentos;
        }
        public List<mDescuento> mostrarAjustes(int id){
            foreach (var item in db.spConsultarAjuste(id))
            {
                lista_descuentos.Add(new mDescuento(item.id_descuento, Convert.ToDouble(item.sobrante), Convert.ToDouble(item.valor), Convert.ToDouble(item.suma), Convert.ToInt32(item.Id_Persona), item.persona, Convert.ToInt32(item.cab_desc_id), item.descripcion, item.mes, Convert.ToInt32(item.mes_id),Convert.ToDateTime(item.fecha)));
            }
            return lista_descuentos;
        }
    }
}