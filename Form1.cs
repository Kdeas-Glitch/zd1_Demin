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
        public Form1()
        {
            InitializeComponent();
        }
        Shop pyaterochka = new Shop();


        private void button1_Click(object sender, EventArgs e)//Ввод товаров
        {
            
            pyaterochka.CreateProduct("Кола", 85, 200);
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, 50);
            showEl();

        }

        private void pract2ToolStripMenuItem_Click(object sender, EventArgs e)//Практика 2 вилимая
        {
            panel1.Visible = true;//Показать все элементы относящиеся ко 2й практике

        }

        private void pract3ToolStripMenuItem_Click(object sender, EventArgs e)//Практика 3 видимая
        {
            panel1.Visible = false;//Скрыть все элементы относящиеся ко 2й практике
        }

        private void button3_Click(object sender, EventArgs e)//Показать все товары в магазине +прибыль магазина элементы
        {
            showEl();
            listBox1.Items.Add($"Прибыль магазина {pyaterochka.GetProf()}");
        }

        private void button2_Click(object sender, EventArgs e)//Продажа товара
        {

            if (textBox1.Text != "")//Проверка на пустое имя товара
            {
                string name = textBox1.Text;
                int count = Convert.ToInt32(numericUpDown1.Value);
                if (Basket.ContainsKey(name))
                {
                    MessageBox.Show("Товар уже добавлен");
                }
                else {
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

        private void button4_Click(object sender, EventArgs e)//Добавить товар
        {
            if (textBox2.Text != "")
            {
                string name = textBox2.Text;
                int count =Convert.ToInt32(numericUpDown2.Value);
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
            else{
                MessageBox.Show("Введите имя товара");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < names.Count; i++)
            {
                pyaterochka.Sell(names[i], Basket[names[i]]);
            }
            listBox2.Items.Clear();
            showEl();
        }
    }
}
