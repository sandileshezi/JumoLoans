using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JumoLoans.Enums;
using NUnit.Framework;
using JumoLoans.Services;

namespace JumoLoans.Tests
{
    [TestFixture]
    public class LoanServiceTest
    {

        [Test]
        public void Get_Aggregate_Loan_By_Network()
        {
            //Arrange
            var loans = CsvDeserializer.AllLoans;
            var property = PropertyName.Network;
            var service = new LoanService(loans, property);

            //Act
            var aggregateLoan = service.GetLoanAggregate();

            //Assert
            Assert.That(aggregateLoan, Is.Not.Null);
        }
    }
}
