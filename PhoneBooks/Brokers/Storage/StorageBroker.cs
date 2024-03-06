using PhoneBooks.Models;

namespace PhoneBooks.Brokers.FileBroker
{
    public class StorageBroker : IStorageBroker
    {
        private readonly string filePath = "../../../Assets/Contacts.txt";
        public StorageBroker()
        {
            EnsureFileExists();
        }
        public Contact DeleteContactByLine(int line)
        {
            string[] contactLines = File.ReadAllLines(filePath);
            contactLines[line] = contactLines[line+1];
            string contactLine = contactLines[line];
            string[] contactProperties = contactLine.Split('*');
            Contact contact = new Contact
            {
                Id = Convert.ToInt32(contactProperties[0]),
                Name = contactProperties[1],
                Phone = contactProperties[2]
            };
            File.WriteAllLines(filePath, contactLines);
            return contact;
        }

        public Contact[] GetAllContacts()
        {
            string[] contactLines = File.ReadAllLines(filePath);
            int contactLength = contactLines.Length;
            Contact[] contacts = new Contact[contactLength];

            for (int iterator = 0; iterator < contactLength; iterator++)
            {
                string contactLine = contactLines[iterator];
                string[] contactProperties = contactLine.Split('*');

                Contact contact = new Contact
                {
                    Id = Convert.ToInt32(contactProperties[0]),
                    Name = contactProperties[1],
                    Phone = contactProperties[2]
                };

                contacts[iterator] = contact;
            }

            return contacts;
        }

        public Contact GetContactByLine(int line)
        {
            string[] contactLines = File.ReadAllLines(filePath);

            string contactLine= contactLines[line];
            string[] contactProperties = contactLine.Split('*');

            Contact contact = new Contact
            {
                Id = Convert.ToInt32(contactProperties[0]),
                Name = contactProperties[1],
                Phone = contactProperties[2]
            };
            return contact;
        }

        public Contact InsertContact(Contact contact)
        {
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n";
            File.AppendAllText(filePath, contactLine);
            return contact;
        }

        public Contact UpdateContactByLine(int line, Contact contact)
        {
            string[] allLines = File.ReadAllLines(filePath);
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n"; ;
            allLines[line] = contactLine;
            File.WriteAllLines(filePath, allLines);
            return contact;
        }
        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(filePath);

            if (fileExists is false)
            {
                File.Create(filePath).Close();
            }
        }
    }
}
