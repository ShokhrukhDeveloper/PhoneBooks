using PhoneBooks.Models;
using PhoneBooks.Services;
class Program
{
    public static List<Option> options;
    private static IContactService _service = new ContactService();
    static void Main(string[] args)
    {
        do
        {
        Contact? contact= WriteContactMenu();
            if (contact is not null)
            {
                WriteOptionMenu(contact);
            }
        } while (true);
    }
    static void WriteOptionMenu(Contact contact)
    {
        int index = 0;

       ConsoleKeyInfo keyinfo;

        options = new List<Option>
          {
                new Option("Delete contact"),
                new Option("Update contact"),
                new Option("Back")
          };
        bool running = true;   
        do
        {
            Console.Clear();
            Console.WriteLine($"Id: {contact.Id} \nName: {contact.Name} \nPhone: {contact.PhoneNumber}");
            foreach (var option in options)
            {
                if (option == options[index])
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(option.Name);

            }
            keyinfo = Console.ReadKey();
            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                index++;
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                index--;
            }
            if (keyinfo.Key==ConsoleKey.Enter && index==2)
            {
                running = false;
            }
            else if (keyinfo.Key == ConsoleKey.Enter && index == 1)
            {
                Console.WriteLine("Succesfully deleted");
                Thread.Sleep(2000);
                running = false;
            }
            else if (keyinfo.Key == ConsoleKey.Enter && index == 0)
            {
                Console.WriteLine("Succesfully updated");
                Thread.Sleep(2000);
                running = false;
            }

        } while (running);

    }
    static Contact? WriteContactMenu()
    {
        int index = 0;
        ConsoleKeyInfo keyinfo;
        Contact[] contacts = _service.GetAllContact();
        
        do{
            Console.Clear();
            foreach (Contact contact in contacts)
            {
                if (contact == contacts[index])
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(contact.Name);
            }
            Console.WriteLine("<Create new contact>");
            keyinfo = Console.ReadKey();

            if (keyinfo.Key==ConsoleKey.DownArrow)
            {
                index++;
            }
            else if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                index--;
            }
            else if (keyinfo.Key==ConsoleKey.Enter)
            {
                return contacts[index];
            }

        } while (true);
    }
}

public class Option
{
    public string Name { get; }

    public Option(string name)
    {
        Name = name;
    }
}
