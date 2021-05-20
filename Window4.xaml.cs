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

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
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
            SqlCommand abc = new SqlCommand("select nr_angajat from [User] where Username=@usr and Parola=@pwd", scn);
            abc.Parameters.Clear();
            abc.Parameters.AddWithValue("@usr", textbox1.Text);
            abc.Parameters.AddWithValue("@pwd", textbox2.Password);

            scn.Open();
            abc.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(abc);
            da.Fill(md);
            string getValue = abc.ExecuteScalar().ToString();
            int x = Int32.Parse(getValue);


            var select = "SELECT Angajat.nume_angajat as Angajat, FORMAT (Pontaj.data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare, Pontaj.ora_iesire as Iesire,Pontaj.tip as Observatii, CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate' FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id WHERE Pontaj.nr_angajat =" + x + "Order by data DESC";
            var c = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataTable();
            dataAdapter.Fill(ds);

            dataGridView1.ItemsSource = ds.DefaultView;
            //dataGridView1.Show = dataGridView1.RowCount - 1;

            var selecte = "SELECT Angajat.nume_angajat as Angajat,Comanda.nume_comanda as Comanda, Proiect.nume_proiect as Proiect, FORMAT (Pontaj_management.data, 'dd.MM.yyyy ') as Data, Pontaj_management.ora as Ore FROM Pontaj_management inner join Angajat on Pontaj_management.nr_angajat = Angajat.Id left join Comanda on Pontaj_management.nr_comanda = Comanda.Id left join Proiect on Pontaj_management.nr_proiect = Proiect.Id WHERE Pontaj_management.nr_angajat =" + x + "ORDER BY data DESC";
            var ce = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdaptere = new SqlDataAdapter(selecte, ce);

            var commandBuildere = new SqlCommandBuilder(dataAdaptere);
            var dse = new DataTable();
            dataAdaptere.Fill(dse);

            dataGridView2.ItemsSource = dse.DefaultView;
            //dataGridView1.Show = dataGridView1.RowCount - 1;

            var selectt = "SELECT Angajat.nume_angajat as Angajat,Cerere.nume_cerere AS Denumire ,Cerere.stare_cerere AS Stare From Cerere inner join Angajat on Cerere.nr_angajat = Angajat.Id WHERE Cerere.nr_angajat =" + x + "";
            var ca = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapterr = new SqlDataAdapter(selectt, ca);

            var commandBuilderr = new SqlCommandBuilder(dataAdapterr);
            var dsa = new DataTable();
            dataAdapterr.Fill(dsa);

            datagrid2.ItemsSource = dsa.DefaultView;
            //dataGridView1.Show = dataGridView1.RowCount - 1;








            scn.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Pontaj_management. You can modify this code as needed.
            licenta.testTableAdapters.Pontaj_managementTableAdapter testPontaj_managementTableAdapter = new licenta.testTableAdapters.Pontaj_managementTableAdapter();
            testPontaj_managementTableAdapter.Fill(test.Pontaj_management);
            System.Windows.Data.CollectionViewSource pontaj_managementViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pontaj_managementViewSource")));
            pontaj_managementViewSource.View.MoveCurrentToFirst();
            datagrid2.IsReadOnly = true;
            dataGridView1.IsReadOnly = true;
            dataGridView2.IsReadOnly = true;
        }
    }
}
