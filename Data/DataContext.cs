using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DatabasePath") //Make sure to adjust the database path in App.config
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
    }
}
