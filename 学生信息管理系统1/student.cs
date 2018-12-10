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
    public partial class student : Form
    {
        Form1 form1;
        public student()
        {
            
            InitializeComponent();
        }

        private void student_Load(object sender, EventArgs e)
        {
            form1 = (Form1)this.Owner;
            label1.Text = "欢迎  "+form1.textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {
     
        }

        private void button1_Click(object sender, EventArgs e)//查询信息
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);//实例化链接
            conn.Open();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql =" Select * from student where  学号= '" + form1.textBox1.Text + "'";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)//查询课表
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);//实例化链接
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            string str1 = "Select 班级 from student where 学号='" + form1.textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);
            da.SelectCommand = cmd;
            DataSet d = new DataSet();
            da.Fill(d);
            int b = d.Tables[0].Rows.Count;
            if(b>0)
            {
                string zz = d.Tables[0].Rows[0]["班级"].ToString();
                DataSet dds = new DataSet();//创建dataset实例
                string selectsql = " Select * from classmessage where  班级= '" + zz + "'";
                SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
                DataTable dt = new DataTable();
                sqlDap.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)//查询成绩
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);//实例化链接
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            string str1 = "Select 姓名 from student where 学号='" + form1.textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(str1, conn);
            da.SelectCommand = cmd;
            DataSet d = new DataSet();
            da.Fill(d);
            int b = d.Tables[0].Rows.Count;
            if (b > 0)
            {
                string zz = d.Tables[0].Rows[0]["姓名"].ToString();
                DataSet dds = new DataSet();//创建dataset实例
                string selectsql = " Select * from studentgrades where  姓名= '" + zz + "'";
                SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
                DataTable dt = new DataTable();
                sqlDap.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            conn.Close();
        }
    }
}
