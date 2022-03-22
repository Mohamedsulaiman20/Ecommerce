using Ecommerce.BusinessRepository;
using Ecommerce.Model;
using Ecommerce.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.BusinessLogic
{
    public class EcommerceBL
    {
        private readonly EcommerceBR EcommerceBR;
        public EcommerceBL(EcommerceBR ecommerceBR)
        {
            EcommerceBR = ecommerceBR;
        }

        public List<EcommerceView> GetUserAddress()
        {
            //Address add = new Address();
            //List<EcommerceView> ecom = new List<EcommerceView>();

         
            //foreach(var address in ecom)
            //{
            //    Console.WriteLine(new EcommerceView { Addresses = add.Door_No + ", " + add.Street + ", " + add.City + ", Pincode - " + add.Pincode });
            //}         
            
            return EcommerceBR.GetUserAddress();
        }
        public List<EcommerceView> GetUserAddressById(int Id)
        {

            

            return EcommerceBR.GetUserAddressById(Id);
        }

        public async Task<List<User>> GetUserAsync()
        {
            return await EcommerceBR.GetUserAsync();
        }
    }
}











