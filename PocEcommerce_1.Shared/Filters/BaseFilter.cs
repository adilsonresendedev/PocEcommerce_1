using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocEcommerce_1.Shared.Filters
{
    public class BaseFilter
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 100;
    }
}
