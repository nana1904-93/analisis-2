﻿using Capa_Logica;
using Capa_Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_Presentacion.Controllers
{
    public class PrestamoAudiovisualController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<PrestamoAudiovisual> listaPrestamoAudiovisual = new List<PrestamoAudiovisual>();
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var data = prestamoAudiovisual.ConsultarPrestamosAudioVisual().ToList();
                foreach (var item in data)
                {
                    PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                    modelo.Id = item.Id;
                    modelo.CodigoPrestamoAudiovisual = item.codigoPrestamoAudiovisual;
                    modelo.NombreSolicitante = item.nombreSolicitante;
                    modelo.ApellidoSolicitante1 = item.apellidoSolicitante1;
                    modelo.ApellidoSolicitante2 = item.apellidoSolicitante2;
                    modelo.Telefono = item.telefono;
                    modelo.Departamento = item.departamento;
                    modelo.NombreActividad = item.nombreActividad;
                    modelo.Categoria = item.categoria;
                    modelo.EspecificacionCategoria = item.especificacionCategoria;
                    modelo.Ubicacion = item.ubicacion;
                    modelo.HoraInicio = item.horaInicio;
                    modelo.HoraFinal = item.horaFin;
                    modelo.Descripcion = item.descripcion;
                    modelo.EquipoRequerido = item.equipoRequerido;
                    modelo.Aforo = item.aforo;
                    modelo.GeneroSolicitante = item.generoSolicitante;

                    listaPrestamoAudiovisual.Add(modelo);
                }

                return View(listaPrestamoAudiovisual);
            }
            catch
            {
                return RedirectToAction("505", "Error");
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }

        [HttpPost]
        public ActionResult Agregar(PrestamoAudiovisual prestamoAudiovisual)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoAudiovisual);
                }
                clsPrestamoAudiovisual objPrestamoAudiovisual = new clsPrestamoAudiovisual();
                bool resultado = objPrestamoAudiovisual.AgregarPrestamoAudioVisual(prestamoAudiovisual.NombreSolicitante, prestamoAudiovisual.ApellidoSolicitante1, prestamoAudiovisual.ApellidoSolicitante2, prestamoAudiovisual.Telefono, prestamoAudiovisual.Departamento, prestamoAudiovisual.NombreActividad, prestamoAudiovisual.Categoria, prestamoAudiovisual.EspecificacionCategoria, prestamoAudiovisual.Ubicacion, prestamoAudiovisual.HoraInicio, prestamoAudiovisual.HoraFinal, prestamoAudiovisual.Descripcion, prestamoAudiovisual.EquipoRequerido, prestamoAudiovisual.Aforo, prestamoAudiovisual.GeneroSolicitante);
                if (resultado)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Pagina de ERROR
                    return RedirectToAction("404", "Error");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("505", "Error");
            }
        }

        [HttpGet]
        public ActionResult Actualizar(int Id)
        {
            try
            {
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                var dato = prestamoAudiovisual.ConsultarPrestamoAudioVisual(Id);
                PrestamoAudiovisual modelo = new PrestamoAudiovisual();
                modelo.CodigoPrestamoAudiovisual = dato[0].codigoPrestamoAudiovisual;
                modelo.NombreSolicitante = dato[0].nombreSolicitante;
                modelo.ApellidoSolicitante1 = dato[0].apellidoSolicitante1;
                modelo.ApellidoSolicitante2 = dato[0].apellidoSolicitante2;
                modelo.Telefono = dato[0].telefono;
                modelo.Departamento = dato[0].departamento;
                modelo.NombreActividad = dato[0].nombreActividad;
                modelo.Categoria = dato[0].categoria;
                modelo.EspecificacionCategoria = dato[0].especificacionCategoria;
                modelo.Ubicacion = dato[0].ubicacion;
                modelo.HoraInicio = dato[0].horaInicio;
                modelo.HoraFinal = dato[0].horaFin;
                modelo.Descripcion = dato[0].descripcion;
                modelo.EquipoRequerido = dato[0].equipoRequerido;
                modelo.Aforo = dato[0].aforo;
                modelo.GeneroSolicitante = dato[0].generoSolicitante;
                return View(modelo);
            }
            catch
            {
                return RedirectToAction("504", "Error");
            }
        }

        [HttpPost]
        public ActionResult Actualizar(int Id, PrestamoAudiovisual prestamoAudiovisual)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(prestamoAudiovisual);
                }
                clsPrestamoAudiovisual objPrestamoAudiovisual = new clsPrestamoAudiovisual();
                bool resultado = objPrestamoAudiovisual.ActualizarPrestamoAudioVisual(prestamoAudiovisual.Id, prestamoAudiovisual.CodigoPrestamoAudiovisual, prestamoAudiovisual.NombreSolicitante, prestamoAudiovisual.ApellidoSolicitante1, prestamoAudiovisual.ApellidoSolicitante2, prestamoAudiovisual.Telefono, prestamoAudiovisual.Departamento, prestamoAudiovisual.NombreActividad, prestamoAudiovisual.Categoria, prestamoAudiovisual.EspecificacionCategoria, prestamoAudiovisual.Ubicacion, prestamoAudiovisual.HoraInicio, prestamoAudiovisual.HoraFinal, prestamoAudiovisual.Descripcion, prestamoAudiovisual.EquipoRequerido, prestamoAudiovisual.Aforo, prestamoAudiovisual.GeneroSolicitante);
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
                clsPrestamoAudiovisual prestamoAudiovisual = new clsPrestamoAudiovisual();
                bool resultado = prestamoAudiovisual.EliminarPrestamoAudioVisual(Id);
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