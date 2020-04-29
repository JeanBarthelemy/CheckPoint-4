using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Checkpoint4WPF
{
    /// <summary>
    /// Interaction logic for BuyTicketWindow.xaml
    /// </summary>
    public partial class BuyTicketWindow : Window
    {
        public Event SelectedEvent { get; set; }
        public Show SelectedShow { get; set; } = new Show();

        public BuyTicketWindow(ShowsWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            DataContext = owner.EventListView.SelectedItem;
            SelectedEvent = (Event)DataContext;
            SelectedShow = DisplayInformation.GetShowFromEvent(SelectedEvent);
            ShowTitleTxtBlock.Text = SelectedShow.Name;
            DateTxtBlock.Text = SelectedEvent.StartTime.ToString("MM-dd-yyyy");
            TimeTxtBlock.Text = SelectedEvent.StartTime.ToString("HH:mm");
            PriceTxtBlock.Text = SelectedShow.TicketPrice.ToString();


        }

        private void ValidateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (QuantityTxtBox.Text != "0" && QuantityTxtBox.Text != String.Empty && TotalPriceTxtBlock.Text != String.Empty)
            {
                using (var context = new CircusDataContext())
                {
                    Ticket newTicket = new Ticket();
                    newTicket.ShowName = SelectedShow.Name;
                    newTicket.TicketPrice = SelectedShow.TicketPrice;
                    newTicket.StartTime = SelectedEvent.StartTime;
                    newTicket.EndTime = SelectedEvent.EndTime;

                    

                    Order newOrder = new Order();
                    newOrder.Quantity = Convert.ToInt32(QuantityTxtBox.Text);
                    newOrder.OrderPrice = Convert.ToDouble(TotalPriceTxtBlock.Text);
                    newOrder.OrderDate = DateTime.Now;
                    newOrder.Ticket = newTicket;

                    context.Add(newTicket);
                    context.Add(newOrder);
                    context.SaveChanges();
                }

                MessageBox.Show("Your ticket(s) is(are) sent to your mailbox");
                this.Close();
            }
            else
            {
                MessageBox.Show("If you want to buy tickets please insert a valid quantity number (not \"0\") and click OK to get the total price");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            double quantity = Convert.ToDouble(QuantityTxtBox.Text);
            double price = Convert.ToDouble(PriceTxtBlock.Text);
            double totalPrice = quantity * price;
            TotalPriceTxtBlock.Text = totalPrice.ToString();
        }
    }
}
