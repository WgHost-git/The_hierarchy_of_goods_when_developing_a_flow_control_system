using System;

namespace ManualFourDz2
{
    internal class HouseholdChemicals : Goods
    {
        protected int hazardClass;

        public HouseholdChemicals(int id, string Article, string Manufacturer, string Country, int PriceBatch,
            double WeightBatch, int QuantityOfGoods, string ProductTypeBatch, int hazardClass, string Status)
            : base(id, Article, Manufacturer, Country, PriceBatch, WeightBatch, QuantityOfGoods, ProductTypeBatch, Status)
        {           
            this.hazardClass = hazardClass;
        }

        public new void HeaderTablePrint()
        {
            base.HeaderTablePrint();
            Console.Write($" {"Вредность класс",-15} |\n");
        }

        public new void Print()
        {
            base.Print();
            Console.Write($" {hazardClass,-15} |\n");
        }
    }
}
