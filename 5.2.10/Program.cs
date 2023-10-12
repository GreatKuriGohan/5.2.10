using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            // сортируем контакты по имени и фамилии
            phoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName).ToList();

            while (true)
            {
                Console.WriteLine("Enter the page number (1-3):");
                char pageChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (char.IsDigit(pageChar))
                {
                    int pageNumber = int.Parse(pageChar.ToString());

                    if (pageNumber >= 1 && pageNumber <= 3)
                    {
                        int startIndex = (pageNumber - 1) * 2;
                        int endIndex = Math.Min(startIndex + 2, phoneBook.Count);

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            Console.WriteLine(phoneBook[i].Name + " " + phoneBook[i].LastName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid page number. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }

    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, string email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }
}