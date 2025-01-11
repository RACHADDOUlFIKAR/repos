namespace DentisteApp.Models.Entities
{
    public class Facture
    {
        public int ID { get; set; }
        public DateTime DateFacture { get; set; }
        public decimal MontantTotal { get; set; }
        public string? EtatPaiement { get; set; }
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }

    }
}
