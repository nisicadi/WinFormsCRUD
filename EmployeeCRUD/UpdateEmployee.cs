using EmployeeCRUD.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeCRUD
{
    public partial class UpdateEmployee : Form
    {
        Employee employee;
        public UpdateEmployee(Employee emp)
        {
            employee = emp;
            InitializeComponent();
            cmbOffice.DataSource = DatabaseConnection.EODB.Offices.ToList();

            txtName.Text = employee.Name.ToString();
            txtSurname.Text = employee.Surname.ToString();
            txtEmail.Text = employee.Email.ToString();
            cmbOffice.SelectedItem = employee.Office;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee updatedEmp = new Employee{
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                Office = cmbOffice.SelectedItem as Office
            };          
         
            DatabaseConnection.EODB.Employees.Remove(employee);
            DatabaseConnection.EODB.Employees.Add(updatedEmp);
            DatabaseConnection.EODB.SaveChanges();

            this.Close();
        }
    }
}
