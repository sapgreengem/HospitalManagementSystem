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
    /// Interaction logic for ReleasePatientPage.xaml
    /// </summary>
    public partial class ReleasePatientPage : Page
    {
        public ReleasePatientPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        public MySqlConnection conn = DBConnect.connectToDb();
        public MySqlConnection conn2 = DBConnect.connectToDb();
        public string product_name;
        public string quantity;
        public string days;
        public string per_quantity_price;
        public string total_medicine_cost;

        public int per_quantity_price_int=0;
        public int quantity_int=0;
        public int days_int=0;
        public int total_medicine_cost_int=0;

       /* public string product_name[];
        public string quantity[];
        public string days[];
        public string per_quantity_price[];
        public string total_medicine_cost[];

        public int per_quantity_price_int[];
        public int quantity_int[];
        public int days_int[];
        public int total_medicine_cost_int[];*/
        private void btnReleasePatient_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //conn.Open();
                string Query = "select product_name,quantity,days from user.admitted_medicine where patient_contact_no='" + txtContactNo.Text + "'";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    product_name = MyReader.GetString(0);
                    quantity = MyReader.GetString(1);
                    days = MyReader.GetString(2);
                    //conn.Open();
                    string Query1 = "select selling_price from user.supplier where product_name='" + product_name + "'";
                    MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn2);
                    MySqlDataReader MyReader1;
                    MyReader1 = MyCommand1.ExecuteReader();
                    while (MyReader1.Read())
                    {
                        per_quantity_price = MyReader1.GetString(0);
                    }

                    quantity_int = Int32.Parse(quantity);
                    days_int = Int32.Parse(days);
                    per_quantity_price_int = Int32.Parse(per_quantity_price);
                    total_medicine_cost_int += quantity_int * days_int * per_quantity_price_int;


                }
                conn.Close();

                MessageBox.Show("Product Name: " + product_name + "\n" + "Days: " + days + "\n" + "Quantity: " + quantity);

                /*conn.Open();
                string Query1 = "select selling_price from user.supplier where product_name='" + product_name + "'";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    per_quantity_price = MyReader1.GetString(0);
                }
                conn.Close();*/

                MessageBox.Show("Selling price: " + per_quantity_price);

               /* quantity_int = Int32.Parse(quantity);
                days_int = Int32.Parse(days);
                per_quantity_price_int = Int32.Parse(per_quantity_price);

                total_medicine_cost_int = quantity_int * days_int * per_quantity_price_int;*/
                total_medicine_cost = total_medicine_cost_int.ToString();

                txtMedicineCost.Text = total_medicine_cost;

                //conn.Open();
                /*string Query = "select product_name,quantity,days from user.admitted_medicine where patient_contact_no='" + txtContactNo.Text + "'";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    product_name = MyReader.GetString(0);
                    quantity = MyReader.GetString(1);
                    days = MyReader.GetString(2);
                }
                conn.Close();

               // MessageBox.Show("Product Name: " + product_name + "\n" + "Days: " + days + "\n" + "Quantity: " + quantity);

                conn.Open();
                string Query1 = "select selling_price from user.supplier where product_name='" + product_name + "'";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    per_quantity_price = MyReader1.GetString(0);
                }
                conn.Close();

                //MessageBox.Show("Selling price: " + per_quantity_price);

                quantity_int = Int32.Parse(quantity);
                days_int = Int32.Parse(days);
                per_quantity_price_int = Int32.Parse(per_quantity_price);

                total_medicine_cost_int = quantity_int * days_int * per_quantity_price_int;
                total_medicine_cost = total_medicine_cost_int.ToString();

                txtMedicineCost.Text = total_medicine_cost;*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
