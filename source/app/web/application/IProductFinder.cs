using System.Collections.Generic;

namespace app.web.application
{
    public interface IProductFinder
    {
        IEnumerable<Product> get_the_products_in_a_department(Department department);
    }
}