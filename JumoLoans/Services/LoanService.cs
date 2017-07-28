using System.Collections.Generic;
using System.Linq;
using JumoLoans.Entities;
using JumoLoans.Enums;
using JumoLoans.Model;

namespace JumoLoans.Services
{
    public class LoanService
    {
        private IList<Loan> Loans { get; }
        private PropertyName Property { get; }

        public LoanService(IList<Loan> loans, PropertyName property)
        {
            Loans = loans;
            Property = property;
        }

        public List<LoanModel> GetLoanAggregate()
        {
            return GetAggregate(Property);
        }

        private List<LoanModel> GetAggregate(PropertyName property)
        {
            var aggregateList = new List<LoanModel>();

            foreach (var loan in Loans)
            {
                if (Property == PropertyName.Network)
                {
                    var aggregateItem = aggregateList.FirstOrDefault(x => x.Value == loan.Network);
                    
                    if(aggregateItem == null)
                        aggregateList.Add(new LoanModel(loan.Network, loan.Amount, 1));
                    else
                    {
                        aggregateItem.CalculateAccumulatedAmount(loan.Amount);
                    }
                    
                }
                else if (Property == PropertyName.Product)
                {
                    var aggregateItem = aggregateList.FirstOrDefault(x => x.Value == loan.Product);

                    if (aggregateItem == null)
                        aggregateList.Add(new LoanModel(loan.Product, loan.Amount, 1));
                    else
                    {
                        aggregateItem.CalculateAccumulatedAmount(loan.Amount);
                    }
                }
                else
                {
                    var aggregateItem = aggregateList.FirstOrDefault(x => x.Value == loan.Date);

                    if (aggregateItem == null)
                        aggregateList.Add(new LoanModel(loan.Date, loan.Amount, 1));
                    else
                    {
                        aggregateItem.CalculateAccumulatedAmount(loan.Amount);
                    }
                }
            }
            return CalculateSum(aggregateList);
        }
        private List<LoanModel> CalculateSum(List<LoanModel> aggregateList)
        {

            foreach (var item in aggregateList)
            {
                item.CalculateAggregateAmount();
            }
            return aggregateList;
        }
    }
}
