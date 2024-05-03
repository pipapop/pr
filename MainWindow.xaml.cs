﻿using System;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public MainWindow()
        {
            InitializeComponent();
            //connectionString = 
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Airplanes";
            AeroportTable = new DataTable();
            
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("sp_InsertPhone", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@airplane_id", SqlDbType.Int, 0, "airplane_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@airplane_name", SqlDbType.NVarChar, 100, "airplane_name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@date_of_issue", SqlDbType.Date, 0, "date_of_issue"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@capacity", SqlDbType.Int, 0, "capacity"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@last_tech_service", SqlDbType.Date, 0, "last_tech_service"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@flight_hours", SqlDbType.Int, 0, "flight_hours"));

                connection.Open();
                adapter.Fill(AeroportTable);
                MainDG.ItemsSource = AeroportTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void Add_new_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CRUD(1);
            window.Show();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CRUD(2);
            window.Show();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CRUD(4);
            window.Show();
        }

        private void Update_DG_Click(object sender, RoutedEventArgs e)
        {
            Window window = new CRUD(3);
            window.Show();
        }
    }
}
