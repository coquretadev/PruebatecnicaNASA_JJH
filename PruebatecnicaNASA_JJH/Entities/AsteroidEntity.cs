namespace PruebatecnicaNASA_JJH.Entities
{
    public class AsteroidEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPotentiallyHazardous { get; set; }

        public double EstimatedDiameterMin { get; set; }

        public double EstimatedDiameterMax { get; set; }

        public double RelativeVelocityKilometersPerHour { get; set; }

        public DateTime CloseApproachDate { get; set; }

        public string OrbitingBody { get; set; }
    }
}
