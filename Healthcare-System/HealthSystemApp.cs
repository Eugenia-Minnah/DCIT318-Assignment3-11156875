using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo = new Repository<Patient>();
        private Repository<Prescription> _prescriptionRepo = new Repository<Prescription>();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new Dictionary<int, List<Prescription>>();

        public void SeedData()
        {
            _patientRepo.Add(new Patient(1, "Eugenia Minnah", 20, "Female"));
            _patientRepo.Add(new Patient(2, "Kevin Yeboah", 25, "Male"));
            _patientRepo.Add(new Patient(3, "Stephen Owusu", 38, "Male"));

            _prescriptionRepo.Add(new Prescription(1, 1, "Amoxicillin", DateTime.Now.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-3)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Paracetamol", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(4, 3, "Cetirizine", DateTime.Now.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(5, 2, "Lisinopril", DateTime.Now.AddDays(-1)));
        }

        public void BuildPrescriptionMap()
        {
            foreach (var prescription in _prescriptionRepo.GetAll())
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }

                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public void PrintAllPatients()
        {
            foreach (var patient in _patientRepo.GetAll())
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
        }

        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var p in prescriptions)
                {
                    Console.WriteLine($"- {p.MedicationName}, Issued on {p.DateIssued.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No prescriptions found for that patient.");
            }
        }
        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            {
                return prescriptions;
            }
            return new List<Prescription>();
        }
    }
}