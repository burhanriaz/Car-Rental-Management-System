﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_Management_System
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

        private void label2_Click(object sender, EventArgs e)
        {
            string message = "Do you want to Close this Windows?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Login temp = new Login();
                this.Close();
                temp.Show();
            }
            else
            {
               
            } 
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string message = "Do you want to Logout?";
            string title = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Login temp = new Login();
                this.Close();
                temp.Show();
                
            }
            else
            {
                
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cars temp = new cars();
            this.Hide();
            temp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer temp = new Customer();
            this.Hide();
            temp.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Rental temp = new Rental();
            this.Hide();
            temp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Return temp = new Return();
            this.Hide();
            temp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User temp = new User();
            this.Hide();
            temp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard temp = new Dashboard();
            this.Hide();
            temp.Show();
        }

        
    }
}
