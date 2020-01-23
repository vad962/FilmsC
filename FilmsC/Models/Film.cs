using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmsC.Models
{
    public class Film
    {
        #region Properties

        //Первичный ключ
        public int ID { get; set; }
        //Название фильма
        [Required]
        [StringLength(255)]
        [Display(Name = "Название фильма")]
        public string Name { get; set; }
        //Описание фильма
        [Required]
        [StringLength(255)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        //Год выпуска фильма
        [Required]
        [StringLength(10)]
        [Display(Name = "Год выпуска")]
        public string Year { get; set; }
        //Режиссер
        [Required]
        [StringLength(255)]
        [Display(Name = "Режиссер")]
        public string Producer { get; set; }
        //Жанр
        [Required]
        [StringLength(255)]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }
        //Владелец записи
        [Required]
        [StringLength(255)]
        [Display(Name = "Добавил")]
        public string Owner { get; set; }
        //------------------------------------------------
        //Коллекция картинок - постер
        //Картинка - постер
        public byte[] Poster { get; set; }
        //Картинка
        //Название картинки
        [StringLength(255)]
        public string PosterName { get; set; }
        //Тип картинки
        [StringLength(100)]
        public string ContentType { get; set; }
        //-------------------------------------------------
        #endregion Properties

        #region Constructor

        public Film()
        {
        }

        #endregion Constructor

        #region Events

        //--------------------------------------------------
        //Реализация события PropertyChanged
        //--------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion Events
    }
}