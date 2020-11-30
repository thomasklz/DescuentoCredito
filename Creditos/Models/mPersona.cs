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
        public double salario { get; set; }
        public double diferencia { get; set; }
        public double cant_descnt { get; set; }
        public string nombre_cargo { get; set; }
        public string tipo_cont { get; set; }
        public string n_cuenta { get; set; }
        public string banco { get; set; }
        public string password { get; set; }
        public string user { get; set; }
        public int idUser { get; set; }
        public string rol { get; set; }
        public int idRol { get; set; }
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
        public mPersona(string Cedula, string Nombres, string Direccion, string TelefonoC, string nombre_cargo, string tipo_cont, string n_cuenta, string banco, double salario){
            this.Cedula = Cedula;
            this.Nombres = Nombres;
            this.Direccion = Direccion;
            this.TelefonoC = TelefonoC;
            this.nombre_cargo = nombre_cargo;
            this.tipo_cont = tipo_cont;
            this.n_cuenta = n_cuenta;
            this.banco = banco;
            this.salario = salario;
        }
        public mPersona(int idUser, int idPersona, string nombre, string apellido1, string apellido2, int rolid, string rol){
            this.idUser = idUser;
            this.Id_Persona = idPersona;
            this.Nombres = nombre;
            this.ApellidoPaterno = apellido1;
            this.ApellidoMaterno = apellido2;
            this.idRol = idRol;
            this.rol = rol;
        }
    }
}