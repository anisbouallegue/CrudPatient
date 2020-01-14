using CrudPatient.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPatient.Models.DataManager
{
    public class PatientManager : IDataRepository<Patient>
    {
        readonly PatientDbContext _patientContext;
        public PatientManager(PatientDbContext context)
        {
            _patientContext = context;
        }

        public IEnumerable<Patient> getAll()
        {
            return _patientContext.Patients.ToList();
        }

        public Patient getById(long id)
        {
            return _patientContext.Patients
                  .FirstOrDefault(e => e.Id == id);
        }

        public void createPatient(Patient entity)
        {
            _patientContext.Patients.Add(entity);
            _patientContext.SaveChanges();
        }

        public void updatePatient(Patient patient, Patient entity)
        {
            patient.Nom = entity.Nom;
            patient.Prenom = entity.Prenom;
            patient.NumTel = entity.NumTel;
            patient.Address = entity.Address;
            patient.BirthDay = entity.BirthDay;
            patient.IsActive = entity.IsActive;

            _patientContext.SaveChanges();
        }

        public void delPatient(Patient patient)
        {
            _patientContext.Patients.Remove(patient);
            _patientContext.SaveChanges();
        }
    }
}
