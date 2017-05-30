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
    /// <summary>
    /// Interaction logic for UpdateStaffPage.xaml
    /// </summary>
    public partial class UpdateStaffPage : Page
    {
        public UpdateStaffPage()
        {
            InitializeComponent();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        public void loadStaff()
        {
            try
            {
                string sql = "SELECT name from staff where staff_id='" + textBox1.Text + "';";
                MySqlCommand MyCommand = new MySqlCommand(sql, con);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    staffName.Text = MyReader.GetString(0).ToString();
                }
                MyReader.Close();
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sql1 = "update user.staff set staff_password='" + staffPass.Text + "' where staff_id='" + textBox1.Text + "';";
                MySqlCommand MyCommand1 = new MySqlCommand(sql1, con);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                MyReader1.Close();
                MessageBox.Show("Password Updated Succesfully");
                staffPass.Text = "";
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sql2 = "update user.staff set contact_num='" + staffContact.Text + "' where staff_id='" + textBox1.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql2, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Contact Number Updated Succesfully");
                staffContact.Text = "";
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                string sql3 = "update user.staff set address='" + staffAddress.Text + "' where staff_id='" + textBox1.Text + "';";
                MySqlCommand MyCommand3 = new MySqlCommand(sql3, con);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                MyReader3.Close();
                MessageBox.Show("Address Updated Succesfully");
                staffAddress.Text = "";
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}
