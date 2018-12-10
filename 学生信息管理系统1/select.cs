using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 学生信息管理系统1
{
    public partial class select : Form
    {
        public select()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//查找信息
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);//实例化链接
            conn.Open();
            if(textBox1.Text!=null)
            {
                string select1 = "Select * from student where 学号='" + textBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(select1, conn);
                DataSet d = new DataSet();
                da.Fill(d, "学生信息");
                DataTable ta = d.Tables["学生信息"];
                dataGridView1.DataSource = ta;
                conn.Close();
            }
          else if(textBox2.Text!=null)
            {
                string select2 = "Select * from student where 姓名='" + textBox2.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(select2, conn);
                DataSet d = new DataSet();
                da.Fill(d, "学生信息");
                DataTable ta = d.Tables["学生信息"];
                dataGridView1.DataSource = ta;
                conn.Close();
            }
            else if(textBox3.Text!=null)
            {
                string select3 = "Select * from student where 班级='" + textBox3.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(select3, conn);
                DataSet d = new DataSet();
                da.Fill(d, "学生信息");
                DataTable ta = d.Tables["学生信息"];
                dataGridView1.DataSource = ta;
                conn.Close();
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mainform main = new Mainform();
            main.Show();
            this.Hide();
        }
    }
}
