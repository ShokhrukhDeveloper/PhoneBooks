﻿using PhoneBooks.Models;

namespace PhoneBooks.Brokers.FileBroker
{
    public interface IStorageBroker
    {
        Contact InsertContact(Contact contact);
        Contact[] GetAllContacts();
        Contact GetContactByLine(int line);
        Contact UpdateContactByLine(int line, Contact contact);
        Contact DeleteContactByLine(int line);
    }
}
