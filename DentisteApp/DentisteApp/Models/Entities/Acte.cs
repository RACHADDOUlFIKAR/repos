namespace DentisteApp.Models.Entities
{
    public class Acte
    {
        public int ID { get; set; }
        public string? TypeActe { get; set; }
        public DateTime DateActe { get; set; }
        public string? Description { get; set; }

        public List<int>? Dents { get; set; }
        public decimal Prix { get; set; }
        public decimal MontantPaye { get; set; }
        public decimal Reste { get; set; }
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
