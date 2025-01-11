namespace DentisteApp.Models.Entities
{
    public class FeuilleDeSoin
    {
        public int ID { get; set; }
        public DateTime DateFeuille { get; set; }
        public string? Description { get; set; }
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
