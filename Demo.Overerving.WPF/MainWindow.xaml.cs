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
using Demo.Overerving.LIB.Entiteiten;
using Demo.Overerving.LIB.Services;

namespace Demo.Overerving.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persoon> personen;
        Docenten alledocenten;
        Cursisten allecursisten;
        Opleidingen deopleidingen;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            alledocenten = new Docenten();
            allecursisten = new Cursisten();
            deopleidingen = new Opleidingen();
            VulPersonen();
            MaakLeeg();
        }
        private void VulPersonen()
        {
            personen = new List<Persoon>();

            if (chkCursisten.IsChecked == true)
            {
                personen.AddRange(allecursisten.cursisten);
            }
            if(chkDocenten.IsChecked == true)
            {
                personen.AddRange(alledocenten.docenten);
            }
            personen = personen.OrderBy(p => p.Sorteernaam).ToList();
            lstPersonen.ItemsSource = personen;

        }
        private void ChkCursisten_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            VulPersonen();
        }
        private void ChkDocenten_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            VulPersonen();
        }
        private void ChkCursisten_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            VulPersonen();
        }
        private void ChkDocenten_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IsLoaded) return;
            VulPersonen();
        }
        private void LstPersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaakLeeg();
            if (lstPersonen.SelectedIndex == -1) return;

            Persoon persoon = (Persoon) lstPersonen.SelectedItem;
            lblNaam.Content = persoon.Naam;
            lblVoornaam.Content = persoon.Voornaam;
            if(persoon.Geboortedatum != null)
                lblGeboortedatum.Content = ((DateTime) persoon.Geboortedatum).ToString("dd/MM/yyyy");
            lblGeslacht.Content = persoon.Gender;
            if (persoon is Cursist)
            {
                lblRol.Content = "Cursist";
                Cursist cursist = (Cursist)persoon;
                lblEmailSchool.Content = cursist.EmailSchool;
                OpleidingenCursist(cursist);
            }
            else
            {
                lblRol.Content = "Docent";
                lblEmailSchool.Content = persoon.EmailSchool;
                OpleidingenDocent((Docent)persoon);
            }

        }

        private void OpleidingenCursist(Cursist cursist)
        {
            grpCursist.Visibility = Visibility.Visible;
            grpCursist.Margin = new Thickness(345, 184, 0, 0);
            lstVolgtNiet.Items.Clear();
            lstVolgtWel.Items.Clear();

            foreach (Opleiding cursus in deopleidingen.opleidingen)
            {
                bool gevonden = false;
                foreach (Opleiding tevolgen in cursist.TeVolgenCursussen)
                {
                    if (tevolgen == cursus)
                    {
                        gevonden = true;
                        break;
                    }
                }
                if (gevonden)
                    lstVolgtWel.Items.Add(cursus);
                else
                    lstVolgtNiet.Items.Add(cursus);
            }
        }
        private void OpleidingenDocent(Docent docent)
        {
            grpDocent.Visibility = Visibility.Visible;
            grpDocent.Margin = new Thickness(345, 184, 0, 0);

            lstGeeftWel.Items.Clear();
            lstGeeftNiet.Items.Clear();

            foreach (Opleiding cursus in deopleidingen.opleidingen)
            {
                bool gevonden = false;
                foreach (Opleiding tegeven in docent.Opdrachten)
                {
                    if (tegeven == cursus)
                    {
                        gevonden = true;
                        break;
                    }
                }
                if (gevonden)
                    lstGeeftWel.Items.Add(cursus);
                else
                    lstGeeftNiet.Items.Add(cursus);
            }
        }

        private void BtnCursistToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (lstVolgtNiet.SelectedIndex == -1) return;

            Cursist cursist = (Cursist) lstPersonen.SelectedItem;
            Opleiding opleiding = (Opleiding)lstVolgtNiet.SelectedItem;
            cursist.TeVolgenCursussen.Add(opleiding);
            OpleidingenCursist(cursist);
        }

        private void BtnCursistVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lstVolgtWel.SelectedIndex == -1) return;

            Cursist cursist = (Cursist)lstPersonen.SelectedItem;
            Opleiding opleiding = (Opleiding)lstVolgtWel.SelectedItem;
            cursist.TeVolgenCursussen.Remove(opleiding);
            OpleidingenCursist(cursist);

        }

        private void BtnDocentToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (lstGeeftNiet.SelectedIndex == -1) return;

            Docent docent = (Docent)lstPersonen.SelectedItem;
            Opleiding opleiding = (Opleiding)lstGeeftNiet.SelectedItem;
            docent.Opdrachten.Add(opleiding);
            OpleidingenDocent(docent);
        }

        private void BtnDocentVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lstGeeftWel.SelectedIndex == -1) return;

            Docent docent = (Docent)lstPersonen.SelectedItem;
            Opleiding opleiding = (Opleiding)lstGeeftWel.SelectedItem;
            docent.Opdrachten.Remove(opleiding);
            OpleidingenDocent(docent);

        }

        private void MaakLeeg()
        {
            lblEmailSchool.Content = "-";
            lblGeboortedatum.Content = "-";
            lblGeslacht.Content = "-";
            lblNaam.Content = "-";
            lblRol.Content = "-";
            lblVoornaam.Content = "-";

            grpCursist.Visibility = Visibility.Hidden;
            grpDocent.Visibility = Visibility.Hidden;
        }
    }
}
