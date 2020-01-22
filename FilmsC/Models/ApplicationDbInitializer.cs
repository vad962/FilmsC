using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace FilmsC.Models
{
    public class ApplicationDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var films = new List<Film>
            //{
            //    new Film { Name="Один дома",Description="Семья Кевина уезжает в отпуск...",Year="1990", Producer = "Джон Хьюз", Genre = "Комедия", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="Три секунды",Description="Три секунды - время полета пули, выпущенной из снайперской винтовки с расстояния 1 500 метров. Именно столько времени остается, чтобы принять решение...",Year="2019", Producer = "Андрео Ди Стефано", Genre = "Криминал. Драма." },
            //    new Film { Name="Ричард прощается",Description="Профессор колледжа решает жить на полную катушку после того, как ему ставят серьезный диагноз...",Year="2018", Producer = "Уэйн Робертс", Genre = "Драма. Комедия.", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="К звездам",Description="Инженер армейского корпуса путешествует по Галактике в поисках отца, который отправился на поиски внеземной цивилизации 20 лет назад...",Year="2019", Producer = "Джеймс Грэй", Genre = " Приключения. Драма. Детектив. Фантастика. Триллер.", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="Форсаж: Хоббс и Шоу",Description="Превосходный спецагент, боец и стрелок Люк Хоббс вынужден объединиться со своим старым врагом, опаснейшим преступником Деккардом Шоу, чтобы противостоять общему противнику...",Year="2019", Producer = "Дэвид Литч", Genre = "Боевик. Приключения. Триллер.", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="Человек-паук: Вдали от дома",Description="Питер Паркер вместе с друзьями отправляется на летние каникулы в Европу. Однако отдохнуть приятелям вряд ли удастся...",Year="2019", Producer = " Джонатан Уоттс", Genre = "Боевик. Приключения. Фантастика.", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="Тайная жизнь домашних животных 2",Description="Почему человек так долго спит утром? Чем вкусно пахнет? Дай мне, дай, дай, дай! Как заставить человека чесать за ушком весь день?",Year="2019", Producer = "Chris Renaud, Jonathan del Val", Genre = "Мультфильм. Приключения. Комедия. Семейный.", Owner = "A", Poster = new byte[1], PosterName = "F1" },
            //    new Film { Name="Люди Икс: Темный феникс",Description="Джин Грей обретает невероятные суперспособности, которые меняют её и превращают в Темного Феникса. Теперь Людям Икс придется решить, что важнее для них...",Year="2019", Producer = "Саймон Кинберг", Genre = " Фантастика. Боевик. Приключения.", Owner = "A", Poster = new byte[1], PosterName = "F1" }
            //};


            var films = new List<Film>
            {
                new Film { Name="Один дома",Description="Семья Кевина уезжает в отпуск...",Year="1990", Producer = "Джон Хьюз", Genre = "Комедия", Owner = "", Poster = new byte[1], PosterName = "", ContentType = "" },
                new Film { Name="Три секунды",Description="Три секунды - время полета пули, выпущенной из снайперской винтовки с расстояния 1 500 метров. Именно столько времени остается, чтобы принять решение...",Year="2019", Producer = "Андрео Ди Стефано", Genre = "Криминал. Драма.", Owner = "Автор", Poster = new byte[1], PosterName = "Ф1", ContentType = "image/jpg" },
                new Film { Name="Ричард прощается",Description="Профессор колледжа решает жить на полную катушку после того, как ему ставят серьезный диагноз...",Year="2018", Producer = "Уэйн Робертс", Genre = "Драма. Комедия.", Owner = "Автор", Poster = new byte[1], PosterName = "Ф2", ContentType = "im" },
                new Film { Name="К звездам",Description="Инженер армейского корпуса путешествует по Галактике в поисках отца, который отправился на поиски внеземной цивилизации 20 лет назад...",Year="2019", Producer = "Джеймс Грэй", Genre = " Приключения. Драма. Детектив. Фантастика. Триллер.", Owner = "Автор", Poster = new byte[1], PosterName = "F3", ContentType = "im" },
                new Film { Name="Форсаж: Хоббс и Шоу",Description="Превосходный спецагент, боец и стрелок Люк Хоббс вынужден объединиться со своим старым врагом, опаснейшим преступником Деккардом Шоу, чтобы противостоять общему противнику...",Year="2019", Producer = "Дэвид Литч", Genre = "Боевик. Приключения. Триллер.", Owner = "Author", Poster = new byte[1], PosterName = "F4", ContentType = "im" },
                new Film { Name="Человек-паук: Вдали от дома",Description="Питер Паркер вместе с друзьями отправляется на летние каникулы в Европу. Однако отдохнуть приятелям вряд ли удастся...",Year="2019", Producer = " Джонатан Уоттс", Genre = "Боевик. Приключения. Фантастика.", Owner = "Auth", Poster = new byte[1], PosterName = "F5", ContentType = "im" },
                new Film { Name="Тайная жизнь домашних животных 2",Description="Почему человек так долго спит утром? Чем вкусно пахнет? Дай мне, дай, дай, дай! Как заставить человека чесать за ушком весь день?",Year="2019", Producer = "Chris Renaud, Jonathan del Val", Genre = "Мультфильм. Приключения. Комедия. Семейный.", Owner = "Auth", Poster = new byte[1], PosterName = "F6", ContentType = "Im" },
                new Film { Name="Люди Икс: Темный феникс",Description="Джин Грей обретает невероятные суперспособности, которые меняют её и превращают в Темного Феникса. Теперь Людям Икс придется решить, что важнее для них...",Year="2019", Producer = "Саймон Кинберг", Genre = " Фантастика. Боевик. Приключения.", Owner = "Auth", Poster = new byte[1], PosterName = "F7", ContentType = "Img" }
            };


            try
            {

                films.ForEach(s => context.Films.Add(s));
                context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                string errStr = "";
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    errStr += "Object: " + validationError.Entry.Entity.ToString() + "\n";

                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        errStr += err.ErrorMessage + "\n";
                        Console.WriteLine(errStr);
                    }
                }
            }
        }
    }
}