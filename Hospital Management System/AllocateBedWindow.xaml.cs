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

namespace Hospital_Management_System
{
    /// <summary>
    /// Interaction logic for AllocateBedWindow.xaml
    /// </summary>
    public partial class AllocateBedWindow : Window
    {
        AdmitPatientPage p;
        public AllocateBedWindow(AdmitPatientPage p1)
        {
            InitializeComponent();

            p = p1;

            //By default, set all fields non-clickable
            this.comboboxChooseWard.IsEnabled = false;
            this.comboboxChooseBed.IsEnabled = false;
            this.submitBed.IsEnabled = false;
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public string name = "";
        public string type = "";
        public string contact;

        public string check()
        { 
            if(radiobtnNormal.IsChecked == true)
            {
                type = "Normal";
            }
            if(radiobtnVIP.IsChecked == true)
            {
                type = "VIP";
            }
            return type;
        }

        private void radiobtnNormal_Checked(object sender, RoutedEventArgs e)
        {
            comboboxChooseBed.Items.Clear();
            comboboxChooseWard.Items.Clear();
            try
            {

                string Query = "select distinct ward_name from user.ward_bed where bed_type='"+"Normal"+"';";                
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while(MyReader2.Read())
                {
                    name = MyReader2.GetString(0);
                    comboboxChooseWard.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch
            {
                
            }
            this.comboboxChooseWard.IsEnabled = true;
        }

        private void radiobtnVIP_Checked(object sender, RoutedEventArgs e)
        {

            comboboxChooseBed.Items.Clear();
            comboboxChooseWard.Items.Clear();
            try
            {
                string Query = "select distinct ward_name from user.ward_bed where bed_type='"+"VIP"+"';";              
                MySqlCommand MyCommand3 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader3;
                MyReader3 = MyCommand3.ExecuteReader();
                while(MyReader3.Read())
                {
                    name = MyReader3.GetString(0);
                    comboboxChooseWard.Items.Add(name);
                }
                MyReader3.Close();
            }
            catch
            {
            }
            this.comboboxChooseWard.IsEnabled = true;
        }

        private void comboboxChooseWard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxChooseBed.Items.Clear();
            try
            {
                string text = comboboxChooseWard.SelectedItem.ToString();
                string Query = "select bed_no from user.ward_bed where ward_name='" + text + "' and bed_status='" + "Free" + "' and bed_type='" + check().ToString() + "';";  
                MySqlCommand MyCommand4 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader4;
                MyReader4 = MyCommand4.ExecuteReader();
                while (MyReader4.Read())
                {
                    name = MyReader4.GetString(0);
                    comboboxChooseBed.Items.Add(name);
                }
                MyReader4.Close();
            }
            catch
            { }
            this.comboboxChooseBed.IsEnabled = true;
            radiobtnNormal.IsEnabled = false;
            radiobtnVIP.IsEnabled = false;
        }

        private void comboboxChooseBed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.submitBed.IsEnabled = true;
        }     

        private void submitBed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                p.textboxWard.Text = this.comboboxChooseWard.SelectedItem.ToString();
                p.textboxBed.Text = this.comboboxChooseBed.SelectedItem.ToString();
                p.textboxBedType.Text = this.check();

                string Query = "update user.bed set pat_contact_no='" + contact + "',bed_status='" + "Occupied" + "' where bed_no='" + comboboxChooseBed.SelectedItem.ToString() + "';";
                MySqlCommand MyCommand4 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader4;
                MyReader4 = MyCommand4.ExecuteReader();
                while (MyReader4.Read())
                {
                    name = MyReader4.GetString(0);
                    comboboxChooseBed.Items.Add(name);
                }
                MyReader4.Close();
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
            }
        }        
    }
}
