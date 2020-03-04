using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsValorUtilizado{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mValorUtilizado> lista_valor_utili = new List<mValorUtilizado>();
        public List<mValorUtilizado> mostrar(){
            foreach (var item in db.spConsultarValorUtilizado()){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_asig, item.id_valor_asig, item.Nombres+' '+item.ApellidoPaterno, item.nombre, item.descripcion2, Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_utili;
        }
        public void ingresar(mValorUtilizado datos){
            db.spInsertarValorUtilizado(datos.valor_asig_id, datos.mes_id, datos.cantidad_usada);
        }
        public void eliminar(int id){
            db.spEliminarValorUtilizado(id);
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
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_asig, item.id_valor_asig, item.id_mes, Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_utili;
        }
        public List<mValorUtilizado> mostrarxProv(int id){
            foreach (var item in db.spConultarValorUsadoxProv(id)){
                lista_valor_utili.Add(new mValorUtilizado(item.id_valor_asig, item.aso, item.persona, item.mes, Convert.ToDouble(item.monto_aprobado), Convert.ToDouble(item.monto_aprobado)));
            }
            return lista_valor_utili;
        }
    }
}