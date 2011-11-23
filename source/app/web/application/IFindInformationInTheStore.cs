using System.Collections.Generic;

namespace app.web.application
{
  public interface IFindInformationInTheStore
  {
    IEnumerable<Department> get_the_main_departments();
    IEnumerable<Department> get_the_departments_in_a_department(Department department);
    IEnumerable<Product> get_the_products_in_a_department(Department department);
  }
}