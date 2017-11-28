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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace test
{
    /// <summary>
    /// Logika interakcji dla klasy DODAJ_KONTRAHENTA.xaml
    /// </summary>

    public partial class DODAJ_KONTRAHENTA : Window
    {
        private bool czyNowyKontraent = false;
        private Kontrahenci nowyKontrahent = null;
        private MainWindow mainWindow = null;
        public DODAJ_KONTRAHENTA()
        {
            InitializeComponent();
        }

        public DODAJ_KONTRAHENTA(MainWindow Main, bool czyNowy = false)
        {
            InitializeComponent();
            mainWindow = Main;
            czyNowyKontraent = czyNowy;
            PrzygotujWizazanie();
        }

        private void PrzygotujWizazanie()
        {
            nowyKontrahent = new Kontrahenci("", "", 0, "", "", "", 0);
            gridKontrahenci.DataContext = nowyKontrahent;
        }
        private void Button_Click(object sender, RoutedEventArgs e) // Przycisk POTWIERDŹ w DODAJ_KONTRAHENTA
        {
            mainWindow.listaKontrahentow.Add(nowyKontrahent);

            string path = @"C:\NIE_USUWAC\Kontrahenci.txt";
            StreamWriter sw = new StreamWriter(path);

            foreach(Kontrahenci o in mainWindow.listaKontrahentow)
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
