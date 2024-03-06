using PhoneBooks.Models;
using PhoneBooks.Services;
class Program
{
    private static IContactService _service = new ContactService();
    static void Main(string[] args)
    {
        bool running = true;
        do
        {

            Console.Clear();
            _service.ShowAllContact();
            Console.WriteLine("Phone Contact CRUD Menu");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    Console.Write("Enter Id: ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    UpdateContact(Id);
                    break;
                case "4":
                    Console.WriteLine("Enter Id: ");
                    Id = Convert.ToInt32(Console.ReadLine());
                    DeleteContact(Id);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (running);
    }

    private static void DeleteContact(int Id)
    {
        _service.DeleteContactById(Id);
    }

    private static void UpdateContact(int Id)
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Phone: ");
        string phone = Console.ReadLine();
        _service.UpdateContactById(Id, new Contact {Id=Id, Name=name, Phone=phone });
    }

    private static void ViewContacts()
    {
        _service.ShowAllContact();
    }

    private static void AddContact()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Phone: ");
        string phone = Console.ReadLine();
        _service.InsertContact(new Contact { Id = new Random().Next(100), Name = name, Phone = phone });
    }
}
