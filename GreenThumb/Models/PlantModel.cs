using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenThumb.Models
{
    public class PlantModel
    {
        [Key]
        [Column("plant_id")]
        public int PlantId { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("origin")]
        public string? Origin { get; set; }
        public List<GardenModel> Gardens { get; set; } = new();
        public List<InstructionModel> Instructions { get; set; } = new();
    }
}
