using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsValorUtilizado{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mValorUtilizado> lista_valor_utili = new List<mValorUtilizado>();
        public List<mValorUtilizado> mostrar(){
            foreach (var item in db.spConsultarValorUtilizado()){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_usad, item.persona, item.nombre, item.mes, Convert.ToDouble(item.monto_aprobado), Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_utili;
        }
        public void ingresar(mValorUtilizado datos){
            db.spInsertarValorUtilizado(Convert.ToInt32(datos.valor_asig_id), Convert.ToInt32(datos.mes_id), Convert.ToDouble(datos.cantidad_usada));
        }
        public void eliminar(int id){
            db.spEliminarValorUtilizado(id);
        }

        public Boolean modificarajuste(int id, double valor_a){
            Boolean result = false;
            try{
                db.spAjustarValUsados(id, valor_a);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public Boolean modificar(mValorUtilizado datos){
            Boolean result = false;
            try{
                db.spModificarValorUtilizado(datos.id_valor_usad, datos.valor_asig_id, datos.mes_id, datos.cantidad_usada);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mValorUtilizado> mostrarById(int id){
            foreach (var item in db.spConsultarValorUtilizadoById(id)){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_usad, item.id_valor_asig, item.persona, item.id_mes, Convert.ToDouble(item.monto_aprobado), Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_utili;
        }
        public List<mValorUtilizado> mostrarxProv(int id){
            foreach (var item in db.spConultarValorUsadoxProv(id)){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_usad, item.aso, item.id_valor_asig, item.persona, item.mes, Convert.ToDouble(item.monto_aprobado), Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_utili;
        }
        public List<mValorUtilizado> mostrarxEmpleado(int id){
            foreach (var item in db.spConsultarValorUsadoxEmpleado(id)){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_usad, item.persona, item.nombre, item.mes, Convert.ToDouble(item.monto_aprobado), Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_utili;
        }
        public List<mValorUtilizado> mostrarValorAjuste(int id_per, int id_mes){
            foreach (var item in db.spListarValoresUsad(id_per, id_mes))
            {
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_usad, item.persona, Convert.ToInt32(item.Id_Persona), item.prov, Convert.ToInt32(item.proveedor_id), Convert.ToDateTime(item.fecha),Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_utili;
        }
    }
}