using Ecommerce.BusinessLogic;
using Ecommerce.Model;
using Ecommerce.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly EcommerceBL EcommerceBL;
        public EcommerceController(EcommerceBL ecommerceBL)
        {
            EcommerceBL = ecommerceBL;
        }

        [HttpGet("GetUserAddress")]
        public List<EcommerceView> GetUserAddress()
        {
            return EcommerceBL.GetUserAddress();
        }

        [HttpGet("GetUserAddressById")]
        public List<EcommerceView> GetUserAddressById(int Id)
        {
            return EcommerceBL.GetUserAddressById(Id);
        }

        [HttpGet("GetUser")]
        public async Task<List<User>> GetUserAsync()
        {
            return await EcommerceBL.GetUserAsync();
        }
    }
}
