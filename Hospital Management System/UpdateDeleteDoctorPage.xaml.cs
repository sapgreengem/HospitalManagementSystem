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
    /// Interaction logic for UpdateDeleteDoctorPage.xaml
    /// </summary>
    public partial class UpdateDeleteDoctorPage : Page
    {
        public UpdateDeleteDoctorPage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT id,name,age,department,specialist_in,address,counsiling_hour from doctor;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                txtDocId.Text = row["id"].ToString();
            }
            catch { }
        }

        private void btnUpdateName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set name='" + txtDocName.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocName.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateAge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set age='" + txtDocAge.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocAge.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateDept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set department='" + txtDocDept.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocDept.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateSpeciality_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set specialist_in='" + txtDocSpecialist.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocSpecialist.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set address='" + txtDocAddress.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Address Updated Succesfully");
                txtDocAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateCouncilingHour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.doctor set counsiling_hour ='" + txtDocCouncilingHour.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Councilling Hour Changed Succesfully");
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from user.doctor where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Doctor Deleted");
                txtDocId.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}