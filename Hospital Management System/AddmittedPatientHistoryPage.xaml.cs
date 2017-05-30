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
    public class ShowHistory1
    {
        public string Patient_Name { get; set; }
        public string Contact_No { get; set; }
        public string Age { get; set; }
        public string Ward_Name { get; set; }
        public string Bed_No { get; set; }
    }

    
    /// <summary>
    /// Interaction logic for AddmittedPatientHistoryPage.xaml
    /// </summary>
    public partial class AddmittedPatientHistoryPage : Page
    {
        public AddmittedPatientHistoryPage()
        {
            InitializeComponent();
            show_all();
        }
        public MySqlConnection conn = DBConnect.connectToDb();

        void show_all()
        {
            try
            {
                string sql = "select patient_name,patient_contact_no,patient_age,ward_name,bed_no from user.allocate_patient_bed where bed_status='" + "Occupied" + "' ;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                Dgrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if(txtPhn.Text.Equals(""))
            {
                txtBed.Text = "";
                txtWard.Text = "";
            }
            try
            {
                string sql = "select ward_name,bed_no from user.allocate_patient_bed where bed_status='" + "Occupied" + "' and patient_contact_no='"+txtPhn.Text+"' ;";

                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;

                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    txtWard.Text = MyReader2.GetValue(0).ToString();
                    txtBed.Text = MyReader2.GetValue(1).ToString();
                }
                MyReader2.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message.ToString()); }
        }
    }

     
}
