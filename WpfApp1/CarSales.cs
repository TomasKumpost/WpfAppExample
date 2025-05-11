namespace WpfApp1
{
    class CarSales(string name)
    {
        private readonly string name = name;
        private double salesNonDPH = 0;
        private double salesDPH = 0;

        public string GetName()
        {
            return name;
        }

        public string GetSalesNonDPH()
        {
            return salesNonDPH.ToString("N2");
        }

        public string GetSalesDPH()
        {
            return salesDPH.ToString("N2");
        }

        public void AddSale(string DPH, string price)
        {
            double tempPrice = double.Parse(price);
            salesNonDPH += tempPrice;
            salesDPH += tempPrice * (1.0 + (double.Parse(DPH) / 100));
        }
    
    }
}
