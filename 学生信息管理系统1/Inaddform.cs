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
    public partial class Inaddform : Form
    {
        public Inaddform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//添加信息
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string insert1 = "insert into student(学号,姓名,性别,身份证号,学制,班级,专业,入学时间,地址,电话,邮编) values('" + textBox1.Text + "','" + textBox2.Text +"','"+textBox3.Text +"','"+textBox11.Text
                +"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox10.Text+"','"+textBox8.Text+"','" +textBox9.Text+"','"+ textBox7.Text+  "')"; 
            SqlCommand cmd = new SqlCommand(insert1, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("添加成功");
                this.Hide();
                Mainform form = new Mainform();
                form.Show();
            }else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
