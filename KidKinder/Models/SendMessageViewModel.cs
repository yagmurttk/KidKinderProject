using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Ad soyad alanı boş geçilemez.")]
        [StringLength(30, ErrorMessage = "Lütfen en fazla 30 karaktere veri girişi yapınız.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karaktere veri girişi yapınız.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu alanı boş geçilemez.")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karaktere veri girişi yapınız.")]
        [MinLength(5, ErrorMessage = "Lütfen en az 5 karakter giriniz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Mesaj alanı boş geçilemez.")]
        [StringLength(1000, ErrorMessage = "Lütfen en az veri girişi yapınız.")]
        public string Message { get; set; }
    }
}