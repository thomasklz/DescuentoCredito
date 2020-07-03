using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;
namespace Creditos.Clases{
    public class clsPersona{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mPersona> person = new List<mPersona>();
        mPersona objPer = new mPersona();
        public List<mPersona> mostrar(){
            foreach (var item in db.spConsultarPersona()){
                person.Add(new mPersona(item.Id_Persona, item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, item.FechaNac, item.Email));
            }
            return person;
        }
        public mPersona mostrarRpt(int emp_id){
            foreach (var item in db.spReporteRol(emp_id)){
                objPer =new mPersona(item.Cedula, item.persona, item.Direccion, item.TelefonoC, item.nombre_cargo, item.Descripcion, item.NroCuenta, item.banco, Convert.ToDouble(item.SueldoNumero));
            }
            return objPer;
        }
        public List<mPersona> mostrarById(int id){
            foreach (var item in db.spConsultarPersonaById(id)){
                person.Add(new mPersona(item.Id_Persona, item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, item.FechaNac, item.Email));
            }
            return person;
        }
        public List<mPersona> mostrarSinAso(){
            foreach (var item in db.spConsultarEmpleadosSinAso()){
                person.Add(new mPersona(Convert.ToInt32(item.Id_Persona), item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, Convert.ToDateTime(item.FechaNac), item.Email));
            }
            return person;
        }
        public List<mPersona> mostrarcongastos(){
            foreach (var item in db.spConsultarDescuentoxMes()){
                person.Add(new mPersona(item.Id_Persona, item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, item.FechaNac, item.Email, Convert.ToDouble(item.sumatoria), item.aso));
            }
            return person;
        }
        
        public List<mPersona> mostrarvalpen(int id){
            foreach (var item in db.spConsultarValoresPendientes(id)){
                person.Add(new mPersona(item.Id_Persona, item.persona, item.Cedula,Convert.ToDouble(item.cantidad_usada), Convert.ToDouble(item.cantidad_descontada), Convert.ToDouble(item.diferencia), Convert.ToInt32(item.mes_id), item.descripcion));
            }
            return person;
        }
    }
}