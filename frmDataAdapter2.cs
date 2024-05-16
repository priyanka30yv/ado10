using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinApps
{
    public partial class frmDataAdapter2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public frmDataAdapter2()
        {
            InitializeComponent();
            con=new SqlConnection("server=DESKTOP-NJ7SO96\\SQLEXPRESS;database=Greysoft;user id=sa;password=greysoft");
            da = new SqlDataAdapter();
            cmd = new SqlCommand();
            cmd.CommandText = "select distinct songtype from singer";
            cmd.Connection=con;

        }

        private void frmDataAdapter2_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            con.Close();    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandText = "select distinct songtype from singer";
            da.SelectCommand.Connection = con;
            con.Open();
           SqlDataReader dr=da.SelectCommand.ExecuteReader();
            while(dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da.InsertCommand = new SqlCommand();
            da.InsertCommand.Connection = con;
            da.InsertCommand.Connection.Open();
            da.InsertCommand.CommandText = "insert into singer values(@p1,@p2,@p3)";
            da.InsertCommand.Parameters.Add("@p1", SqlDbType.Int);
            da.InsertCommand.Parameters.Add("@p2", SqlDbType.VarChar, 20);
            da.InsertCommand.Parameters.Add("@p3", SqlDbType.VarChar, 20);
            da.InsertCommand.Parameters["@p1"].Value = 89;
            da.InsertCommand.Parameters["@p2"].Value = "tonny kakkar";
            da.InsertCommand.Parameters["@p3"].Value = "folk";
            int ans=da.InsertCommand.ExecuteNonQuery();
            if(ans > 0) 
                MessageBox.Show("inserted");
                else
                    MessageBox.Show("not inserted");


            }

        private void button2_Click(object sender, EventArgs e)
        {      da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection = con;
            
            da.SelectCommand.CommandText = "select * from singer where songtype=@p1 ";
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.VarChar, 20);
            da.SelectCommand.Parameters["@p1"].Value = comboBox1.Text;
            DataSet d = new DataSet();
            da.Fill(d);
            dataGridView1.DataSource = d.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            da.UpdateCommand=new SqlCommand();
            da.UpdateCommand.Connection = con;
            da.UpdateCommand.CommandText = "update singer set singername=@p1 where singername=@p2";
            da.UpdateCommand.Parameters.Add("@p1", SqlDbType.VarChar, 20);
            da.UpdateCommand.Parameters.Add("@p2", SqlDbType.VarChar, 20);
            da.UpdateCommand.Parameters["@p1"].Value = "A R rehman";
            da.UpdateCommand.Parameters["@p2"].Value = "arijit singh";
       con.Open();
            int ans =da.UpdateCommand.ExecuteNonQuery();
            if (ans == 1)
                MessageBox.Show("updated");
            else
                MessageBox.Show("not updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
da.DeleteCommand=new SqlCommand();
            da.DeleteCommand.Connection = con;
            da.DeleteCommand.CommandText = "delete from singer where singerid=@p1";
            da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Int);
            da.DeleteCommand.Parameters["@p1"].Value = 1;
            con.Open();
            int ans=da.DeleteCommand.ExecuteNonQuery();
            if (ans == 1)
                MessageBox.Show("deleted");
            else
                MessageBox.Show("not deleted");

        }
    }
    }

