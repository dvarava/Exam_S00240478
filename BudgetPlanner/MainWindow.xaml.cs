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
            DateTime after3MonthDate = DateTime.Now.AddMonths(5);

            BudgetItem b1 = new BudgetItem() { Name = "Grant", Date = DayOfMonth(5), Amount = 300, Reccuring = true, BudgetItemType = ItemType.Income };

            IncomeItems.Add(b1);

            IncomeItems.Sort();
            lbxIncome.ItemsSource = IncomeItems;
        }

        public DateTime DayOfMonth(int day)
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, day);
        }
    }
}
