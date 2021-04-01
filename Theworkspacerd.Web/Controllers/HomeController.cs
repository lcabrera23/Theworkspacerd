using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Theworkspacerd.Web.Helpers;
using Theworkspacerd.Web.Models;

namespace Theworkspacerd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISendEmail _email;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration,ISendEmail email)
        {
            _logger = logger;
            _configuration = configuration;
            _email = email;
        }

        public IActionResult Index()
        {

           
            return View();
        }

       

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Servicios()
        {
            return View();
        }

        public IActionResult Planes()
        {

            return View();
        }
        public IActionResult Pagos()
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Headers.Add("authorization", "Bearer A21AAFnNagckuSeTmuxh76PObGZDBf2Pu3zG9AzZzakdXrIL8KyGmx7eOr_mV0pKpmoiLn8_dxQdaB1miYyrGIxArfofTUxoA");
            client.Headers.Add("accept", "application/json");

            var body = @"{
              ""sender_batch_header"": {
                ""email_subject"": ""You have a payment"",
                ""sender_batch_id"": ""batch-1612486420098""
              },
              ""items"": [
                {
                  ""recipient_type"": ""PHONE"",
                  ""amount"": {
                    ""value"": ""1.00"",
                    ""currency"": ""USD""
                  },
                  ""receiver"": ""4087811638"",
                  ""note"": ""Payouts sample transaction"",
                  ""sender_item_id"": ""item-1-1612486420098""
                },
                {
                  ""recipient_type"": ""EMAIL"",
                  ""amount"": {
                    ""value"": ""1.00"",
                    ""currency"": ""USD""
                  },
                  ""receiver"": ""ps-rec@paypal.com"",
                  ""note"": ""Payouts sample transaction"",
                  ""sender_item_id"": ""item-2-1612486420098""
                },
                {
                  ""recipient_type"": ""PAYPAL_ID"",
                  ""amount"": {
                    ""value"": ""1.00"",
                    ""currency"": ""USD""
                  },
                  ""receiver"": ""FSMRBANCV8PSG"",
                  ""note"": ""Payouts sample transaction"",
                  ""sender_item_id"": ""item-3-1612486420098""
                }
              ]
            }";

            try
            {
                var response = client.UploadString("https://api.sandbox.paypal.com/v1/payments/payouts", "POST", body);
                Console.WriteLine(response);

                return RedirectToAction(response);
                // Keep the console window open in debug mode.
                //Console.ReadKey();
            }
            catch (WebException e)
            {
                var errorResponse = e.Response as HttpWebResponse;
                Console.WriteLine(e.Response.Headers);
                string responseText;
                using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);
                }
                // Keep the console window open in debug mode.
                Console.ReadKey();
            }
            return View();
        }

		public IActionResult Pagos2(int? id) {

            var listaOficinas = new List<Oficinas>() {
                new Oficinas
                    {
                        id = 1,
                        precio = 350,
                        espacio = "Oficina 7.2 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                 new Oficinas
                    {
                          id= 2,
                         precio= 400,
                          espacio= "Oficina 8.0 mts2",
                          tipo= "mensual",
                          oficina= "Oficina Privada"
                    },
                  new Oficinas
                    {
                        id = 3,
                        precio = 425,
                        espacio = "Oficina 8.5 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                   new Oficinas
                    {
                        id = 4,
                        precio = 450,
                        espacio = "Oficina 9.0 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                    new Oficinas
                    {
                        id = 5,
                        precio = 480,
                        espacio = "Oficina 10.0 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                     new Oficinas
                    {
                        id = 6,
                        precio = 520,
                        espacio = "Oficina 11.0 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                      new Oficinas
                    {
                        id = 7,
                        precio = 700,
                        espacio = "Oficina 15.8 mts2",
                        tipo = "mensual",
                        oficina = "Oficina Privada"
                    },
                       new Oficinas
                    {
                        id = 8,
                        precio = 120,
                        espacio = "",
                        tipo = "mensual",
                        oficina = "ESPACIOS ABIERTO"
                    },
                        new Oficinas
                    {
                        id = 9,
                        precio = 35,
                        espacio = "",
                        tipo = "PASADIA",
                        oficina = "ESPACIOS ABIERTO"
                    },
                         new Oficinas
                    {
                        id = 10,
                        precio = 60,
                        espacio = "",
                        tipo = "Sabados",
                        oficina = "ESPACIOS ABIERTO"
                    },
                          new Oficinas
                    {
                        id = 11,
                        precio = 220,
                        espacio = "Escritorios y puestos trabajo asignados ",
                        tipo = "",
                        oficina = "Espacios Compartidos"
                    },
                           new Oficinas
                    {
                        id = 12,
                        precio = 20,
                        espacio = "",
                        tipo = "hora",
                        oficina = "SALON REUNIONES"
                    },
                     new Oficinas
                    {
                        id = 13,
                        precio = 100,
                        espacio = "",
                        tipo = "Basico",
                        oficina = "Asistente Virtual"
                    },
                      new Oficinas
                    {
                        id = 14,
                        precio = 125,
                        espacio = "",
                        tipo = "Intermedio",
                        oficina = "Asistente Virtual"
                    },
                     new Oficinas
                    {
                        id = 15,
                        precio = 200,
                        espacio = "",
                        tipo = "Completo",
                        oficina = "Asistente Virtual"
                    },
                      new Oficinas
                    {
                        id = 16,
                        precio = 300,
                        espacio = "",
                        tipo = "Full",
                        oficina = "Asistente Virtual"
                    },
                         new Oficinas
                    {
                        id = 17,
                        precio = 100,
                        espacio = "",
                        tipo = "Hora",
                        oficina = "Salón de Eventos"
                    }

           };

            var oficina = listaOficinas.FirstOrDefault(x => x.id == id);
            ViewBag.objecto = oficina;
            return View(oficina);
		}


		public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            var mensaje = new Mensaje();
            return View(mensaje);
        }

        [HttpPost]
        public IActionResult Contacto(Mensaje mensaje)
        {
            _email.enviarEmail(mensaje);

            var newMensaje = new Mensaje();
            return View(newMensaje);
        }

        //Esta accion es para guardar los usuarios que desean saber ofertas
        public IActionResult Boletin()
        {
            return View();
        }


        //Esta accion enviar un correo al comprador y se le da un codigo de al comprador
        [HttpPost]
        public IActionResult EnviarCorreo([FromBody]TransacionPaypal data)
        {

          var clineteEmail =  _email.enviarEmailCliente($"{data.Email_address}", $"Información de su estancia: {data.Description}", data);
          var empresaEmail =  _email.enviarEmailEmpresa($"{data.Description}", data);

            if (clineteEmail == true && empresaEmail == true)
            {
                return Ok(true);
            }

            return View();
        }

        public IActionResult CorreosEnviardos(string correo) {
            @ViewBag.email = correo;
            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
