using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    enum Colors
    {
        Red = 1, Green, Blue
    }
    struct Book
    {
        public int Id;
        public string Name;
        public double Price;
        public Colors Color;
    }
    enum Operations
    {
        Exit, Add, Edit, Details, Delete, DisplayAll
    }
    class Program
    {
        static int GetBookIndex(List<Book> books)
        {
            int id;
            int index = -1;
            Print("Please Enter book Id: ");
            id = int.Parse(Console.ReadLine());
            if (id < 0)
                return index;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static bool ValidateIndex(int bookIndex)
        {
            if (bookIndex > -1)
                return true;
            Console.WriteLine("Sorry Book wasn't found");
            return false;
        }
        static void Print(string message)
        {
            Console.Write(message);
        }
        static void ValidateUser()
        {
            string userName, password;
            while (true)
            {
                Print("Please Enter Your User Name : ");
                userName = Console.ReadLine();
                Print("Please Enter Your Password : ");
                password = Console.ReadLine();

                if (userName == "admin" && password == "123456")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error Invalid user Name or password !!");
                }
            }
        }
        static void ShowPanel()
        {
            Console.WriteLine("\t\t******************");
            Console.WriteLine("\t\t\tWelcome");
            Console.WriteLine("\t\t******************");
            Console.WriteLine("1- Add\n2- Edit\n3- Book Details\n4- Delete\n5- Display All\n0- Exit");
        }
        static Book AddBook(List<Book> books, ref int counter)
        {
            Book book = new Book();
            book.Id = ++counter;
            Print("Please Enter Book Name : ");
            book.Name = Console.ReadLine();
            Print("Please Enter Book Price : ");
            book.Price = double.Parse(Console.ReadLine());
            Console.WriteLine("1- Red 2- Green 3- Blue");
            Print("Please Enter Book Color : ");
            book.Color = (Colors)int.Parse(Console.ReadLine());
            books.Add(book);
            return book;
        }
        static void DisplayAll(List<Book> books)
        {
            foreach (var item in books)
            {
                PrintBook(item);
                Console.WriteLine("*******************");
            }
        }
        static void PrintBook(Book item)
        {
            Console.WriteLine($"Book Id : {item.Id}");
            Console.WriteLine($"Book Name : {item.Name}");
            Console.WriteLine($"Book Price : {item.Price}");
            Console.WriteLine($"Book Color : {item.Color}");
        }
        static void PrintBookDetails(List<Book> books)
        {
            int bookIndex = GetBookIndex(books);
            if (ValidateIndex(bookIndex))
                PrintBook(books[bookIndex]);
        }
        static void RemoveBook(List<Book> books)
        {
            int bookIndex = GetBookIndex(books);
            if (ValidateIndex(bookIndex))
            {
                books.RemoveAt(bookIndex);
                Console.WriteLine("Done");
            }
        }
        static void EditBook(List<Book> books)
        {
            int bookIndex = GetBookIndex(books);
            if (ValidateIndex(bookIndex))
            {
                Console.WriteLine("--Old Data");
                PrintBook(books[bookIndex]);
                Console.WriteLine("--Please Enter new data--");
                Book updatedBook = new Book();
                updatedBook.Id = books[bookIndex].Id;
                Print("Please Enter Book Name : ");
                updatedBook.Name = Console.ReadLine();
                Print("Please Enter Book Price : ");
                updatedBook.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("1- Red 2- Green 3- Blue");
                Print("Please Enter Book Color : ");
                updatedBook.Color = (Colors)int.Parse(Console.ReadLine());
                books[bookIndex] = updatedBook;
            }
        }
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Name="C#",
                    Price=100,
                    Color=Colors.Blue
                },
                new Book()
                {
                    Id=2,
                    Name="C++",
                    Price=200,
                    Color=Colors.Red
                },
            };
            int counter = 2;
            Operations choice;
            ValidateUser();
            while (true)
            {
                ShowPanel();
                Print("Please Pick an operation : ");
                choice = (Operations)int.Parse(Console.ReadLine());
                if (choice == Operations.Exit)
                    break;
                switch (choice)
                {
                    case Operations.Add:
                        AddBook(books, ref counter);
                        break;
                    case Operations.Edit:
                        EditBook(books);
                        break;
                    case Operations.Details:
                        PrintBookDetails(books);
                        break;
                    case Operations.Delete:
                        RemoveBook(books);
                        break;
                    case Operations.DisplayAll:
                        DisplayAll(books);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
