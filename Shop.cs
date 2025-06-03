using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd1_Demin_2
{
    class Shop
    {
        private Dictionary<Product, int> products;
        private double profit;//прибыль
        public Shop()
        {
            products = new Dictionary<Product, int>();//Библиотека товаров
        }
        public double GetProf()//Добавление продукта в массив
        {
            return profit;
        }
        public void AddProduct(Product product, int count)//Добавление продукта в массив
        {
            products.Add(product, count);
        }
        public void CreateProduct(string name, decimal price, int count)//Созданиепродукта
        {
            products.Add(new Product(name, price), count);
        }
        
        public string WriteAllProducts()//вывод всех продуктов
        {
            string s = "";
            s+=("Список продуктов: ");
            foreach (var product in products)
            {
                s += "\n";
                s += (product.Key.GetInfo() + "; Количество: " + product.Value);//Вывод всех продуктов в массиве
            }
            return s;
        }
        public Product FindByName(string name)//Нахождение совпадений товаров по имени
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
        public void Sell(string ProductName,int count)//Перегрузка продажа товара
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                this.Sell(ToSell,count);
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }


        
        }

        public bool CheckforCount(string name,int count)
        {
            Product ToSell = FindByName(name);
            if (ToSell != null)
            {
                if (products.ContainsKey(ToSell))
                {
                    if (products[ToSell] == 0)
                    {
                        MessageBox.Show("Нет в наличии!");
                        return false;
                    }
                    else
                    {
                        if (count > products[ToSell])
                        {
                            MessageBox.Show("Нет такого количества товара в наличии Выберите ещё раз");
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
                return false;
            }
        }

        public void Sell(Product product,int count)//Продажа товара
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    MessageBox.Show("Нет в наличии!");
                }
                else
                {
                    if (count > products[product])
                    {
                        MessageBox.Show("Нет такого количества товара в наличии Выберите ещё раз");

                    }
                    else
                    {
                        ProfitCount(Convert.ToInt32(product.Price),products[product]);
                        products[product] -= count;
                    }
                }
            }
            else
            {
               MessageBox.Show("Товар не найден!");
            }
        }

        public void ProfitCount(int price,int count)//Подсчёт сколько магазин получил прибыли за продажу товара
        {
            profit += price*count;
        }

        public void ProfitCount(int price, int count,int Coefficient)//Подсчёт сколько магазин потратил на товары
        {
            profit -= price * count/Coefficient;
        }
    }
}
