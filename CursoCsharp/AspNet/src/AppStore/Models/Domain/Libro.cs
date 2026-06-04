using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppStore.Models.Domain
{
    public class Libro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? CreateDate { get; set; }
        public string? Imagen { get; set; }
        [Required]
        public string? Autor { get; set; }

        
        //referencia a la tabla intermedia
        public virtual ICollection<Categoria>? CategoriaRelationList { get; set; }
        public virtual ICollection<LibroCategoria>? LibroCategoriaRelationList { get; set; }

        //para recibir las categorias seleccionadas en el formulario
        //no se mapea a la base de datos
        [NotMapped]
        public List<int>? Categorias { get; set; }

        [NotMapped]
        public string? CategoriasNames { get; set; }

    }
}