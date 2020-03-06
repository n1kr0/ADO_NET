using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFilterNameRepository
    {
        Filter Add(Filter filter);

        Filter GetByName(string name);

        IQueryable<Filter> GetAll();

        int SaveChanges();
    }
}
