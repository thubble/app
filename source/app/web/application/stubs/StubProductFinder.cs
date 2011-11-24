using System.Collections.Generic;
using System.Linq;

namespace app.web.application.stubs
{
    public class StubProductFinder : IProductFinder
    {
		public IEnumerable<Product> get_the_products_in_a_department(Department department)
        {
            return Enumerable.Range(1, 10).Select( x => new Product {name = x.ToString("Product 0")});
        }
    }
}