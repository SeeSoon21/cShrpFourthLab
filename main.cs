using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;




namespace just_try
{
    class Program
    {

        static void Main(string[] args)
        {

            Magazine objectMagazine1 = new Magazine("Космос", Frequency.Monthly, new DateTime(2023, 5, 27), 50);
            Magazine objectMagazine2 = new Magazine("Циклон", Frequency.Monthly, new DateTime(2021, 3, 19), 100);
            Magazine objectMagazine3 = new Magazine("Бегемот", Frequency.Yearly, new DateTime(2021, 3, 19), 275);
            Magazine objectMagazine4 = new Magazine("Шляпка", Frequency.Weekly, new DateTime(2019, 12, 19), 1234);
            Magazine objectMagazine5 = new Magazine("Соль", Frequency.Monthly, new DateTime(2021, 7, 19), 230);

            Article[] ArrayArticle1 = new Article[4];
            ArrayArticle1[0] = new Article(new Person("Анатолий", "Карапченко", new DateTime(2000, 6, 30)), "Картошка", 2.8);
            ArrayArticle1[1] = new Article(new Person("Вызымат", "Дурмалеев", new DateTime(2020, 1, 23)), "Барабир", 8.1);
            ArrayArticle1[2] = new Article(new Person("Сергей", "Довлатов", new DateTime(1983, 4, 21)), "Чемоданище", 8.9);
            ArrayArticle1[3] = new Article(new Person("Изольд", "Харетьянов", new DateTime(2021, 7, 1)), "Апочему", 7.8);
            Article[] ArrayArticle2 = new Article[2];
            ArrayArticle2[0] = new Article(new Person("Алексей", "Трынд", new DateTime(2000, 6, 30)), "Зефир", 9.9);
            ArrayArticle2[1] = new Article(new Person("Дмитрий", "Шляпников", new DateTime(2020, 1, 23)), "Бегемот", 4.5);
            Article[] ArrayArticle3 = new Article[1];
            ArrayArticle3[0] = new Article(new Person("Трофим", "Богоугодский", new DateTime(2000, 6, 30)), "Сказка о грешниках", 9.8);
            Article[] ArrayArticle4 = new Article[2];
            ArrayArticle4[0] = new Article(new Person("Житиг", "Житиев", new DateTime(2000, 6, 30)), "Крахмал", 1.3);
            ArrayArticle4[1] = new Article(new Person("Трисс", "Флисс", new DateTime(2000, 3, 30)), "Пальмовое масло", 3);
            Article[] ArrayArticle5 = new Article[2];
            ArrayArticle5[0] = new Article(new Person("Трисс", "Флисс", new DateTime(2000, 3, 30)), "Пальмовое масло", 3);
            ArrayArticle5[1] = new Article(new Person("Фродо", "Торбинс", new DateTime(1999, 7, 11)), "Хоббитания", 9.2);

            Person[] listEditors = new Person[4];
            listEditors[0] = new Person("Степан", "Крымалов", new DateTime(2018, 12, 16));
            listEditors[1] = new Person("Вызымат", "Дурмалеев", new DateTime(2020, 1, 23));
            listEditors[2] = new Person("Игорь", "Леопольдов", new DateTime(2013, 11, 4));
            listEditors[3] = new Person("Изольд", "Харетьянов", new DateTime(2021, 7, 1));

            objectMagazine1.AddArticles(ArrayArticle1);
            objectMagazine1.AddEditors(listEditors);
            objectMagazine2.AddArticles(ArrayArticle2);
            objectMagazine2.AddEditors(listEditors);
            objectMagazine3.AddArticles(ArrayArticle3);
            objectMagazine3.AddEditors(listEditors);
            objectMagazine4.AddArticles(ArrayArticle4);
            objectMagazine4.AddEditors(listEditors);
            objectMagazine5.AddArticles(ArrayArticle5);
            objectMagazine5.AddEditors(listEditors);


            ////////////////////////////////4-я лаба
            //I-e: Создать два объекта MagazineCollection с разными именами
            Console.WriteLine("------------------------------------4-я Лабораторная------------------------------------");
            Console.WriteLine("---------------------------------------1-e задание--------------------------------------");
            KeySelector<string> myKeySelectorFirst = delegate (Magazine magObj)
            {
                return magObj.Mag_title;
            };

            MagazineCollection<string> magazineCollectionFirst = new MagazineCollection<string>(myKeySelectorFirst);
            MagazineCollection<string> magazineCollectionSecond = new MagazineCollection<string>(myKeySelectorFirst);
            magazineCollectionFirst.CollectionName = "Первая коллекция";
            magazineCollectionSecond.CollectionName = "Вторая коллекция";
            
            //II-e: создать Listener и подписать его на MagazinesChanged обоих MagazineCollection("..First", "..Second")
            Listener listener = new Listener();
            magazineCollectionFirst.MagazinesChanged += listener.MagazinesChanged;
            magazineCollectionSecond.MagazinesChanged += listener.MagazinesChanged;

            //III-e)
            //1) добавление элементов
            magazineCollectionFirst.AddMagazines(objectMagazine1, objectMagazine2);
            magazineCollectionSecond.AddMagazines(objectMagazine3, objectMagazine4, objectMagazine5);
            Console.WriteLine("\n\nВывод magCollectionFirst:");
            Console.WriteLine(magazineCollectionFirst.ToShortString());
            Console.WriteLine("\n\nВывод magCollectionSecond:");
            Console.WriteLine(magazineCollectionSecond.ToShortString());

            //изменения свойств элементов, входящих в коллекцию
            objectMagazine2.EditionTitle = "Тыквёныш";
            objectMagazine3.DateEdition = new DateTime(2001, 12, 14);
            objectMagazine5.EditionCirculation = 300;


            //3) заменить один из элементов коллекции
            Magazine magazineTemp = new Magazine();
            magazineCollectionFirst.Replace(objectMagazine1, magazineTemp);
            objectMagazine1.EditionTitle = "Кряква";


            //IV-e)
            Console.WriteLine("\nВывод Listener:");
            Console.WriteLine(listener.ToString());

        }



        public static int CheckInt()
        {
            int number;
            
            while(!int.TryParse(Console.ReadLine(), out number) || number < 0)
            {
                Console.WriteLine("Неверный ввод! Введите ещё раз!");
            }

            return number;
           
        }





        
        

    }


}






