using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mEmpleadoAsociacion{
        public int id_empl_aso { get; set; }
        public Nullable<int> empleado_id { get; set; }
        public Nullable<int> asociacion_id { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string persona { get; set; }
        public string aso { get; set; }

        public mEmpleadoAsociacion() { }
        public mEmpleadoAsociacion(int id_empl_aso, int empleado_id, int asociacion_id, DateTime fecha_ingreso)
        {
            this.id_empl_aso = id_empl_aso;
            this.empleado_id = empleado_id;
            this.asociacion_id = asociacion_id;
            this.fecha_ingreso = fecha_ingreso;
        }
        public mEmpleadoAsociacion(int id_empl_aso, string persona, string aso, DateTime fecha_ingreso)
        {
            this.id_empl_aso = id_empl_aso;
            this.persona = persona;
            this.aso = aso;
            this.fecha_ingreso = fecha_ingreso;
        }
        public mEmpleadoAsociacion(int id_empl_aso, string persona, DateTime fecha_ingreso){
            this.id_empl_aso = id_empl_aso;
            this.persona = persona;
            this.fecha_ingreso = fecha_ingreso;
        }
        public mEmpleadoAsociacion(int id_empl_aso, string persona, int empleado_id, string aso, DateTime fecha_ingreso)
        {
            this.id_empl_aso = id_empl_aso;
            this.persona = persona;
            this.empleado_id = empleado_id;
            this.aso = aso;
            this.fecha_ingreso = fecha_ingreso;
        }
        public mEmpleadoAsociacion(int id_empl_aso, string persona, int empleado_id, int asociacion_id, DateTime fecha_ingreso){
            this.id_empl_aso = id_empl_aso;
            this.persona = persona;
            this.empleado_id = empleado_id;
            this.asociacion_id = asociacion_id;
            this.fecha_ingreso = fecha_ingreso;
        }
    }
}