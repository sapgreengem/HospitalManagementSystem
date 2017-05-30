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
    /// <summary>
    /// Interaction logic for AddMedicinePage.xaml
    /// </summary>
    public partial class AddMedicinePage : Page
    {
        public AddMedicinePage()
        {
            InitializeComponent();
            
            load_combo_disease_typee();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        public void load_combo_disease_typee()
        {
            try
            {
                string Query = "select distinct disease_type from user.test_name;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboDiseaseType.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void load_combo_disease_namee()
        {
            try
            {
                string Query = "select distinct disease_name from user.test_name where disease_type='" + comboDiseaseType.SelectedItem.ToString() + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboDiseaseName.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch{}
        }


        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (txtMedicineName.Text.Equals("")|| comboDiseaseType.Text.Equals("") || comboDiseaseName.Text.Equals("") || txtCompanyName.Text.Equals("") || txtContactNo.Text.Equals("") || txtDate.Text.Equals("") || txtQuantity.Text.Equals("") || txtBuyingPrice.Text.Equals("") || txtSellingPrice.Text.Equals(""))
            {
                MessageBox.Show("Please Fill All the fields");
            }
            else
            {
                try
                {
                    string Query = "insert into user.supplier values('" + txtCompanyName.Text + "','" + txtContactNo.Text + "','" + txtMedicineName.Text + "','" + "Medicine" + "','" + txtDate.Text + "','" + txtQuantity.Text + "','" + txtBuyingPrice.Text + "','" + txtSellingPrice.Text + "');";
                    MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    MyReader.Close();

                    string Query1 = "insert into user.medicine_name values('" + txtMedicineName.Text + "','" + comboDiseaseType.SelectedItem + "','" + comboDiseaseName.SelectedItem + "');";
                    MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                    MySqlDataReader MyReader1;
                    MyReader1 = MyCommand1.ExecuteReader();
                    MyReader1.Close();

                    MessageBox.Show("Medicine added");

                    txtMedicineName.Text = "";
                    txtCompanyName.Text = "";
                    txtContactNo.Text = "";
                    txtDate.Text = "";
                    txtQuantity.Text = "";
                    txtBuyingPrice.Text = "";
                    txtSellingPrice.Text = "";
                    btnAddMedicine.IsEnabled = false;
                    comboDiseaseType.Items.Clear();
                    load_combo_disease_typee();

                    txtCompanyName.IsEnabled = false;
                    txtContactNo.IsEnabled = false;
                    txtDate.IsEnabled = false;
                    txtQuantity.IsEnabled = false;
                    txtBuyingPrice.IsEnabled = false;
                    txtSellingPrice.IsEnabled = false;
                    comboDiseaseType.IsEnabled = false;
                    comboDiseaseName.IsEnabled = false;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
        private void comboDiseaseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboDiseaseName.Items.Clear();
            load_combo_disease_namee();
            comboDiseaseName.IsEnabled = true;
        }

        private void txtSellingPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAddMedicine.IsEnabled = true;
        }

        public int result;

        private void txtMedicineName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string Query6 = "SELECT COUNT(*) from user.medicine_name where medicine_name='" + txtMedicineName.Text + "';";
                MySqlCommand MyCommand = new MySqlCommand(Query6, conn);
                result = int.Parse(MyCommand.ExecuteScalar().ToString());
                if (testing().ToString().Equals("False"))
                {
                    MessageBox.Show("Medicine already exists");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());

            }

            comboDiseaseType.IsEnabled = true;


        }
        public bool testing()
        {
            if (result == 0)
                return true; //is empty
            else
                return false;//is not empty
        }

        private void comboDiseaseName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCompanyName.IsEnabled = true;
        }

        private void txtCompanyName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtContactNo.IsEnabled = true;
        }

        private void txtContactNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtContactNo.ToString().Length >= 11)
            {
                txtDate.IsEnabled = true;
            }
            
        }

        private void txtDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtQuantity.IsEnabled = true;
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBuyingPrice.IsEnabled = true;
        }
        
        private void txtBuyingPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSellingPrice.IsEnabled = true;
        }
    }
}
