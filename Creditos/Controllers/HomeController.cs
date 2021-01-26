using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;
using Creditos.Entity;
using Newtonsoft.Json;

namespace Creditos.Controllers
{
    public class HomeController : Controller
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsPersona clsPers = new clsPersona();

        public ActionResult index(){

                if (Request.Cookies["espam"] != null){
                    string usuario = Server.HtmlEncode(Request.Cookies["espam"]["kus"]);
                    string contraseña = Server.HtmlEncode(Request.Cookies["espam"]["kpa"]);

                    Catalogo_Seguridad _objSeguridad = new Catalogo_Seguridad();
                    string userx = _objSeguridad.DesEncriptar(usuario);

                    try{ validar(userx, contraseña); }
                    catch
                    { }
                }else{
                ViewBag.showSuccessAlert = false;
                //ClientScript.RegisterStartupScript(GetType(), "actualizar", "javascript:nocredenciales();", true);
            }
            return View();
        }

        protected void validar(string _usuario, string _clave){
            mPersona _dato = null;
            try{
                _dato = clsPers.usuarioVald(_usuario, _clave);

                if (_dato != null){

                    Session.Add("usuarioId", _dato.idUser);
                    Session.Add("personaId", _dato.Id_Persona);
                    Session.Add("nombres", _dato.Nombres);
                    Session.Add("apellido", _dato.ApellidoPaterno);
                    Session.Add("apellido2", _dato.ApellidoMaterno);
                    //Session.Add("rolId", _dato.idRol);
                    //Session.Add("rol", _dato.rol);

                    if (Request.Cookies["espam"] != null){
                        string rolGalleta = Server.HtmlEncode(Request.Cookies["espam"]["kro"]);
                        Catalogo_Seguridad _objSeguridad = new Catalogo_Seguridad();
                        string RolAsignado = _objSeguridad.DesEncriptar(rolGalleta);

                        switch (RolAsignado){
                            case "Encargado de Asociacion":
                                Session.Add("encargado", _dato.idUser);
                                RedirectToAction("Layout_Aso", "AsoLayoutController");
                                break;
                            case "Empleado":
                                Session.Add("empleado", _dato.idUser);
                                RedirectToAction("Layout_User", "UsuarioLayoutController");
                                break;
                            case "Proveedor":
                                Session.Add("proveedor", _dato.idUser);
                                RedirectToAction("Layout_Nom", "NomLayoutController");
                                break;
                            case "Nómina":
                                Session.Add("nomina", _dato.idUser);
                                RedirectToAction("Layout_Prov", "ProvLayoutController");
                                break;

                            default:
                                Response.Redirect("~/Views/Shared/error.cshtml", false);
                                break;
                        }
                    }
                }else{
                    Server.Transfer("~/logIn.aspx");
                }
            }catch (Exception ex){
                ViewBag.showSuccessAlert = false;
                //ClientScript.RegisterStartupScript(GetType(), "actualizar", "javascript:nocredenciales();", true);
                //ClientScript.RegisterStartupScript(GetType(), "swal", "javascript:swal('Usuario o contraseña incorrecto ', 'Verifique que esta ingresando los datos correctamente.','error');", true);
            }
        }

    }
}