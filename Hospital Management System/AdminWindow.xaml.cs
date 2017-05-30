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

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctorPage objAddDoctor = new AddDoctorPage();
            adminFrame.NavigationService.Navigate(objAddDoctor);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void btnUpdateDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeleteDoctorPage objUpdateDeleteDoctor = new UpdateDeleteDoctorPage();
            adminFrame.NavigationService.Navigate(objUpdateDeleteDoctor);
        }

        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaffPage objAddStaff = new AddStaffPage();
            adminFrame.NavigationService.Navigate(objAddStaff);
        }

        private void btnUpdateDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeleteStaffPage objUpdateDeleteStaff = new UpdateDeleteStaffPage();
            adminFrame.NavigationService.Navigate(objUpdateDeleteStaff);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMedicinePage objAddMedicinePage = new AddMedicinePage();
            adminFrame.NavigationService.Navigate(objAddMedicinePage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddTestByAdminPage p2 = new AddTestByAdminPage();
            adminFrame.NavigationService.Navigate(p2);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ReleasedPatientHistory r = new ReleasedPatientHistory();
            adminFrame.NavigationService.Navigate(r);
            
        }
    }
}