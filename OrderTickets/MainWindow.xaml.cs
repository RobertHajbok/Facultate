using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace OrderTickets
{
    public partial class TicketForm
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        private void purchaseTickets_Click(object sender, RoutedEventArgs e)
        {
            var eventBe =
                EventList.GetBindingExpression(ComboBox.TextProperty);
            var customerReferenceBe =
                CustomerReference.GetBindingExpression(TextBox.TextProperty);
            var privilegeLevelBe =
                PrivilegeLevel.GetBindingExpression(ComboBox.TextProperty);
            var numberOfTicketsBe =
                NumberOfTickets.GetBindingExpression(RangeBase.ValueProperty);

            if (eventBe == null) return;
            eventBe.UpdateSource();
            if (customerReferenceBe == null) return;
            customerReferenceBe.UpdateSource();
            if (privilegeLevelBe == null) return;
            privilegeLevelBe.UpdateSource();
            if (numberOfTicketsBe == null) return;
            numberOfTicketsBe.UpdateSource();

            if (eventBe.HasError || customerReferenceBe.HasError ||
                privilegeLevelBe.HasError || numberOfTicketsBe.HasError)
            {
                MessageBox.Show("Please correct errors", "Purchase aborted");
            }
            else
            {
                var ticketOrderBinding =
                    BindingOperations.GetBinding(PrivilegeLevel, ComboBox.TextProperty);
                if (ticketOrderBinding == null) return;
                var ticketOrder = ticketOrderBinding.Source as TicketOrder;
                if (ticketOrder != null) MessageBox.Show(ticketOrder.ToString(), "Purchased");
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
