namespace Altaliza.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public int VehicleCategoryId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public float Rent1Day { get; set; }

        public float Rent7Day { get; set; }

        public float Rent15Day { get; set; }
    }
}
