using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOWinApps
{
    public partial class frmDataAdapter : Form
    {
        public frmDataAdapter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NJ7SO96\\SQLEXPRESS;database=Greysoft;user id=sa;password=greysoft");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from employee", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            MessageBox.Show(ds.Tables[0].Rows.Count.ToString() + "name :\n" + ds.Tables[0].Rows[3][1] + "name :\n" + ds.Tables[0].Rows[3]["EmpName"]);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NJ7SO96\\SQLEXPRESS;database=Greysoft;user id=sa;password=greysoft");

            SqlDataAdapter da = new SqlDataAdapter("select * from employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "GreysoftEmp");
            da.SelectCommand.CommandText = "select * from singer";
            da.Fill(ds, "greysoftSinger");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NJ7SO96\\SQLEXPRESS;database=Greysoft;user id=sa;password=greysoft");

            SqlDataAdapter da = new SqlDataAdapter("select * from employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "GreysoftEmp");
            da.SelectCommand.CommandText = "select * from singer";
            da.Fill(ds, "greysoftSinger");
            ds.Tables[0].WriteXml("D:\\TRGDemos\\employee.xml");
            ds.Tables[1].WriteXml("D:\\TRGDemos\\singer.xml");
            MessageBox.Show("xml created");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=DESKTOP-NJ7SO96\\SQLEXPRESS;database=Greysoft;user id=sa;password=greysoft");

            SqlDataAdapter da = new SqlDataAdapter("select * from singer where songtype='classical'", con);

            DataSet s = new DataSet();

            da.Fill(s, "song1");
            da.SelectCommand.CommandText = "select * from singer where songtype='bollywood'";

            da.Fill(s, "song2");

            dataGridView1.DataSource = s.Tables["song1"];
            dataGridView2.DataSource = s.Tables["song2"];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet d = new DataSet();
            d.ReadXml("D://TRGDemos//emp.xml");
            dataGridView1.DataSource = d.Tables[0];
        }
    }
}
