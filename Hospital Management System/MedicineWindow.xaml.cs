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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for MedicineWindow.xaml
    /// </summary>
    public partial class MedicineWindow : Window
    {
        public CheckPatientPage p;
        public MedicineWindow(CheckPatientPage p1)
        {
            InitializeComponent();
            p = p1;
            fill_combo_timming();
            this.disease.Text = p1.testingprocess.Text.ToString();
            if (p1.check().Equals("Accepted"))
            {
                QueryMedicine = "select medicine_name from user.medicine_name where disease_type='" + this.disease.Text.ToString() + "';";
            }
            else if (p1.check().Equals("Admitted"))
            {
                QueryMedicine = "select medicine_name from user.medicine_name where disease_name='" + this.disease.Text.ToString() + "';";
            }
            fill_combo_medicine_name();
        }

        public MySqlConnection conn = DBConnect.connectToDb();
        public int fgg = 1;

        
       public string QueryMedicine = "";

        void fill_combo_medicine_name()
        {

            try
            {
                MySqlCommand MyCommand2 = new MySqlCommand(QueryMedicine, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboboxMedicineName.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void fill_combo_timming()
         {

            try
            {
                string Query = "select * from user.timing;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboboxTiming.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string a, b, c;
        public int x, y;

        public void add_medicine()
        {
            try
            {
                string Query = "insert into user.medicine values('" + medwindowContactNumber.Text + "', '" + medwindowDate.Text + "', '" + doc_id.Text + "' , '" + disease.Text + "', '" + comboboxMedicineName.Text + "', '" + quantity.Text + "', '" + Num_of_days.Text + "', '" + comboboxTiming.Text + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Prescription Added . . .");
                MyReader2.Close();
                p.btnExit.IsEnabled = false;
                //MessageBox.Show(x.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            add_medicine();
            p.see_medicine_list();
            p.AddMore.IsEnabled = true;
            p.Remove.IsEnabled = true;
            p.Submit.IsEnabled = true;
            p.btnRefreshMedList.IsEnabled = false;
            p.btnRefreshMedList.IsEnabled = true;
            p.PrescribeMedicine.IsEnabled = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (p.check().Equals("Accepted"))
            {
                QueryMedicine = "select medicine_name from user.medicine_name where disease_type='" + this.disease.Text.ToString() + "' and medicine_name!='" + comboboxMedicineName.SelectedItem + "' ;";
            }
            else if (p.check().Equals("Admitted"))
            {
                QueryMedicine = "select medicine_name from user.medicine_name where disease_name='" + this.disease.Text.ToString() + "' and medicine_name!='" + comboboxMedicineName.SelectedItem + "' ;";
            }
            
            add_medicine();
            comboboxMedicineName.Items.Clear();
            fill_combo_medicine_name();
            Num_of_days.Text = "";
            quantity.Text = "";
        }
    }
}
