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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();
            // Load data into the table Comanda. You can modify this code as needed.
            licenta.testTableAdapters.ComandaTableAdapter testComandaTableAdapter = new licenta.testTableAdapters.ComandaTableAdapter();
            testComandaTableAdapter.Fill(test.Comanda);
            System.Windows.Data.CollectionViewSource comandaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("comandaViewSource")));
            comandaViewSource.View.MoveCurrentToFirst();
            // Load data into the table Proiect. You can modify this code as needed.
            licenta.testTableAdapters.ProiectTableAdapter testProiectTableAdapter = new licenta.testTableAdapters.ProiectTableAdapter();
            testProiectTableAdapter.Fill(test.Proiect);
            System.Windows.Data.CollectionViewSource proiectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("proiectViewSource")));
            proiectViewSource.View.MoveCurrentToFirst();


            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();

            if (textboxdata.Text == "" && textboxore.Text == "" && comboBox1.Text == "" && comboBox3.Text == "")
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
                    MessageBox.Show(" Inserati datele ");
                    return;
                }

                else if (comboBox3.Text == "" | comboBox3.Text == "0")
                {

                    DateTime d;
                    d = DateTime.Parse(textboxdata.Text);
                    var cmd = new SqlCommand("INSERT INTO Pontaj_management (nr_angajat, data, ora, nr_comanda,data_creare) VALUES(@nr_angajat, @data, @ora, @nr_comanda,@data_creare);", conn);
                    cmd.Parameters.AddWithValue("@nr_angajat", this.comboBox2.SelectedValue);
                    cmd.Parameters.Add("@data", d);
                    cmd.Parameters.Add("@ora", textboxore.Text);

                    cmd.Parameters.AddWithValue("@nr_comanda", this.comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@data_creare", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                else
                {
                    DateTime d;
                    d = DateTime.ParseExact(textboxdata.Text, "dd.MM.yyyy", null);
                    var cmd = new SqlCommand("INSERT INTO Pontaj_management (nr_angajat, data, ora, nr_proiect,data_creare) VALUES(@nr_angajat, @data, @ora, @nr_proiect,@data_creare);", conn);
                    cmd.Parameters.AddWithValue("@nr_angajat", this.comboBox2.SelectedValue);
                    cmd.Parameters.Add("@data", d);
                    cmd.Parameters.Add("@ora", textboxore.Text);
                    cmd.Parameters.AddWithValue("@nr_proiect", this.comboBox3.SelectedValue);
                    cmd.Parameters.AddWithValue("@data_creare", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                
                MessageBox.Show(" Adaugat ");
                
            }
        }
    }
}
