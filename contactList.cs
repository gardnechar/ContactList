using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{

    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Person(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
        
    }

    class Program
    {
       static List<Person> contacts = new List<Person>();

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to your contact directory");
            Console.WriteLine(" ");
            Console.WriteLine("To add a contact type 'add'");
            Console.WriteLine("To remove a contact type 'remove'");
            Console.WriteLine("To find a contact type 'find'");
            Console.WriteLine("To update a contact type 'update'");
            Console.WriteLine("To view all contacts type 'view'");
            Console.WriteLine(" ");

            start();

        }

        public static void start()
        {
         
            String a = Console.ReadLine();

            if (a == "add")
            {
                addPerson();
            }
            else if (a == "remove")
            {
                removePerson();
            }
            else if (a == "find")
            {
                findPerson();
            }
            else if (a == "update")
            {
                updatePerson();
            }
            else if (a == "view")
            {
                viewList();
            }
            else
            {
                Console.WriteLine("Sorry that command is not recognised");
                start();
            }           

        }

        public static void addPerson()
        {

            Console.WriteLine("Please enter the contacts name");
            String name = Console.ReadLine();

            Console.WriteLine("Please enter the contacts phone");
            String phone = Console.ReadLine();

            Console.WriteLine("Please enter the contacts email");
            String email = Console.ReadLine();

            Person p = new Person(name, phone, email);
            contacts.Add(p);

            Console.WriteLine("New contact " + name + " added!");

            start();

        }

        public static void viewList()
        {
            if (contacts.Count() == 0)
            {
                Console.WriteLine("Sorry there are no contacts to display");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.Name + ", " + contact.Phone + ", " + contact.Email);
                }
                
            }

            start();
        }

        public static void removePerson()
        {
            Console.WriteLine("Enter persons name you want removed");
            String name = Console.ReadLine();

            Boolean found = false;

            for (int i = 0; i < contacts.Count(); i++ )
            {
                
                if (contacts[i].Name == name)
                {
                    found = true;
                    contacts.RemoveAt(i);
                    break;
                }
            }

            if (found == true)
            {
                Console.WriteLine("Contact " + name + " has been removed");
            }
            else
            {
                Console.WriteLine("Contact " + name + " was not found");
            }

            start();

        }

        public static int? find(String name)
        {
            int? index = null;

            for (int i = 0; i < contacts.Count(); i++)
            {

                if (contacts[i].Name == name)
                {
                    index = i;
                    break;
                }

            }

            return index;

        }

        public static void updateField(string field, int i)
        {

            if (field == "name")
            {
                Console.WriteLine("Enter the new name");
                String answer = Console.ReadLine();
                contacts[i].Name = answer;
                Console.WriteLine("Name updated");
            }
            else if (field == "phone")
            {
                Console.WriteLine("Enter the new phone number");
                String answer = Console.ReadLine();
                contacts[i].Phone = answer;
                Console.WriteLine("Phone updated");
            }
            else if (field == "email")
            {
                Console.WriteLine("Enter the new email address");
                String answer = Console.ReadLine();
                contacts[i].Email = answer;
                Console.WriteLine("Email updated");
            }
            else
            {
                Console.WriteLine("Sorry that command is not recognised, please try again!");
                String answer = Console.ReadLine();
                updateField(answer, i);
            }

            start();

        }

        public static void updatePerson()
        {

            Console.WriteLine("Enter the persons name you want to update");
            String name = Console.ReadLine();

            int? result = find(name);

            if (result != null)
            {
                int i = result.Value;

                Console.WriteLine(contacts[i].Name + ", " + contacts[i].Phone + ", " + contacts[i].Email);

                Console.WriteLine("Type the field you want to update 'name', 'phone' or 'email' ");
                String field = Console.ReadLine();

                updateField(field, i);               
            }
            else
            {
                Console.WriteLine("Contact " + name + " was not found");
            }

            start();

        }

        public static void findPerson()
        {

            Console.WriteLine("Enter persons name you want found");
            String name = Console.ReadLine();

            int? result = find(name);

            if (result != null)
            {
                int i = result.Value;
                Console.WriteLine(contacts[i].Name + ", " + contacts[i].Phone + ", " + contacts[i].Email);
            }
            else
            {
                Console.WriteLine("Contact " + name + " was not found");
            }

            start();
        }

    }
   
}
