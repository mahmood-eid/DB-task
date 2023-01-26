using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }
        private void ShowEmp()
        {
            try
            {
                string Query = "Select * from EmployeeTb1";
                EmployeeList.DataSource = Con.GetData(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SalaryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
