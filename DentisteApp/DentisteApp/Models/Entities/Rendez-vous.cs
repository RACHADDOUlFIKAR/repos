using DentisteApp.Models.@enum;

namespace DentisteApp.Models.Entities
{
    public class Rendez_vous
    {
        public int Id { get; set; }
        public string? type { get; set; }

        public DateTime date { get; set; }

        public Status status { get; set; }
        public int PatientID { get; set; }
        public Patient? Patient { get; set; }
    }
}
