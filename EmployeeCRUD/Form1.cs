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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvResults.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvResults.DataSource = DatabaseConnection.EODB.Employees.ToList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshSearch();
        }

        private void RefreshSearch()
        {
            List<Employee> newList = new List<Employee>();

            string filter = txtSearch.Text.ToLower();

            foreach (var emp in DatabaseConnection.EODB.Employees)
            {
                if (emp.Name.ToLower().Contains(filter) || emp.Surname.ToLower().Contains(filter))
                    newList.Add(emp);
            }

            dgvResults.DataSource = newList;
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)//postavljanje pitanja
                {
                    DatabaseConnection.EODB.Employees.Remove(dgvResults.SelectedRows[0].DataBoundItem as Employee);
                    DatabaseConnection.EODB.SaveChanges();

                    RefreshSearch();
                }
                
            }
            else
            {
                var update = new UpdateEmployee(dgvResults.SelectedRows[0].DataBoundItem as Employee);
                update.ShowDialog();
                RefreshSearch();
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var newEmp = new AddEmployee();
            newEmp.ShowDialog();

            RefreshSearch();
        }
    }
}
