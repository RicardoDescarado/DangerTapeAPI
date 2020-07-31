using System.ComponentModel.DataAnnotations;

namespace DangerTapeAPI.Database.Entities
{
    public class Mode
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}