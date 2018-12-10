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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“学生信息管理系统DataSet2.student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.学生信息管理系统DataSet2.student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            DataSet dds = new DataSet();//创建dataset实例
            string selectsql = "Select * from student";
            SqlDataAdapter sqlDap = new SqlDataAdapter(selectsql, conn);//创建DataAdapter数据适配器实例
            DataTable dt = new DataTable();
            sqlDap.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                dataGridView1.DataSource = dt;
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)//跳转添加页面
        {
            Inaddform add = new Inaddform();
            add.ShowDialog();
            this.Hide();
            this.Dispose();
            
        }

        private void button3_Click(object sender, EventArgs e)//查找信息
        {
            select up = new select();
            up.ShowDialog();
            this.Hide();
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)//删除信息
        {
            string str = @"Data Source=desktop-mbupc0n;Initial catalog=学生信息管理系统;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["学号"] == null) return;
            string bd = Convert.ToString(row["学号"]);
            string sql = "delete from student where 学号 =" + bd + "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int del = cmd.ExecuteNonQuery();
            if(del==1)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
