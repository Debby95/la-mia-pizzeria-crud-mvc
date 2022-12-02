using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "E' obbligatorio inserire il nome della pizza")]
        [StringLength(50, ErrorMessage = "Il nome della pizza non può superare i 50 caratteri")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "E' obbligatorio inserire la descrizione della pizza")]
        [StringLength(400, ErrorMessage = "La descrizione della pizza non può superare i 400 caratteri")]
        public string Description { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "E' obbligatorio inserire il prezzo della pizza")]
        [Range(1, 30, ErrorMessage = "Il prezzo della pizza non può essere minore di 1 o maggiore di 30.")]
        public float Price { get; set; }

        public Pizza()
        {

        }

        public Pizza(int id, string name, string description, string image, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
