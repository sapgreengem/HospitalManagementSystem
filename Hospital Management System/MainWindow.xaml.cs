using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;


namespace Hospital_Management_System
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.Items.Add("Adminstrator");
            combobox.Items.Add("Doctor");
            combobox.Items.Add("Staff");
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem == null)
            {
                MessageBox.Show("Please choose an option");
            }
            else if (combobox.SelectedItem.Equals("Staff"))
            {
                /*StaffWindow objStaffWindow = new StaffWindow();
                objStaffWindow.Show();
                this.Close();*/

                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from user.staff where staff_id='" + textboxUsername.Text + "' and staff_password='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        StaffWindow objStaffWindow = new StaffWindow();
                        objStaffWindow.Show();
                        objStaffWindow.loginAsStaff.Text = textboxUsername.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else if (combobox.SelectedItem.Equals("Doctor"))
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from user.doctor where id='" + textboxUsername.Text + "' and password='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        DoctorWindow objDoctorWindow = new DoctorWindow();
                        objDoctorWindow.loginAsDoctor.Text = textboxUsername.Text;
                        objDoctorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (combobox.SelectedItem.Equals("Adminstrator"))
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {                              
                    string q = "select * from user.admin where username='" + textboxUsername.Text + "' and password='" + textboxPassword.Password + "';";               
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();     
                    if(MyReader2.Read()) 
                    {
                       MessageBox.Show("You have succesfully logged in");                       
                       AdminWindow objAdminWindow = new AdminWindow();
                       objAdminWindow.Show();
                       this.Close();
                     }
                     else
                     {
                       MessageBox.Show("Username or password do not match");
                     }
                     conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                    
            }
        }
    }
}
