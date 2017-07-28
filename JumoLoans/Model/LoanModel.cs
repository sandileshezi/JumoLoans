using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumoLoans.Enums;

namespace JumoLoans.Model
{
    public class LoanModel

    {
        public string Value { get; }
        public decimal AccumulatedAmount { get; set; }
        public decimal AggregateAmount { get; set; }
        public int RowCount { get; set; }

        public LoanModel()
        {
        }

        public LoanModel(string value, decimal amount, int rowCount)
        {
            Value = value;
            AccumulatedAmount = amount;
            RowCount = rowCount;
        }
        public void CalculateAccumulatedAmount(decimal amount)
        {
            RowCount++;
            AccumulatedAmount = AccumulatedAmount + amount;
        }
        public void CalculateAggregateAmount()
        {
            AggregateAmount = AccumulatedAmount / RowCount;
        }
    }


}
