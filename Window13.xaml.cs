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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;

namespace licenta
{
    /// <summary>
    /// Interaction logic for Window13.xaml
    /// </summary>
    public partial class Window13 : Window
    {
        public Window13()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            /* licenta.licentaDataSet licentaDataSet = ((licenta.licentaDataSet)(this.FindResource("licentaDataSet")));
             // Load data into the table Angajat. You can modify this code as needed.
             licenta.licentaDataSetTableAdapters.AngajatTableAdapter licentaDataSetAngajatTableAdapter = new licenta.licentaDataSetTableAdapters.AngajatTableAdapter();
             licentaDataSetAngajatTableAdapter.Fill(licentaDataSet.Angajat);
             System.Windows.Data.CollectionViewSource angajatViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource")));
             angajatViewSource.View.MoveCurrentToFirst();
             */
            licenta.test test = ((licenta.test)(this.FindResource("test")));
            // Load data into the table Angajat. You can modify this code as needed.
            licenta.testTableAdapters.AngajatTableAdapter testAngajatTableAdapter = new licenta.testTableAdapters.AngajatTableAdapter();
            testAngajatTableAdapter.Fill(test.Angajat);
            System.Windows.Data.CollectionViewSource angajatViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatViewSource1")));
            angajatViewSource1.View.MoveCurrentToFirst();
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string abc1 = null;
            string abc2 = null;
            string abc3 = null;
            string abc4 = null;
            string abc5 = null;
            string abc6 = null;
            string abc7 = null;
            string abc8 = null;
            string abc9 = null;
            string abc10 = null;
            string data = null;
            int i = 0;
            int j = 0;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id WHERE data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + "Order By data ASC;";

            SqlCommand cmd = new SqlCommand(sql, cnn);


            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            
            abc1 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + ";";


            SqlCommand cnm1 = new SqlCommand(abc1, cnn);
            SqlDataAdapter dscm1 = new SqlDataAdapter(abc1, cnn);
            DataSet d1 = new DataSet();
            dscm1.Fill(d1);

            xlWorkSheet.Cells[1, 18].Font.Bold = true;
            data = d1.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 18] = "TOTAL ORE";
            xlWorkSheet.Cells[2, 18] = data;



            abc2 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = ''";

            SqlCommand cnm2 = new SqlCommand(abc2, cnn);
            SqlDataAdapter dscm2 = new SqlDataAdapter(abc2, cnn);
            DataSet d2 = new DataSet();
            dscm2.Fill(d2);

            xlWorkSheet.Cells[1, 9].Font.Bold = true;
            data = d2.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 9] = "Ore normale";
            xlWorkSheet.Cells[2, 9] = data;

            abc3 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Home Office'";

            SqlCommand cnm3 = new SqlCommand(abc3, cnn);
            SqlDataAdapter dscm3 = new SqlDataAdapter(abc3, cnn);
            DataSet d3 = new DataSet();
            dscm3.Fill(d3);

            xlWorkSheet.Cells[1, 10].Font.Bold = true;
            data = d3.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 10] = "Home Office";
            xlWorkSheet.Cells[2, 10] = data;

            abc4 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Concediu medical'";

            SqlCommand cnm4 = new SqlCommand(abc4, cnn);
            SqlDataAdapter dscm4 = new SqlDataAdapter(abc4, cnn);
            DataSet d4 = new DataSet();
            dscm4.Fill(d4);

            xlWorkSheet.Cells[1, 11].Font.Bold = true;
            data = d4.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 11] = "Concediu Medical";
            xlWorkSheet.Cells[2, 11] = data;

            abc5 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Concediu de odihna'";

            SqlCommand cnm5 = new SqlCommand(abc5, cnn);
            SqlDataAdapter dscm5 = new SqlDataAdapter(abc5, cnn);
            DataSet d5 = new DataSet();
            dscm5.Fill(d5);

            xlWorkSheet.Cells[1, 12].Font.Bold = true;
            data = d5.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 12] = "Concediu de odihna";
            xlWorkSheet.Cells[2, 12] = data;

            abc6 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Delegatie'";

            SqlCommand cnm6 = new SqlCommand(abc6, cnn);
            SqlDataAdapter dscm6 = new SqlDataAdapter(abc6, cnn);
            DataSet d6 = new DataSet();
            dscm6.Fill(d6);

            xlWorkSheet.Cells[1, 13].Font.Bold = true;
            data = d6.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 13] = "Delegatie";
            xlWorkSheet.Cells[2, 13] = data;

            abc7 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Concediu ingrijire a copilului'";

            SqlCommand cnm7 = new SqlCommand(abc7, cnn);
            SqlDataAdapter dscm7 = new SqlDataAdapter(abc7, cnn);
            DataSet d7 = new DataSet();
            dscm7.Fill(d7);

            xlWorkSheet.Cells[1, 14].Font.Bold = true;
            data = d7.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 14] = "Concediu ingrijire a copilului";
            xlWorkSheet.Cells[2, 14] = data;

            abc8 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Concediu fara salariu'";

            SqlCommand cnm8 = new SqlCommand(abc8, cnn);
            SqlDataAdapter dscm8 = new SqlDataAdapter(abc8, cnn);
            DataSet d8 = new DataSet();
            dscm8.Fill(d8);

            xlWorkSheet.Cells[1, 15].Font.Bold = true;
            data = d8.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 15] = "Concediu fara salariu";
            xlWorkSheet.Cells[2, 15] = data;

            abc9 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Concediu evenimente deosebite'";

            SqlCommand cnm9 = new SqlCommand(abc9, cnn);
            SqlDataAdapter dscm9 = new SqlDataAdapter(abc9, cnn);
            DataSet d9 = new DataSet();
            dscm9.Fill(d9);

            xlWorkSheet.Cells[1, 16].Font.Bold = true;
            data = d9.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 16] = "Concediu evenimente deosebite";
            xlWorkSheet.Cells[2, 16] = data;

            abc10 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker5.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker6.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = 'Zi libera legala'";

            SqlCommand cnm10 = new SqlCommand(abc10, cnn);
            SqlDataAdapter dscm10 = new SqlDataAdapter(abc10, cnn);
            DataSet d10 = new DataSet();
            dscm10.Fill(d10);

            xlWorkSheet.Cells[1, 17].Font.Bold = true;
            data = d10.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 17] = "Zi libera legala";
            xlWorkSheet.Cells[2, 17] = data;
            


            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1].Font.Bold = true;
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport " + comboBox1.Text + " din " + dateTimePicker5.Text + " pana " + dateTimePicker6.Text + " " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
           DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string abc1 = null;
            string abc2 = null;
            string abc3 = null;
            string abc4 = null;
            string abc5 = null;
            string abc6 = null;
            string abc7 = null;
            string abc8 = null;
            string abc9 = null;
            string abc10 = null;
            string data = null;
            int i = 0;
            int j = 0;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id WHERE data between '" + dateTimePicker7.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker8.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox2.SelectedValue + "AND Pontaj.tip = '" + comboBox3.Text + "'Order By data ASC;";

            SqlCommand cmd = new SqlCommand(sql, cnn);


            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);






            abc2 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker7.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker8.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Angajat.Id = " + comboBox1.SelectedValue + " and tip = '" + comboBox3.Text + "'";

            SqlCommand cnm2 = new SqlCommand(abc2, cnn);
            SqlDataAdapter dscm2 = new SqlDataAdapter(abc2, cnn);
            DataSet d2 = new DataSet();
            dscm2.Fill(d2);

            xlWorkSheet.Cells[1, 9].Font.Bold = true;
            data = d2.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 9] = comboBox3.Text;
            xlWorkSheet.Cells[2, 9] = data;





            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1].Font.Bold = true;
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport " + comboBox2.Text + " din " + dateTimePicker7.SelectedDate.Value.ToString("MM.dd.yyyy") + " pana " + dateTimePicker8.SelectedDate.Value.ToString("MM.dd.yyyy") + " tip " + comboBox3.Text + " " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string abc1 = null;
            string abc2 = null;
            string abc3 = null;
            string abc4 = null;
            string abc5 = null;
            string abc6 = null;
            string abc7 = null;
            string abc8 = null;
            string abc9 = null;
            string abc10 = null;
            string data = null;
            int i = 0;
            int j = 0;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id WHERE data between '" + dateTimePicker1.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker2.SelectedDate.Value.ToString("MM.dd.yyyy") + "' Order By data ASC;";

            SqlCommand cmd = new SqlCommand(sql, cnn);


            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);





            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1].Font.Bold = true;
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport angajati din " + dateTimePicker1.Text + " pana " + dateTimePicker2.Text + " " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string abc1 = null;
            string abc2 = null;
            string abc3 = null;
            string abc4 = null;
            string abc5 = null;
            string abc6 = null;
            string abc7 = null;
            string abc8 = null;
            string abc9 = null;
            string abc10 = null;
            string data = null;
            int i = 0;
            int j = 0;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat as Angajat, FORMAT (data, 'dd.MM.yyyy ') as Data, Pontaj.ora as Intrare ,Pontaj.ora_iesire as Iesire,CONVERT(varchar(5), DATEADD(minute, DATEDIFF(minute, ora, ora_iesire), 0),114) AS 'Ore lucrate', Pontaj.tip as Observatii FROM Pontaj inner join Angajat on Pontaj.nr_angajat = Angajat.Id WHERE data between '" + dateTimePicker3.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker4.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND Pontaj.tip = '" + comboBox4.Text + "'Order By data ASC;";

            SqlCommand cmd = new SqlCommand(sql, cnn);


            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);




            abc2 = "select SUM(DATEDIFF(hour, ora, ora_iesire)) as 'or' from pontaj  inner join Angajat on Pontaj.nr_angajat = Angajat.Id where data between '" + dateTimePicker3.SelectedDate.Value.ToString("MM.dd.yyyy") + "' AND '" + dateTimePicker4.SelectedDate.Value.ToString("MM.dd.yyyy") + "'and tip = '" + comboBox4.Text + "'";

            SqlCommand cnm2 = new SqlCommand(abc2, cnn);
            SqlDataAdapter dscm2 = new SqlDataAdapter(abc2, cnn);
            DataSet d2 = new DataSet();
            dscm2.Fill(d2);

            xlWorkSheet.Cells[1, 9].Font.Bold = true;
            data = d2.Tables[0].Rows[i].ItemArray[j].ToString();
            xlWorkSheet.Cells[1, 9] = comboBox4.Text;
            xlWorkSheet.Cells[2, 9] = data;




            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                xlWorkSheet.Cells[1, j + 1].Font.Bold = true;
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport angajati din " + dateTimePicker3.Text + " pana " + dateTimePicker4.Text + " tip " + comboBox4.Text + " " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
            DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat, Departament.nume_departament, Proiect.nume_proiect,Proiect.numar_proiect, Pontaj_management.ora, FORMAT (data, 'dd.MM.yyyy ') as data FROM Pontaj_management inner join Angajat on Pontaj_management.nr_angajat = Angajat.Id inner join Proiect on Pontaj_management.nr_proiect = Proiect.Id inner join Departament on Angajat.nr_departament = Departament.Id WHERE Proiect.Id =" + comboBox1.SelectedValue + " ;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            //cmd.Parameters.AddWithValue("@d", textBox2.Text);

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);


            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport proiect " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string n = string.Format("{0:dd-MM-yyyy HH-mm-ss}",
           DateTime.Now);
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=licenta;Persist Security Info=True;User ID=artur;password=artur";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "SELECT Angajat.nume_angajat, Departament.nume_departament, Comanda.numar_comanda, Comanda.nume_comanda,  Pontaj_management.ora, FORMAT (data, 'dd.MM.yyyy ') as data FROM Pontaj_management  inner join Angajat on Pontaj_management.nr_angajat = Angajat.Id inner join Comanda on Pontaj_management.nr_comanda = Comanda.Id inner join Departament on Angajat.nr_departament = Departament.Id WHERE Comanda.Id =" + comboBox6.SelectedValue + " ;";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            //cmd.Parameters.AddWithValue("@d", textBox2.Text);

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);


            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
            {
                data = ds.Tables[0].Columns[j].ColumnName;
                xlWorkSheet.Cells[1, j + 1] = data;
            }

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 2, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs("raport comanda " + n + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();



            MessageBox.Show("Fisier creat in documents");
        }
    }
}
