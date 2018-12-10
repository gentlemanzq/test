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
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//修改按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["名称"] == null) return;
            string bd = Convert.ToString(row["名称"]);
            string sqlupdata = "update classmessage set 名称='" + textBox1.Text + "',班级='" + textBox2.Text + "',学期='" + textBox3.Text + "',学时='" 
                + textBox4.Text + "',教材='" + textBox5.Text + "',where 名称= '" + bd + "'";
   
            SqlCommand cmd = new SqlCommand(sqlupdata, conn);
            int rel = cmd.ExecuteNonQuery();
            if (rel > 0)
                MessageBox.Show("更新成功");
            conn.Close();
        }

        private void teacher_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“学生信息管理系统DataSet2.studentgrades”中。您可以根据需要移动或删除它。
            this.studentgradesTableAdapter.Fill(this.学生信息管理系统DataSet2.studentgrades);
            // TODO: 这行代码将数据加载到表“学生信息管理系统DataSet2.classmessage”中。您可以根据需要移动或删除它。
            this.classmessageTableAdapter.Fill(this.学生信息管理系统DataSet2.classmessage);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//添加按钮代码
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string insert1 = "insert into classmessage(名称,班级,学期,学时,教材) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"
               + textBox4.Text + "','" + textBox5.Text + "')";
            SqlCommand cmd = new SqlCommand(insert1, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)//显示信息按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select * from classmessage";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)//删除按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["名称"] == null) return;
            string bd = Convert.ToString(row["名称"]);
            string sql = "delete from classmessage where 名称 ='" + bd + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int del = cmd.ExecuteNonQuery();
            if (del == 1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)//显示按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select * from studentgrades";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView2.DataSource = dt;
            }
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)//添加按钮
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string insert1 = "insert into studentgrades(姓名,课程,学期,成绩) values('" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"
               + textBox9.Text + "')";
            SqlCommand cmd = new SqlCommand(insert1, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView2.SelectedRows.Count != 1) return;
            if (dataGridView2.CurrentRow == null) return;
            DataRowView row = dataGridView2.CurrentRow.DataBoundItem as DataRowView;
            if (row["姓名"] == null) return;
            string bd = Convert.ToString(row["姓名"]);
            string sql = "delete from studentgrades where 姓名 ='" + bd + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int del = cmd.ExecuteNonQuery();
            if (del == 1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
