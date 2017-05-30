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
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for AppointmentStatusPage.xaml
    /// </summary>
    public partial class AppointmentStatusPage : Page
    {
        public AppointmentStatusPage()
        {
            InitializeComponent();
            load_table();
        }

        void load_table()
        {
            try
            {
                string sql = "select * from user.appointment;";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridAppointmentStatus.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Refresh_Click_1(object sender, RoutedEventArgs e)
        {
            load_table();      
        }

        private void datagridAppointmentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)datagridAppointmentStatus.SelectedItems[0];
                textBox.Text = row["pat_name"].ToString();
                textBox2.Text = row["pat_contact_no"].ToString();
                status.Text = row["appointment_status"].ToString();
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox2.Text.Equals(""))
            {
                textBox.Text = "";
                status.Text = "";
            }
            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {

                    string q = "select * from user.appointment where pat_contact_no='" + textBox2.Text + "';";

                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                        textBox.Text = MyReader2.GetValue(0).ToString();
                        status.Text = MyReader2.GetValue(8).ToString();
                        textBox.Focus();
                        status.Focus();

                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
            }
            
        }       
    }
}