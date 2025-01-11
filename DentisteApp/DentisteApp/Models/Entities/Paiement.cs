namespace DentisteApp.Models.Entities
{
    public class Paiement
    {
        public int ID { get; set; }
        public DateTime DatePaiement { get; set; }
        public decimal Montant { get; set; }
        public string? MoyenPaiement { get; set; }
        public string? Note { get; set; }
        public int ActeID { get; set; }
        public Acte? Acte { get; set; }



    }
}
