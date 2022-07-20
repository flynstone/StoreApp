namespace Api.Dtos
{
    public class OrderDto
    {
        public string BaskeId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShippedToAddress { get; set; }
    }
}
