using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Test_Site.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Test_Site.Models.Enum;
using Test_Site.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace Test_Site.Controllers
{
    public delegate Task<string> ImageUploadDelegate(IFormFile image, string uploadsFolder);
    public delegate IEnumerable<TutorsModel> FilterDelegate(IEnumerable<TutorsModel> tutors);

    public class TutorsController : Controller, ITutors
    {
        private readonly UserManager<Person> _userManager;
        private readonly TutorsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Статический делегат для загрузки изображений
        public static ImageUploadDelegate ImageUploadHandler = async (image, uploadsFolder) =>
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return uniqueFileName;
        };

        // Статические делегаты для фильтрации
        public static FilterDelegate FilterBySubjectHandler = (tutors) =>
        {
            return tutors.Where(t => t.Subjects == StaticFilterSubject);
        };

        public static FilterDelegate FilterByPriceRangeHandler = (tutors) =>
        {
            return tutors.Where(t => t.Price >= StaticMinPrice && t.Price <= StaticMaxPrice);
        };

        // Статические свойства для фильтрации
        public static Subjects StaticFilterSubject { get; set; }
        public static int StaticMinPrice { get; set; }
        public static int StaticMaxPrice { get; set; }

        public TutorsController(TutorsContext context, UserManager<Person> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TutorFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Использование статического делегата для загрузки изображения
                string uniqueFileName = model.Image != null ? await ImageUploadHandler(model.Image, uploadsFolder) : null;

                var tutor = new TutorsModel
                {
                    Subjects = model.Subjects,
                    Name = model.Name,
                    Description = model.Description,
                    Education = model.Education,
                    Skill = model.Skill,
                    Price = model.Price,
                    Checked = model.Checked,
                    Trial = model.Trial,
                    Image = uniqueFileName,
                    Email = model.Email,
                    Phone = model.Phone
                };

                _context.TutorsModels.Add(tutor);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(IndexTutors));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var teacher = _context.TutorsModels.FirstOrDefault(teacher => teacher.Id == Id);
            if (teacher != null)
            {
                TutorEditModel tutorFormViewModel = new TutorEditModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Description = teacher.Description,
                    Subjects = teacher.Subjects,
                    Education = teacher.Education,
                    Skill = teacher.Skill,
                    Price = teacher.Price,
                    Checked = teacher.Checked,
                    Trial = teacher.Trial,
                    Email = teacher.Email,
                    Phone = teacher.Phone
                };
                return View(tutorFormViewModel);
            }
            return RedirectToAction(nameof(IndexTutors));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TutorEditModel t)
        {
            if (ModelState.IsValid)
            {
                TutorsModel teacher = _context.TutorsModels.FirstOrDefault(teacher => teacher.Id == t.Id);
                if (teacher != null)
                {
                    teacher.Name = t.Name;
                    teacher.Description = t.Description;
                    teacher.Subjects = t.Subjects;
                    teacher.Education = t.Education;
                    teacher.Skill = t.Skill;
                    teacher.Price = t.Price;
                    teacher.Checked = t.Checked;
                    teacher.Trial = t.Trial;
                    teacher.Email = t.Email;
                    teacher.Phone = t.Phone;

                    _context.TutorsModels.Update(teacher);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(IndexTutors));
                }
            }
            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var teacher = _context.TutorsModels.FirstOrDefault(teacher => teacher.Id == Id);
            if (teacher != null)
            {
                _context.TutorsModels.Remove(teacher);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(IndexTutors));
        }

        public IActionResult IndexTutors()
        {
            List<TutorsModel> teachers = _context.TutorsModels.ToList();
            return View(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Filter(Subjects subject)
        {
            StaticFilterSubject = subject;
            var filteredTutors = FilterBySubjectHandler(_context.TutorsModels).ToList();
            return View("IndexTutors", filteredTutors);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByPrice(int minPrice, int maxPrice)
        {
            StaticMinPrice = minPrice;
            StaticMaxPrice = maxPrice;
            var filteredTutors = FilterByPriceRangeHandler(_context.TutorsModels).ToList();
            return View("IndexTutors", filteredTutors);
        }
    }
}
