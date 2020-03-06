using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class FilterService : IFilterService
    {
        private readonly IFilterNameRepository _filterNameRepository;

        public FilterService()
        {
            EFContext context = new EFContext();
            _filterNameRepository = new FilterNameRepository(context);
        }

        public IEnumerable<FilterItemModel> GetAll()
        {
            var filters = _filterNameRepository.GetAll()
                .Select(t => new FilterItemModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Values = t.FilterValues
                    .Select(y => new FilterItemValueModel()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        CountProducts = y.ProductFilters.Count
                    }).ToList()
                });
            return filters;
        }
    }
}
