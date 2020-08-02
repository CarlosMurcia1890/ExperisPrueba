using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExperisPrueba.Datos;
using ExperisPrueba.Models;
using ExperisPrueba.Utilidades;

namespace ExperisPrueba.Controllers
{
    public class CandidatosController : Controller
    {
        private AccesoDatos db = new AccesoDatos();

        // GET: Candidatos
        public ActionResult Index()
        {
            DatosJson candidatos = new DatosJson();
            ServicioDatos datos = new ServicioDatos();
            List<Candidatos> Clist = new List<Candidatos>();
            
            var result  = datos.ObtenerDatosCandidatos();

            foreach(var c in result)
            {
                var val = (c.id % 2);

                if(val != 0)
                {
                    Clist.Add(new Candidatos { id = c.id, Nombre = c.Name.Split(' ')[0].ToString(), Apellido = c.Name.Split(' ')[1].ToString(), Correo = c.Email, Telefono = c.Phone, WebSite = c.WebSite });
                }
            }

            if (TempData["Mensaje"] != null)
            {
                ViewBag.Mensaje = TempData["Mensaje"].ToString();
            }
            return View(Clist);
        }
      
        // GET: Candidatos/Consulta/
        public ActionResult Consulta()
        {
            try
            {
                List<Consulta> consulta = new List<Consulta>();

                var consdatos = from c in db.Candidatos
                                join e in db.Entrevistas on c.id equals e.IdCandidato
                                select new
                                {
                                    c.id,
                                    c.Nombre,
                                    c.Apellido,
                                    c.Telefono,
                                    c.Correo,
                                    c.WebSite,
                                    e.FechaEntrevista,
                                    e.Horaentrevista,
                                    e.TipoEntrevista
                                };

                foreach (var c in consdatos)
                {
                    consulta.Add(new Consulta { Nombre = c.Nombre, Apellido = c.Apellido, Telefono = c.Telefono, Correo = c.Correo, WebSite = c.WebSite, id = c.id, IdCandidato = c.id, FechaEntrevista = c.FechaEntrevista, Horaentrevista = c.Horaentrevista, TipoEntrevista = c.TipoEntrevista });
                }



                return View(consulta);
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "Error al consultar los datos." + ex.ToString();
                return View();
            }
        }

        
        // GET: Candidatos/Create
        public ActionResult Create(int? id)
        {
            DatosJson candidatos = new DatosJson();
            ServicioDatos datos = new ServicioDatos();
            List<Candidatos> Clist = new List<Candidatos>();
            Candidatos data = new Candidatos();

            try
            {

                var result = datos.ObtenerDatosCandidatos();

                foreach (var c in result)
                {
                    var val = (c.id % 2);

                    if (val != 0)
                    {
                        Clist.Add(new Candidatos { id = c.id, Nombre = c.Name.Split(' ')[0].ToString(), Apellido = c.Name.Split(' ')[1].ToString(), Correo = c.Email, Telefono = c.Phone, WebSite = c.WebSite });
                    }
                }

                data = Clist.Where(x => x.id == id).FirstOrDefault();


                return View(data);
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "Error al obtener los datos." + ex.ToString();
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult CallEntrevista()
        {
            var model = new Entrevista();
            
            return PartialView("Entrevista", model);
        }

        // POST: Candidatos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Apellido,Correo,Telefono,WebSite")] Candidatos candidatos, [Bind(Include = "FechaEntrevista, Horaentrevista,TipoEntrevista")] Entrevista entrevista)
        {

            try
            {
                var Fechas = from f in db.Entrevistas
                             where f.FechaEntrevista == entrevista.FechaEntrevista && f.Horaentrevista == entrevista.Horaentrevista
                             select f.FechaEntrevista;

                if (Fechas.Count() > 0)
                {
                    ViewBag.Mensaje = "No puede agendar ya que existe una entrevista en este mismo horario.";
                    return View();
                }


                if (ModelState.IsValid)
                {
                    db.Candidatos.Add(candidatos);
                    db.SaveChanges();
                    entrevista.IdCandidato = candidatos.id;
                    db.Entrevistas.Add(entrevista);
                    db.SaveChanges();
                    TempData["Mensaje"] = "Agendamiento creado de forma correcta.";
                    return RedirectToAction("Index");
                }

                return View(candidatos);
            }
            catch(Exception ex)
            {
                ViewBag.Mensaje = "Error al crear el agendamiento." + ex.ToString();
                return View();
            }

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
