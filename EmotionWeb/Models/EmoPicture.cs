using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmotionWeb.Models
{
    public class EmoPicture
    {
        public int Id { get; set; }
        [Display(Name = "Nombre foto")]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }

        public virtual ObservableCollection<EmoFace> Faces { get; set; } //Arreglo para asignar muchos rostros a una fotografia
    }
}