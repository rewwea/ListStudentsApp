using System;
using System.Collections.Generic;
using System.Linq;

namespace ListStudentsApp
{
    public static class StudentListOperations
    {
        public static void DobavitStudenta(List<Student> spisokStudentov, Student student)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            spisokStudentov.Add(student);
        }

        public static void UdalitStudenta(List<Student> spisokStudentov, int idStudenta)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            var student = spisokStudentov.FirstOrDefault(s => s.Id == idStudenta);
            if (student != null)
            {
                spisokStudentov.Remove(student);
            }
        }

        public static Student? NajtiStudenta(List<Student> spisokStudentov, int idStudenta) // Добавлено nullable (?)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            return spisokStudentov.FirstOrDefault(s => s.Id == idStudenta);
        }

        public static void SortirovatPoId(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            spisokStudentov.Sort();
        }

        public static void SortirovatPoFamilii(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            spisokStudentov.Sort((x, y) => string.Compare(x.Familia ?? "", y.Familia ?? ""));
        }

        public static List<Student> FiltrirovatPoSrednemuBallu(List<Student> spisokStudentov, double minBall)
        {
            if (spisokStudentov == null) throw new ArgumentNullException(nameof(spisokStudentov));
            return spisokStudentov.Where(s => s.SredniyBall >= minBall).ToList();
        }

        public static double RaschetSrednegoBall(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0) return 0;
            return spisokStudentov.Average(s => s.SredniyBall);
        }

        public static Student? NajtiSamogoStarshego(List<Student> spisokStudentov) // Добавлено nullable (?)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0) return null;
            return spisokStudentov.OrderBy(s => s.DataRozhdeniya).FirstOrDefault();
        }
    }
}