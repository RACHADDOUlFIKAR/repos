namespace DentisteApp.Models.Entities
{
    public class Imagerie
    {
        public int ID { get; set; }
        public DateTime DateImagerie { get; set; }
        public string? TypeImagerie { get; set; }
        public string? UrlImage { get; set; }

        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
