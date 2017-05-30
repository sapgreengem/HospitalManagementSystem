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
    /// Interaction logic for DispensaryPage.xaml
    /// </summary>
    public partial class DispensaryPage : Page
    {
        public DispensaryPage()
        {
            InitializeComponent();
            datagrid();
        }

        void datagrid()
        {
            try
            {
                string sql = "select product_name,quantity,selling_price,company_name from user.supplier where product_type='Medicine';";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridDispensary.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //datagrid();
            this.Visibility = Visibility.Hidden;         
        }
    }
}