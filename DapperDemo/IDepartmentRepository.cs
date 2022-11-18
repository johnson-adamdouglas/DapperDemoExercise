using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public interface IDepartmentRepository //This is a completely abstract class which can only contain abstract methods and properties with empty bodies
                                           //To access these methods, this interface must be implemented by another class.
    {
        public IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment(string newDepartmentName);
    }
}
