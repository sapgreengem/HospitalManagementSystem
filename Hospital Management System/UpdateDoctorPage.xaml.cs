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
    /// Interaction logic for UpdateDoctorPage.xaml
    /// </summary>
    public partial class UpdateDoctorPage : Page
    {
        public UpdateDoctorPage()
        {
            InitializeComponent();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        public void loadDoctor()
        {
            try
            {
                string sql = "SELECT name,password,contact_no,address from doctor where id='"+docid.Text+"';";
                MySqlCommand MyCommand = new MySqlCommand(sql, con);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while(MyReader.Read())
                {
                    DocName.Text = MyReader.GetString(0).ToString();
                    DocPass.Text = MyReader.GetString(1).ToString();
                    DocPhone.Text = MyReader.GetString(2).ToString();
                    DocAddress.Text = MyReader.GetString(3).ToString();

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
                string sql1 = "update user.doctor set password='" +DocPass.Text+ "' where id='" +docid.Text+ "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql1, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Password Updated Succesfully");
                DocPass.Text = "";
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
                string sql2 = "update user.doctor set contact_no='" +DocPhone.Text+ "' where id='" +docid.Text+ "';";
                MySqlCommand MyCommand02 = new MySqlCommand(sql2, con);
                MySqlDataReader MyReader02;
                MyReader02 = MyCommand02.ExecuteReader();
                MyReader02.Close();
                MessageBox.Show("Contact Nunber Updated Succesfully");
                DocPhone.Text = "";
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
                string sql3 = "update user.doctor set address='" + DocAddress.Text + "' where id='" + docid.Text + "';";
                MySqlCommand MyCommand002 = new MySqlCommand(sql3, con);
                MySqlDataReader MyReader002;
                MyReader002 = MyCommand002.ExecuteReader();
                MyReader002.Close();
                MessageBox.Show("Address Updated Succesfully");
                DocAddress.Text = "";
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}
