using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JNodzynskalab1
{
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public virtual void Move() {
            Console.WriteLine("Poruszam sie..."); 
        }

        public override string ToString()
        {
            return $"Heja, jestem {Name}, mam {Age} lat! Moj gatunek: {Species}";
        }
    }

    class Fish : Animal { public override void Move() { 
            Console.WriteLine("Plyne..."); 
        } 
    }
    class Dog : Animal { public override void Move()
        {
            Console.WriteLine("Biegam...");
        }
    }

    class Program
    {

        private static void Calculator()
        {
            string answer = "";
            while (answer != "N" || answer != "n")
            {
                Console.WriteLine("Podaj liczby:");
                double equation = double.NaN; ;
                double userValueA = 0;
                double userValueB = 0;
                string sign = "";
                try
                {
                    Console.WriteLine("A: ");
                    userValueA = double.Parse(Console.ReadLine());
                    Console.WriteLine("B: ");
                    userValueB = double.Parse(Console.ReadLine());
                    Console.WriteLine("Wybierz dzialanie [+, -, /, *,A!,B!]");
                    sign = Console.ReadLine();
                    switch (sign)
                    {
                        case "+":
                            equation = userValueA + userValueB;
                            break;
                        case "-":
                            equation = userValueA - userValueB;
                            break;
                        case "*":
                            equation = userValueA * userValueB;
                            break;
                        case "/":
                            if (userValueB != 0)
                                equation = userValueA / userValueB;
                            break;
                        case "A!":
                            equation = 1;
                            for (int i = 1; i < userValueA + 1; i++)
                            {
                                equation = equation * i;
                            }
                            break;
                        case "B!":
                            equation = 1;
                            for (int i = 1; i < userValueB + 1; i++)
                            {
                                equation = equation * i;
                            }
                            break;

                    }
                    if (!double.IsNaN(equation))
                    {
                        if (sign == "A!")
                        {
                            Console.WriteLine("Wynik dzialania: " + userValueA + "! wynosi: ");
                        }
                        else if (sign == "B!")
                        {
                            Console.WriteLine("Wynik dzialania: " + userValueA + "! wynosi: ");
                        }
                        else
                        {
                            Console.WriteLine("Wynik dzialania: " + userValueA + sign + userValueB + " wynosi: ");
                        }
                        Console.WriteLine(equation);
                    }
                    Console.WriteLine("Kontynuowac? [Click N to finish]");
                    answer = Console.ReadLine();
                    if (answer == "N" || answer == "n")
                    {
                        Environment.Exit(0);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Podana wartość jest nieprawidłowa");
                }
            }
        }
        private static void TablesEx()
        {
            int size = 0;
            int maxValue = 0;
            try
            {
                Console.WriteLine("Rozmiar tablicy:");
                size = int.Parse(Console.ReadLine());
                Console.WriteLine("Max wartosc przechowywana w tablicy:");
                maxValue = int.Parse(Console.ReadLine());

                Random randomNumber = new Random();

                if (size > 0)
                {
                    int[] someNumbers = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        someNumbers[i] = randomNumber.Next(maxValue);
                    }
                    printArray(someNumbers);

                }
                else Console.WriteLine("Rozmiar tablicy musi byc wiekszy od 0!");
            }
            catch
            {
                Console.WriteLine("Podana wartość jest nieprawidłowa");
            }
        }
        private static void printArray(int[] anArray) {
            Console.WriteLine();
            foreach (var number in anArray)
            {
                Console.Write(number + " ");
            }
        }
        private static int[] GenerateRandomArray()
        {
            int size = 0;
            int maxValue = 0;
            int[] anArray = null;
            try
            {
                Console.WriteLine("Rozmiar tablicy:");
                size = int.Parse(Console.ReadLine());
                Console.WriteLine("Max wartosc przechowywana w tablicy:");
                maxValue = int.Parse(Console.ReadLine());

                Random randomNumber = new Random();
                if (size > 0)
                {
                    anArray = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        anArray[i] = randomNumber.Next(maxValue);
                    }
                 }
                else Console.WriteLine("Rozmiar tablicy musi byc wiekszy od 0!");
            }
            catch
            {
                Console.WriteLine("Podana wartość jest nieprawidłowa");
            }
            return anArray;
        }
        private static void BubbleSort(int[] anArray)
        {
            bool isSorted;
            Console.WriteLine();
            do
            {
                isSorted = true;
                for (int i = 0; i < anArray.Length - 1; i++)
                {
                    if(anArray[i] > anArray[i + 1])
                    {
                        int number = anArray[i];
                        anArray[i] = anArray[i + 1];
                        anArray[i + 1] = number;
                        isSorted = false;
                    }
                }
            }
            while (isSorted == false);
        }
        private static void BubbleSortEx()
        {
            int[] anArray = GenerateRandomArray();
            Console.WriteLine("Tablica:");
            printArray(anArray);
            BubbleSort(anArray);
            Console.WriteLine();
            Console.WriteLine("Tablica po posortowaniu:");
            printArray(anArray);
        }

        private static void Collections()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i + " liczba do listy:");
                try
                {
                    int givenNumber = int.Parse(Console.ReadLine());
                    list1.Add(givenNumber);
                }
                catch
                {
                    Console.WriteLine("Podano nieprawidlowy element listy!");
                }
            }

            Console.WriteLine("Lista nr 1:");
            writeToList(list1);
            Console.WriteLine();
            Console.WriteLine("Lista nr 2 jest pusta");
            Console.WriteLine();
            Console.WriteLine("Uwaga! Z listy nr 1 zostana usuniete wszystkie liczby < 2, pozostale zostana skopiowane do listy nr 2");
            Console.WriteLine();

            for (int i = list1.Count - 1; i >= 0; i--)
            {
                if (list1[i] < 2) list1.RemoveAt(i);
                else list2.Add(list1[i]);
            }

            Console.WriteLine("Lista nr 1 po operacji:");
            writeToList(list1);
            Console.WriteLine();
            Console.WriteLine("Lista nr 2 po operacji:");
            writeToList(list2);
            Console.WriteLine();
        }

        private static void writeToList(List<int> list)
        {
            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
        }

        private static void Classes()
        {
            Animal animal = new Animal { Name = "Bryk", Age = 3, Species = "Kot" };
            Console.WriteLine(animal);
            animal.Move();

            Animal fish = new Fish { Name = "Przytulas", Age = 1, Species = "Zarlacz Bialy" };
            Console.WriteLine(fish);
            fish.Move();

            Animal dog = new Dog { Name = "Sliniak", Age = 6, Species = "Buldog" };
            Console.WriteLine(dog);
            dog.Move();
        }

        static void Main(string[] args)

        {
            Console.WriteLine("Menu");
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("[0] Zakoncz program");
            Console.WriteLine("[1] Kalkulator");
            Console.WriteLine("[2] Generacja Tablicy");
            Console.WriteLine("[3] Sortowanie babelkowe");
            Console.WriteLine("[4] Kolekcje");
            Console.WriteLine("[5] Klasy");

            try { 
            int userFuction = int.Parse(Console.ReadLine());
            
            switch (userFuction)
            {
                case 1:
                    Calculator();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                case 2:
                    TablesEx();
                    break;
                case 3:
                    BubbleSortEx();
                    break;
                case 4:
                    Collections();
                    break;
                case 5:
                    Classes();
                    break;
                default:
                    Console.WriteLine("Nieprawidlowa opcja");
                    break;

            }
            }
            catch
            {
                Console.WriteLine("Podana wartość jest nieprawidłowa");
            }

            Console.ReadKey();
        }
    }
}
