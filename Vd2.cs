using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public override string ToString() => $"ID:{Id}, Name:{Name}, Age:{Age}, GPA:{GPA}";
    }

    class Program
    {
        static List<Student> students = new();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n1.QLSV  99.Thoat");
                int.TryParse(Console.ReadLine(), out choice);
                if (choice == 1) ManageStudents();
            } while (choice != 99);
        }

        static void ManageStudents()
        {
            int c;
            do
            {
                Console.WriteLine("\n1.Them 2.Xoa 3.CapNhat 4.HienThi 5.TimTen 6.GPA>8 7.SortTen 8.SortGPA 9.Back");
                int.TryParse(Console.ReadLine(), out c);
                switch (c)
                {
                    case 1:
                        students.Add(new Student
                        {
                            Id = Input("ID:"),
                            Name = Input("Ten:"),
                            Age = int.Parse(Input("Tuoi:")),
                            GPA = double.Parse(Input("GPA:"))
                        });
                        break;
                    case 2:
                        students.RemoveAll(s => s.Id == Input("Nhap ID can xoa:"));
                        break;
                    case 3:
                        var id = Input("Nhap ID can cap nhat:");
                        var sv = students.FirstOrDefault(s => s.Id == id);
                        if (sv != null)
                        {
                            sv.Name = Input("Ten moi:");
                            sv.Age = int.Parse(Input("Tuoi moi:"));
                            sv.GPA = double.Parse(Input("GPA moi:"));
                        }
                        break;
                    case 4:
                        students.ForEach(s => Console.WriteLine(s));
                        break;
                    case 5:
                        var name = Input("Nhap ten:");
                        students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                                .ToList().ForEach(s => Console.WriteLine("Tim thay: " + s));
                        break;
                    case 6:
                        students.Where(s => s.GPA > 8).ToList().ForEach(s => Console.WriteLine("Gioi: " + s));
                        break;
                    case 7:
                        students = students.OrderBy(s => s.Name).ToList(); break;
                    case 8:
                        students = students.OrderByDescending(s => s.GPA).ToList(); break;
                }
            } while (c != 9);
        }

        static string Input(string msg) { Console.Write(msg); return Console.ReadLine(); }
    }
}
