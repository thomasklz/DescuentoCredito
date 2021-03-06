﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models{
    public class mCredito{
        public int id_credito{ get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public double desc_mensual { get; set; }
        public Nullable<int> emp_aso_id { get; set; }
        public int numero_cuota { get; set; }
        public Boolean estado_activacion { get; set; }
        public Boolean estado_aprobacion { get; set; }
        public Boolean estado_rechazo { get; set; }
        public string persona { get; set; }
        public string aso { get; set; }
        public string cedula { get; set; }

        public mCredito() { }
        public mCredito(int id_credito, String descripcion, double cantidad, DateTime fecha_solicitud, DateTime fecha_aprobacion, double desc_mensual, int emp_aso_id, int numero_cuota, Boolean estado_activacion, Boolean estado_aprobacion, Boolean estado_rechazo){
            this.id_credito = id_credito;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_solicitud = fecha_solicitud;
            this.fecha_aprobacion = fecha_aprobacion;
            this.desc_mensual = desc_mensual;
            this.emp_aso_id = emp_aso_id;
            this.numero_cuota = numero_cuota;
            this.estado_activacion = estado_activacion;
            this.estado_aprobacion = estado_aprobacion;
            this.estado_rechazo = estado_rechazo;
        }

        public mCredito(int id_credito, String descripcion, double cantidad, DateTime fecha_solicitud, DateTime fecha_aprobacion, double desc_mensual, string persona, string cedula, string aso, int emp_aso_id, int numero_cuota, Boolean estado_activacion, Boolean estado_aprobacion, Boolean estado_rechazo)
        {
            this.id_credito = id_credito;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_solicitud = fecha_solicitud;
            this.fecha_aprobacion = fecha_aprobacion;
            this.desc_mensual = desc_mensual;
            this.persona = persona;
            this.cedula = cedula;
            this.aso = aso;
            this.emp_aso_id = emp_aso_id;
            this.numero_cuota = numero_cuota;
            this.estado_activacion = estado_activacion;
            this.estado_aprobacion = estado_aprobacion;
            this.estado_rechazo = estado_rechazo;
        }
        public mCredito(int id_credito, String descripcion, double cantidad, DateTime fecha_solicitud, DateTime fecha_aprobacion, double desc_mensual, string persona, string aso, int emp_aso_id, int numero_cuota, Boolean estado_activacion, Boolean estado_aprobacion, Boolean estado_rechazo)
        {
            this.id_credito = id_credito;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_solicitud = fecha_solicitud;
            this.fecha_aprobacion = fecha_aprobacion;
            this.desc_mensual = desc_mensual;
            this.persona = persona;
            this.aso = aso;
            this.emp_aso_id = emp_aso_id;
            this.numero_cuota = numero_cuota;
            this.estado_activacion = estado_activacion;
            this.estado_aprobacion = estado_aprobacion;
            this.estado_rechazo = estado_rechazo;
        }
        public mCredito(int id_credito, String persona, double cantidad, DateTime fecha_solicitud, DateTime fecha_aprobacion, double desc_mensual, int numero_cuota, Boolean estado_activacion, Boolean estado_aprobacion, Boolean estado_rechazo){
            this.id_credito = id_credito;
            this.persona = persona;
            this.cantidad = cantidad;
            this.fecha_solicitud = fecha_solicitud;
            this.fecha_aprobacion = fecha_aprobacion;
            this.desc_mensual = desc_mensual;
            this.numero_cuota = numero_cuota;
            this.estado_activacion = estado_activacion;
            this.estado_aprobacion = estado_aprobacion;
            this.estado_rechazo = estado_rechazo;
        }
    }
}