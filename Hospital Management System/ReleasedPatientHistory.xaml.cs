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
    /// Interaction logic for ReleasedPatientHistory.xaml
    /// </summary>
    public partial class ReleasedPatientHistory : Page
    {
        public ReleasedPatientHistory()
        {
            InitializeComponent();
            load_table();
        }
        public MySqlConnection conn = DBConnect.connectToDb();

        void load_table()
        {
            try
            {
                string sql = "select * from user.release_patient;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }
    }
}
