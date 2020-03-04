using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsTipoIngreso{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mTipoIngreso> lista_t_ingreso = new List<mTipoIngreso>();

        public List<mTipoIngreso> mostrar(){
           
            foreach (var item in db.spConsultarTipoIngreso())
            {
                lista_t_ingreso.Add(new mTipoIngreso(item.id_tipo_ingreso, item.descripcion));
            }
            return lista_t_ingreso;
        }
        public void ingresar(mTipoIngreso datos){
            db.spInsertarTipoIngreso(datos.descripcion);
        }
        public void eliminar(int id){
            db.spEliminarTipoIngreso(id);
        }
        public Boolean modificar(mTipoIngreso datos){
            Boolean result = false;
            try{
                db.spModificarTipoIngreso(datos.id_tipo_ingreso, datos.descripcion);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mTipoIngreso> mostrarById(int id){
            foreach (var item in db.spConsultarTipoIngresoById(id)){
                lista_t_ingreso.Add(new mTipoIngreso(item.id_tipo_ingreso, item.descripcion));
            }
            return lista_t_ingreso;
        }
    }
}