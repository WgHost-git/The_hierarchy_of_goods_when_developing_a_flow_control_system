using System;
using System.Collections.Generic;

namespace ManualFourDz2
{
     interface IFlowStatus
    {
        int id { get; set; }

        static string StatusReceived { get; set; }
        static string StatusRealised { get; set; }
        static string StatusWrittenOff { get; set; }
        static string StatusTransferred { get; set; }
    }

    internal class Goods : IFlowStatus
    {
        public int id { get; set; } = 1;
        internal string Article { get; set; }
        internal string Manufacturer { get; set; }
        internal string Country { get; set; }
        internal int PriceBatch { get; set; }
        internal double WeightBatch { get; set; }
        internal int QuantityOfGoods { get; set; }
        internal string ProductTypeBatch { get; set; }
        internal string Status { get; set; }
        private DateTime DateArrivalGoods { get; set; }   
        public DateTime dateRealised = DateTime.Now;
        public DateTime dateWrittenOff = DateTime.Now;
        public DateTime dateTransferred = DateTime.Now;

        public static string StatusReceived = "Получен";
        public static string StatusRealised = "Реализован";
        public static string StatusWrittenOff = "Списано";
        public static string StatusTransferred = "Передано";

        // Возможна реализация добовления от пользователя (необходимы правки в меню)
        //public Goods()
        //{
        //    Console.Write("Введите артикль партии товара: ");
        //    Article = Console.ReadLine();
        //    Console.Write("Введите наименование производителя: ");
        //    Manufacturer = Console.ReadLine();
        //    Console.Write("Введите Страну производителя: ");
        //    Country = Console.ReadLine();
        //    Console.Write("Введите стоимость партии: ");
        //    PriceBatch = Getint();
        //    Console.Write("Введите вес партии: ");
        //    WeightBatch = GetDouble();
        //    Console.Write("Введите кол-во товара в партии: ");
        //    QuantityOfGoods = Getint();
        //    Console.Write("Введите тип продукта: ");
        //    ProductTypeBatch = Console.ReadLine();            
        //    DateArrivalGoods = DateTime.Now;
        //    Flow = "Пришло";
        //    Console.WriteLine();
        //}

        public Goods()
        {
        }

        public Goods(int id, string Article, string Manufacturer, string Country, int PriceBatch,
            double WeightBatch, int QuantityOfGoods, string ProductTypeBatch, string Status)
        {
            this.id = id;
            this.Article = Article;
            this.Manufacturer = Manufacturer;
            this.Country = Country;
            this.PriceBatch = PriceBatch;
            this.WeightBatch = WeightBatch;
            this.QuantityOfGoods = QuantityOfGoods;
            this.ProductTypeBatch = ProductTypeBatch;
            this.Status = Status;
            DateArrivalGoods = DateTime.Now;                     
        }

        internal static double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }
        internal static int Getint()
        {
            return int.Parse(Console.ReadLine());
        }

        internal virtual void HeaderTablePrint()
        {
            Console.Write($"| {"Id",-5} | {"Артикль",-7} | {"Производитель",-12} | {"Страна",-8} | " +
                $"{"Стоимость руб.",-15} | {"Вес тн.",-7} | {"Кол-во в шт",-12} | {"Тип",-10} | {"Дата прибытия",-15} | {"Статус", -11} |");
        }

        internal virtual void Print()
        {          
            Console.Write($"| {id, -5} | {Article,-7} | {Manufacturer,-13} | {Country,-8} | {PriceBatch,-15} " +
                $"| {WeightBatch,-7} | {QuantityOfGoods,-12} | {ProductTypeBatch,-10} | " +
                $"{DateArrivalGoods.ToString("d"),-16}| {Status,-11} |");
        }

        internal virtual void HeaderTablePrintStatusReceived()
        {
            Console.Write($"| {"Id",-5} | {"Артикль",-7} | {"Производитель",-15} | {"Дата прибытия",-15} |\n");
        }        
        internal virtual void HeaderTablePrintStatusRealised()
        {
            Console.Write($"| {"Id",-5} | {"Артикль",-7} | {"Производитель",-15} | {"Дата прибытия",-15} | {"Дата реализации",-15} |\n");
        }
        internal virtual void HeaderTablePrintStatusWrittenOff()
        {
            Console.Write($"| {"Id",-5} | {"Артикль",-7} | {"Производитель",-15} | {"Дата прибытия",-15} | {"Дата реализации",-15} | {"Дата списания",-15} |\n");
        }


        internal virtual void PrintStatusReceived()
        {
            Console.Write($"| {id,-5} | {Article,-7} | {Manufacturer,-15} | {DateArrivalGoods.ToString("d"),-15} |\n");
        }
        internal virtual void PrintStatusRealised()
        {
            Console.Write($"| {id,-5} | {Article,-7} | {Manufacturer,-15} | {DateArrivalGoods.ToString("d"),-15} | {dateRealised.ToString("d"),-15} |\n");
        }
        internal virtual void PrintStatusWrittenOff()
        {
            Console.Write($"| {id,-5} | {Article,-7} | {Manufacturer,-15} | {DateArrivalGoods.ToString("d"),-15} | {dateRealised.ToString("d"),-15} " +
                $"| {dateWrittenOff.ToString("d"),-15} |\n");
        }
    }
}
