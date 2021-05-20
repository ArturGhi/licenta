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


namespace licenta
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var select = "SELECT Pontaj.Id as ID,Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,Pontaj.data_creare as [Data creare] ,Pontaj.data_creare_iesire as [Data creare iesire],Pontaj.data_modificare as [Data modificare],CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id";
            var c = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataTable();
            dataAdapter.Fill(ds);
            datagrid2.ItemsSource = ds.DefaultView;
            */
            var selectt = "SELECT Pontaj_management.Id as ID,Angajat.nume_angajat as Angajat, Departament.nume_departament as Departament, Proiect.nume_proiect as Proiect, Proiect.numar_proiect as [Numar proiect],Comanda.nume_comanda as Comanda, Comanda.numar_comanda as [Numar comanda], Pontaj_management.ora as Ora, FORMAT (data, 'dd.MM.yyyy ') as Data FROM Pontaj_management  inner join Angajat on Pontaj_management.nr_angajat = Angajat.Id left join Proiect on Pontaj_management.nr_proiect = Proiect.Id left join Comanda on Pontaj_management.nr_comanda = Comanda.Id inner join Departament on Angajat.nr_departament = Departament.Id";
            var con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapterr = new SqlDataAdapter(selectt, con);
            var commandBuilderr = new SqlCommandBuilder(dataAdapterr);
            var dsa = new DataTable();
            dataAdapterr.Fill(dsa);
            datagrid3.ItemsSource = dsa.DefaultView;


            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();
            // Load data into the table Departament. You can modify this code as needed.
            licenta.testTableAdapters.DepartamentTableAdapter testDepartamentTableAdapter = new licenta.testTableAdapters.DepartamentTableAdapter();
            testDepartamentTableAdapter.Fill(test.Departament);
            System.Windows.Data.CollectionViewSource departamentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departamentViewSource")));
            departamentViewSource.View.MoveCurrentToFirst();
            datagrid.Columns.RemoveAt(2);
            // Load data into the table Pontaj. You can modify this code as needed.
            /*licenta.testTableAdapters.PontajTableAdapter testPontajTableAdapter = new licenta.testTableAdapters.PontajTableAdapter();
            testPontajTableAdapter.Fill(test.Pontaj);
            System.Windows.Data.CollectionViewSource pontajViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pontajViewSource")));
            pontajViewSource.View.MoveCurrentToFirst();
            */


            licenta.licentaDataSet licentaDataSet = ((licenta.licentaDataSet)(this.FindResource("licentaDataSet")));
            // Load data into the table Pontaj. You can modify this code as needed.
            licenta.licentaDataSetTableAdapters.PontajTableAdapter licentaDataSetPontajTableAdapter = new licenta.licentaDataSetTableAdapters.PontajTableAdapter();
            licentaDataSetPontajTableAdapter.Fill(licentaDataSet.Pontaj);
            System.Windows.Data.CollectionViewSource pontajViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pontajViewSource1")));
            pontajViewSource1.View.MoveCurrentToFirst();

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
            // Load data into the table User. You can modify this code as needed.
            licenta.testTableAdapters.UserTableAdapter testUserTableAdapter = new licenta.testTableAdapters.UserTableAdapter();
            testUserTableAdapter.Fill(test.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
            // Load data into the table Cerere. You can modify this code as needed.
            licenta.testTableAdapters.CerereTableAdapter testCerereTableAdapter = new licenta.testTableAdapters.CerereTableAdapter();
            testCerereTableAdapter.Fill(test.Cerere);
            System.Windows.Data.CollectionViewSource cerereViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cerereViewSource")));
            cerereViewSource.View.MoveCurrentToFirst();
            // Load data into the table Pontaj_management. You can modify this code as needed.
            licenta.licentaDataSetTableAdapters.Pontaj_managementTableAdapter licentaDataSetPontaj_managementTableAdapter = new licenta.licentaDataSetTableAdapters.Pontaj_managementTableAdapter();
            licentaDataSetPontaj_managementTableAdapter.Fill(licentaDataSet.Pontaj_management);
            System.Windows.Data.CollectionViewSource pontaj_managementViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pontaj_managementViewSource")));
            pontaj_managementViewSource.View.MoveCurrentToFirst();
            // Load data into the table Pontaj1. You can modify this code as needed.
            /*licenta.licentaDataSetTableAdapters.Pontaj1TableAdapter licentaDataSetPontaj1TableAdapter = new licenta.licentaDataSetTableAdapters.Pontaj1TableAdapter();
            licentaDataSetPontaj1TableAdapter.Fill(licentaDataSet.Pontaj1);
            System.Windows.Data.CollectionViewSource pontaj1ViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pontaj1ViewSource")));
            pontaj1ViewSource.View.MoveCurrentToFirst();
            */
            datagrid1.Columns[4].Visibility = Visibility.Collapsed;
            datagrid1.Columns[5].Visibility = Visibility.Collapsed;
            datagrid1.Columns[6].Visibility = Visibility.Collapsed;
            //datagrid1.Columns[7].Visibility = Visibility.Collapsed;
            datagrid4.Columns[3].Visibility = Visibility.Collapsed;
            datagrid5.Columns[3].Visibility = Visibility.Collapsed;
            datagrid2.Columns[5].Visibility = Visibility.Collapsed;
            this.datagrid1.Columns[1].Header = "Angajat";
            this.datagrid1.Columns[2].Header = "Departament";
            this.datagrid1.Columns[3].Header = "Telefon";
            this.datagrid.Columns[1].Header = "Departament";
            this.datagrid4.Columns[1].Header = "Nr comanda";
            this.datagrid4.Columns[2].Header = "Comanda";
            this.datagrid5.Columns[1].Header = "Nr proiect";
            this.datagrid5.Columns[2].Header = "Proiect";
            this.datagrid7.Columns[1].Header = "Angajat";
            this.datagrid7.Columns[2].Header = "Cerere";
            this.datagrid7.Columns[3].Header = "Stare";
            this.datagrid7.Columns[4].Header = "Data";
            this.grid.Columns[1].Header = "Tip";
            this.grid.Columns[2].Header = "Nume";
            this.grid.Columns[3].Header = "Text";
            this.datagrid8.Columns[1].Header = "Utilizator";
            this.datagrid8.Columns[2].Header = "Angajat";
            this.datagrid8.Columns[3].Header = "Parola";
            this.datagrid8.Columns[4].Header = "Tip";

            this.datagrid2.Columns[2].Header = "Data";
            this.datagrid2.Columns[3].Header = "Ora intrare";
            this.datagrid2.Columns[4].Header = "Creat intrare";
            this.datagrid2.Columns[6].Header = "Tip";
            this.datagrid2.Columns[7].Header = "Ora iesire";
            this.datagrid2.Columns[8].Header = "Creat iesire";
            


            // Load data into the table Sugestie. You can modify this code as needed.
            licenta.licentaDataSetTableAdapters.SugestieTableAdapter licentaDataSetSugestieTableAdapter = new licenta.licentaDataSetTableAdapters.SugestieTableAdapter();
            licentaDataSetSugestieTableAdapter.Fill(licentaDataSet.Sugestie);
            System.Windows.Data.CollectionViewSource sugestieViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sugestieViewSource")));
            sugestieViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            SqlCommand cmd;
            con.Open();
            string s = "insert into Departament values(@nume_departament)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@nume_departament", textbox.Text);


            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();

            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.DepartamentTableAdapter testDepartamentTableAdapter = new licenta.testTableAdapters.DepartamentTableAdapter();
            testDepartamentTableAdapter.Fill(test.Departament);
            System.Windows.Data.CollectionViewSource departamentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departamentViewSource")));
            departamentViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*object item = datagrid.SelectedItem;
            string CourseName = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete the course " + CourseName + "?");
            if (result == MessageBoxResult.OK)
            {
                var itemSource = datagrid.ItemsSource as DataView;

                itemSource.Delete(datagrid.SelectedIndex);

                datagrid.ItemsSource = itemSource;
            }*/
            object item = datagrid.SelectedItem;
            string CourseName = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Departament where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.DepartamentTableAdapter testDepartamentTableAdapter = new licenta.testTableAdapters.DepartamentTableAdapter();
            testDepartamentTableAdapter.Fill(test.Departament);
            System.Windows.Data.CollectionViewSource departamentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departamentViewSource")));
            departamentViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.DepartamentTableAdapter testDepartamentTableAdapter = new licenta.testTableAdapters.DepartamentTableAdapter();
            testDepartamentTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");

        }

        private void datagridview_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            SqlCommand cmd;
            con.Open();
            string s = "INSERT INTO Angajat (nume_angajat,nr_departament,telefon) VALUES(@nume_angajat,@nr_departament,@telefon)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@nume_angajat", textbox1.Text);
            cmd.Parameters.AddWithValue("@nr_departament", this.combobox.SelectedValue);
            cmd.Parameters.AddWithValue("@telefon", textboxtelefon.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            object item = datagrid1.SelectedItem;
            string CourseName = (datagrid1.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Angajat where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
            angajatViewSource.View.MoveCurrentToFirst();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            object item = datagrid2.SelectedItem;
            string CourseName = (datagrid2.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Pontaj where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            var select = "SELECT Pontaj.Id as ID, Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,Pontaj.data_creare as [Data creare] ,Pontaj.data_creare_iesire as [Data creare iesire],Pontaj.data_modificare as [Data modificare],CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id";
            var c = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapter = new SqlDataAdapter(select, c);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataTable();
            dataAdapter.Fill(ds);
            datagrid2.ItemsSource = ds.DefaultView;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            object item = datagrid3.SelectedItem;
            string CourseName = (datagrid3.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Pontaj_management where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            var selectt = "SELECT Pontaj_management.Id as ID,Angajat.nume_angajat as Angajat, Departament.nume_departament as Departament, Proiect.nume_proiect as Proiect, Proiect.numar_proiect as [Numar proiect],Comanda.nume_comanda as Comanda, Comanda.numar_comanda as [Numar comanda], Pontaj_management.ora as Ora, FORMAT (data, 'dd.MM.yyyy ') as Data FROM Pontaj_management  inner join Angajat on Pontaj_management.nr_angajat = Angajat.Id left join Proiect on Pontaj_management.nr_proiect = Proiect.Id left join Comanda on Pontaj_management.nr_comanda = Comanda.Id inner join Departament on Angajat.nr_departament = Departament.Id";
            var con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            var dataAdapterr = new SqlDataAdapter(selectt, con);
            var commandBuilderr = new SqlCommandBuilder(dataAdapterr);
            var dsa = new DataTable();
            dataAdapterr.Fill(dsa);
            datagrid3.ItemsSource = dsa.DefaultView;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

            licenta.licentaDataSet licentaDataSet = ((licenta.licentaDataSet)(this.FindResource("licentaDataSet")));
            licenta.licentaDataSetTableAdapters.PontajTableAdapter licentaDataSetPontajTableAdapter = new licenta.licentaDataSetTableAdapters.PontajTableAdapter();

            licentaDataSetPontajTableAdapter.Update(licentaDataSet);
            MessageBox.Show(" Rand salvat ");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            SqlCommand cmd;
            con.Open();
            string s = "insert into Comanda values(@numar_comanda,@nume_comanda)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@numar_comanda", textboxcomanda2.Text);
            cmd.Parameters.AddWithValue("@nume_comanda", textboxcomanda1.Text);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ComandaTableAdapter testComandaTableAdapter = new licenta.testTableAdapters.ComandaTableAdapter();
            testComandaTableAdapter.Fill(test.Comanda);
            System.Windows.Data.CollectionViewSource comandaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("comandaViewSource")));
            comandaViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            object item = datagrid4.SelectedItem;
            string CourseName = (datagrid4.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Comanda where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ComandaTableAdapter testComandaTableAdapter = new licenta.testTableAdapters.ComandaTableAdapter();
            testComandaTableAdapter.Fill(test.Comanda);
            System.Windows.Data.CollectionViewSource comandaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("comandaViewSource")));
            comandaViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ComandaTableAdapter testComandaTableAdapter = new licenta.testTableAdapters.ComandaTableAdapter();
            testComandaTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            SqlCommand cmd;
            con.Open();
            string s = "insert into Proiect values(@numar_proiect,@nume_proiect)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@numar_proiect", textboxproiect2.Text);
            cmd.Parameters.AddWithValue("@nume_proiect", textboxproiect1.Text);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ProiectTableAdapter testProiectTableAdapter = new licenta.testTableAdapters.ProiectTableAdapter();
            testProiectTableAdapter.Fill(test.Proiect);
            System.Windows.Data.CollectionViewSource proiectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("proiectViewSource")));
            proiectViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            object item = datagrid5.SelectedItem;
            string CourseName = (datagrid5.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Proiect where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ProiectTableAdapter testProiectTableAdapter = new licenta.testTableAdapters.ProiectTableAdapter();
            testProiectTableAdapter.Fill(test.Proiect);
            System.Windows.Data.CollectionViewSource proiectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("proiectViewSource")));
            proiectViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.ProiectTableAdapter testProiectTableAdapter = new licenta.testTableAdapters.ProiectTableAdapter();
            testProiectTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            SqlCommand cmd;
            con.Open();
            string s = "INSERT INTO [User] (Username,Parola,Tip,nr_angajat) VALUES(@Username,@Parola,@Tip,@nr_angajat)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@Username", textboxuser1.Text);
            cmd.Parameters.AddWithValue("@Parola", textboxuser2.Password);
            cmd.Parameters.AddWithValue("@Tip", this.comboboxuser1.Text);
            cmd.Parameters.AddWithValue("@nr_angajat", this.comboboxuser2.SelectedValue);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.UserTableAdapter testUserTableAdapter = new licenta.testTableAdapters.UserTableAdapter();
            testUserTableAdapter.Fill(test.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            object item = datagrid8.SelectedItem;
            string CourseName = (datagrid8.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from [user] where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.UserTableAdapter testUserTableAdapter = new licenta.testTableAdapters.UserTableAdapter();
            testUserTableAdapter.Fill(test.User);
            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            userViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.UserTableAdapter testUserTableAdapter = new licenta.testTableAdapters.UserTableAdapter();
            testUserTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            object item = datagrid7.SelectedItem;
            string CourseName = (datagrid7.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Cerere where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            cn.Close();
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.CerereTableAdapter testCerereTableAdapter = new licenta.testTableAdapters.CerereTableAdapter();
            testCerereTableAdapter.Fill(test.Cerere);
            System.Windows.Data.CollectionViewSource cerereViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cerereViewSource")));
            cerereViewSource.View.MoveCurrentToFirst();

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {

            object item = datagrid7.SelectedItem;
            string CourseName = (datagrid7.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur");
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select nr_angajat from Cerere where Id = @Id", cn);
            cmd.Parameters.AddWithValue("Id", CourseName);
            cmd.ExecuteNonQuery();
            string getValu = cmd.ExecuteScalar().ToString();
            int z = Int32.Parse(getValu);
            cn.Close();

            cn.Open();
            SqlCommand cmda = new SqlCommand("Select telefon from Angajat where Id = " + z + "", cn);

            cmd.ExecuteNonQuery();

            string getValue = cmda.ExecuteScalar().ToString();

            cn.Close();
            object itemm = datagrid7.SelectedItem;
            string CourseNamee = (datagrid7.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            string CourseNameee = (datagrid7.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            try
            {
                WebClient client = new WebClient();
                Stream s = client.OpenRead(string.Format("https://platform.clickatell.com/messages/http/send?apiKey=jlJ8DRJ1RJKIPLuOKDK9aQ==&to=" + getValue + "&content=Starea+cererii+" + CourseNameee + "+este+" + CourseNamee + " "));
                StreamReader reader = new StreamReader(s);
                string result = reader.ReadToEnd();
                MessageBox.Show("Mesaj trimis");
                //result, "Mesaj",MessageBoxButton.OK
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare sms");
                //ex.Message,"eroare",MessageBoxButton.OK
            }

            licenta.test test = ((licenta.test)(this.FindResource("test")));
            licenta.testTableAdapters.CerereTableAdapter testCerereTableAdapter = new licenta.testTableAdapters.CerereTableAdapter();
            testCerereTableAdapter.Update(test);
            MessageBox.Show(" Rand salvat ");
        }
    

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            licenta.licentaDataSet licentaDataSet = ((licenta.licentaDataSet)(this.FindResource("licentaDataSet")));
            licenta.licentaDataSetTableAdapters.Pontaj_managementTableAdapter licentaDataSetPontaj_managementTableAdapter = new licenta.licentaDataSetTableAdapters.Pontaj_managementTableAdapter();

            licentaDataSetPontaj_managementTableAdapter.Update(licentaDataSet.Pontaj_management);
            MessageBox.Show(" Rand salvat ");
            
           
        }

        private void datagrid7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datagrid7_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void datagrid6_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void datagrid6_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            {
                
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gt = (DataGrid)sender;
            DataRowView row = gt.SelectedItem as DataRowView;
            if (row != null)
            {
                textboxsugestie.Text = row[3].ToString();
            }
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
