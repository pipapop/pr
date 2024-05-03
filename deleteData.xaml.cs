using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace PPPR17
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class deleteData : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public deleteData()
        {
            InitializeComponent();
        }
    
    private void delbtn_click(object sender, RoutedEventArgs e)
    {

        string sql = $"delete from Airplanes where airplane_id='{id_stroki}'";
        AeroportTable = new DataTable();

        //try
        //{
        connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
        adapter = new SqlDataAdapter(command);
        MessageBox.Show("Данные добавлены");
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}
        //finally
        //{

        if (connection != null)
            connection.Close();
        //}
    }
            
    }
}
