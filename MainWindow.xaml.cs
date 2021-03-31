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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table User. You can modify this code as needed.
            //   licenta.testTableAdapters.UserTableAdapter testUserTableAdapter = new licenta.testTableAdapters.UserTableAdapter();
            //    testUserTableAdapter.Fill(test.User);
           //  System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
           // userViewSource.View.MoveCurrentToFirst();
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();
            combobox1.SelectedIndex = -1;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur"
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();
            

            if (textboxdata.Text == "" && textboxore.Text == "" && combobox1.Text == "")
            {
                MessageBox.Show(" Inserati datele ");
                return;
            }
            else if (textboxdata.Text.Length <= 9 | textboxdata.Text.Length > 10)
            {
                MessageBox.Show("Inserati data ex. 08.09.2021");
                return;
            }
            else
            {


                if (textboxore.Text == "")
                {
                    MessageBox.Show(" Inserati ora ");
                    return;
                }
                else if (combobox1.Text == "")
                {
                    MessageBox.Show(" Inserati numele ");
                    return;
                }

                else
                {

                    DateTime d;
                    d = DateTime.Parse(textboxdata.Text);
                    var cmd = new SqlCommand("INSERT INTO Pontaj (nr_angajat, data, ora, data_creare, tip) VALUES(@nr_angajat, @data, @ora, @data_creare, @tip);", conn);
                    cmd.Parameters.AddWithValue("@nr_angajat", this.combobox1.SelectedValue);
                    cmd.Parameters.Add("@data", d);
                    cmd.Parameters.Add("@ora", textboxore.Text);
                    cmd.Parameters.AddWithValue("@data_creare", DateTime.Now);
                    cmd.Parameters.AddWithValue("@tip", this.combobox2.Text);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show(" Adaugat ");
            }
        }




        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var conn1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn1.Open();

            if (textboxdata.Text == "" && textboxore.Text == "" && combobox1.Text == "")
            {
                MessageBox.Show(" Inserati datele ");
                return;
            }
            else if (textboxdata.Text.Length <= 9 | textboxdata.Text.Length > 10)
            {
                MessageBox.Show("Inserati data ex. 08.09.2021");
                return;
            }
            else
            {


                if (textboxore.Text == "")
                {
                    MessageBox.Show(" Inserati ora ");
                    return;
                }
                else if (combobox1.Text == "")
                {
                    MessageBox.Show(" Inserati numele ");
                    return;
                }

                else
                {
                    DateTime d;
                    d = DateTime.Parse(textboxdata.Text);
                    SqlCommand exista = new SqlCommand("SELECT COUNT(*) FROM [Pontaj] WHERE [nr_angajat] = @nr_angajat AND [data]=@data", conn1);
                    exista.Parameters.AddWithValue("@nr_angajat", this.combobox1.SelectedValue);
                    exista.Parameters.Add("@data", d);
                    int UserExist = (int)exista.ExecuteScalar();

                    if (UserExist > 0)
                    {

                        //DateTime d;
                        // d = DateTime.Parse(textboxdata.Text);
                        var cmd = new SqlCommand("UPDATE Pontaj SET ora_iesire = @ora_iesire, data_creare_iesire=@data_creare_iesire WHERE data = @data AND nr_angajat =@nr_angajat; ", conn1);
                        cmd.Parameters.AddWithValue("@nr_angajat", this.combobox1.SelectedValue);
                        cmd.Parameters.Add("@data", d);
                        cmd.Parameters.Add("@ora_iesire", textboxore.Text);
                        cmd.Parameters.AddWithValue("@data_creare_iesire", DateTime.Now);
                        cmd.Parameters.AddWithValue("@tip", this.combobox2.Text);
                        cmd.ExecuteNonQuery();
                        conn1.Close();
                        MessageBox.Show(" Adaugat ");
                    }
                    else
                    {
                        MessageBox.Show(" Puneti prima data de intrare ");
                    }
                }

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 mw = new Window1();
            mw.Show();
            //this.Close();
        }

        private void textboxore_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window4 mw = new Window4();
            mw.Show();
            //this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window5 mw = new Window5();
            mw.Show();
            //this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Window6 mw = new Window6();
            mw.Show();
            //this.Close();
        }
    }
}
