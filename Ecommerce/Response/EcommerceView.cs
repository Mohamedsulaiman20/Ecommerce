using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Response
{
    public class EcommerceView
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public string Type { get; set; }
        //public String Addresses { get; set; }
        public List<ListOfAddress> Addresses { get; set; }

    }
}
