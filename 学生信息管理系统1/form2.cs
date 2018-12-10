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
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//注册按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string insert1;
            if(radioButton1.Checked)
            {
                 insert1 = "insert into login(username,password) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            }
            else
            {
                 insert1 = "insert into teacherlogin(username,password) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            }
           
            SqlCommand cmd = new SqlCommand(insert1, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("注册成功");
            }
            else
                MessageBox.Show("注册失败");
            conn.Close();
            
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
