using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theworkspacerd.Web.Models
{
    public class TransacionPaypal
    {
        public string Id { get; set; }
        public string Email_address { get; set; }
        public string Payer_id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Currency_code { get; set; }
    }
}
