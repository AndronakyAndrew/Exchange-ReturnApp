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

namespace Exchange_ReturnApp
{

    public partial class MainWindow : Window
    {
        private ExchangeReturnContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new ExchangeReturnContext();
        }

        private void CalculateExchange(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(CostInput.Text, out decimal cost) &&
                decimal.TryParse(AmountPaidInput.Text, out decimal amountPaid))
            {
                var change = amountPaid - cost;
                var smallCoinsCount = CalculateSmallCoins(change);

                ChangeLabel.Content = $"Change: ${change:0.00}";
                SmallCoinsLabel.Content = $"Small Coins: {smallCoinsCount}";

                SaveTransaction(cost, amountPaid, change, smallCoinsCount);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }

        private int CalculateSmallCoins(decimal change)
        {
            return (int)(change * 100);
        }

        private void SaveTransaction(decimal cost, decimal amountPaid, decimal change, int smallCoinsCount)
        {
            var transaction = new Transaction
            {
                Cost = cost,
                AmountPaid = amountPaid,
                Change = change,
                SmallCoinsCount = smallCoinsCount
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();

        }
    }
}
