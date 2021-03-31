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
using System.Data.SqlClient;
using System.Data;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable md = new DataTable();
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            SqlCommand scmd = new SqlCommand("select count (*) as cnt from [User] where Username=@usr and Parola=@pwd", scn);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", textbox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textbox2.Password);
            scn.Open();

            string getValu = scmd.ExecuteScalar().ToString();
            int z = Int32.Parse(getValu);
            if (z == 0)
            {
                MessageBox.Show("Nu sunt corecte");
            }
            else
            {


                SqlCommand abc = new SqlCommand("select Tip from [User] where Username=@usr and Parola=@pwd", scn);
                abc.Parameters.Clear();
                abc.Parameters.AddWithValue("@usr", textbox1.Text);
                abc.Parameters.AddWithValue("@pwd", textbox2.Password);


                abc.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(abc);
                da.Fill(md);
                string getValue = abc.ExecuteScalar().ToString();
                int x = Int32.Parse(getValue);
                if (x == 1)
                {

                    Window2 mw = new Window2();
                    mw.Show();
                    this.Close();
                }

                else if (x == 0)
                {
                    Window3 mw = new Window3();
                    mw.Show();
                    this.Close();
                }
                scn.Close();

            }

        }
    }
}
