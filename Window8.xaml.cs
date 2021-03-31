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
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        public Window8()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* string abc = text1.Text;
            try
            {
                WebClient client = new WebClient();
                Stream s = client.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apiKey=jlJ8DRJ1RJKIPLuOKDK9aQ==&to=+40742435265&content="+abc+""));
                StreamReader reader = new StreamReader(s);
                string result = reader.ReadToEnd();
                MessageBox.Show("Mesaj trimis");
                //result, "Mesaj",MessageBoxButton.OK
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eroare");
                //ex.Message,"eroare",MessageBoxButton.OK
            }
           */
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Artur\Desktop\licenta\program\Cerereconcediu\text.txt";
           
            StreamReader stream = new StreamReader(path);
            string filedata = stream.ReadLine();






            string Numeprenume = numeprenumebox.Text;
            string Functia = functiabox.Text;
            string Zilelibere2 = zilelibere1box.Text;
            string Zilelibere1 = zilelibere2box.Text;
            string Perioada1 = perioada1box.Text;
            string Perioada2 = perioada2box.Text;
            string Inlocuitor = inlocuitorbox.Text;
            string Data = databox.Text;
            string Semnatura = Numeprenume;
            string Semnatura2 = Inlocuitor;

            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            string m = filedata;



            // // template path
            string tmpPath = @"C:\Users\Artur\Desktop\licenta\program\Cerereconcediu\Cerere_concediu.doc";

            // output path
            string outputName = @"C:\Users\Artur\Desktop\licenta\PDF\Cerere concediu  " + Numeprenume + "  nr." + m + " " + n + ".pdf";

            // shadow file name
            string shadowFile = @"C:\Users\Artur\Desktop\licenta\program\tem.doc";






            // Create shadow File
            System.IO.File.Copy(tmpPath, shadowFile, true);


            // open word
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(shadowFile);






            object oBookMark = "numeprenumefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Numeprenume;


            oBookMark = "nrcomandafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;


            // oBookMark = "textfield";
            //doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;


            oBookMark = "functiafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Functia;


            oBookMark = "zilelibere1field";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Zilelibere1;


            oBookMark = "zilelibere2field";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Zilelibere2;


            oBookMark = "perioada1field";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Perioada1;


            oBookMark = "perioada2field";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Perioada2;

            oBookMark = "inlocuitorfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Inlocuitor;


            oBookMark = "datafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Data;


            oBookMark = "semnaturafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Semnatura;

            oBookMark = "semnatura2field";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Semnatura2;




            doc.ExportAsFixedFormat(outputName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

            doc.Close();

            System.IO.File.Delete(shadowFile);
            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Cerere (nr_angajat,nume_cerere, data) VALUES(@nr_angajat,'cerere concediu', @data);", conn);
            cmd.Parameters.AddWithValue("@nr_angajat", this.numeprenumebox.SelectedValue);

            cmd.Parameters.AddWithValue("@data", DateTime.Now);

            cmd.ExecuteNonQuery();
            conn.Close();




            MessageBox.Show("PDF ul a fost creat in" + " " + outputName + "", "Felicitari",MessageBoxButton.OK);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("artur.ghidora@eurial.com.ro");
                mail.To.Add("ghidoraartur@gmail.com");

                //mail.CC.Add("");

                mail.Subject = "Cerere concediu-" + Numeprenume;
                mail.Body = "<b>Buna ziua!</b> <p>Atasat se gaseste cererea de concediu al angajatului " + Numeprenume + "</p><b>O zi buna!</b>";
                mail.IsBodyHtml = true;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(outputName);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("artur.ghidora@eurial.com.ro", "Px3h8DIOAt68S0c3");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail trimis!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            stream.Close();

            TextWriter tsw = new StreamWriter(@"C:\Users\Artur\Desktop\licenta\program\Cerereconcediu\text.txt");
           
            //Writing text to the file.
            string number1 = filedata;

            int result = int.Parse(number1) + 1;
            tsw.WriteLine(result);

            //Close the file.
            tsw.Close();
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
    }
}
