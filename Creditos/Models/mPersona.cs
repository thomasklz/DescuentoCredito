using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models{
    public class mPersona{
        public int Id_Persona { get; set; }
        public string Nombres { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string CalleSecundaria { get; set; }
        public string Numero { get; set; }
        public string ReferenciaD { get; set; }
        public string TelefonoD { get; set; }
        public string TelefonoC { get; set; }
        public string ParroquiaNac { get; set; }
        public DateTime FechaNac { get; set; }
        public string Email { get; set; }
        public double gastos { get; set; }
        public string aso { get; set; }
        public string mes { get; set; }
        public int id_mes { get; set; }
        public double cant_usada { get; set; }
        public double diferencia { get; set; }
        public double cant_descnt { get; set; }

        public mPersona(){}
        public mPersona(int Id_Persona, string Nombres, string SegundoNombre, string ApellidoPaterno, string ApellidoMaterno, string Cedula, string Direccion, string CalleSecundaria, string Numero,string ReferenciaD,string TelefonoD, string TelefonoC, string ParroquiaNac, DateTime FechaNac, string Email){
            this.Id_Persona = Id_Persona;
            this.Nombres = Nombres;
            this.SegundoNombre = SegundoNombre;
            this.ApellidoPaterno = ApellidoPaterno;
            this.ApellidoMaterno = ApellidoMaterno;
            this.Cedula = Cedula;
            this.Direccion = Direccion;
            this.CalleSecundaria = CalleSecundaria;
            this.Numero = Numero;
            this.ReferenciaD = ReferenciaD;
            this.TelefonoD = TelefonoD;
            this.TelefonoC = TelefonoC;
            this.ParroquiaNac = ParroquiaNac;
            this.FechaNac = FechaNac;
            this.Email = Email;
        }
        public mPersona(int Id_Persona, string Nombres, string SegundoNombre, string ApellidoPaterno, string ApellidoMaterno, string Cedula, string Direccion, string CalleSecundaria, string Numero, string ReferenciaD, string TelefonoD, string TelefonoC, string ParroquiaNac, DateTime FechaNac, string Email, double gastos, string aso)
        {
            this.Id_Persona = Id_Persona;
            this.Nombres = Nombres;
            this.SegundoNombre = SegundoNombre;
            this.ApellidoPaterno = ApellidoPaterno;
            this.ApellidoMaterno = ApellidoMaterno;
            this.Cedula = Cedula;
            this.Direccion = Direccion;
            this.CalleSecundaria = CalleSecundaria;
            this.Numero = Numero;
            this.ReferenciaD = ReferenciaD;
            this.TelefonoD = TelefonoD;
            this.TelefonoC = TelefonoC;
            this.ParroquiaNac = ParroquiaNac;
            this.FechaNac = FechaNac;
            this.Email = Email;
            this.gastos = gastos;
            this.aso = aso;
        }
        public mPersona(int Id_Persona, string Nombres, string Cedula, double cant_usada, double cant_descnt, double diferencia, int id_mes, string mes)
        {
            this.Id_Persona = Id_Persona;
            this.Nombres = Nombres;
            this.Cedula = Cedula;
            this.cant_usada = cant_usada;
            this.cant_descnt = cant_descnt;
            this.diferencia = diferencia;
            this.id_mes = id_mes;
            this.mes = mes;
        }
    }
}