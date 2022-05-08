using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

using WPF_SQL.Models;


namespace WPF_SQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string V = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database_FirstBlood;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text))
              && string.IsNullOrEmpty(GroupName.Text))
            {
                MessageBox.Show("Please enter in all lines :");
            }
            else
            {
                using (Database_FirstBloodContext dBContext = new Database_FirstBloodContext())
                {
                    Group group = dBContext.Groups.FirstOrDefault(t => t.Title == GroupName.Text);
                    Student student = new Student()
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Group = group,
                        GroupId = group.Id,
                        Dates = DateTime.Now
                    };
                    dBContext.Students.Add(student);
                    //students.Add(student);
                    //Database_FirstBloodContext database_ = new Database_FirstBloodContext() {
                    //    Students = students
                    //};
                    //dBContext.Add(database_);
                    dBContext.SaveChanges();

                    if (student.Id > 0)
                    {
                        //string result = string.Format("Students Id: {0},Students Name: {1},Students ")
                        //MessageBox.Show("Students id is " + student.Id);

                        try
                        {
                            using (SqlConnection con = new SqlConnection())
                            {
                                con.ConnectionString = V;
                                SqlDataAdapter cmd = new SqlDataAdapter();
                                //SqlCommand com = new("SELECT * FROM dbo.Groups WHERE Title=N'" + GroupName.Text + "'",con);
                                con.Open();

                                //int index = (int)com.ExecuteScalar();
                                SqlCommand com = new("SELECT * FROM dbo.Students WHERE FirstName='" + FirstName.Text + "'", con);
                                SqlDataReader rd = com.ExecuteReader();
                                while (rd.Read())
                                {
                                    string res = rd["FirstName"].ToString();
                                    res += " ";
                                    res += rd["LastName"].ToString();
                                    res += " ";
                                    res += rd["Cost"].ToString();
                                    res += " ";
                                    res += rd["Dates"].ToString();
                                    res += " ";
                                    res += rd["GroupId"].ToString();

                                    MessageBox.Show(res);
                                }
                                //string result = com.ExecuteReader().ToString();
                                //MessageBox.Show(result);

                            }
                        }
                        catch (Exception es)
                        {

                            MessageBox.Show(es.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
    }
}
