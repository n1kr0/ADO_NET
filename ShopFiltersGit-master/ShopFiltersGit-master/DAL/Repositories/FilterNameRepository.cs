using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FilterNameRepository : IFilterNameRepository
    {
        private readonly EFContext _context;

        public FilterNameRepository(EFContext context)
        {
            _context = context;
        }

        public Filter Add(Filter filter)
        {
            _context.Filters.Add(filter);
            return filter;
        }

        public IQueryable<Filter> GetAll()
        {
            return _context.Filters.AsQueryable();
        }

        public Filter GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(t => t.Name == name);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
