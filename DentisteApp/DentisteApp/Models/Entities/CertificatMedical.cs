namespace DentisteApp.Models.Entities
{
    public class CertificatMedical
    {
        public int ID { get; set; }
        public DateTime DateCertificat { get; set; }
        public string? Raison { get; set; }
        public int Duree { get; set; }
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
