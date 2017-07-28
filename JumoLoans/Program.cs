using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumoLoans.Enums;
using JumoLoans.Services;

namespace JumoLoans
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //only uncomment one method at a time

                //GetAggregate(PropertyName.Network);
                //GetAggregate(PropertyName.Month);
                GetAggregate(PropertyName.Product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void GetAggregate(PropertyName property)
        {
            var loans = CsvDeserializer.AllLoans;
            var service = new LoanService(loans, property);
            var loansAggregate = service.GetLoanAggregate();

            string path = @"C:\workspace\JumoLoans\JumoLoans\SampleData\Output.csv";
            if (!File.Exists(path))
            {
                File.Create(path); //This line create csv file if file doesn't exist. 
            }
          
            var sb = new StringBuilder();
            sb.AppendLine("Tuple, AggregateLoan, LoanCount"); //Create file header
            foreach (var loan in loansAggregate)
            {
                var newRecord = $"{loan.Value},{loan.AggregateAmount},{loan.RowCount}";
                sb.AppendLine(newRecord);
                    
            }
            File.WriteAllText(path, sb.ToString());

            Console.WriteLine("Loan Output file created.");
            Console.ReadLine();
        }
    }
}
