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
using System.Globalization‌;
using System.Threading;

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
            dt2 = DateTime.Now.Date;
            dateRelease = dt2.ToString("yyyy-MM-dd");
            txtDateOfRelease.Text = dateRelease;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        string dateRelease = "";

        public string product_name = "";
        public string quantity = "";
        public string days = "";
        public string per_quantity_price;
        public string total_medicine_cost;

        public string test_cost;

        public string num_of_days;
        public string per_day_cost;

        public string admitted_date = "";

        public string pat_name, pat_age, pat_address, doc_name, disease, addmission_date;

        public int quantity_int=0;
        public int days_int=0;
        public int per_quantity_price_int=0;
        public int total_medicine_cost_int=0;

        public int test_cost_int;
        public int total_test_cost_int=0;

        public int num_of_days_int;
        public int per_day_cost_int;
        public int total_bed_cost_int=0;

        public DateTime dt1, dt2;
        public int date_difference = 0;

        //Hashtable hashtable = new Hashtable();

        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string QueryLoadDetails = "select patient_name,patient_age,patient_address,doc_name,patient_disease from user.admitted_patient where patient_contact_no='" + txtContactNo.Text + "' and checked_status='" + "Checked" + "' ";
                MySqlCommand MyCommandLoadDetails = new MySqlCommand(QueryLoadDetails, conn);
                MySqlDataReader MyReaderLoadDetails;
                MyReaderLoadDetails = MyCommandLoadDetails.ExecuteReader();
                while (MyReaderLoadDetails.Read())
                {
                    pat_name = MyReaderLoadDetails.GetString(0);
                    pat_age = MyReaderLoadDetails.GetString(1);
                    pat_address = MyReaderLoadDetails.GetString(2);
                    disease = MyReaderLoadDetails.GetString(4);
                    doc_name = MyReaderLoadDetails.GetString(3);
                }

                txtPatientName.Text = pat_name;
                txtPatientAge.Text = pat_age;
                txtPatientAddress.Text = pat_address;
                txtDocName.Text = doc_name;
                txtDisease.Text = disease;
                MyReaderLoadDetails.Close();

                ///Calculating Total Medicine Cost
                string Query = "select quantity,days,selling_price,time_of_admission from user.admitted_medicine_cost where patient_contact_no='" + txtContactNo.Text + "' ";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    quantity = MyReader.GetString(0);
                    days = MyReader.GetString(1);
                    per_quantity_price = MyReader.GetString(2);
                    admitted_date = MyReader.GetString(3);

                    quantity_int = Int32.Parse(quantity);
                    days_int = Int32.Parse(days);
                    per_quantity_price_int = Int32.Parse(per_quantity_price);
                    total_medicine_cost_int = total_medicine_cost_int + (quantity_int * per_quantity_price_int * days_int);
                    total_medicine_cost = total_medicine_cost_int.ToString();
                    //deletenow quantity_int*days_int
                }
                txtMedicineCost.Text = total_medicine_cost;
                MyReader.Close();

                txtDateOfAdmit.Text = admitted_date;

                ///Calculating Test Cost
                string QueryTest = "select test_cost from user.admitted_test_cost where patient_contact_no='" + txtContactNo.Text + "' ";
                MySqlCommand MyCommandTest = new MySqlCommand(QueryTest, conn);
                MySqlDataReader MyReaderTest;
                MyReaderTest = MyCommandTest.ExecuteReader();
                while (MyReaderTest.Read())
                {
                    test_cost = MyReaderTest.GetString(0);
                    test_cost_int = Int32.Parse(test_cost);
                    total_test_cost_int = total_test_cost_int + test_cost_int;
                }
                txtTestCost.Text = total_test_cost_int.ToString();
                MyReaderTest.Close();
            }
            catch { }
        }

        public int x, y;

        private void btnReleasePatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            
                string Query = "insert into user.release_patient values('" + txtPatientName.Text + "','" + txtPatientAge.Text + "','" + txtContactNo.Text + "','" + txtPatientAddress.Text + "','" + txtDisease.Text + "','" + txtDocName.Text + "','" + txtDateOfAdmit.Text + "','" + txtDateOfRelease.Text + "','" + txtDays.Text + "','" +txtMedicineCost.Text +"','" +txtTestCost.Text +"', '" + txtBedCost.Text + "', '"+txtTotalCost.Text+"');";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();
                MessageBox.Show("Patient Released!");

                string Query1 = "update user.admitted_patient set checked_status='" + "Released" + "' where patient_contact_no='" + txtContactNo.Text + "';";
                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                MyReader1.Close();


                //These 3 block codes are responsible for free-ing the bed.
                string Query2 = "update user.bed set pat_contact_no='" + "" + "', bed_status='" + "Free" + "' where pat_contact_no='" + txtContactNo.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query2, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();

                //SELECT ward.ward_name,bed.pat_contact_no, bed.bed_no,bed.bed_type ,bed.bed_cost, bed.bed_status FROM ward,bed WHERE ward.ward_id = bed.ward_id

                string Query3 = "DROP TABLE user.ward_bed;";
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, conn);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                MyReader3.Close();

                string Query4 = "CREATE TABLE ward_bed AS SELECT ward.ward_name,bed.pat_contact_no, bed.bed_no,bed.bed_type ,bed.bed_cost, bed.bed_status FROM ward,bed WHERE ward.ward_id = bed.ward_id;";
                MySqlCommand MyCommand4 = new MySqlCommand(Query4, conn);
                MySqlDataReader MyReader4;
                MyReader4 = MyCommand4.ExecuteReader();
                MyReader4.Close();


                string Query5 = "DROP TABLE user.allocate_patient_bed;";
                MySqlCommand MyCommand5 = new MySqlCommand(Query5, conn);
                MySqlDataReader MyReader5;
                MyReader5 = MyCommand5.ExecuteReader();
                MyReader5.Close();

                string Query6 = "CREATE TABLE allocate_patient_bed AS SELECT admitted_patient.patient_name,admitted_patient.patient_age,admitted_patient.patient_contact_no,ward_bed.ward_name,ward_bed.bed_no,ward_bed.bed_type,ward_bed.bed_cost,ward_bed.bed_status FROM admitted_patient,ward_bed WHERE admitted_patient.patient_contact_no=ward_bed.pat_contact_no AND admitted_patient.ward_name=ward_bed.ward_name;";
                MySqlCommand MyCommand6 = new MySqlCommand(Query6, conn);
                MySqlDataReader MyReader6;
                MyReader6 = MyCommand6.ExecuteReader();
                MyReader6.Close();

                txtContactNo.Text = ""; txtPatientAge.Text = ""; txtPatientAddress.Text = ""; txtDateOfRelease.Text = "";
                txtPatientName.Text = ""; txtDisease.Text = ""; txtDocName.Text = ""; txtDateOfAdmit.Text = "";
                txtMedicineCost.Text = ""; txtBedCost.Text = ""; txtTestCost.Text = ""; txtTotalCost.Text = ""; txtDays.Text = "";
                btnReleasePatient.IsEnabled = false;

                /*string Query5 = "select quantity,days from user.admitted_medicine where product_name='" + comboboxMedicineName.SelectedItem + "';";
                MySqlCommand MyCommand5 = new MySqlCommand(Query5, conn);
                MySqlDataReader MyReader5;
                MyReader5 = MyCommand5.ExecuteReader();
                while (MyReader5.Read())
                {
                    string medquantyty = MyReader5.GetString(0);
                    x = Int32.Parse(medquantyty);
                    string c = this.quantity.Text;
                    y = Int32.Parse(c);

                    x = x - y;
                }
                MyReader5.Close();

                string Query6 = "update user.supplier set quantity='" + x.ToString() + "' where product_name='" + comboboxMedicineName.SelectedItem + "' ;";
                MySqlCommand MyCommand6 = new MySqlCommand(Query6, conn);
                MySqlDataReader MyReader6;
                MyReader6 = MyCommand6.ExecuteReader();
                MyReader6.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDays_TextChanged(object sender, TextChangedEventArgs e)
        {

            //////Calculating Bed Cost and Total Cost

            num_of_days = txtDays.Text.ToString();
            num_of_days_int = Int32.Parse(num_of_days);

            //MessageBox.Show(num_of_days_int.ToString());
            string QueryBed = "select bed_cost from user.allocate_patient_bed where patient_contact_no='" + txtContactNo.Text + "' ";
            MySqlCommand MyCommandBed = new MySqlCommand(QueryBed, conn);
            MySqlDataReader MyReaderBed;
            MyReaderBed = MyCommandBed.ExecuteReader();
            while (MyReaderBed.Read())
            {
                per_day_cost = MyReaderBed.GetString(0);
                per_day_cost_int = Int32.Parse(per_day_cost);
                total_bed_cost_int = per_day_cost_int * num_of_days_int;
            }
            txtBedCost.Text = total_bed_cost_int.ToString();
            txtTotalCost.Text = (total_test_cost_int + total_medicine_cost_int + total_bed_cost_int).ToString();
            MyReaderBed.Close();

            btnReleasePatient.IsEnabled = true;
        }
    }
}