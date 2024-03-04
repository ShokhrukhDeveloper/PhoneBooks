using PhoneBooks.Models;

namespace PhoneBooks.Services
{
    internal class ContactService : IContactService
    {
       static Contact[] contacts = { 
            new Contact() { Id = 1, Name = "New qwer", PhoneNumber = "+998997531097" },
            new Contact() { Id = 2, Name = "New jhas", PhoneNumber = "+998997531099" },
            new Contact() { Id = 3, Name = "New ewrgt", PhoneNumber = "+998997531002" },
            new Contact() { Id = 4, Name = "New asdf", PhoneNumber = "+998997531087" },
            new Contact() { Id = 5, Name = "New hgj", PhoneNumber = "+998997538090" },
        };
        public void DeleteContactById(int id)
        {
            
        }

        public Contact[] GetAllContact()
        {
            return contacts;
        }

        public Contact GetContactById(int id)
        {
            return contacts[id];
        }

        public Contact InsertContact(Contact contact)
        {
            contacts.Append(contact);
            return contact;
        }

        public Contact UpdateContactById(int id, Contact contact)
        {
            contacts[id] = contact;
            return contact;
        }
    }
}
