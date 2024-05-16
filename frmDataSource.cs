using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ADOWinApps
{
    public partial class frmDataSource : Form
    {
        public frmDataSource()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con =new OleDbConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;Provider=MSOLedbSQL;user id=sa;password=greysoft");
                con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into singer values(?,?,?)";
            cmd.Parameters.Add("1", OleDbType.Integer);
            cmd.Parameters.Add("2", OleDbType.VarChar, 20);
            cmd.Parameters.Add("3", OleDbType.VarChar, 20);
            cmd.Parameters["1"].Value = 178;
            cmd.Parameters["2"].Value = "aman";
            cmd.Parameters["3"].Value = "tollywood";
            cmd.Connection = con;   
            int ans = cmd.ExecuteNonQuery();
            if (ans == 1)
                MessageBox.Show("inserted");
            else
                MessageBox.Show("not inserted");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;Provider=MSOLedbSQL;user id=sa;password=greysoft");
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from marksheet",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Data Source=DESKTOP-NJ7SO96\\SQLEXPRESS;Initial Catalog=Greysoft;Provider=MSOLedbSQL;user id=sa;password=greysoft");
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from NewsArticle", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"NewsArticle");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
