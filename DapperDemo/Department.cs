using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    public class Department // This class holds the data coming from the departments table. Each of these properties are columns from that table.
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

    }
}
