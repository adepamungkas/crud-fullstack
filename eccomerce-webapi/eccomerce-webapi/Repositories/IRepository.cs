using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eccomerce_webapi.Repositories
{
    public interface IRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel GetSingle(int id);
        TModel Add(TModel model);
        TModel Update(TModel model);
        void Delete(TModel model);
        int Save();

    }
}
