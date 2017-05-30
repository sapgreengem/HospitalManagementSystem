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
    /// Interaction logic for UpdateDeleteStaffPage.xaml
    /// </summary>
    public partial class UpdateDeleteStaffPage : Page
    {
        public UpdateDeleteStaffPage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT staff_id,name,age,post,address FROM user.staff;";                
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                DataGridStaff.ItemsSource = ds.Tables[0].DefaultView;
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

        private void DataGridStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridStaff.SelectedItems[0];
                txtStaffId.Text = row["staff_id"].ToString();
            }
            catch { }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.staff set name='"+txtStaffName.Text+"' where staff_id='"+txtStaffId.Text+"';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtStaffName.Text = "";
                load();  
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.staff set age='" + txtStaffAge.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Age Updated Succesfully");
                txtStaffAge.Text = "";
                load();  
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.staff set post='" + txtSTaffPost.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Post Updated Succesfully");
                txtSTaffPost.Text = "";
                load();  
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update user.staff set address='" + txtStaffAddress.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Address Updated Succesfully");
                txtStaffAddress.Text = "";
                load();  
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtStaffId.Text = "";
            load();           
        }

        private void btnDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from user.staff where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Staff Deleted");
                load();  
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}