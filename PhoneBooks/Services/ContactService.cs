using PhoneBooks.Brokers.FileBroker;
using PhoneBooks.Brokers.Logging;
using PhoneBooks.Models;

namespace PhoneBooks.Services
{
    internal class ContactService : IContactService
    {
        private readonly ILoggingBroker loggingBroker = new LoggingBroker();
        private readonly IStorageBroker storageBroker = new StorageBroker();
        public void DeleteContactById(int id)
        {
            try
            {
                this.storageBroker.DeleteContactByLine(id);
                loggingBroker.LogInformation("Contact successfully deleted");
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(DeleteContactById)}  please contract developer");
                loggingBroker.LogError(exception);
            }
           
        }

        public void ShowAllContact()
        {
            try
            {
                Contact[] contacts = this.storageBroker.GetAllContacts();
                int i = 0;
                foreach (Contact contact in contacts)
                {
                    i++;
                    this.loggingBroker.LogInformation($"{i}. {contact.Name} - {contact.Phone}");
                }

                this.loggingBroker.LogInformation("===End of contacts===");

            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError(exception);
            }
            
        }

        public Contact GetContactById(int line)
        {
            try
            {
            return storageBroker.GetContactByLine(line);
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError($"Error occured getting at {nameof(GetContactById)} please contract developer");
                this.loggingBroker.LogError(exception);
                return new Contact();
            }
           
        }

        public Contact InsertContact(Contact contact)
        {
            try
            {
                return contact is null
                ? CreateAndLogInvalidContact()
                : ValidateAndAddContact(contact);
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError($"Error occured at creating contact {nameof(InsertContact)} please contract developer");
                this.loggingBroker.LogError(exception);
                return new Contact(); 
            }
            
        }

        public Contact UpdateContactById(int id, Contact contact)
        {
            try
            {
                return ValidateAndUpdateContact(id, contact);
            }
            catch (Exception exception)
            {
                this.loggingBroker.LogError($"Error occured at updating contact {nameof(InsertContact)} please contract developer");
                this.loggingBroker.LogError(exception);
                return new Contact();
            }
            
        }
        
        private Contact CreateAndLogInvalidContact()
        {
            this.loggingBroker.LogError("Contact is invalid.");
            return new Contact();
        }
        
        private Contact ValidateAndAddContact(Contact contact)
        {
            if (contact.Id is 0
                || String.IsNullOrWhiteSpace(contact.Name)
                || String.IsNullOrWhiteSpace(contact.Phone))
            {
                this.loggingBroker.LogError("Contact details missing.");
                return new Contact();
            }
            else
            {
                return this.storageBroker.InsertContact(contact);
            }
        }
        
        private Contact ValidateAndUpdateContact(int Id,Contact contact)
        {
            if (Id is 0
                || String.IsNullOrWhiteSpace(contact.Name)
                || String.IsNullOrWhiteSpace(contact.Phone))
            {
                this.loggingBroker.LogError("Contact details missing.");
                return new Contact();
            }
            else
            {
                return this.storageBroker.UpdateContactByLine(Id,contact);
            }
        }
    }
}
