using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public CustomerDetailDto GetByEmail(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.UserId
                    select new CustomerDetailDto
                    {
                        CustomerId = customer.CustomerId,
                        UserId = customer.UserId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        CompanyName = customer.CompanyName,
                        CustomerFindexScore = (int)customer.CustomerFindexScore
                    };
                return result.SingleOrDefault(filter);

            }


        }

        public List<CustomerDetailDto> GetCustomerDetails()
        {

            using (ReCapProjectContext context = new ReCapProjectContext())
            {


                var result = from c in context.Customers
                             join u in context.Users
                                 on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 CustomerFindexScore = (int)c.CustomerFindexScore,
                                 Email = u.Email
                             };

                return result.ToList();

            }
        }
    }
}
