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
            VivestiMenu();
            string? vibor = Console.ReadLine();

            switch (vibor)
            {
                case "1":
                    StudentListOperations.DobavitStudenta(spisokStudentov);
                    break;
                case "2":
                    StudentListOperations.UdalitStudenta(spisokStudentov);
                    break;
                case "3":
                    StudentListOperations.NajtiStudentaPoId(spisokStudentov);
                    break;
                case "4":
                    StudentListOperations.SortirovatPoId(spisokStudentov);
                    break;
                case "5":
                    StudentListOperations.SortirovatPoFamilii(spisokStudentov);
                    break;
                case "6":
                    StudentListOperations.FiltrirovatPoSrednemuBallu(spisokStudentov);
                    break;
                case "7":
                    StudentListOperations.RaschetSrednegoBall(spisokStudentov);
                    break;
                case "8":
                    StudentListOperations.NajtiSamogoStarshego(spisokStudentov);
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

    private static void VivestiMenu()
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
    }
}