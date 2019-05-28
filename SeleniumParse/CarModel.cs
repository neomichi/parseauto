using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumParse
{
    public class CarModel
    {
        [Display(Name = "ид")]
        public Guid Id { get; set; }

        [Display(Name = "название")]
        public string Title { get; set; }       

        [Display(Name = "Год выпуска")]
        public string CreateYear { get; set; }

        [Display(Name = "Пробег")]
        public string Mileage { get; set; }

        [Display(Name = "Кузов")]
        public string Body { get; set; }

        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Display(Name = "Двигатель")]
        public string Engine { get; set; }

        [Display(Name = "Коробка")]
        public string Transmission { get; set; }

        [Display(Name = "Привод")]
        public string DriveUnit { get; set; }

        [Display(Name = "Руль")]
        public string SteeringWheel { get; set; }

        [Display(Name = "Состояние")]
        public string Condition { get; set; }

        [Display(Name = "Фотографии")]
        public List<string> Photos { get; set; }

    }

    ///Год выпуска	
}
