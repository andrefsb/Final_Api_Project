using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty]
        public int Id { get; private set; }

        [MaxLength(50)]
        [Required]
        public string First_name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Last_name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        [MaxLength(15)]
        [Required]
        public string Gender { get; set; }

        [MaxLength(50)]
        [Required]
        public string Ip_address { get; set; }

    }
}
