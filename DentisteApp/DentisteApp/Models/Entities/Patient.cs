namespace DentisteApp.Models.Entities
{
    public class Patient
    {
        public int ID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }

    }
}
