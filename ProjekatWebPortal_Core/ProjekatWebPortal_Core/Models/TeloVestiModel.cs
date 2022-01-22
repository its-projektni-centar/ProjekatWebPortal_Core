using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatWebPortal_Core.Models
{
    public class TeloVestiModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VestModel")]
        public int VestId { get; set; }
        public VestModel VestModel { get; set; }
        public string TeloVesti { get; set; }
    }
}
