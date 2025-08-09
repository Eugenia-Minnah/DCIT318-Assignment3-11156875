using School_Grading_System;
using System;
using System.Collections.Generic;
using System.IO;

namespace School_Grading_System
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                        throw new MissingFieldException($"Invalid data format: {line}");

                    if (!int.TryParse(parts[0].Trim(), out int id))
                        throw new MissingFieldException($"Invalid or missing ID in line: {line}");

                    string fullName = parts[1].Trim();

                    if (string.IsNullOrWhiteSpace(fullName))
                        throw new MissingFieldException($"Missing name in line: {line}");

                    if (!int.TryParse(parts[2].Trim(), out int score))
                        throw new InvalidScoreFormatException($"Invalid score format in line: {line}");

                    students.Add(new Student(id, fullName, score));
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (Student student in students)
                {
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
            }
        }
    }
}