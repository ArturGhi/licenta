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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Reflection;
using System.Net.Mail;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window14.xaml
    /// </summary>
    public partial class Window14 : Window
    {
        public Window14()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            licenta.licentaDataSet licentaDataSet = ((licenta.licentaDataSet)(this.FindResource("licentaDataSet")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.licentaDataSetTableAdapters.AngajatTableAdapter licentaDataSetAngajatTableAdapter = new licenta.licentaDataSetTableAdapters.AngajatTableAdapter();
            licentaDataSetAngajatTableAdapter.Fill(licentaDataSet.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();
            d.Columns[4].Visibility = Visibility.Collapsed;
            d.Columns[5].Visibility = Visibility.Collapsed;
            */
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();

            if (comboBox1.Text == "")
            {
                MessageBox.Show(" Tipul ");
                return;
            }
            else if (textbox2.Text == "")
            {
                MessageBox.Show(" Inserati textul ");
                return;
            }

            else
            {


                var cmd = new SqlCommand("INSERT INTO Sugestie (nume, text,tip,data) VALUES(@nume,@sugestie,@tip,@data);", conn);
                cmd.Parameters.Add("@nume", textbox1.Text);
                cmd.Parameters.Add("@sugestie", textbox2.Text);
                cmd.Parameters.AddWithValue("@data", DateTime.Now);
                cmd.Parameters.AddWithValue("@tip", this.comboBox1.Text);
                cmd.ExecuteNonQuery();
            }
            conn.Close();

            try
            {
                string sugestie = comboBox1.Text;
                string nume = textbox1.Text;
                string texxt = textbox2.Text;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("artur.ghidora@eurial.com.ro");
                mail.To.Add("artur.ghidora@eurial.com.ro");

                //mail.CC.Add("artur.ghidora@eurial.com.ro");

                mail.Subject = "Sugestie/Reclamatii";
                mail.Body = "<b>Buna ziua!</b> <p>A fost adaugata o  " + sugestie + " de la " + nume + "</p><b>O zi buna!</b>";
                mail.IsBodyHtml = true;


                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("artur.ghidora@eurial.com.ro", "Fh%TB^9'n?Nv$}_d");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MessageBox.Show(" Adaugat ");
        }
    }
    }

