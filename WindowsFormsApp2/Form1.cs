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
using System.IO;
using System.Drawing.Imaging;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\source\repos\WindowsFormsApp2\WindowsFormsApp2\Database1.mdf;Integrated Security=True");
        //SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Att
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter1.Fill(this.database1DataSet1.Table);
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void b_Click(object sender, EventArgs e)
        {
           
             
            

        }

       
        private void save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Users values('" + ID.Text + "','" + name.Text + "','" + salary.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved");


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Users SET name='"+name.Text+"' WHERE ID='"+ID.Text+"'" ;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated");

        }

        private void display_Click(object sender, EventArgs e)
        {

            //   string con = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
            string cmd = "Select * from Users";
            SqlDataAdapter dp = new SqlDataAdapter(cmd, con);
            //  SqlCommandBuilder cb = new SqlCommandBuilder(dp);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView2.DataSource = bs;

        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Users WHERE ID='" + ID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            display_Click(sender, e);
            

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                img.Text = openFileDialog1.FileName;

           // pictureBox1.ImageLocation = img.Text;
          //pictureBox1.Image = Convert.ToSByte(openFileDialog1.FileName);
        }

        private void saveimg_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            //FileStream fs1 = new FileStream(img.Text);
            Byte[] mypic = File.ReadAllBytes(openFileDialog1.FileName);

            cmd1.CommandText = "Insert into imagestore values('" + ID.Text + "','" +pictureBox1.Image + "')";
            cmd1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void shwimg_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda=new SqlDataAdapter("select * from imagestore where Id="+ ID.Text ,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            byte[] mydata = new byte[0];
            mydata = (byte[])dt.Rows[0][1];
            MemoryStream ms = new MemoryStream(mydata);       
            pictureBox1.Image = Image.FromStream(ms);
            con.Close();
           
        }

        private void img_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
