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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
            cmbOffice.DataSource = DatabaseConnection.EODB.Offices.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Check your input.");
            }
            else
            {
                Employee newEmp = new Employee
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Email = txtEmail.Text,
                    Office = cmbOffice.SelectedItem as Office
                };
                DatabaseConnection.EODB.Employees.Add(newEmp);
                DatabaseConnection.EODB.SaveChanges();

                this.Close();
            }
        }
    }
}
