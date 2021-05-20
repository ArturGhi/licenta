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
using System.IO;
using System.Reflection;
using System.Net;
using System.Data.SqlClient;
using System.Net.Mail;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window12.xaml
    /// </summary>
    public partial class Window12 : Window
    {
        public Window12()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Artur\Desktop\licenta\program\Cerereincetarecontract\text.txt";
            
            StreamReader stream = new StreamReader(path);
            string filedata = stream.ReadLine();






            string Numeprenume = numeprenumebox.Text;
            string Functia = functiabox.Text;
            string CNP = cnpbox.Text;
            string Seria = seriabox.Text;
            string Numarcnp = numarcnpbox.Text;
            string Eliberatde = eliberatdebox.Text;
            string Dataeliberare = dataeliberarebox.Text;
            string Localitate = localitatebox.Text;
            string Strada = stradabox.Text;
            string Numar = numarstradabox.Text;
            string Ap = apbox.Text;
            string Judet = judetbox.Text;
            string Numarcontract = numarcontractbox.Text;
            string Datainitiere = datainitierebox.Text;
            string Dataincetare = dataincetarebox.Text;
            string Datadeazi = datadeazibox.Text;
            string Semnatura = Numeprenume;
            //ToString("dd MMMM yyyy", new System.Globalization.CultureInfo("ro-RO"));
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            string m = filedata;




            




            // // template path
            string tmpPath = @"C:\Users\Artur\Desktop\licenta\program\Cerereincetarecontract\Cerere_incetare_contract.docx";

            // output path
            string outputName = @"C:\Users\Artur\Desktop\licenta\PDF\Cerere Incetare contract " + Numeprenume + " nr." + m + " " + n + ".pdf";

            // shadow file name
            string shadowFile = @"C:\Users\Artur\Desktop\licenta\program\Cerereincetarecontract\tem.doc";






            // Create shadow File
            System.IO.File.Copy(tmpPath, shadowFile, true);


            // open word
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(shadowFile);






            object oBookMark = "numeprenumefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Numeprenume;


            // oBookMark = "textfield";
            //doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;


            oBookMark = "functiafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Functia;


            oBookMark = "nrcomandafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;


            oBookMark = "cnpfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = CNP;


            oBookMark = "seriafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Seria;


            oBookMark = "numarcnpfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Numarcnp;


            oBookMark = "eliberatdefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Eliberatde;


            oBookMark = "dataeliberarefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Dataeliberare;


            oBookMark = "localitatefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Localitate;


            oBookMark = "stradafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Strada;


            oBookMark = "numarfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Numar;


            oBookMark = "apfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Ap;


            oBookMark = "judetfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Judet;


            oBookMark = "numarcontractfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Numarcontract;


            oBookMark = "datainitierefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Datainitiere;


            oBookMark = "dataincetarefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Dataincetare;


            oBookMark = "datadeazifield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Datadeazi;


            oBookMark = "semnaturafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Semnatura;






            doc.ExportAsFixedFormat(outputName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

            doc.Close();

            System.IO.File.Delete(shadowFile);
            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Cerere (nr_angajat,nume_cerere, data) VALUES(@nr_angajat,'cerere incetare contract', @data);", conn);
            cmd.Parameters.AddWithValue("@nr_angajat", this.numeprenumebox.SelectedValue);

            cmd.Parameters.AddWithValue("@data", DateTime.Now);

            cmd.ExecuteNonQuery();
            conn.Close();




            MessageBox.Show("PDF ul a fost creat in" + " " + outputName + "", "Felicitari", MessageBoxButton.OK);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("artur.ghidora@eurial.com.ro");
                mail.To.Add("ghidoraartur@gmail.com");

                //mail.CC.Add("");

                mail.Subject = "Cerere incetare contract-" + Numeprenume;
                mail.Body = "<b>Buna ziua!</b> <p>Atasat se gaseste cererea de incetare contract pentru " + Numeprenume + "</p><b>O zi buna!</b>";
                mail.IsBodyHtml = true;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(outputName);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("artur.ghidora@eurial.com.ro", "Fh%TB^9'n?Nv$}_d");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail trimis!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            stream.Close();

            TextWriter tsw = new StreamWriter(@"C:\Users\Artur\Desktop\licenta\program\Cerereincetarecontract\text.txt");
           
            //Writing text to the file.
            string number1 = filedata;

            int result = int.Parse(number1) + 1;
            tsw.WriteLine(result);

            //Close the file.
            tsw.Close();
        }
    }
}
