using System;
using System.Collections.Generic;
namespace c_week3
{
    class Program
    {
        class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
            public List<(string Book, DateTime DueDate)> BorrowedBooks { get; set; }

            public User()
            {
                BorrowedBooks = new List<(string, DateTime)>();
            }
        }

        static Dictionary<string, User> users = new Dictionary<string, User>();
        static User currentUser = null;

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Library ===");
                if (currentUser == null)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("0. Exit");
                    Console.Write("--library--");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Register();
                    }
                    else if (choice == "2")
                    {
                        Login();
                    }
                    else if (choice == "0")
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine($"Welcome, {currentUser.FullName}!");
                    Console.WriteLine("1. Borrow Book");
                    Console.WriteLine("2. Show book list borrowed");
                    Console.WriteLine("3. Edit");
                    Console.WriteLine("4. Logout");
                    Console.Write("Select menu:");
                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        BorrowBook();
                    }
                    else if (choice == "2")
                    {
                        ShowBorrowedBooks();
                    }
                    else if (choice == "3")
                    {
                        EditProfile();
                    }
                    else if (choice == "4")
                    {
                        currentUser = null;
                        Console.WriteLine("Logged out successfully!");
                        Console.ReadKey();
                    }
                    {

                    }
                }
            }
        }


        static void Register()
        {
            Console.Write("Input Username:");
            string username = Console.ReadLine();
            if (users.ContainsKey(username))
            {
                Console.WriteLine("Username Have been register!");
                Console.ReadKey();
                return;
            }
            Console.Write("Input Password: ");
            string password = Console.ReadLine();
            Console.Write("Input Your name: ");
            string fullName = Console.ReadLine();

            users[username] = new User { Name = username, Password = password, FullName = fullName };
            Console.WriteLine("Registration complete!");
            Console.ReadKey();
        }
        static void Login()
        {
            Console.Write("Username:");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username].Password == password)
            {
                currentUser = users[username];
                Console.WriteLine("Login complete!");
            }
            else
            {
                Console.WriteLine("Username or password incorrrect!");
            }
            Console.ReadKey();
        }


        static void BorrowBook()
        {
            Console.Write("List borrow look:");
            string book = Console.ReadLine();
            DateTime dueDate = DateTime.Now.AddDays(7); // Set due date to 7 days from now
            currentUser.BorrowedBooks.Add((book, dueDate));
            Console.WriteLine($"Book name: \"{book}\" and Duedate {dueDate.ToShortDateString()}");
            Console.ReadKey();
        }

        static void ShowBorrowedBooks()
        {
            if (currentUser.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No found borrow book");
            }
            else
            {
                Console.WriteLine("=== Borrowed Books ===");
                foreach (var b in currentUser.BorrowedBooks)
                {
                    Console.WriteLine($"- {b.Book} (DueDate: {b.DueDate.ToShortDateString()}");
                }
            }
            Console.ReadKey();
        }
        static void EditProfile()
        {
            Console.Write("Edit new name:");
            string newName = Console.ReadLine();
            Console.Write("Edit new password:");
            string newPass = Console.ReadLine();

            currentUser.FullName = newName;
            currentUser.Password = newPass;

            Console.WriteLine("Edit complete!");
            Console.ReadKey();
        }
    }
}
