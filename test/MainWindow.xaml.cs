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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace test
{

    public partial class MainWindow : Window
    {

        public ObservableCollection<Kontrahenci> listaKontrahentow = null;
        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        public void PrzygotujWiazanie()
        {
            listaKontrahentow = new ObservableCollection<Kontrahenci>();

            string path = @"C:\NIE_USUWAC\Kontrahenci.txt";
            StreamReader sr = new StreamReader(path);
            string imie;
            string nazwisko;
            int telefon;
            string miejscowosc;
            string data;
            int ocena;
            string opis;

            while(true)
            {
                imie = sr.ReadLine();
                if(imie == null)
                {
                    break;
                }
                nazwisko = sr.ReadLine();
                telefon = Convert.ToInt32(sr.ReadLine());
                miejscowosc = sr.ReadLine();
                data = sr.ReadLine();
                ocena = Convert.ToInt32(sr.ReadLine());
                opis = sr.ReadLine();

                Kontrahenci nowy = new Kontrahenci(imie, nazwisko, telefon, miejscowosc, data, opis, ocena);

                listaKontrahentow.Add(nowy);

            } //while (imie != null);

            sr.Close(); 


            /*listaKontrahentow.Add(new Kontrahenci("Artur", "Marszałek", 661292962, "Ketrzyn", "20-04-2017", "opiskrotkihjgjfdfkgv", 10));
            listaKontrahentow.Add(new Kontrahenci("Wojciech", "Marszałek", 123456789, "Ketrzyn", "25-04-2017", "opiskrotki32sdfrgsdgreg", 9));
            listaKontrahentow.Add(new Kontrahenci("Karolina", "Tytko", 612398762, "Ketrzyn", "29-04-2017", "opiskrotki123dfgregdfg", 8));
            listaKontrahentow.Add(new Kontrahenci("Dominik", "Marszałek", 987654321, "Ketrzyn", "10-04-2017", "opiskrotki28dgrdg", 7));
            listaKontrahentow.Add(new Kontrahenci("Bogusława", "Marszałek", 987654321, "Ketrzyn", "10-04-2017", "opiskrotki28dgrdg", 9)); */
            lista.ItemsSource = listaKontrahentow;

            

            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lista.ItemsSource);
            widok.SortDescriptions.Add(new SortDescription("nazwisko", ListSortDirection.Ascending)); //sortowamie wg nazwisk
            widok.SortDescriptions.Add(new SortDescription("imie", ListSortDirection.Ascending)); //sortowamie wg imion

            widok.Filter = FiltrUzytkownika; //nazwisko
        }

        private bool FiltrUzytkownika(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text) && String.IsNullOrEmpty(txtFilter2.Text.ToString()) && String.IsNullOrEmpty(txtFilter3.Text))
                return true;
            if (String.IsNullOrEmpty(txtFilter.Text) == false)
             return ((item as Kontrahenci).nazwisko.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) == 0);

            if (String.IsNullOrEmpty(txtFilter2.Text.ToString()) == false)
                return ((item as Kontrahenci).telefon.ToString().IndexOf(txtFilter2.Text.ToString(), StringComparison.OrdinalIgnoreCase) == 0);

            if (String.IsNullOrEmpty(txtFilter3.Text) == false)
            {
                return ((item as Kontrahenci).miejscowosc.IndexOf(txtFilter3.Text, StringComparison.OrdinalIgnoreCase) == 0);
            }

            return false;

        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lista.ItemsSource).Refresh();
        }

        private void txtFilter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lista.ItemsSource).Refresh();
        }

        private void txtFilter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lista.ItemsSource).Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e) // Przycisk OPIS
        {
            try
            {
                MessageBox.Show(((Kontrahenci)lista.SelectedItem).opis);
            }

            catch
            {
                MessageBox.Show("Proszę wybrać Kontrahenta z listy.", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Przycisk DODAJ
        {
            DODAJ_KONTRAHENTA okno = new DODAJ_KONTRAHENTA(this, true);
            okno.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Przycisk USUŃ
        {
            try
            {
                Kontrahenci kotrahent_z_listy = lista.SelectedItem as Kontrahenci;

                MessageBoxResult odpowiedz = MessageBox.Show("Czy wykasować Kontrahenta " + ((Kontrahenci)lista.SelectedItem).imie + " " + ((Kontrahenci)lista.SelectedItem).nazwisko + " ?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (odpowiedz == MessageBoxResult.Yes)
                {
                    listaKontrahentow.Remove(kotrahent_z_listy);
                    string path = @"C:\NIE_USUWAC\Kontrahenci.txt";
                    StreamWriter sw = new StreamWriter(path);

                    foreach (Kontrahenci o in listaKontrahentow)
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
                }
            }

            catch
            {
                MessageBox.Show("Proszę wybrać Kontrahenta z listy.", "UWAGA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public void Dodaj_do_listy(Kontrahenci _nowy)
        {
            listaKontrahentow.Add(_nowy);
            MessageBox.Show("dodano.");
            listaKontrahentow.Add(new Kontrahenci("Dominika", "Marszałek", 987657321, "Ketrzyn", "10-04-2017", "opisksdrotki28", 7));
        }

        private void lista_MouseDoubleClick(object sender, MouseButtonEventArgs e) // EDYCJA
        {
            EDYTUJ_KONTRAHENTA okno = new EDYTUJ_KONTRAHENTA(this);
            okno.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // Przycisk Liczba Kontrahentów
        {
            MessageBox.Show("Aktualna liczba Kontrahentów: " + listaKontrahentow.Count);
        }
    }
}
