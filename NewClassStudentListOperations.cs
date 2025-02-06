using System;
using System.Collections.Generic;
using System.Linq;

namespace ListStudentsApp
{
    public static class StudentListOperations
    {
        public static void DobavitStudenta(List<Student> spisokStudentov)
        {
            Console.WriteLine("Добавление студента:");

            string? imya = VvodStroki("Введите имя: ");
            if (string.IsNullOrEmpty(imya))
            {
                VivestiSoobshenie("Имя не может быть пустым.");
                return;
            }

            string? familia = VvodStroki("Введите фамилию: ");
            if (string.IsNullOrEmpty(familia))
            {
                VivestiSoobshenie("Фамилия не может быть пустой.");
                return;
            }

            DateTime dataRozhdeniya;
            while (true)
            {
                string? vvod = VvodStroki("Введите дату рождения (гггг-мм-дд): ");
                if (DateTime.TryParse(vvod, out dataRozhdeniya))
                    break;
                else
                    VivestiSoobshenie("Некорректная дата рождения.");
            }

            double sredniyBall;
            while (true)
            {
                string? vvod = VvodStroki("Введите средний балл: ");
                if (double.TryParse(vvod, out sredniyBall) && sredniyBall >= 0 && sredniyBall <= 5)
                    break;
                else
                    VivestiSoobshenie("Некорректный средний балл (должен быть от 0 до 5).");
            }

            try
            {
                Student noviyStudent = new Student
                {
                    Imya = imya,
                    Familia = familia,
                    DataRozhdeniya = dataRozhdeniya,
                    SredniyBall = sredniyBall
                };
                spisokStudentov.Add(noviyStudent);
                VivestiSoobshenie("Студент успешно добавлен.");
            }
            catch (Exception ex)
            {
                VivestiSoobshenie($"Ошибка: {ex.Message}");
            }
        }

        public static void UdalitStudenta(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            int id;
            while (true)
            {
                string? vvod = VvodStroki("Введите ID студента для удаления: ");
                if (int.TryParse(vvod, out id) && id > 0)
                    break;
                else
                    VivestiSoobshenie("Некорректный ID.");
            }

            var student = spisokStudentov.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                spisokStudentov.Remove(student);
                VivestiSoobshenie("Студент удален.");
            }
            else
            {
                VivestiSoobshenie("Студент с указанным ID не найден.");
            }
        }

        public static void NajtiStudentaPoId(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            int id;
            while (true)
            {
                string? vvod = VvodStroki("Введите ID студента: ");
                if (int.TryParse(vvod, out id) && id > 0)
                    break;
                else
                    VivestiSoobshenie("Некорректный ID.");
            }

            var student = spisokStudentov.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                VivestiSoobshenie(student.ToString());
            }
            else
            {
                VivestiSoobshenie("Студент не найден.");
            }
        }

        public static void SortirovatPoId(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            spisokStudentov.Sort();
            VivestiSpisok(spisokStudentov);
        }

        public static void SortirovatPoFamilii(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            spisokStudentov.Sort((x, y) => string.Compare(x.Familia ?? "", y.Familia ?? ""));
            VivestiSpisok(spisokStudentov);
        }

        public static void FiltrirovatPoSrednemuBallu(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            double minBall;
            while (true)
            {
                string? vvod = VvodStroki("Введите минимальный средний балл: ");
                if (double.TryParse(vvod, out minBall) && minBall >= 0 && minBall <= 5)
                    break;
                else
                    VivestiSoobshenie("Некорректный средний балл (должен быть от 0 до 5).");
            }

            var otfiltrovannyySpisok = spisokStudentov.Where(s => s.SredniyBall >= minBall).ToList();
            if (otfiltrovannyySpisok.Count > 0)
            {
                VivestiSoobshenie("Отфильтрованный список:");
                VivestiSpisok(otfiltrovannyySpisok);
            }
            else
            {
                VivestiSoobshenie("Студенты не найдены.");
            }
        }

        public static void RaschetSrednegoBall(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            double sredniyBall = spisokStudentov.Average(s => s.SredniyBall);
            VivestiSoobshenie($"Средний балл: {sredniyBall:F2}");
        }


        public static void NajtiSamogoStarshego(List<Student> spisokStudentov)
        {
            if (spisokStudentov == null || spisokStudentov.Count == 0)
            {
                VivestiSoobshenie("Список студентов пуст.");
                return;
            }

            var starshiy = spisokStudentov.OrderBy(s => s.DataRozhdeniya).FirstOrDefault();
            if (starshiy != null)
            {
                VivestiSoobshenie("Самый старший студент:");
                VivestiSoobshenie(starshiy.ToString());
            }
            else
            {
                VivestiSoobshenie("Студенты не найдены.");
            }
        }


        private static string? VvodStroki(string soobshenie)
        {
            Console.Write(soobshenie);
            return Console.ReadLine();
        }

        private static void VivestiSoobshenie(string soobshenie)
        {
            Console.WriteLine(soobshenie);
        }

        private static void VivestiSpisok(List<Student> spisokStudentov)
        {
            foreach (var student in spisokStudentov)
            {
                VivestiSoobshenie(student.ToString());
            }
        }
    }
}