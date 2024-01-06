// https://github.com/dvarava/Exam_S00240478

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

namespace BudgetPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BudgetItem> IncomeItems = new List<BudgetItem>();
        List<BudgetItem> ExpenseItems = new List<BudgetItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // On window loaded method
        private void GetData(object sender, RoutedEventArgs e)
        {
            // Initialize objects
            BudgetItem b1 = new BudgetItem() { Name = "Grant", Date = DayOfMonth(5), Amount = 300.00m, Reccuring = true, BudgetItemType = ItemType.Income };
            BudgetItem b2 = new BudgetItem() { Name = "Bonus", Date = DayOfMonth(15), Amount = 300.00m, Reccuring = false, BudgetItemType = ItemType.Income };
            BudgetItem b3 = new BudgetItem() { Name = "Wages", Date = DayOfMonth(25), Amount = 100.00m, Reccuring = true, BudgetItemType = ItemType.Income };

            BudgetItem b4 = new BudgetItem() { Name = "Rent", Date = DayOfMonth(1), Amount = 400.00m, Reccuring = true, BudgetItemType = ItemType.Expense };
            BudgetItem b5 = new BudgetItem() { Name = "Flight", Date = DayOfMonth(5), Amount = 100.00m, Reccuring = false, BudgetItemType = ItemType.Expense };
            BudgetItem b6 = new BudgetItem() { Name = "Netflix", Date = DayOfMonth(15), Amount = 10.00m, Reccuring = true, BudgetItemType = ItemType.Expense };
            BudgetItem b7 = new BudgetItem() { Name = "Spotify", Date = DayOfMonth(20), Amount = 8.00m, Reccuring = true, BudgetItemType = ItemType.Expense };

            // Add objects to a list
            IncomeItems.Add(b1);
            IncomeItems.Add(b2);
            IncomeItems.Add(b3);
            ExpenseItems.Add(b4);
            ExpenseItems.Add(b5);
            ExpenseItems.Add(b6);
            ExpenseItems.Add(b7);

            // Sort the lists
            IncomeItems.Sort();
            ExpenseItems.Sort();

            // Add items to the listboxes
            lbxIncome.ItemsSource = IncomeItems;
            lbxExpenses.ItemsSource = ExpenseItems;

            CalculateTotals();
        }

        // Method to create day of the month
        public DateTime DayOfMonth(int day)
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, day);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BudgetItem newBugetItem = new BudgetItem();
            newBugetItem.Name = tbxName.Text;
            newBugetItem.Date = dpDate.SelectedDate.Value;
            newBugetItem.Amount = decimal.Parse(tbxAmount.Text);

            if (cbReccuring.IsChecked == true)
            {
                newBugetItem.Reccuring = true;
            }
            else
            {
                newBugetItem.Reccuring = false;
            }

            if (rbIncome.IsChecked == true)
            {
                IncomeItems.Add(newBugetItem);
            }
            if (rbExpense.IsChecked == true)
            {
                ExpenseItems.Add(newBugetItem);
            }

            // Update listboxes content
            lbxIncome.ItemsSource = null;
            lbxExpenses.ItemsSource = null;
            lbxIncome.ItemsSource = IncomeItems;
            lbxExpenses.ItemsSource = ExpenseItems;

            CalculateTotals();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            BudgetItem selectedIncomeItem = lbxIncome.SelectedItem as BudgetItem;
            BudgetItem selectedExpenseItem = lbxExpenses.SelectedItem as BudgetItem;

            // Update listboxes content
            if (selectedIncomeItem != null || selectedExpenseItem != null)
            {
                IncomeItems.Remove(selectedIncomeItem);
                ExpenseItems.Remove(selectedExpenseItem);

                lbxIncome.ItemsSource = null;
                lbxIncome.ItemsSource = IncomeItems;
                lbxExpenses.ItemsSource = null;
                lbxExpenses.ItemsSource = ExpenseItems;

                CalculateTotals();
            }
        }

        public void CalculateTotals()
        {
            decimal totalIncome = 0;
            decimal totalExpenses = 0;
            decimal currentBalance = 0;

            foreach(BudgetItem item in IncomeItems)
            {
                totalIncome += item.Amount;
            }

            foreach (BudgetItem item in ExpenseItems)
            {
                totalExpenses += item.Amount;
            }

            currentBalance = totalIncome - totalExpenses;

            tblkTotalIncome.Text = "€" + totalIncome.ToString();
            tblkTotalOutgoings.Text = "€" + totalExpenses.ToString();
            tblkCurrentBalance.Text = "€" + currentBalance.ToString();
        }
    }
}
