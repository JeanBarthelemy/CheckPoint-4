using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace Checkpoint4WPF
{
    /// <summary>
    /// Interaction logic for ArtistsWindow.xaml
    /// </summary>
    public partial class ArtistsWindow : Window
    {
        public List<Troupe> TroupeList = DisplayInformation.GetAllTroupes();

        public ArtistsWindow(MainWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            List<string> troupesName = TroupeList.Select(n => n.Name).ToList();
            TroupeComboBox.ItemsSource = troupesName;
            TroupeComboBox.SelectionChanged += new SelectionChangedEventHandler(TroupeComboBox_SelectionChanged);
        }

        private void TroupeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TroupeComboBox.SelectedItem != null)
            {
                string selectedTroupeName = TroupeComboBox.SelectedItem.ToString();
                Troupe selectedTroupe = TroupeList.FirstOrDefault(n => n.Name == selectedTroupeName);
                List<Artist> artistsOfSelectedTroupe = DisplayInformation.GetArtistsFromTroupe(selectedTroupe);
                ArtistListView.Visibility = Visibility.Visible;
                ArtistListView.ItemsSource = artistsOfSelectedTroupe;
                TroupeNameTxtBlock.Text = selectedTroupe.Name;

            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
