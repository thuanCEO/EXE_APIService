namespace DTOs.Create
{
    public class CreateOrderRequest
    {
        public CreateOrderDTO OrderDTO { get; set; }
        public List<CreateOrderDetailDTO> OrderDetailDTO { get; set; }
    }
}
