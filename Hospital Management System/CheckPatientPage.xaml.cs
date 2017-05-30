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
    /// Interaction logic for CheckPatientPage.xaml
    /// </summary>
    public partial class CheckPatientPage : Page
    {
        public CheckPatientPage()
        {
            InitializeComponent();
        }

        ///Variables For Medicine list
        public string med_name = "";
        public string quantity = "";
        public string days = "";
        public string timeOfDay = "";

        public string type = "";
        public string Query = "";
        public string Query78;
        public string doc_dept = "";

        public int connection = 1;

        public MySqlConnection conn = DBConnect.connectToDb();

        public void check_doctor_dept()
        {
           try
            {
                Query78 = "select department from user.doctor where id='"+hmmtext.Text+"';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query78, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    doc_dept = MyReader2.GetString(0);
                }
                MyReader2.Close();

                if (doc_dept.Equals("Cardiology"))
                {
                    string Query100 = "select distinct disease_type from user.medicine_name where disease_type='" + "Cardiac" + "';";
                    MySqlCommand MyCommand100 = new MySqlCommand(Query100, conn);
                    MySqlDataReader MyReader100;
                    MyReader100 = MyCommand100.ExecuteReader();
                    while (MyReader100.Read())
                    {
                        testingprocess.Text = MyReader100.GetString(0).ToString();
                    }
                    MyReader100.Close();

                }

                else if (doc_dept.Equals("Nurology"))
                {
                    
                    string Query101 = "select distinct disease_type from user.medicine_name where disease_type='" + "Neurological" + "';";
                    MySqlCommand MyCommand101 = new MySqlCommand(Query101, conn);
                    MySqlDataReader MyReader101;
                    MyReader101 = MyCommand101.ExecuteReader();
                    while (MyReader101.Read())
                    {
                        testingprocess.Text = MyReader101.GetString(0).ToString();
                    }
                    MyReader101.Close();
                }

                else if (doc_dept.Equals("Orthopedics"))
                {
                    string Query102 = "select distinct disease_type from user.medicine_name where disease_type='" + "Orthopedic" + "';";
                    MySqlCommand MyCommand102 = new MySqlCommand(Query102, conn);
                    MySqlDataReader MyReader102;
                    MyReader102 = MyCommand102.ExecuteReader();
                    while (MyReader102.Read())
                    {
                        testingprocess.Text = MyReader102.GetString(0).ToString();;
                    }
                    MyReader102.Close();
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string check()
        {
            if (radAcPat.IsChecked == true)
            {
                type = "Accepted";
            }
            if (radAdPat.IsChecked == true)
            {
                type = "Admitted";
            }
            return type;
        }

        public void load_check_list()
        {
            try
            {
                string sql = "select pat_name,pat_age,pat_address,pat_contact_no,appointment_date from user.appointment where doc_id='" + hmmtext.Text.ToString() + "' and appointment_status='"+"Accepted"+"';";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagrid.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        public void load_check_list_admitted()
        {
            try
           {
                string sql = "select patient_name,patient_age,patient_disease,patient_address,patient_contact_no,time_of_admission from user.admitted_patient where doc_id='" + hmmtext.Text.ToString() + "' and checked_status='" + "Admitted" + "';";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagrid.ItemsSource = ds.Tables[0].DefaultView;
           }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        void add_more_medicines()
        {
            conn.Close();
            MedicineWindow medWindow = new MedicineWindow(this);
            medWindow.medwindowDate.Text = checkpatientDate.Text;
            medWindow.medwindowContactNumber.Text = checkpatientContactNo.Text;
            medWindow.disease.Text = testingprocess.Text;
            medWindow.doc_id.Text = hmmtext.Text;
            medWindow.Show();        
        }

        void add_more_test()
        { 
            TestWindow testWindow = new TestWindow(this);
            testWindow.medwindowDateT.Text = checkpatientDate.Text;
            testWindow.medwindowContactNumberT.Text = checkpatientContactNo.Text;
            testWindow.diseaseT.Text = testingprocess.Text;
            testWindow.doc_idT.Text = hmmtext.Text;
            testWindow.Show();
        }

        public void see_medicine_list()
        {
            try
            {
                string sql = "SELECT product_name,quantity,days,time_of_day from user.medicine where pat_contact_no='" + checkpatientContactNo.Text.ToString() + "'and appointment_date='" + checkpatientDate.Text.ToString() + "' and doc_id='" + hmmtext.Text + "';";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagridMedicineList.ItemsSource = ds.Tables[0].DefaultView;

           }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        public void see_test()
        {
            try
            {
                string sql = "SELECT test_name from user.test where pat_contact_no='"+checkpatientContactNo.Text.ToString()+ "' and appointment_date='" + checkpatientDate.Text.ToString() + "' and doc_id='" + hmmtext.Text + "';";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagridTest.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrescribeMedicine.IsEnabled = true;
            PrescribeTest.IsEnabled = true;
            

            if (check().Equals("Admitted")) radAcPat.IsEnabled = false;
            else if (check().Equals("Accepted")) radAdPat.IsEnabled = false;
            
           try
            {
                DataRowView row = (DataRowView)datagrid.SelectedItems[0];
                if (check().Equals("Admitted"))
                {
                    checkpatientContactNo.Text = row["patient_contact_no"].ToString();
                    checkpatientDate.Text = row["time_of_admission"].ToString();
                    checkpatientName.Text = row["patient_name"].ToString();
                    checkpatientAge.Text = row["patient_age"].ToString();
                    testingprocess.Text = row["patient_disease"].ToString();
                    comboboxDiseaseType.IsEnabled = false;                   
                }

                if (check().Equals("Accepted"))
                {
                    checkpatientContactNo.Text = row["pat_contact_no"].ToString();
                    checkpatientDate.Text = row["appointment_date"].ToString();
                    checkpatientName.Text = row["pat_name"].ToString();
                    checkpatientAge.Text = row["pat_age"].ToString();
                }
            }
            catch { }
        }

        private void datagridMedicineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row1 = (DataRowView)datagridMedicineList.SelectedItem;
                med_name = row1["product_name"].ToString();
                quantity = row1["quantity"].ToString();
                days = row1["days"].ToString();
                timeOfDay = row1["time_of_day"].ToString();
            }
            catch { }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            load_check_list();
        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            add_more_medicines();
        }

        public string Query1;
        public string Query2;
        public string Query9;
        public string Query8;
        public string Query3;
        public int i;

        public string x, y;


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
                if (check().Equals("Accepted"))
                {                    
                    Query1 = "DROP TABLE user.appointment_medicine;";
                    Query2 = "CREATE TABLE user.appointment_medicine AS SELECT appointment.pat_name,appointment.pat_contact_no,appointment.appointment_date,appointment.pat_age,medicine.disease,medicine.product_name,medicine.quantity,medicine.days,medicine.time_of_day FROM appointment,medicine WHERE user.appointment.pat_contact_no=user.medicine.pat_contact_no AND user.appointment.appointment_date=user.medicine.appointment_date;";
                    Query9 = "DROP TABLE user.appointment_test;";
                    Query8 = "CREATE TABLE user.appointment_test AS SELECT appointment.pat_name,appointment.pat_contact_no,appointment.appointment_date,appointment.pat_age,test.test_name FROM appointment,test WHERE user.appointment.pat_contact_no=user.test.pat_contact_no AND user.appointment.appointment_date=user.test.appointment_date;"; 
                    Query3 = "update user.appointment set appointment_status='" + "Checked" + "' where pat_contact_no='" + checkpatientContactNo.Text.ToString() + "' and appointment_date='" + checkpatientDate.Text.ToString() + "';";
                    i = 1;
                }

                if (check().Equals("Admitted"))
                {
                    Query1 = "DROP TABLE user.admitted_medicine;";
                    Query2 = "CREATE TABLE user.admitted_medicine AS SELECT admitted_patient.patient_name,admitted_patient.patient_contact_no,admitted_patient.time_of_admission,admitted_patient.patient_age,medicine.disease,medicine.product_name,medicine.quantity,medicine.days,medicine.time_of_day FROM admitted_patient,medicine WHERE user.admitted_patient.patient_contact_no=user.medicine.pat_contact_no AND user.admitted_patient.time_of_admission=user.medicine.appointment_date;";
                    Query9 = "DROP TABLE user.admitted_test;";
                    Query8 = "CREATE TABLE user.admitted_test AS SELECT admitted_patient.patient_name,admitted_patient.patient_contact_no,admitted_patient.time_of_admission,admitted_patient.patient_age,test.test_name FROM admitted_patient,test WHERE user.admitted_patient.patient_contact_no=user.test.pat_contact_no AND user.admitted_patient.time_of_admission=user.test.appointment_date;";
                    Query3 = "update user.admitted_patient set checked_status='" +"Checked"+ "' where patient_contact_no='" + checkpatientContactNo.Text + "' and time_of_admission='" + checkpatientDate.Text + "';";
                    i = 0;
                }

                conn.Open();

                MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader1;
                MyReader1 = MyCommand1.ExecuteReader();
                MyReader1.Close(); 

                MySqlCommand MyCommand2 = new MySqlCommand(Query2, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();

                MySqlCommand MyCommand9 = new MySqlCommand(Query9, conn);
                MySqlDataReader MyReader9;
                MyReader9 = MyCommand9.ExecuteReader();
                MyReader9.Close();

                MySqlCommand MyCommand8 = new MySqlCommand(Query8, conn);
                MySqlDataReader MyReader8;
                MyReader8 = MyCommand8.ExecuteReader();
                MyReader8.Close();

                MySqlCommand MyCommand3 = new MySqlCommand(Query3, conn);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                MyReader3.Close();

                if (i == 0)
                {
                    string Query67 = "DROP TABLE user.admitted_medicine_cost;";
                    string Query68 = "CREATE TABLE admitted_medicine_cost AS SELECT admitted_medicine.patient_name,admitted_medicine.patient_contact_no,admitted_medicine.time_of_admission, admitted_medicine.patient_age, admitted_medicine.disease,admitted_medicine.product_name,admitted_medicine.quantity, admitted_medicine.days,admitted_medicine.time_of_day,supplier.selling_price FROM admitted_medicine,supplier WHERE admitted_medicine.product_name = supplier.product_name;";
                    string Query69 = "DROP TABLE admitted_test_cost;";
                    string Query70 = "CREATE TABLE admitted_test_cost AS SELECT admitted_test.patient_name,admitted_test.patient_contact_no,admitted_test.time_of_admission,admitted_test.patient_age,admitted_test.test_name,test_name.test_cost FROM admitted_test,test_name WHERE admitted_test.test_name=test_name.test_Name;";
                    
                    MySqlCommand MyCommand67 = new MySqlCommand(Query67, conn);
                    MySqlDataReader MyReader67;
                    MyReader67 = MyCommand67.ExecuteReader();
                    MyReader67.Close();

                    MySqlCommand MyCommand68 = new MySqlCommand(Query68, conn);
                    MySqlDataReader MyReader68;
                    MyReader68 = MyCommand68.ExecuteReader();
                    MyReader68.Close();

                    MySqlCommand MyCommand69 = new MySqlCommand(Query69, conn);
                    MySqlDataReader MyReader69;
                    MyReader69 = MyCommand69.ExecuteReader();
                    MyReader69.Close();

                    MySqlCommand MyCommand70 = new MySqlCommand(Query70, conn);
                    MySqlDataReader MyReader70;
                    MyReader70 = MyCommand70.ExecuteReader();
                    MyReader70.Close();
                }               

                MessageBox.Show("Patient checked Succesfully . . .");

                this.checkpatientAge.Text = "";
                this.checkpatientContactNo.Text = "";
                this.checkpatientDate.Text = "";
                this.comboboxDiseaseType.Text = "";
                this.checkpatientName.Text = "";

                datagridMedicineList.ItemsSource = null;
                datagridMedicineList.Items.Refresh();
                datagridTest.ItemsSource = null;
                datagridTest.Items.Refresh();

                this.Visibility = Visibility.Hidden;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            add_more_medicines();
        }

        public int count=0;

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            { 
                count++;
                if (count > 1) 
                {
                    conn.Close();
                    conn.Open();
                }
                else
                {
                    conn.Open();
                }

                string sql = "DELETE FROM user.medicine WHERE pat_contact_no='" + checkpatientContactNo.Text + "' AND appointment_date='" + checkpatientDate.Text + "' AND product_name='" + med_name + "' AND quantity='" + quantity + "' AND days='" + days + "' AND time_of_day='" + timeOfDay + "';";
                MySqlCommand MyCommand68 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader68;
                MyReader68 = MyCommand68.ExecuteReader();
                MyReader68.Close();
                MessageBox.Show("Medicine Removed!");
                datagridMedicineList.ItemsSource = null;
                datagridMedicineList.Items.Refresh();
                btnRefreshMedList.IsEnabled = true;
                conn.Close();

            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            add_more_test();
        }

        private void radAcPat_Checked(object sender, RoutedEventArgs e)
        {
            btnExit.IsEnabled = true;          
            load_check_list();
            Query = "select distinct disease_type from user.medicine_name;";
        }

        private void radAdPat_Checked(object sender, RoutedEventArgs e)
        {
            btnExit.IsEnabled = true;           
            load_check_list_admitted();
            Query = "select distinct disease_name from user.medicine_name;";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            conn.Open();
            string sql = "SELECT product_name,quantity,days,time_of_day from user.medicine where pat_contact_no='" + checkpatientContactNo.Text.ToString() + "'and appointment_date='" + checkpatientDate.Text.ToString() + "' and doc_id='" + hmmtext.Text + "';";
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(ds);
            datagridMedicineList.ItemsSource = ds.Tables[0].DefaultView;
            btnRefreshMedList.IsEnabled = false;
            conn.Close();
        }

        
    }
}
