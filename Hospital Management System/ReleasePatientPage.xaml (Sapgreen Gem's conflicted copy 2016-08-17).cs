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

        public string product_name = "";
        public string quantity = "";
        public string days = "";
        public string per_quantity_price;
        public string total_medicine_cost;

        /*public int quantity_int[];
        public int days_int[];
        public int per_quantity_price_int[];
        public int total_medicine_cost_int[];*/


        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            try
            {
               
                string Query = "select product_name,quantity,days from user.admitted_medicine where patient_contact_no='"+txtContactNo.Text+"' ";
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

                //MessageBox.Show("Productname: " + product_name + "\n" + "Quantity: " + quantity + "\n" + "Days: " + days);

                /*conn.Open();
                string Query1 = "select selling_price from user.supplier where product_name='"+product_name+"'";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                while (MyReader1.Read())
                {
                    per_quantity_price = MyReader1.GetString(0);
                }
                conn.Close();

                quantity_int = Int32.Parse(quantity);
                per_quantity_price_int = Int32.Parse(per_quantity_price);
                days_int = Int32.Parse(days);

                total_medicine_cost_int = quantity_int * per_quantity_price_int * days_int;

                total_medicine_cost = total_medicine_cost_int.ToString();

                txtMedicineCost.Text = total_medicine_cost;*/


                



                /*conn.Open();
                string Query1 = "DROP TABLE user.ward_bed;";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                conn.Close();

                conn.Open();
                string Query2 = "CREATE TABLE ward_bed AS SELECT ward.ward_name,bed.pat_contact_no,bed.bed_no,bed.bed_type,bed.bed_cost,bed.bed_status FROM ward,bed WHERE ward.ward_id=bed.ward_id;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query2, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                conn.Close();

                conn.Open();
                string Query3 = "DROP TABLE user.allocate_patient_bed;";
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, conn);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                conn.Close();

                conn.Open();
                string Query4 = "CREATE TABLE allocate_patient_bed AS SELECT admitted_patient.patient_name,admitted_patient.patient_age,admitted_patient.patient_contact_no,ward_bed.ward_name,ward_bed.bed_no,ward_bed.bed_type,ward_bed.bed_cost,ward_bed.bed_status FROM admitted_patient,ward_bed WHERE admitted_patient.patient_contact_no=ward_bed.pat_contact_no AND admitted_patient.ward_name=ward_bed.ward_name;";
                MySqlCommand MyCommand4 = new MySqlCommand(Query4, conn);
                MySqlDataReader MyReader4;
                MyReader4 = MyCommand4.ExecuteReader();
                conn.Close();

                MessageBox.Show("Patient Addmitted!");

                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no.Text = "";
                comboboxBloodGroup.Text = ""; comboboxDoctorName.Text = "";
                textboxBed.Text = ""; textboxBedType.Text = ""; textboxWard.Text = ""; textboxDoctorDept.Text = "";*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReleasePatient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
