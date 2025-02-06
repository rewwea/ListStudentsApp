using System;

namespace ListStudentsApp
{
    public class Student : IComparable<Student?>
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string? Imya { get; set; }
        public string? Familia { get; set; }
        public DateTime DataRozhdeniya { get; set; }
        public double SredniyBall { get; set; }

        public Student()
        {
            Id = nextId++;
        }

        public int CompareTo(Student? drugoy)
        {
            if (drugoy == null) return 1;
            return this.Id.CompareTo(drugoy.Id);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Imya ?? "Не указано"} {Familia ?? "Не указано"}, Дата рождения: {DataRozhdeniya.ToShortDateString()}, Средний балл: {SredniyBall}";
        }
    }
}