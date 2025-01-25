using DentisteApp.Models.Entities;

namespace DentisteApp.IRepositories
{
   // public interface IUserRepository : IRepositoryGlobal<User> { }

    public interface IPatientRepository : IRepositoryGlobal<Patient> { }

    public interface IPaiementRepository : IRepositoryGlobal<Paiement> { }

    public interface IOrdonnanceRepository : IRepositoryGlobal<Ordonnance> { }

    public interface IImagerieRepository : IRepositoryGlobal<Imagerie> { }
    public interface IRendez_vousRepository : IRepositoryGlobal<Rendez_vous> { }

    public interface IFeuilleDeSoinRepository : IRepositoryGlobal<FeuilleDeSoin> { }

    public interface IFactureRepository : IRepositoryGlobal<Facture> { }
    public interface IActeRepository : IRepositoryGlobal<Acte> { }


    public interface ICertificatMedicalRepository : IRepositoryGlobal<CertificatMedical> { }
}
