namespace DTO
{
    public class orderDTO
    {
        public int OrderId { get; set; }

        public DateOnly OrderDate { get; set; }

        public int OrderSum { get; set; }

        public int UserId { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

    }
}
