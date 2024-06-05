using ETicketStore.Domain.Models;
using System;

namespace ETicketStore.Domain.Models
{
    public class CustomerDTO : BaseEntity
    {
        public Customer(Guid id, string name, string email, string address, string city, string postalCode, string country, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            City = city;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
