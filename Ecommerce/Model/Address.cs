using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Model
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public int Door_No { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
       


    }
}
