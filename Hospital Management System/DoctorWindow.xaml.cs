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

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void btnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateDoctorPage objUpdateDoctor = new UpdateDoctorPage();
            objUpdateDoctor.docid.Text = loginAsDoctor.Text.ToString();
            objUpdateDoctor.loadDoctor();
            doctorFrame.NavigationService.Navigate(objUpdateDoctor);
        }

        private void btnViewRequests_Click(object sender, RoutedEventArgs e)
        {          
            ViewConsultationRequestPage objViewConsultationRequest = new ViewConsultationRequestPage();
            objViewConsultationRequest.ulala.Text = loginAsDoctor.Text;
            try
            {
                string sql1 = "select pat_name,pat_age,pat_address,pat_contact_no,appointment_date,appointment_status from user.appointment where doc_id='" + loginAsDoctor.Text + "' and appointment_status='"+"pending"+"';";
                DataSet ds1 = new DataSet();
                MySqlDataAdapter da1 = new MySqlDataAdapter(sql1, conn);
                da1.Fill(ds1);
                objViewConsultationRequest.datagridAllRequest.ItemsSource = ds1.Tables[0].DefaultView;
                //conn.Close();

                ///For Accepted Table
                string sql2 = "select pat_name,pat_age,pat_address,pat_contact_no,appointment_date,appointment_status from user.appointment where doc_id='" + loginAsDoctor.Text + "' and appointment_status='"+"Accepted"+"';";
                DataSet ds2 = new DataSet();
                MySqlDataAdapter da2 = new MySqlDataAdapter(sql2, conn);
                da2.Fill(ds2);
                objViewConsultationRequest.datagridAccepted.ItemsSource = ds2.Tables[0].DefaultView;
                //conn.Close();
            }
            catch (Exception show)
            {
                MessageBox.Show(show.Message.ToString());
            }
            doctorFrame.NavigationService.Navigate(objViewConsultationRequest);         
        }

        private void btnCheckPatient_Click(object sender, RoutedEventArgs e)
        {
            CheckPatientPage objCheckPatient = new CheckPatientPage();
            objCheckPatient.hmmtext.Text = loginAsDoctor.Text.ToString();
            doctorFrame.NavigationService.Navigate(objCheckPatient);
            objCheckPatient.check_doctor_dept();
        }

        private void btnPatientRecord_Click(object sender, RoutedEventArgs e)
        {
            AppointmentPatientHistoryPage objAppointmentPatientHistoryPage = new AppointmentPatientHistoryPage();
            objAppointmentPatientHistoryPage.textbox.Text = this.loginAsDoctor.Text;

            try
            {
                string sql1 = "select distinct pat_name,pat_contact_no,pat_age from user.appointment where doc_id='" + loginAsDoctor.Text.ToString() + "' and appointment_status='" + "Checked" + "';";//
                /////ekhane disease ta ante hobe
                DataSet ds1 = new DataSet();
                MySqlDataAdapter da1 = new MySqlDataAdapter(sql1, conn);
                da1.Fill(ds1);
                objAppointmentPatientHistoryPage.datagrid1.ItemsSource = ds1.Tables[0].DefaultView;
            }
            catch (Exception show)
            {
                MessageBox.Show(show.Message.ToString());
            }


            doctorFrame.NavigationService.Navigate(objAppointmentPatientHistoryPage);
        }
    }
}
