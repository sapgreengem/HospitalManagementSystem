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
    /// Interaction logic for BloodBankPage.xaml
    /// </summary>
    public partial class BloodBankPage : Page
    {
        public BloodBankPage()
        {
            InitializeComponent();
            LoadBloodBank();
            BloodGroup();
        }
        public MySqlConnection conn = DBConnect.connectToDb();
        public string test="";
        void BloodGroup()
        {
            comboBox.Items.Add("A+");
            comboBox.Items.Add("B+");
            comboBox.Items.Add("O+");
            comboBox.Items.Add("AB+");
            comboBox.Items.Add("A-");
            comboBox.Items.Add("B-");
            comboBox.Items.Add("O-");
            comboBox.Items.Add("AB-");
        }

        void LoadBloodBank()
        {
            try
            {
                string sql = "select * from blood_bank;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                DataGrid.ItemsSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            catch (Exception accept)
            {
                MessageBox.Show(accept.Message.ToString());
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                conn.Open();
                string Query1 = "SELECT COUNT(*) from user.blood_bank where group_name='"+comboBox.SelectedItem+"';";

                MySqlCommand MyCommand = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                //while(MyReader.Read())
                //{
                    test = MyReader.Read().ToString();
                    MessageBox.Show(test);
                //}
                MyReader.Close();

                if (test.Equals("False"))
                {
                    string Query = "insert into user.blood_bank values ('"+comboBox.SelectedItem+"','"+textBox.Text+"','"+textBox1.Text+"');";

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Blood Added . . .");

                    conn.Close();
                    MyReader2.Close();
                    textBox.Text = ""; textBox1.Text = "";
                    comboBox.Text = "";
                    LoadBloodBank();
                }
                else if (test.Equals("True"))
                {
                    string v="";
                    int j;
                    string Query01 = "SELECT quantity from user.blood_bank where group_name='"+comboBox.SelectedItem+"';";
                    MySqlCommand MyCommand01 = new MySqlCommand(Query01, conn);
                    MySqlDataReader MyReader01;
                    MyReader01 = MyCommand.ExecuteReader();
                    //v=MyReader01.Read().ToString();
                    while (MyReader01.Read())
                    {
                        v = MyReader01.GetString(0);
                        //j = Int32.Parse(MyReader01.GetString(0));
                        MessageBox.Show(v.ToString());
                    }
                    MyReader01.Close();

                    //int i = Int32.Parse(textBox.Text);
                    //j = j + i;
                    //v = j.ToString();
                    //string Query = "update user.blood_bank set quantity='"+v+"',storage_date='"+textBox1.Text+"' where group_name='"+comboBox.SelectedItem+"';";

                    //MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    //MySqlDataReader MyReader2;

                    //MyReader2 = MyCommand2.ExecuteReader();
                    //MessageBox.Show("Blood Added . . .");

                    //MyReader2.Close();
                    //textBox.Text = ""; textBox1.Text = "";
                    //comboBox.Text = "";
                    //LoadBloodBank();
                }
                
            //}
            //catch (Exception ex)
            //{
             //   MessageBox.Show(ex.Message);
            //}
        }
    }
}