using eccomerce_webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eccomerce_webapi.Repositories
{
    public class CustomerRepository : IRepository<CustomerModel>
    {
        private readonly DataBaseContext _DbContex;

        public CustomerRepository(DataBaseContext dbcontext)
        {
            _DbContex = dbcontext;
        }

        public CustomerModel Add(CustomerModel model)
        {
            _DbContex.Customers.Add(model);
            return model;
        }

        public void Delete(CustomerModel model)
        {
            _DbContex.Customers.Remove(model);
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _DbContex.Customers;
        }

        public CustomerModel GetSingle(int id)
        {
            return _DbContex.Customers.FirstOrDefault(x => x.Id == id);
        }

        public int Save()
        {
            return _DbContex.SaveChanges();
        }

        public CustomerModel Update(CustomerModel model)
        {
            _DbContex.Customers.Update(model);
            return model;
        }
    }
}
