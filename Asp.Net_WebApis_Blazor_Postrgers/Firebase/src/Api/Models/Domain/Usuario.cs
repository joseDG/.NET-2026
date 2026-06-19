using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain;

    public class Usuario
    {
        [Key]
        [Required]
        public int Id {get;set;}
        public string? Email {get;set;}
        public string? FullName {get;set;}
        public string? FirebaseId {get;set;}

        public ICollection<Role>? Roles {get; set;}
    }
