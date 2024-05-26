using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Test_Site.Models.Enum;

namespace Test_Site.Models
{
    public class TutorEditModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Предмети")]
        public Subjects Subjects { get; set; }

        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Освіта")]
        public string Education { get; set; }

        [Required]
        [Display(Name = "Досвід")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "Ціна")]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Електронна пошта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Перевірений репетитор")]
        public bool Checked { get; set; }

        [Display(Name = "Пробний урок безкоштовно")]
        public bool Trial { get; set; }
    }
}
