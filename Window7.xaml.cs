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
using System.Data;
using System.Net.Mail;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\Artur\Desktop\licenta\program\proces\text.txt";
            //string path = @"\\192.168.0.251\Public-Eurial\Service\PV\program\text.txt";

            StreamReader stream = new StreamReader(path);
            string filedata = stream.ReadLine();



            string Personal = personalbox.Text;
            string Client = clientbox.Text;
            string Reprezentantclient = reprezentantclientbox.Text;
            string Data = databox.Text;
            string Intervalorar = intervalorarbox.Text;
            string Nrore = nrorebox.Text;
            //    string Nrcomanda = nrcomandabox.Text;
            string Defectiuni = defectiunibox.Text;
            string Lucrari = lucraribox.Text;
            string Observatii = observatiibox.Text;
         
            string Semnatura = Personal;
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            string m = filedata;



            // template path
           // string tmpPath = @"\\192.168.0.251\Public-Eurial\Service\PV\program\Template.docx";

            // output path
           // string outputName = @"\\192.168.0.251\Public-Eurial\Service\PV\PV " + Personaleurial + "  nr." + m + " " + n + ".pdf";

            // shadow file name
            //string shadowFile = @"\\192.168.0.251\Public-Eurial\Service\PV\program\tem.docx";






            // template path
            string tmpPath = @"C:\Users\Artur\Desktop\licenta\program\proces\Template.docx";

            // output path
            string outputName = @"C:\Users\Artur\Desktop\licenta\PDF\PV " + Personal + "  nr." + m +" " + n + ".pdf";

            // shadow file name
            string shadowFile = @"C:\Users\Artur\Desktop\licenta\program\proces\tem.docx";






            // Create shadow File
            System.IO.File.Copy(tmpPath, shadowFile, true);


            // open word
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(shadowFile);






            object oBookMark = "personaleurialfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Personal;


            // oBookMark = "textfield";
            //doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;


            oBookMark = "clientfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Client;


            oBookMark = "reprezentantclientfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Reprezentantclient;


            oBookMark = "datafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Data;


            oBookMark = "intervalorarfield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Intervalorar;


            oBookMark = "nrorefield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Nrore;

            // oBookMark = "nrcomandafield";
            //doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Nrcomanda;
            oBookMark = "nrcomandafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = filedata;

            oBookMark = "defectiunifield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Defectiuni;


            oBookMark = "lucrarifield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Lucrari;


            oBookMark = "observatiifield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Observatii;

           


            oBookMark = "semnaturafield";
            doc.Bookmarks.get_Item(ref oBookMark).Range.Text = Semnatura;





            doc.ExportAsFixedFormat(outputName, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

            doc.Close();

            System.IO.File.Delete(shadowFile);

            var conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Cerere (nr_angajat,nume_cerere, data) VALUES(@nr_angajat,'proces verbal', @data);", conn);
            cmd.Parameters.AddWithValue("@nr_angajat", this.personalbox.SelectedValue);

            cmd.Parameters.AddWithValue("@data", DateTime.Now);

            cmd.ExecuteNonQuery();
            conn.Close();




            MessageBox.Show("PDF ul a fost creat in" + " " + outputName + "", "Felicitari");

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                mail.From = new MailAddress("artur.ghidora@eurial.com.ro");
                mail.To.Add("ghidoraartur@gmail.com");
              
                //mail.CC.Add("");
                
                mail.Subject = "Proces verbal interventie-" + Client;
                mail.Body = "<b>Buna ziua!</b> <p>Atasat se gaseste procesul verbal pentru clientul " + Client + "</p><b>O zi buna!</b>" + "<p><b>" + Personal + "</b>";
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

            TextWriter tsw = new StreamWriter(@"C:\Users\Artur\Desktop\licenta\program\proces\text.txt");
            //TextWriter tsw = new StreamWriter(@"\\192.168.0.251\Public-Eurial\Service\PV\program\text.txt");

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
