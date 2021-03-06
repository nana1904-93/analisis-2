﻿using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class FormularioCIIEController : Controller
    {
        // GET: FormularioCIIE
        public ActionResult Index()
        {
            try
            {
                List<FormularioCIIE> listaFormularioCIIE = new List<FormularioCIIE>();
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                var data = formularioCIIE.ConsultarFormulariosCIIE().ToList();
                foreach (var item in data)
                {
                    FormularioCIIE modelo = new FormularioCIIE();
                    modelo.Id = Convert.ToInt32(item.Id);
                    modelo.CodigoCIIE = item.codigoCIIE;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Email = item.email;
                    modelo.TipoDespacho = item.tipoDespacho;
                    modelo.Fraccion = item.fraccion;
                    modelo.EspecificacionDespacho = item.especificacionDespacho;
                    modelo.TipoConsulta = item.tipoConsulta;
                    modelo.EspecificacionConsulta = item.especificacionConsulta;
                    modelo.Tema = item.tema;
                    modelo.InformacionRequerida = item.informacionRequerida;
                    modelo.UsoInformacion = item.usoInformacion;
                    modelo.GeneroSolicitante = item.generoSolicitante;
                    modelo.FechaIngreso = item.fechaIngreso;
                    modelo.FechaRespuesta = item.fechaRespuesta;
                    modelo.Estado = item.estado;

                    listaFormularioCIIE.Add(modelo);

                }
                return View(listaFormularioCIIE);
            }
            catch
            {
                return RedirectToAction("Roles", "Index");
            }
        }

        public ActionResult Agregar()
        {
            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(FormularioCIIE formularioCIIE)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                bool resultado = objFormularioCIIE.AgregarFormularioCIIE(formularioCIIE.NombreSolicitante, formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, formularioCIIE.Telefono, formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, formularioCIIE.EspecificacionDespacho, formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, formularioCIIE.Tema, formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, formularioCIIE.GeneroSolicitante, formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Pagina de ERROR
                    return RedirectToAction("Agregar", "FormularioCIIE");
                }
            }
            catch
            {
                return RedirectToAction("Agregar", "Usuario");
            }
        }

        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsFormularioCIIE formulario = new clsFormularioCIIE();
                var dato = formulario.ConsultarFormularioCIIE(Id);
                FormularioCIIE modelo = new FormularioCIIE();
                modelo.CodigoCIIE = dato[0].codigoCIIE;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Email = dato[0].email;
                modelo.TipoDespacho = dato[0].tipoDespacho;
                modelo.Fraccion = dato[0].fraccion;
                modelo.EspecificacionDespacho = dato[0].especificacionDespacho;
                modelo.TipoConsulta = dato[0].tipoConsulta;
                modelo.EspecificacionConsulta = dato[0].especificacionConsulta;
                modelo.Tema = dato[0].tema;
                modelo.InformacionRequerida = dato[0].informacionRequerida;
                modelo.UsoInformacion = dato[0].usoInformacion;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                modelo.FechaIngreso = dato[0].fechaIngreso;
                modelo.FechaRespuesta = dato[0].fechaRespuesta;
                modelo.Estado = dato[0].estado;
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }
        [HttpPost]
        public ActionResult Actualizar(int Id, FormularioCIIE formularioCIIE)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(formularioCIIE);
                }
                clsFormularioCIIE objFormularioCIIE = new clsFormularioCIIE();
                bool resultado = objFormularioCIIE.ActualizarFormularioCIIE(formularioCIIE.Id, formularioCIIE.CodigoCIIE, formularioCIIE.NombreSolicitante, formularioCIIE.ApellidoSolicitante1, formularioCIIE.ApellidoSolicitante2, formularioCIIE.Telefono, formularioCIIE.Email, formularioCIIE.TipoDespacho, formularioCIIE.Fraccion, formularioCIIE.EspecificacionDespacho, formularioCIIE.TipoConsulta, formularioCIIE.EspecificacionConsulta, formularioCIIE.Tema, formularioCIIE.InformacionRequerida, formularioCIIE.UsoInformacion, formularioCIIE.GeneroSolicitante, formularioCIIE.FechaIngreso, formularioCIIE.FechaRespuesta, formularioCIIE.Estado);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        public ActionResult Eliminar(int Id)
        {
            try
            {
                clsFormularioCIIE formularioCIIE = new clsFormularioCIIE();
                bool resultado = formularioCIIE.EliminarFormularioCIIE(Id);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }
    }
}