using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Results.Product
{
    public class GetAllProductsResult
    {
        public List<ProductListResult> ProductList { get; set; }
    }
}
