using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd1_Demin_2
{
    class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public string CurrentSong()//Текущая песня
        {
            if (list.Count > 0)
                return $"{list[currentIndex].Title} {list[currentIndex].Author} ";//Вернуть текущую песню
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");//Вывод об ошибке
        }

       public void AddSong(string filename,string title,string author)//Добавить песнб с автором
        {
            Song song = new Song();
            song.Author = author;
            song.Filename = filename;
            song.Title = title;
            list.Add(song);//Добавить песню
        }

        public void AddSong(string filename, string title)//Добавить песнб без авторов
        {
            Song song = new Song();
            song.Author = "Без автора";//Автор может отсутствовать
            song.Filename = filename;
            song.Title = title;
            list.Add(song);//Добавить песню
        }

        public void AddSong(string filename, string title, string author, string author2)//Добавить песнб с двумя авторами
        {
            Song song = new Song();
            song.Author = author+" "+author2;//У песни 2 автора
            song.Filename = filename;
            song.Title = title;
            list.Add(song);//Добавить песню
        }

        public int GetCount()//Получить количество песен
        {
            return list.Count();
        }

        public void AddCurInd()//Добавить 1 к индексу текущей песни
        {
            currentIndex++;
            if (currentIndex > list.Count-1)
            {
                currentIndex = 0;
            }
        }
        public void MinusCurInd()//Убавить 1 у индекса текущей песни
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = list.Count()-1;
            }
        }
        public void SetCurInd(int i)//Поставить входящий индекс как индекс текущей песни
        {
            if (i <= list.Count())
            {
                currentIndex = i-1;
            }
            else
            {
                MessageBox.Show("Неверный индекс");//Вывод об ошибке
            }
        }

        public string GetSong(int i)//Получить песню по индексу
        {
            return $"{list[i].Title} {list[i].Author} {list[i].Filename}";
        }

        public void Delete(int ind)//Удалить песню по индексу
        {
         for(int i = 0; i < list.Count(); i++)
            {
                if (i == ind)
                {
                    list.RemoveAt(ind);
                    return;
                }
            }
            MessageBox.Show("Нет Песни с таки Индексом");//Вывод об ошибке
        }

        public void Delete(string FileName, string a)//Удалить по имени песни
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Title == FileName)
                {
                    list.RemoveAt(i);
                    return;
                }
            }
            MessageBox.Show("Нет Песни с таки именем");//Вывод об ошибке
        }

        public void Delete(string Author)//Удалить по имени автору
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Author.Contains(Author))
                {
                    list.RemoveAt(i);
                    return;
                }
            }
            MessageBox.Show("Нет Песни с таки Автором");//Вывод об ошибке
        }

        public void Clear()//Очистить список
        {
            list.Clear();
        }
    }


}
