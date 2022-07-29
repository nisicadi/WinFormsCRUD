using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCRUD.Data
{
    public class DatabaseConnection
    {
        public static DataContext EODB { get; set; } = new DataContext();
    }
}
