using PhoneBooks.Models;

class Program
{
    public static List<Option> options;
    static void Main(string[] args)
    {
        
        options = new List<Option>
            {
                new Option("Contact list"),
                new Option("Add new contact"),
                new Option("Delete contact"),
                new Option("Create contact"),
                new Option("Update contact"),
                new Option("Exit"),
            };

        int index = 0;
        WriteMenu(options, options[index]);

        // Store key info in here
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < options.Count)
                {
                    index++;
                    WriteMenu(options, options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(options, options[index]);
                }
            }
            
            if (keyinfo.Key == ConsoleKey.Enter)
            {
               
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();

    }
    // Default action of all the options. You can create more methods
    static void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(3000);
        WriteMenu(options, options.First());
    }



    static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }
    static void WriteContactMenu(List<Contact> options, Contact selectedOption)
    {
        Console.Clear();

        foreach (Contact option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
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
