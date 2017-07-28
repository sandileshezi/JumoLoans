using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using JumoLoans.Entities;

namespace JumoLoans.Services
{
    public static class CsvDeserializer
    {
        private static List<Loan> _allLoans;
        public static List<Loan> AllLoans => _allLoans ?? (_allLoans = GetAllLoans());

        private static List<Loan> GetAllLoans()
        {

            using (var reader = new StreamReader(@"C:\workspace\JumoLoans\JumoLoans\SampleData\Loans.csv"))
            {
                List<Loan> loans = new List<Loan>();
                reader.ReadLine(); //This line discards the header row

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    
                    if (values.Length == 5)
                    {
                        var msisdn = Convert.ToInt64(values[0]);
                        var amount = Convert.ToDecimal(values[4], CultureInfo.InvariantCulture);
                        var month = values[2].Substring(4, 3);

                        loans.Add(new Loan(msisdn, values[1], month, values[3], amount));
                    }
                }
                return loans;
            }
        }
    }
}
