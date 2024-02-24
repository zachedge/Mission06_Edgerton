using System.ComponentModel.DataAnnotations;

namespace Mission06_Edgerton.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; } //read only variable
        public string Category { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public Boolean Edited { get; set; }
        public string Lent { get; set; }
        //[StringLength(25)]
        public string Notes { get; set; }
    }
}
