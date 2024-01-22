using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebatecnicaNASA_JJH.Entities
{
    public class AsteroidEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public double EstimatedDiameter { get; set; }

        public double Velocity { get; set; }

        public DateTime Date { get; set; }

        public string Planet { get; set; }
    }
}
