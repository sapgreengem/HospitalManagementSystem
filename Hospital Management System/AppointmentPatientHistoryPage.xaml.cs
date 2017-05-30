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


    public class ShowHistory
    {
        public string Patient_Name { get; set; }
        public string Contact_No { get; set; }
        public string Age { get; set; }
    }

    public class ShowDetailedHistory
    {
        public string Patient_Name { get; set; }
        public string Contact_No { get; set; }
        public string Age { get; set; }
        public string Visited_Date { get; set; }
    }


    /// <summary>
    /// Interaction logic for AppointmentPatientHistoryPage.xaml
    /// </summary>
    public partial class AppointmentPatientHistoryPage : Page
    {
        public AppointmentPatientHistoryPage()
        {
            InitializeComponent();
        }

        public string a = "";
        public string b = "";
        public string c = "";

        void show_all()
        {
            try
            {
                string sql = "select distinct pat_name,pat_contact_no,pat_age from user.appointment where doc_id='" + textbox.Text.ToString() + "' and appointment_status='" + "Checked" + "';";////                
                DataTable dt = DataAccess.GetDataTable(sql);
                int t = dt.Rows.Count;
                List<ShowHistory> users = new List<ShowHistory>();
                for (int i = 0; i < t; i++)
                {
                    users.Add(new ShowHistory() { Patient_Name = (dt.Rows[i]["pat_name"].ToString()), Contact_No = (dt.Rows[i]["pat_contact_no"].ToString()), Age = (dt.Rows[i]["pat_age"].ToString()) });
                }
                datagrid1.ItemsSource = users;
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            show_all();
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)datagrid1.SelectedItems[0];
                //ShowHistory row = (ShowHistory)datagrid1.SelectedItem;
                a = row["pat_contact_no"].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "select pat_name,pat_contact_no,appointment_date,pat_age from user.appointment where pat_contact_no='" + a + "' and doc_id='" + textbox.Text.ToString() + "';";
                DataTable dt = DataAccess.GetDataTable(sql);
                int t = dt.Rows.Count;
                List<ShowDetailedHistory> users = new List<ShowDetailedHistory>();
                for (int i = 0; i < t; i++)
                {
                    users.Add(new ShowDetailedHistory() { Patient_Name = (dt.Rows[i]["pat_name"].ToString()), Visited_Date = (dt.Rows[i]["appointment_date"].ToString()), Contact_No = (dt.Rows[i]["pat_contact_no"].ToString()), Age = (dt.Rows[i]["pat_age"].ToString()) });

                }
                datagrid2.ItemsSource = users;
            }
            catch (Exception show)
            {
                MessageBox.Show(show.Message.ToString());
            }
        }

        private void datagrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ShowDetailedHistory row = (ShowDetailedHistory)datagrid2.SelectedItem;
            b = row.Contact_No.ToString();
            c = row.Visited_Date.ToString();
           
        }

        private void viewDetails_Click(object sender, RoutedEventArgs e)
        {
            DetailsOfMedicineWindow d1 = new DetailsOfMedicineWindow(this);
            d1.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
