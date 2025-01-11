namespace DentisteApp.Models.Entities
{
    public class Ordonnance
    {
        public int ID { get; set; }
        public DateTime DateOrdonnance { get; set; }
        public string? Medicaments { get; set; }

        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
