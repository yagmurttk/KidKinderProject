using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class UpdateClassroomViewModel
    {
        public int ClassroomId { get; set; }
        [Required(ErrorMessage = "Sınıf adı boş bırakılamaz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Sınıf açıklaması boş bırakılamaz.")]
        [MinLength(20, ErrorMessage = "Minimum 20 karakter girmelisin.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Sınıf yaş aralığı boş bırakılamaz.")]
        public string AgeOfKids { get; set; }
        [Required(ErrorMessage = "Sınıf kapasitesi boş bırakılamaz.")]
        public byte TotalSeats { get; set; }
        [Required(ErrorMessage = "Çalışma saatleri boş bırakılamaz.")]
        public string ClassTime { get; set; }
        [Required(ErrorMessage = "Fiyat boş bırakılamaz.")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}