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

namespace Car_Rental_Management_System
{
    public partial class Rental : Form
    {
        public Rental()
        {
            InitializeComponent();
        }
        SqlConnection Cnn = new SqlConnection(@"Data Source=BURHAN;Initial Catalog= Car Rental System ; Integrated Security=True");
        private void fillCarcombo()
        {
            Cnn.Open();
            string query = "Select  RegNum from Cars where Avialable ='"+"Yes"+"' ";
            SqlCommand cmd = new SqlCommand(query, Cnn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum",typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember= "RegNum";
            CarRegCb.DataSource = dt;
            Cnn.Close();

        }
        private void fillCustomerID()
        {
            Cnn.Open();
            string query = "Select C_id  from Customer";
            SqlCommand cmd = new SqlCommand(query, Cnn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("C_id", typeof(int));
            dt.Load(rdr);
            CustomerIDcb.ValueMember = "C_id";
            CustomerIDcb.DataSource = dt;
            Cnn.Close();
        }
        private void fetchCustomerName()
        {
            if (Cnn.State != ConnectionState.Open)
            {
                Cnn.Open();
                string query = "Select * from Customer where C_id=" + CustomerIDcb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CustomerName.Text = dr["Cname"].ToString();
                }
                Cnn.Close();
            }
            else
            {
                string query = "Select * from Customer where C_id=" + CustomerIDcb.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, Cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CustomerName.Text = dr["Cname"].ToString();
                }
                Cnn.Close();
            } 
        }
        private void populate()
        {
            Cnn.Open();
            string query = "Select * from Rental";
            SqlDataAdapter Da = new SqlDataAdapter(query, Cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(Da);
            var ds = new DataSet();
            Da.Fill(ds);
            RentalDGV.DataSource = ds.Tables[0];

            Cnn.Close();

        }

        private void UpdateOnRent()
        {
            Cnn.Open();
            string query = "update Cars Set Avialable='" + "No" + "'where RegNum='" + CarRegCb.SelectedValue.ToString() +"';";
            SqlCommand cmd = new SqlCommand(query, Cnn);
            cmd.ExecuteNonQuery();
           // MessageBox.Show("Car Successfully Updated");
            Cnn.Close();

        }
        private void UpdateOnRentDelete()
        {
            Cnn.Open();
            string query = "update Cars Set Avialable='" + "Yes" + "'where RegNum='" + CarRegCb.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, Cnn);
             // MessageBox.Show("Car Successfully Updated");
            cmd.ExecuteNonQuery();
            Cnn.Close();

        }
        private void label2_Click(object sender, EventArgs e)
        {
             
            string message = "Do you want to close this window?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Main_Menu temp = new Main_Menu();
                this.Close();
                temp.Show();
            }
            else
            {

            }  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main_Menu temp = new Main_Menu();
            this.Close();
            temp.Show();
        }

        private void Rental_Load(object sender, EventArgs e)
        {
           
            fillCarcombo();
            fillCustomerID();
            populate();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Rid.Text == "" || CustomerName.Text == "" || fee.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Cnn.Open();
                    string query = "Insert into  Rental Values(" + Rid.Text + ",'" + CarRegCb.SelectedValue.ToString() +"'," + CustomerIDcb.SelectedValue.ToString() + ",'" + CustomerName.Text + "','" + RentDate.Value.Date + "','" + ReturnDate.Value.Date + "','" + fee.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Rented");
                    Cnn.Close();
                    UpdateOnRent();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }

            }
        }

        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CustomerIDcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchCustomerName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Rid.Text == "")
            {
                MessageBox.Show("You have not provied any Rental ID Which you want to delete");
            }
            else
            {
                try
                {
                    Cnn.Open();
                    string query = "Delete from Rental where Rental_id=" + Rid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Delete Successfully");
                    UpdateOnRentDelete();
                    Cnn.Close();
                    populate();
                    

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void RentalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = RentalDGV.Rows[e.RowIndex];
                Rid.Text = row.Cells[0].Value.ToString();
               CarRegCb.SelectedValue = row.Cells[1].Value.ToString();
                CustomerIDcb.SelectedValue = row.Cells[2].Value.ToString();
                CustomerName.Text = row.Cells[3].Value.ToString();
                RentDate.Value = Convert.ToDateTime(row.Cells[4].Value);
                ReturnDate.Value = Convert.ToDateTime(row.Cells[5].Value);
               fee.Text = row.Cells[6].Value.ToString();
            } 
         
        }

        }

        }
    


