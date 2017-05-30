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

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for AddDoctorPage.xaml
    /// </summary>
    public partial class AddDoctorPage : Page
    {
        public AddDoctorPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            
            if(textBox.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals("") || comboboxDept.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("") || datepicker.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals("") || textBox8.Text.Equals(""))
            {
                MessageBox.Show("Please Fill All the fields");
            }
            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string Query = "insert into user.doctor(name,age,contact_no,department,specialist_in,address,join_date,counsiling_hour,id,password) values('" + textBox.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboboxDept.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + datepicker.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "');";

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Doctor Added . . .");

                    conn.Close();

                    textBox.Text = ""; textBox1.Text = ""; textBox2.Text = "";
                    comboboxDept.Text = ""; 
                    textBox4.Text = ""; textBox5.Text = "";
                    datepicker.Text = ""; textBox6.Text = ""; textBox7.Text = "";
                    textBox8.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }           
        }
    }
}