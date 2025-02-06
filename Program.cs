using System;
using System.Collections.Generic;
using ListStudentsApp;
class Program
{
    static void Main(string[] args)
    {
        List<Student> spisokStudentov = new List<Student>();
        bool vuvod = false;

        while (!vuvod)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Найти студента по ID");
            Console.WriteLine("4. Отсортировать по ID");
            Console.WriteLine("5. Отсортировать по фамилии");
            Console.WriteLine("6. Фильтр по среднему баллу");
            Console.WriteLine("7. Расчет среднего балла");
            Console.WriteLine("8. Найти самого старшего студента");
            Console.WriteLine("9. Выйти");

            Console.Write("Выберите действие: ");
            string? vibor = Console.ReadLine();

            switch (vibor)
            {
                case "1":
                    DobavitStudenta(spisokStudentov);
                    break;
                case "2":
                    UdalitStudenta(spisokStudentov);
                    break;
                case "3":
                    NajtiStudentaPoId(spisokStudentov);
                    break;
                case "4":
                    SortirovatPoId(spisokStudentov);
                    break;
                case "5":
                    SortirovatPoFamilii(spisokStudentov);
                    break;
                case "6":
                    FiltrirovatPoBallu(spisokStudentov);
                    break;
                case "7":
                    RaschetSrednegoBall(spisokStudentov);
                    break;
                case "8":
                    NajtiSamogoStarshego(spisokStudentov);
                    break;
                case "9":
                    vuvod = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void DobavitStudenta(List<Student> spisokStudentov)
    {
        Console.Write("Введите имя: ");
        string? imya = Console.ReadLine();
        Console.Write("Введите фамилию: ");
        string? familia = Console.ReadLine();

        if (imya == null || familia == null)
        {
            Console.WriteLine("Введены некорректные данные.");
            return;
        }

        Console.Write("Введите дату рождения (гггг-мм-дд): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataRozhdeniya))
        {
            Console.WriteLine("Некорректная дата рождения.");
            return;
        }

        Console.Write("Введите средний балл: ");
        if (!double.TryParse(Console.ReadLine(), out double sredniyBall))
        {
            Console.WriteLine("Некорректный средний балл.");
            return;
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
            StudentListOperations.DobavitStudenta(spisokStudentov, noviyStudent);
            Console.WriteLine("Студент успешно добавлен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void UdalitStudenta(List<Student> spisokStudentov)
    {
        Console.Write("Введите ID студента для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Некорректный ID.");
            return;
        }

        StudentListOperations.UdalitStudenta(spisokStudentov, id);
        Console.WriteLine("Студент удален.");
    }

    static void NajtiStudentaPoId(List<Student> spisokStudentov)
    {
        Console.Write("Введите ID студента: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Некорректный ID.");
            return;
        }

        Student? student = StudentListOperations.NajtiStudenta(spisokStudentov, id);
        if (student != null)
        {
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine("Студент не найден.");
        }
    }

    static void SortirovatPoId(List<Student> spisokStudentov)
    {
        StudentListOperations.SortirovatPoId(spisokStudentov);
        Console.WriteLine("Список отсортирован по ID.");
        VivestiSpisok(spisokStudentov);
    }

    static void SortirovatPoFamilii(List<Student> spisokStudentov)
    {
        StudentListOperations.SortirovatPoFamilii(spisokStudentov);
        Console.WriteLine("Список отсортирован по фамилии.");
        VivestiSpisok(spisokStudentov);
    }

    static void FiltrirovatPoBallu(List<Student> spisokStudentov)
    {
        Console.Write("Введите минимальный средний балл: ");
        if (!double.TryParse(Console.ReadLine(), out double minBall))
        {
            Console.WriteLine("Некорректный средний балл.");
            return;
        }

        List<Student> otfiltrovannyySpisok = StudentListOperations.FiltrirovatPoSrednemuBallu(spisokStudentov, minBall);
        Console.WriteLine("Отфильтрованный список:");
        VivestiSpisok(otfiltrovannyySpisok);
    }

    static void RaschetSrednegoBall(List<Student> spisokStudentov)
    {
        double sredniyBall = StudentListOperations.RaschetSrednegoBall(spisokStudentov);
        Console.WriteLine($"Средний балл: {sredniyBall}");
    }

    static void NajtiSamogoStarshego(List<Student> spisokStudentov)
    {
        Student? starshiy = StudentListOperations.NajtiSamogoStarshego(spisokStudentov);
        if (starshiy != null)
        {
            Console.WriteLine("Самый старший студент:");
            Console.WriteLine(starshiy);
        }
        else
        {
            Console.WriteLine("Список пуст.");
        }
    }

    static void VivestiSpisok(List<Student> spisokStudentov)
    {
        foreach (var student in spisokStudentov)
        {
            Console.WriteLine(student);
        }
    }
}