using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;
namespace Creditos.Clases{
    public class clsPersona{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mPersona> person = new List<mPersona>();
        public List<mPersona> mostrar(){
            foreach (var item in db.spConsultarPersona()){
                person.Add(new mPersona(item.Id_Persona, item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, item.FechaNac, item.Email));
            }
            return person;
        }
        public List<mPersona> mostrarById(int id){
            foreach (var item in db.spConsultarPersonaById(id)){
                person.Add(new mPersona(item.Id_Persona, item.Nombres, item.SegundoNombre, item.ApellidoPaterno, item.ApellidoMaterno, item.Cedula, item.Direccion, item.CalleSecundaria, item.Numero, item.ReferenciaD, item.TelefonoD, item.TelefonoC, item.ParroquiaNac, item.FechaNac, item.Email));
            }
            return person;
        }
    }
}