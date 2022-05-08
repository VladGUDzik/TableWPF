using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private string ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Database_FirstBlood; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False";

        DataTable studentsTablet;
        DataBase dataBase;
        SqlDataAdapter adapter;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (studentsGrid.SelectedItems != null) {
                for (int i = 0; i < studentsGrid.SelectedItems.Count; i++)
                {
                    DataRowView data = studentsGrid.SelectedItems[i] as DataRowView;
                    if (data != null) {
                        DataRow dataRow = (DataRow)data.Row;
                        dataRow.Delete();
                    }

                }
            }
           
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            dataBase = new DataBase();
            studentsTablet = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * From dbo.Students", conn);
                adapter = new SqlDataAdapter(cmd);

                adapter.InsertCommand = new SqlCommand("sp_Students", conn);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Parameters.Add(new SqlParameter("@firstname", SqlDbType.NVarChar, 50, "Firstname"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.NVarChar, 50, "Lastname"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@cost", SqlDbType.Money, 0, "Cost"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@groupId", SqlDbType.Int, 0, "GroupId"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@dates", SqlDbType.Date, 0, "Dates"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                conn.Open();

                adapter.Fill(studentsTablet);
                studentsGrid.ItemsSource = studentsTablet.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) {
                    conn.Close();
                }
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(studentsTablet);
        }
    }

    public struct Students
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int cost { get; set; }
        public DateTime dates { get; set; }
        public int groupId { get; set; }
        public string title { get; set; }

    }
    public class DataBase
    {
        public void InsertStd(SqlConnection conn, Students std)
        {
            try
            {
                string stringInsert = @"INSERT INTO dbo.Students(FirstName,LastName,Cost,Dates,GroupId) VALUES 
                 (@FirstName,@LastName,@Cost,@Dates,@GroupId)";
                var cmd = new SqlCommand(stringInsert, conn);

                cmd.Parameters.Add(new SqlParameter("@FirstName", std.firstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", std.lastName));
                cmd.Parameters.Add(new SqlParameter("@Cost", std.cost));
                cmd.Parameters.Add(new SqlParameter("@Dates", std.dates));
                cmd.Parameters.Add(new SqlParameter("@GroupId", std.groupId));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Update(SqlConnection conn, Students std)
        {

            try
            {
                string UpdateString = @"UPDATE dbo.Students SET FirstName ='" + std.firstName + "' WHERE Id = @id ";

                var cmd = new SqlCommand(UpdateString, conn);

                cmd.Parameters.Add(new SqlParameter(@"Id", 2002));
                cmd.Parameters.Add(new SqlParameter("@FirstName", std.firstName));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void Delete(SqlConnection conn, Students std)
        {

            try
            {
                string deleteString = @"DELETE FROM dbo.TakeCash WHERE StudentId = @StudentId; DELETE FROM dbo.Students WHERE Id = @Id";
                var cmd = new SqlCommand(deleteString, conn);

                cmd.Parameters.Add(new SqlParameter("@Id", std.id));
                cmd.Parameters.Add(new SqlParameter("@StudentId", std.id));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void InsertGrop(SqlConnection conn, Students std)
        {
            try
            {
                string stringInsert = @"INSERT INTO dbo.Groups(Title) VALUES 
                 (@Title)";
                var cmd = new SqlCommand(stringInsert, conn);

                cmd.Parameters.Add(new SqlParameter("@Title", std.title));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }

}

