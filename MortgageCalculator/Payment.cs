namespace MortgageCalculator
{
    class Payment
    {
        public int Month { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double RemainingPrincipal { get; set; }

        public Payment(int month, double principal, double interest, double remainingPrincipal)
        {
            this.Month = month;
            this.Principal = principal;
            this.Interest = interest;
            this.RemainingPrincipal = remainingPrincipal;
        }

        public override string ToString()
        {
            return $"{Month} - {Principal.ToString("C")}/{Interest.ToString("C")} - {RemainingPrincipal.ToString("C")}";
        }
    }
}
