using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FilterItemModel
    {
        public FilterItemModel()
        {
            Values = new List<FilterItemValueModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<FilterItemValueModel> Values { get; set; }
    }
}
