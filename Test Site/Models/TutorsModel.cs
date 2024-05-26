using Test_Site.Models.Enum;

namespace Test_Site.Models
{
    public class TutorsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Subjects Subjects { get; set; }
        public string Education { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Trial { get; set; }
        public bool Checked { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
