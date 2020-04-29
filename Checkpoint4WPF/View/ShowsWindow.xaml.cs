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
    public partial class ShowsWindow : Window
    {
        List<Show> ShowsList = DisplayInformation.DisplayAllShows();

        public ShowsWindow(MainWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            List<string> showsName = ShowsList.Select(n => n.Name).ToList();
            ShowsComboBox.ItemsSource = showsName;
            ShowsComboBox.SelectionChanged += new SelectionChangedEventHandler(ShowsComboBox_SelectionChanged);
        }

        private void ShowsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowsComboBox.SelectedItem != null)
            {
                TroupeLabel.Visibility = Visibility.Visible;
                DescriptionLabel.Visibility = Visibility.Visible;
                PriceLabel.Visibility = Visibility.Visible;
                DollarLabel.Visibility = Visibility.Visible;
                NextLabel.Visibility = Visibility.Visible;
                EventListView.Visibility = Visibility.Visible;
    
                string selectedShowName = ShowsComboBox.SelectedItem.ToString();
                Show selectedShow = ShowsList.FirstOrDefault(n => n.Name == selectedShowName);
                ShowTitleTxtBlock.Text = selectedShow.Name;
                Troupe troupeOfSelectedShow = DisplayInformation.GetTroupeFromShow(selectedShow);
                TroupeNameTxtBlock.Text = troupeOfSelectedShow.Name;
                DescriptionTxtBlock.Text = selectedShow.Description;
                PriceTxtBlock.Text = selectedShow.TicketPrice.ToString();
                List<Event> eventsFromSelectedShow = DisplayInformation.GetEventListFromShow(selectedShow);
                EventListView.ItemsSource = eventsFromSelectedShow;
                
            }
        }

        private void BuyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            if(EventListView.SelectedItem != null)
            {
                BuyTicketWindow buyTicketWindow = new BuyTicketWindow(this);
                buyTicketWindow.Show();
                buyTicketWindow.Closed += (s, eventarg) =>
                {
                    this.Activate();
                };
            }
            else
            {
                MessageBox.Show("You must select the line of the representation before clicking on \"Buy a ticket\"");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EventListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int lala;
        }
    }
}
