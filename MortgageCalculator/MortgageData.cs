using System.Collections.Generic;

namespace MortgageCalculator
{
    class MortgageData
    {
        public double Principal { get; set; }
        public double APR { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalInterestPaid { get; set; }
        public double TotalPaid { get; set; }
        public List<Payment> PaymentSchedule { get; set; }
        public int NumberPayments { get; set; }

        public MortgageData()
            : this(0, 0, 0)
        { }

        public MortgageData(double principal, double apr, double monthlyPayment)
        {
            this.Principal = principal;
            this.APR = apr;
            this.MonthlyPayment = monthlyPayment;
        }

        public int CalculateMortgageData(double extraMonthlyPayment = 0)
        {
            double monthlyInterestRate = APR / 12;

            TotalInterestPaid = 0;
            TotalPaid = 0;
            PaymentSchedule = new List<Payment>();
            NumberPayments = 0;

            while (Principal > 0)
            {
                // Calculate the interest on this month
                double interestPayment = monthlyInterestRate * Principal;

                // Now figure out how much principal will actually be paid
                double principalPayment = (MonthlyPayment - interestPayment) + extraMonthlyPayment;

                // Don't go negative
                if (principalPayment > Principal)
                    principalPayment = Principal;

                Principal -= principalPayment;

                // Update all the extra information
                TotalInterestPaid += interestPayment;
                TotalPaid += (interestPayment + principalPayment);
                PaymentSchedule.Add(new Payment(NumberPayments, principalPayment, interestPayment, Principal));
                NumberPayments++;
            }

            return NumberPayments;
        }
    }
}
