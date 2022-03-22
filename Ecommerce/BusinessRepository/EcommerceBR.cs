using Ecommerce.Context;
using Ecommerce.Model;
using Ecommerce.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.BusinessRepository
{
    public class EcommerceBR
    {
        private readonly DBcontext Context;
        public EcommerceBR(DBcontext context)
        {
            Context = context;
        }

        public List<EcommerceView> GetUserAddress()
        {


            IQueryable<EcommerceView> Query = null;

            Query = (from U in Context.User
                                                //join A in Context.Address on U.ID equals A.UserID
                                                //into UserAddress
                                                //from useadd in UserAddress.DefaultIfEmpty()
                                                select new EcommerceView
                                                {
                                                    ID = U.ID,
                                                    Name = U.Name,
                                                    Type = U.Type,
                                                    //Addresses = (IList<EcommerceView>)$"{useadd.Door_No}, {useadd.Street}, {useadd.City}, Pincode - {useadd.Pincode}".ToList()
                                                    //Addresses = ($"{useadd.Door_No}, {useadd.Street}, {useadd.City}, Pincode - {useadd.Pincode}")
                                                    //Addresses = { new ListOfAddress() { GroupOfAddress = useadd.Door_No + ", " + useadd.Street + ", " + useadd.City + ", Pincode - " + useadd.Pincode } }
                                                    Addresses = new  List< ListOfAddress >  (from A in Context.Address
                                                                                            where A.UserID == U.ID

                                                                                            select new ListOfAddress
                                                                                               {
                                                                                                   Address = $"{A.Door_No}, {A.Street}, {A.City}, Pincode - {A.Pincode}"
                                                                                               }).ToList() 

                                                });

            return Query.ToList();

        }

        public List<EcommerceView> GetUserAddressById(int Id)
        {
            IQueryable<EcommerceView> UserById = (from u in Context.User
                                                  //join a in Context.Address on u.ID equals a.UserID
                                                  //into UserAddress
                                                  //from useadd in UserAddress.DefaultIfEmpty()
                                                  //select new { u, useadd }));
                                                  orderby u.Name
                                               select new EcommerceView
                                               {
                                                   ID = u.ID,
                                                   Name = u.Name,
                                                   Type = u.Type,
                                                   //Addresses = (IList<EcommerceView>)(useadd.Door_No + ", " + useadd.Street + ", " + useadd.City + ", Pincode - " + useadd.Pincode).ToList()
                                                   //Addresses = useadd.Door_No + ", " + useadd.Street + ", " + useadd.City + ", Pincode - " + useadd.Pincode
                                                   Addresses = new List<ListOfAddress>(from A in Context.Address
                                                                                       where A.UserID == u.ID

                                                                                       select new ListOfAddress
                                                                                       {
                                                                                           Address = $"{A.Door_No}, {A.Street}, {A.City}, Pincode - {A.Pincode}"
                                                                                       }).ToList()

                                               }).Where(x => x.ID == Id);
            return UserById.ToList();
        }

        public async Task<List<User>> GetUserAsync()
        {
        //    List<User> use = await Context.User.Include(a => a.Address).ToListAsync();
            List<User> users = await Context.User.Select(user => user).Include(user => user.Address).ToListAsync();
            return users.ToList();
        }
    }
}







