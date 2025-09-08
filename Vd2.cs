using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagement
{
    // Định nghĩa class Student thay cho lưu trữ string
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, GPA: {GPA}";
        }
    }

    public class SchoolProgram
    {
        private static List<Student> students = new List<Student>();

        public static void Main(string[] args)
        {
            int menu = 0;
            while (menu != 99)
            {
                Console.WriteLine("============= MENU CHINH =============");
                Console.WriteLine("1. Quan ly Sinh vien");
                Console.WriteLine("99. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out menu))
                {
                    Console.WriteLine("Nhap sai, vui long nhap so.");
                    continue;
                }

                if (menu == 1)
                {
                    ManageStudents();
                }
            }
        }

        private static void ManageStudents()
        {
            int smenu = 0;
            while (smenu != 9)
            {
                Console.WriteLine("--- QUAN LY SINH VIEN ---");
                Console.WriteLine("1. Them SV");
                Console.WriteLine("2. Xoa SV");
                Console.WriteLine("3. Cap nhat SV");
                Console.WriteLine("4. Hien thi tat ca SV");
                Console.WriteLine("5. Tim SV theo ten");
                Console.WriteLine("6. Tim SV GPA > 8");
                Console.WriteLine("7. Sap xep theo ten");
                Console.WriteLine("8. Sap xep theo GPA");
                Console.WriteLine("9. Quay lai");

                if (!int.TryParse(Console.ReadLine(), out smenu))
                {
                    Console.WriteLine("Nhap sai, vui long nhap so.");
                    continue;
                }

                switch (smenu)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        RemoveStudent();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        ShowAllStudents();
                        break;
                    case 5:
                        FindStudentByName();
                        break;
                    case 6:
                        ShowGoodStudents();
                        break;
                    case 7:
                        SortByName();
                        break;
                    case 8:
                        SortByGPA();
                        break;
                }
            }
        }

        private static void AddStudent()
        {
            Console.Write("Nhap id: ");
            string id = Console.ReadLine();
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhap GPA: ");
            double gpa = double.Parse(Console.ReadLine());

            students.Add(new Student { Id = id, Name = name, Age = age, GPA = gpa });
            Console.WriteLine("Da them sinh vien thanh cong!");
        }

        private static void RemoveStudent()
        {
            Console.Write("Nhap id can xoa: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Da xoa sinh vien.");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
        }

        private static void UpdateStudent()
        {
            Console.Write("Nhap id can cap nhat: ");
            string id = Console.ReadLine();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Nhap ten moi: ");
                student.Name = Console.ReadLine();
                Console.Write("Nhap tuoi moi: ");
                student.Age = int.Parse(Console.ReadLine());
                Console.Write("Nhap GPA moi: ");
                student.GPA = double.Parse(Console.ReadLine());
                Console.WriteLine("Cap nhat thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien.");
            }
        }

        private static void ShowAllStudents()
        {
            if (!students.Any())
            {
                Console.WriteLine("Danh sach rong.");
                return;
            }
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }

        private static void FindStudentByName()
        {
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();
            var result = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            foreach (var s in result)
            {
                Console.WriteLine("Tim thay: " + s);
            }
        }

        private static void ShowGoodStudents()
        {
            var goodStudents = students.Where(s => s.GPA > 8);
            foreach (var s in goodStudents)
            {
                Console.WriteLine("Sinh vien gioi: " + s);
            }
        }

        private static void SortByName()
        {
            students = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("Da sap xep theo ten.");
        }

        private static void SortByGPA()
        {
            students = students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine("Da sap xep theo GPA.");
        }
    }
}
