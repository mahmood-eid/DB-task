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
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void GetDepartment()
        {
            string Query = "select * from DepartmentTb1";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.Date.ToString();
                    string JDate = JDateTb.Value.Date.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "insert into EmployeeTb1 values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Name,Gender,Dep,DOB,JDate,Salary);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added!!!");
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    
                    string Query = "Delete from EmployeeTb1 where EmpId = {0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Deleted!!!");
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data !!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);

                    string Query = "Update EmployeeTb1 set EmpName = '{0}', EmpGen = '{1}', EmpDep = '{2}', EmpDOB = '{3}', EmpJDate = '{4}', EmpSal = '{5}' where EmpId = '{6}'";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary, Key);
                    Con.SetData(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added!!!");
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
        int Key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            DOBTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
            JDateTb.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            DailySalTb.Text = EmployeeList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
