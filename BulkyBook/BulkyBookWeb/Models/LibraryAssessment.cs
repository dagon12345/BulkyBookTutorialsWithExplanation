using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class LibraryAssessment
    {
        [Key]
        public int ID { get; set; }
        public string Assessment { get; set; }
        public int ?isArchived { get; set; }
    }
}
