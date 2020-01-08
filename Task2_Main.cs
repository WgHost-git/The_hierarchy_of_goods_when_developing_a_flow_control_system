/*
         Разработать архитектуру классов иерархии товаров при разработке системы управления потоками товаров для 
        дистрибьюторской компании. Прописать члены классов . Создать диаграммы взаимоотношений классов.
        Должны быть предусмотрены разные типы товаров, в том числе:
                                                                    • бытовая химия;
                                                                    • продукты питания.
        Предусмотреть классы управления потоком товаров (пришло, реализовано, списано, передано).
 */

using System;
using System.Collections.Generic;

namespace ManualFourDz2
{
    class Task2_Main
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(170, 40);

            int numberMenu;
            int idTemp = 1;
            int idCount = 0;
            bool yesNo = true;
            var goods = new List<Goods>();
            var householdChemicals = new List<HouseholdChemicals>();
            var foodSupply = new List<FoodSupply>();

            householdChemicals.Add(new HouseholdChemicals(idTemp, "000001", "Comit", "Russia", 10000, 1, 5000, "Чистящие", 1, Goods.StatusReceived));
            idTemp++;
            householdChemicals.Add(new HouseholdChemicals(idTemp, "000002", "Sarma", "Sweden", 50000, 5, 10000, "Моющие", 2, Goods.StatusRealised));
            idTemp++;
            householdChemicals.Add(new HouseholdChemicals(idTemp, "000003", "Comit", "Russia", 30000, 3, 15000, "Чистящие", 1, Goods.StatusWrittenOff));
            idTemp++;
            householdChemicals.Add(new HouseholdChemicals(idTemp, "000004", "Sarma", "Sweden", 35000, 3.5, 7000, "Моющие", 2, Goods.StatusTransferred));
            idTemp++;
            foodSupply.Add(new FoodSupply(idTemp, "002001", "Землячки", "Russia", 15000, 2, 3000, "Картошка", 70, Goods.StatusReceived));
            idTemp++;
            foodSupply.Add(new FoodSupply(idTemp, "002000", "Тория", "Russia", 35000, 4, 10000, "Капуста", 30, Goods.StatusTransferred));
            idTemp++;

            goods.AddRange(householdChemicals);
            goods.AddRange(foodSupply);

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\tКомпания Дистрибьютер");
                Console.WriteLine();
                Console.WriteLine("\t1) Вывод полного списка партий товаров на данный момент;\n" +
                    "\t2) Вывод списка по категориям с доп. параметрами\n" +
                    "\t3) Вывод переданных партий и отправка на реализацию;\n" +
                    "\t4) Вывод реализованных партий и отправка на списание;\n" +
                    "\t5) Вывод cписанных партий и передача;\n" +
                    "\t6) Выход.\n");
                Console.Write($"Введите номер меню: ");

                if (int.TryParse(Console.ReadLine(), out numberMenu))
                {               
                    if (numberMenu > 0 && numberMenu < 7)
                    {
                        if (numberMenu == 1)
                        {
                            // Вывод всех партий товара
                            Console.WriteLine();
                            goods[0].HeaderTablePrint();
                            Console.WriteLine();
                            Console.WriteLine(new string('-', 134));
                            for (int i = 0; i < goods.Count; i++)
                            {
                                goods[i].Print();
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку для возврата в меню.");
                            Console.ReadLine();
                            continue;
                        }
                        if (numberMenu == 2)
                        {
                            // Вывод таблиц партий по категориям
                            int numMenu2;

                            Console.WriteLine();
                            Console.WriteLine("Партии по категориям:");
                            Console.WriteLine("\t1) Бытовая химия.");
                            Console.WriteLine("\t2) Продукты питания.");
                            Console.WriteLine();
                            Console.Write("Введите номер категории для отображения: ");

                            if (int.TryParse(Console.ReadLine(), out numMenu2))
                            {
                                if (numberMenu > 0 && numberMenu < 3)
                                {
                                    if (numMenu2 == 1)
                                    {
                                        Console.WriteLine();
                                        householdChemicals[0].HeaderTablePrint();
                                        Console.WriteLine(new string('-', 154));
                                        for (int i = 0; i < householdChemicals.Count; i++)
                                        {
                                            householdChemicals[i].Print();
                                        }
                                    }
                                    else if (numMenu2 == 2)
                                    {
                                        Console.WriteLine();
                                        foodSupply[0].HeaderTablePrint();
                                        Console.WriteLine(new string('-', 160));
                                        for (int i = 0; i < foodSupply.Count; i++)
                                        {
                                            foodSupply[i].Print();
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Вы ввели недопустимое значение!");                                   
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели неверное значение!");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку для возврата в меню.");
                            Console.ReadLine();
                            continue;
                        }
                        if (numberMenu == 3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Все партии в стадии 'Получены':");
                            Console.WriteLine();
                            goods[0].HeaderTablePrintStatusReceived();
                            Console.WriteLine(new string('-', 55));
                            foreach (var item in goods)
                            {
                                if (item.Status == Goods.StatusReceived)
                                {
                                    item.PrintStatusReceived();
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Введите Id партии для отправки на реализацию: ");

                            if (int.TryParse(Console.ReadLine(), out idCount))
                            {
                                for (int i = 0; i < goods.Count; i++)
                                {
                                    if (idCount == goods[i].id)
                                    {
                                        goods[i].Status = Goods.StatusRealised;
                                        goods[i].dateRealised = DateTime.Now;
                                        Console.WriteLine("Отправка на рееализацию успешна!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели недопустимое значение!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели неверное значение!");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку для возврата в меню.");
                            Console.ReadLine();
                            continue;
                        }
                        if (numberMenu == 4)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Все партии в стадии 'Реализованны':");
                            Console.WriteLine();
                            goods[0].HeaderTablePrintStatusRealised();
                            Console.WriteLine(new string('-', 73));
                            foreach (var item in goods)
                            {
                                if (item.Status == Goods.StatusRealised)
                                {
                                    item.PrintStatusRealised();
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Введите Id партии для отправки на списание: ");

                            if (int.TryParse(Console.ReadLine(), out idCount))
                            {
                                for (int i = 0; i < goods.Count; i++)
                                {
                                    if (idCount == goods[i].id)
                                    {
                                        goods[i].Status = Goods.StatusWrittenOff;
                                        goods[i].dateWrittenOff = DateTime.Now;
                                        Console.WriteLine("Отправка на рееализацию успешна!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели недопустимое значение!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели неверное значение!");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку для возврата в меню.");
                            Console.ReadLine();
                            continue;
                        }
                        if (numberMenu == 5)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Все партии в стадии 'Списано':");
                            Console.WriteLine();
                            goods[0].HeaderTablePrintStatusWrittenOff();
                            Console.WriteLine(new string('-', 91));
                            foreach (var item in goods)
                            {
                                if (item.Status == Goods.StatusWrittenOff)
                                {
                                    item.PrintStatusWrittenOff();
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Введите Id партии для отправки на передачу: ");

                            if (int.TryParse(Console.ReadLine(), out idCount))
                            {
                                for (int i = 0; i < goods.Count; i++)
                                {
                                    if (idCount == goods[i].id)
                                    {
                                        goods[i].Status = Goods.StatusTransferred;
                                        goods[i].dateTransferred = DateTime.Now;
                                        Console.WriteLine("Отправка на рееализацию успешна!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы ввели недопустимое значение!");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели неверное значение!");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую кнопку для возврата в меню.");
                            Console.ReadLine();
                            continue;
                        }
                        if (numberMenu == 6)
                        {
                            yesNo = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели недопустимое значение!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    continue;
  
                }        
            } while (yesNo);
        }
    }
}
