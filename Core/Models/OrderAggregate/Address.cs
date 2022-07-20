namespace Core.Models.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string street, string city, string province, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? PostalCode { get; set; }
    }
}
