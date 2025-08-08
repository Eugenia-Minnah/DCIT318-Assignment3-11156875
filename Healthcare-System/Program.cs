using System;

namespace Healthcare_System
{
    class Program
{
        static void Main(string[] args)
        {
        var app = new HealthSystemApp();
        app.SeedData();
        app.BuildPrescriptionMap();

        Console.WriteLine("\n--- All Patients ---");
        app.PrintAllPatients();

        Console.Write("\nEnter a Patient ID to view their prescriptions: ");
        if (int.TryParse(Console.ReadLine(), out int patientId))
        {
            var prescriptions = app.GetPrescriptionsByPatientId(patientId);
            if (prescriptions.Count > 0)
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var p in prescriptions)
                {
                    Console.WriteLine($"{p.MedicationName} - {p.DateIssued.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No prescriptions found for this patient.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Patient ID.");
        }
    }
}
}