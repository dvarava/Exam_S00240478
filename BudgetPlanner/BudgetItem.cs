﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    public enum ItemType
    {
        Income,
        Expense
    }

    public class BudgetItem : IComparable<BudgetItem>
    {
        // Properties
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ItemType BudgetItemType { get; set; }
        public DateTime Date { get; set; }
        public bool Reccuring { get; set; }

        // Display format
        public override string ToString()
        {
            return $"{Date.Day} : {Name} {Amount} - ({Reccuring})";
        }

        // Sort by day of the month
        public int CompareTo(BudgetItem other)
        {
            if (other == null) return 1;
            return other.Date.CompareTo(this.Date);
        }
    }
}