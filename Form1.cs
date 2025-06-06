using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd1_Demin_2
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> Basket = new Dictionary<string, int>();
        List<string> names = new List<string>();
        Playlist playlist = new Playlist();
        public Form1()
        {
            InitializeComponent();
        }
        Shop pyaterochka = new Shop();


        

        private void showEl()//Показать все товары в магазине
        {
            listBox1.Items.Clear();
            string q = pyaterochka.WriteAllProducts();
            string[] s = q.Split('\n');
            for (int i = 0; i < s.Length; i++)
            {
                listBox1.Items.Add(s[i]);
            }

            listBox1.Items.Add($"Прибыль магазина {pyaterochka.GetProf()}");//Вывод прибыли магазина
        }

        private void Введение_Базовый_Данных(object sender, EventArgs e)
        {
            pyaterochka.CreateProduct("Кола", 85, 200);
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, 50);
            showEl();
        }

        private void Добавить_в_Корзину(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//Проверка на пустое имя товара
            {
                string name = textBox1.Text;
                int count = Convert.ToInt32(numericUpDown1.Value);
                if (Basket.ContainsKey(name))
                {
                    MessageBox.Show("Товар уже добавлен");
                }
                else
                {
                    if (pyaterochka.CheckforCount(name, count))
                    {
                        listBox2.Items.Add($"{name} {count}");
                        names.Add(name);
                        Basket.Add(name, count);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите имя товара");
            }
        }

        private void Показать_все_элементы(object sender, EventArgs e)
        {
            showEl();
            listBox1.Items.Add($"Прибыль магазина {pyaterochka.GetProf()}");

        }

        private void Добавить_Товар(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string name = textBox2.Text;
                int count = Convert.ToInt32(numericUpDown2.Value);
                int price = Convert.ToInt32(numericUpDown3.Value);
                if (pyaterochka.FindByName(name) == null)//Проверка на наличие товара
                {
                    pyaterochka.CreateProduct(name, price, count);//Создание продукта
                    pyaterochka.ProfitCount(price, count, 10);//Подсчёт трат на этот продукт
                    showEl();

                }
                else
                {
                    MessageBox.Show("Такой товар уже есть");
                }
            }
            else
            {
                MessageBox.Show("Введите имя товара");
            }
        }

        private void Продать_Товары(object sender, EventArgs e)
        {
            for (int i = 0; i < names.Count; i++)
            {
                pyaterochka.Sell(names[i], Basket[names[i]]);
            }
            listBox2.Items.Clear();
            showEl();
        }

        private void Прейти_ко_2й_практике(object sender, EventArgs e)
        {
            panel2.Visible = false;//Спрятать третье задание
            panel1.Visible = true;//Показать все элементы относящиеся ко 2й практике
        }

        private void Пререйти_к_3й_практике(object sender, EventArgs e)
        {
            panel2.Visible = true;//Показать все элементы относящиеся ко 2й практике
        }

        private void Добавить_песню(object sender, EventArgs e)//Добавить песни по входгым данным
        {
            try
            {
                if (textBox3.Text != "" && textBox4.Text != "")//Проверка на пустые поля 
                {
                    if (textBox5.Text == ""&&textBox6.Text=="")//0 авторов
                    {
                        string filename = textBox3.Text;//имя файла песни
                        string title = textBox4.Text;//имя песни
                        playlist.AddSong(filename,title);//Добавть песню
                    }
                    else
                    {
                        if (textBox5.Text == "" && textBox6.Text != "")//1 автор во втором текстовом
                        {
                            string filename = textBox3.Text;//имя файла песни
                            string title = textBox4.Text;//имя песни
                            string author = textBox6.Text;//имя автора
                            playlist.AddSong(filename, title, author);//Добавить песню
                        }
                        else
                        {
                            if (textBox5.Text != "" && textBox6.Text == "")//1 автора
                            {
                                string filename = textBox3.Text;//имя файла песни
                                string title = textBox4.Text;//имя песни
                                string author = textBox5.Text;//имя автора
                                playlist.AddSong(filename, title, author);//Добавить песню
                            }
                            else
                            {
                                string filename = textBox3.Text;//имя файла песни
                                string title = textBox4.Text;//имя песни
                                string author = textBox5.Text;//имя автора
                                string author2 = textBox6.Text;//имя автора 2
                                playlist.AddSong(filename, title, author,author2);//Добавить песню
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Введите имя песни и имя файла");//Вывод об ошибке из за незаполненых данных
                }
                showSongs();
                }
            catch
            {
                MessageBox.Show("Введены неверные");//Вывод об ошибке в введённых данных
            }
        }

        void showSongs()//Метод показывающий все песни в листе
        {
            listBox3.Items.Clear();//очищаю поле с песнями
            for (int i = 0; i < playlist.GetCount(); i++)
            {
                listBox3.Items.Add(playlist.GetSong(i));//Добавляю песню в окно
            }
        }
        

        private void Следущая_песня(object sender, EventArgs e)//Переключение песни вперёд по списку
        {
            if (playlist.GetCount() > 0)
            {
                playlist.AddCurInd();//Добавить 1 к индексу текущей песни
                label12.Text= playlist.CurrentSong();//Вывод текущей песни на экран
            }
            else
            {
                MessageBox.Show("Нет песен чтобы играть");//Вывод об ошибке
            }
        }

        private void Предыдущая_песня(object sender, EventArgs e)//Переключение песни Назад по списку
        {
            if (playlist.GetCount() > 0)
            {
                playlist.MinusCurInd();//Убрать 1 у индексу текущей песни
                label12.Text = playlist.CurrentSong();//Вывод текущей песни на экран
            }
            else
            {
                MessageBox.Show("Нет песен чтобы играть");//Вывод об ошибке
            }
        }

        private void Играть_По_Индексу(object sender, EventArgs e)//Найти песню по индексу
        {
            if (playlist.GetCount() >= numericUpDown4.Value)
            {
                playlist.SetCurInd(Convert.ToInt32(numericUpDown4.Value));//Поставить индекс текущей песни по входным данным
                label12.Text = playlist.CurrentSong();//Вывод текущей песни на экран
            }
            else
            {
                MessageBox.Show("Нет песени с таким индексом чтобы играть");//Вывод об ошибке
            }
        }

        private void Играть_с_Начала(object sender, EventArgs e)//Сбросить индекс текущей песни
        {
            if (playlist.GetCount() > 0)
            {
                playlist.SetCurInd(1);//Сделать текущий индекс 1
                label12.Text = playlist.CurrentSong();//Вывод текущей песни на экран
            }
            else
            {
                MessageBox.Show("Нет песен чтобы играть");
            }
        }

        private void Удалить_по_Данному(object sender, EventArgs e)//Удалить песнб по одному из 3х данных
        {
            try
            {
                if ((string)comboBox1.SelectedItem == "Индекс")//Выборка по индексу
                {
                    playlist.Delete(Convert.ToInt32(textBox7.Text)-1);//Удалить песню
                    showSongs();//Показать все песани
                }
                else
                if ((string)comboBox1.SelectedItem == "Имя песни")//Выборка по имени песни
                {
                    playlist.Delete(textBox7.Text,"");//Удалить песню
                    showSongs();//Показать все песани
                }
                else
                    if ((string)comboBox1.SelectedItem == "Имя автора")//Выборка по имени песни
                {
                    playlist.Delete(textBox7.Text);//Удалить песню
                    showSongs();//Показать все песани
                }
                else
                {
                    MessageBox.Show("Выберите вариант!");//Вывод об ошибке
                }
                      
            }
            catch
            {
                MessageBox.Show("Неверные данные");//Вывод об ошибке
            }
        }

        private void Очистить_песни(object sender, EventArgs e)
        {
            playlist.Clear();//Очистить лист песен
            listBox3.Items.Clear();//очистить текстовый список песен
        }
    }
}
