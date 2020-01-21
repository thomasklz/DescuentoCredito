using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsValorUtilizado{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mValorUtilizado> mostrar(){
            List<mValorUtilizado> lista_valor_usado = new List<mValorUtilizado>();
            foreach (var item in db.spConsultarValorUtilizado()){
                lista_valor_usado.Add(new mValorUtilizado(item.id_valor_usad, Convert.ToInt32(item.valor_asig_id), Convert.ToInt32(item.mes_id), Convert.ToDouble(item.cantidad_usada)));
            }
            return lista_valor_usado;
        }
        public void ingresar(mValorUtilizado datos){
            db.spInsertarValorUtilizado(datos.valor_asig_id, datos.mes_id, datos.cantidad_usada);
        }
        public void eliminar(mValorUtilizado datos){
            db.spEliminarValorUtilizado(datos.id_valor_usad);
        }
        public void modificar(mValorUtilizado datos){
            db.spModificarValorUtilizado(datos.id_valor_usad, datos.valor_asig_id, datos.mes_id, datos.cantidad_usada);
        }
    }
}