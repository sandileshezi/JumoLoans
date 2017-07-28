using System;
using System.Collections.Generic;

namespace JumoLoans.Entities
{
    public class Loan
    {
        public long Msisdn { get; set; }
        public string Network { get; set; }
        public string Date { get; set; }
        public string Product { get; set; }
        public decimal Amount { get; set; }

        public Loan() { }

        public Loan(long msisdn, string network, string date, string product, decimal amount)
        {
            Msisdn = msisdn;
            Network = network;
            Date = date;
            Product = product;
            Amount = amount;
        }
    }
    public class LoansCollection
    {
        public List<Loan> Loans { get; set; }
    }
}
