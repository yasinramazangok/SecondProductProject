using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Commands.Product
{
    public class DeleteProductCommand
    {
        public int DeletedProductId { get; set; } // Product Id to delete

    }
}
