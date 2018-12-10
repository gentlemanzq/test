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
{//张棋 软件工程3班 201731062320
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//登陆按钮
        {
            if (radioButton1.Checked)
            {
                string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);//实例化链接
                conn.Open();
                string selectsql = "Select * from login where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("登陆成功");
                    student form = new student();//学生界面
                    form.Owner = this;
                    form.ShowDialog();
                    this.Hide();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("用户名或者密码错误");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    return;
                }
                conn.Close();
            }
            else if (radioButton2.Checked)
            {
                string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);//实例化链接
                conn.Open();
                string selectsql = "Select * from teacherlogin where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("登陆成功");
                    teacher te = new teacher();//教师界面
                    te.ShowDialog();
                    this.Hide();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("用户名或者密码错误");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    return;
                }
                conn.Close();
            }
            else if (radioButton3.Checked)
            {
                string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);//实例化链接
                conn.Open();
                string selectsql = "Select * from admain where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("登陆成功");
                    Mainform form = new Mainform();//管理员界面
                    form.ShowDialog();
                    this.Hide();

                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("用户名或者密码错误");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    return;
                }
                conn.Close();
            }
            else
                MessageBox.Show("请选择登陆类型");
          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2 Form2 = new form2();
            Form2.ShowDialog();
            this.Close();
         }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
