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
            ShowSalaries();
            GetEmployees();
        }
        private void GetEmployees()
        {
            string Query = "select * from EmployeeTb1";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }
        int DSal = 0;
        string Period = "";
        private void GetSalary()
        {
            string Query = "select * from EmployeeTb1 where EmpId = {0} ";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            // MessageBox.Show(DSal + "");
            // EmpCb.DataSource = Con.GetData(Query);
        }

        private void ShowSalaries()
        {
            try
            {
                string Query = "Select * from SalaryTb1";
                SalaryList.DataSource = Con.GetData(Query);
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

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmpCb.SelectedIndex == -1 || DaysTb.Text == "" || PeriodTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                } 
                else
                {
                    Period = PeriodTb.Value.Date.Month.ToString() + "-" + PeriodTb.Value.Date.Year.ToString();
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days = Convert.ToInt32(DaysTb.Text); 
                    string Query = "insert into SalaryTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary);
                    Con.SetData(Query);
                    ShowSalaries();
                    MessageBox.Show("Salary Paid!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;

                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }
    }
}
