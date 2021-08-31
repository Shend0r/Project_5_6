using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5_6
{
    internal class Program
    {
        private static (string FirstName, string LastName, byte Age, bool HaveAPet, int PetsQuantity, string PetsNames, ushort LikeColorsQuantity, string LikeColorsNames) GetUserData()
        {
            (string FirstName, string LastName, byte Age, bool HaveAPet, int PetsQuantity, string PetsNames, ushort LikeColorsQuantity, string LikeColorsNames) User;

            #region FirstName and LastName
            Console.WriteLine("Введите ваше Имя :");
            User.FirstName = Console.ReadLine();

            Console.WriteLine("Введите вашу Фамилию :");
            User.LastName = Console.ReadLine();
            #endregion

            #region Age

            string age;
            int corrcetage;

            do
            {
                Console.WriteLine("Введите ваш Возраст (Цифрами) :");
                age = Console.ReadLine();
            }
            while (ChekValue(age, 1, out corrcetage));

            User.Age = (byte)corrcetage;
            #endregion

            #region Pets
            User.HaveAPet = false; // Присвоены начальные значения, иначе ошибка будет. И приложение не скомпилируется.
            User.PetsQuantity = 0;
            User.PetsNames = "";

            Console.WriteLine("Имеет ли пользователь питомца (Да) :");

            string pets_quantity;
            int correct_pets_quantity;
     
            if (Console.ReadLine() == "Да")
            {
                User.HaveAPet = true;

                do
                {
                    Console.WriteLine("Какое количество питомцев имеет пользователь :");
                    pets_quantity = Console.ReadLine();
                }
                while (ChekValue(pets_quantity, 1, out correct_pets_quantity));

                User.PetsQuantity = (byte)correct_pets_quantity;

                Console.WriteLine("Введите Имена ваших петомцев через запятую (Пример : Маруся, Кеша, Бобик) :");
                User.PetsNames = Console.ReadLine();
            }   
            else
            {
                
            }
            #endregion

            #region LikeColors
            User.LikeColorsQuantity = 0; // Присвоены начальные значения, иначе ошибка будет. И приложение не скомпилируется.
            User.LikeColorsNames = "";

            string colors_quantity;
            int correct_colors_quantity;

            do
            {
                Console.WriteLine("Введите количество любимых цветов :");
                colors_quantity = Console.ReadLine();
            }
            while (ChekValue(colors_quantity, 0, out correct_colors_quantity)); // Не имеет смысл делать проверку на 0 здесь, поскольку цветов может и не быть (Только если не делать по примеру Питомцев имеет или не имеет пользователь). Поэтому в проверку на 0, было добавлено минимальное значение

            User.LikeColorsQuantity = (ushort)correct_colors_quantity;

            if (User.LikeColorsQuantity > 0)
            {
                Console.WriteLine("Введите Названия ваших любимых цветов через запятую (Пример : Красный, Зелёный, Синий) :");

                User.LikeColorsNames = Console.ReadLine();
            }
            #endregion

            ShowProfile(User.FirstName, User.LastName, User.Age, User.HaveAPet, User.PetsQuantity, User.PetsNames, User.LikeColorsQuantity, User.LikeColorsNames);

            return User;
        }

        private static void Main(string[] args)
        {
            GetUserData(); // Не уверен что именно так это должно быть реализовано
            Console.ReadKey();
        }

        private static void ShowProfile(string FirstName, string LastName, byte Age, bool HaveAPet, int PetsQuantity, string PetsNames, ushort LikeColorsQuantity, string LikeColorsNames)
        {
            Console.WriteLine("\nПрофиль пользователя :\n");
            Console.WriteLine($"\tИмя --- {FirstName}");
            Console.WriteLine($"\tФамилия --- {LastName}");
            Console.WriteLine($"\tВозраст --- {Age}\n");

            if (HaveAPet == true)
            {
                Console.WriteLine($"\t--------------------");
                Console.WriteLine($"\tСписок питомцев :\n");

                var NamesData = PetsNames.Split(',', ' '); // Я не уверен что массив такого типа был по заданию, но всё равно массив, да и всё равно работает как задумано

                foreach (string Data in NamesData)
                {
                    Console.WriteLine($"\t{Data}");
                }
                Console.WriteLine($"\t--------------------");
            }
            else
            {
                Console.WriteLine($"\tПитомцы отсутствуют.\n");
            }

            if (LikeColorsQuantity > 0)
            {
                Console.WriteLine($"\t--------------------");
                Console.WriteLine($"\tЛюбимые цвета :\n");

                var NamesData = LikeColorsNames.Split(',', ' '); // Я не уверен что массив такого типа был по заданию, но всё равно массив, да и всё равно работает как задумано

                foreach (string Data in NamesData)
                {
                    Console.WriteLine($"\t{Data}");
                }
                Console.WriteLine($"\t--------------------");
            }
            else
            {
                Console.WriteLine($"\tЛюбимые цвета отсутствуют.\n");
            }
        }

        private static bool ChekValue(string Value, int MinValue, out int CorrectValue)
        {
            if(int.Parse(Value) > MinValue - 1)
            {
                CorrectValue = int.Parse(Value);
                return false;
            }
            // Честно говоря думал что тут обязательно что-то должно быть
            {
                CorrectValue = 0;
                return true;
            }
        }
    }
}
