using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Theworkspacerd.Web.Models;

namespace Theworkspacerd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
			
			return View();
        }

		public IActionResult Pagos2() {
    //        var client = new WebClient();
    //        client.Headers.Add("content-type", "application/json");
    //        client.Headers.Add("authorization", "Bearer A21AAFJ9eoorbnbVH3fTJrCTl2o7-P_1T6q8vdYB_QwBB9Ais5ZZmJD4BsNjIiOh8j8OyOcfzLO1BKcgKe0pK-mntpk6jOm-g");
    //        client.Headers.Add("accept", "application/json");

    //        var body = @"{
				//  ""sender_batch_header"": {
				//    ""email_subject"": ""You have a payment"",
				//    ""sender_batch_id"": ""batch-1612486420098""
				//  },
				//  ""items"": [
				//    {
				//      ""recipient_type"": ""PHONE"",
				//      ""amount"": {
				//        ""value"": ""1.00"",
				//        ""currency"": ""USD""
				//      },
				//      ""receiver"": ""4087811638"",
				//      ""note"": ""Payouts sample transaction"",
				//      ""sender_item_id"": ""item-1-1612486420098""
				//    },
				//    {
				//      ""recipient_type"": ""EMAIL"",
				//      ""amount"": {
				//        ""value"": ""1.00"",
				//        ""currency"": ""USD""
				//      },
				//      ""receiver"": ""ps-rec@paypal.com"",
				//      ""note"": ""Payouts sample transaction"",
				//      ""sender_item_id"": ""item-2-1612486420098""
				//    },
				//    {
				//      ""recipient_type"": ""PAYPAL_ID"",
				//      ""amount"": {
				//        ""value"": ""1.00"",
				//        ""currency"": ""USD""
				//      },
				//      ""receiver"": ""FSMRBANCV8PSG"",
				//      ""note"": ""Payouts sample transaction"",
				//      ""sender_item_id"": ""item-3-1612486420098""
				//    }
				//  ]
				//}";

    //        try
    //        {
    //            var response = client.UploadString("https://api.sandbox.paypal.com/v1/payments/payouts", "POST", body);
    //            Console.WriteLine(response);

    //            // Keep the console window open in debug mode.
    //            Console.ReadKey();
    //        }
    //        catch (WebException e)
    //        {
    //            var errorResponse = e.Response as HttpWebResponse;
    //            Console.WriteLine(e.Response.Headers);
    //            string responseText;
    //            using (var reader = new StreamReader(errorResponse.GetResponseStream()))
    //            {
    //                responseText = reader.ReadToEnd();
    //                Console.WriteLine(responseText);
    //            }
    //            // Keep the console window open in debug mode.
    //            Console.ReadKey();
    //        }

            return View();
		}


		public IActionResult Nosotros()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
