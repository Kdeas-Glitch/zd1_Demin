using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_Demin_1
{
    class Cat
    {
        public Cat(string CatName,double CatWeight)
        {
            Name = CatName;
            Weight = CatWeight;
        }
        private double weight; // скрытое поле
        private string name; // скрытое поле

        public double Weight // свойство, реализуем инкапсуляцию!
        {
            // получение значения - просто возврат name
            get
            {
                return weight;
            }
            // установка значения - используем проверку
            set
            {
                // ключ. слово value - это то, что хотят свойству присвоить
                
                if (value > 0&&value<22&&name!="")
                {
                    weight = value;
                }
                else
                {
                    if (name == "")
                    {

                    }
                    else
                    Console.WriteLine($"{Name} - неправильный Вес!!!");
                }
            }
        }

        public string Name // свойство, реализуем инкапсуляцию!
        {
            // получение значения - просто возврат name
            get
            {
                return name;
            }
            // установка значения - используем проверку
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }


        public void Meow()
        {
            if (name != null&&weight!=null)
            {
                Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
            }
        }
        public void SetCatName(string CatName)//Добавление нового кота с проверкой на наличие тлько букв
        {

            bool OnlyLetters = true;

            foreach (var ch in CatName)
            {
                if (!char.IsLetter(ch))
                {
                    OnlyLetters = false;
                }
            }

            if (OnlyLetters)
                name = CatName;
            else
                Console.WriteLine($"{CatName} - неправильное имя!!!");
        }

    }
}
