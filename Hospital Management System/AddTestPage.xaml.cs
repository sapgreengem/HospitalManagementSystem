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
    /// Interaction logic for AddTestByAdminPage.xaml
    /// </summary>
    public partial class AddTestByAdminPage : Page
    {
        public AddTestByAdminPage()
        {
            InitializeComponent();
            table();
            load_combo_disease_typee();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        public void table()
        {
            try
            {
                string sql = "select * from test_name;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagridViewTestList.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch { }
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
            catch { }
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
            catch { }
        }

        private void btnAddTest_Click(object sender, RoutedEventArgs e)
        {
            if (txtTestName.Text.Equals("") || comboDiseaseType.Text.Equals("") || comboDiseaseName.Text.Equals("") || comboDiseaseName.Text.Equals("") || txtCost.Text.Equals(""))
            {
                MessageBox.Show("Please Fill All Fields");
            }
            else
            {
                try
                {
                    string Query = "insert into user.test_name values('" + txtTestName.Text + "','" + comboDiseaseType.SelectedItem.ToString() + "','" + comboDiseaseName.SelectedItem.ToString() + "','" + txtCost.Text + "');";
                    MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader;
                    MyReader = MyCommand.ExecuteReader();
                    MyReader.Close();
                    MessageBox.Show("Test Added");
                    txtTestName.Text = "";
                    txtCost.Text = "";
                    table();
                    txtCost.Text = "";
                    txtTestName.Text = "";
                    comboDiseaseName.Items.Clear();
                    comboDiseaseType.Items.Clear();
                    load_combo_disease_typee();

                }
                catch { }
            }
        }

        private void comboDiseaseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboDiseaseName.Items.Clear();
            comboDiseaseName.IsEnabled = true;
            load_combo_disease_namee();
        }

        private void comboDiseaseName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCost.IsEnabled = true;
        }

        private void txtTestName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTestName.Text.Length > 5)
            {
                comboDiseaseType.IsEnabled = true;
                comboDiseaseName.IsEnabled = false;
            }
            else
            {
                comboDiseaseType.IsEnabled = false;
                comboDiseaseName.IsEnabled = false;
            }
        }

        private void txtCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAddTest.IsEnabled = true;
            comboDiseaseName.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
