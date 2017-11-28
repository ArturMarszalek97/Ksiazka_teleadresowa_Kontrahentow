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
using System.IO;

namespace test
{
    /// <summary>
    /// Logika interakcji dla klasy EDYTUJ_KONTRAHENTA.xaml
    /// </summary>
    public partial class EDYTUJ_KONTRAHENTA : Window
    {
        private MainWindow mainWindow = null;
        public EDYTUJ_KONTRAHENTA()
        {
            InitializeComponent();
        }

        public EDYTUJ_KONTRAHENTA(MainWindow MainWin)
        {
            InitializeComponent();
            mainWindow = MainWin;
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            Kontrahenci Kontrahent_z_listy = mainWindow.lista.SelectedItem as Kontrahenci;
            if(Kontrahent_z_listy != null)
            {
                gridEdycja.DataContext = Kontrahent_z_listy;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\NIE_USUWAC\Kontrahenci.txt";
            StreamWriter sw = new StreamWriter(path);

            foreach (Kontrahenci o in mainWindow.listaKontrahentow)
            {
                sw.WriteLine(o.imie);
                sw.WriteLine(o.nazwisko);
                sw.WriteLine(o.telefon);
                sw.WriteLine(o.miejscowosc);
                sw.WriteLine(o.data);
                sw.WriteLine(o.ocena);
                sw.WriteLine(o.opis);
            }

            sw.Close();
            this.Close();
        }
    }
}
