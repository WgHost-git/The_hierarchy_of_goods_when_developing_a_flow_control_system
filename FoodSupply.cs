using System;

namespace ManualFourDz2
{
    internal class FoodSupply : Goods
    {
        protected int Calorific;

        public FoodSupply(int id, string Article, string Manufacturer, string Country, int PriceBatch,
            double WeightBatch, int QuantityOfGoods, string ProductTypeBatch, int Calorific, string Status)
            : base(id, Article, Manufacturer, Country, PriceBatch, WeightBatch, QuantityOfGoods, ProductTypeBatch, Status)
        {           
            this.Calorific = Calorific;
        }

        public new void HeaderTablePrint()
        {
            base.HeaderTablePrint();
            Console.Write($" {"Пищевая ценность в 100г",-20} |\n");
        }

        public new void Print()
        {
            base.Print();
            Console.Write($" {Calorific,-23} |\n");
        }
    }
}
