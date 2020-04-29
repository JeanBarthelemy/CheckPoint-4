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

namespace Checkpoint4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DescriptionTxtBlock.Text = "Founded in 2000, Wild Circus is a company that does its best to entertain audience with a traditional style of circus with clowns," +
                " tamers, magicians and acrobats. The first full show, \"Magic In The Air\", was the beginning of a small and local success in the city of Vancouver for 2 " +
                "years, then the second show \"In The Heart Of A Sad Clown\", was played for 3 years from 2003 to 2006 and gathered a lot of audience so the company began " +
                "to be pretty famous and won many prices. The third full show, \"Over The Rainbow\" (2007-2012), was played for 5 years all over the world thanks to the good" +
                " reviews of the second show. Through the years, Wild Circus made its name worldwide and attracts more and more spectators, the shows keep on getting better." +
                " After the fourth full show, \"Something Different\" (2013-2018), Wild Circus is now touring with their brand new show : \"Flash Of Genius\".";

        }

        private void ShowsBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowsWindow showsWindow = new ShowsWindow(this);
            showsWindow.Owner = this;
            showsWindow.Show();
            showsWindow.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void ArtistsBtn_Click(object sender, RoutedEventArgs e)
        {
            ArtistsWindow artistsWindow = new ArtistsWindow(this);
            artistsWindow.Owner = this;
            artistsWindow.Show();
            artistsWindow.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }
    }
}
