
using PhoneBooks.Models;

namespace PhoneBooks.Services
{
    public interface IContactService
    {
        void ShowAllContact();
        Contact GetContactById(int id);
        Contact InsertContact(Contact contact);
        void DeleteContactById(int id);
        Contact UpdateContactById(int id,Contact contact);

    }
}
