using Test_Site.Models;
using Test_Site.Models.Enum;
using Xunit;

namespace Test_Site.Tests.Models
{
    public class TutorsModelTests
    {
        [Fact]
        public void CanSetAndGetProperties()
        {
            var tutor = new TutorsModel();
            tutor.Id = 1;
            tutor.Name = "John Doe";
            tutor.Image = "johndoe.jpg";
            tutor.Subjects = Subjects.English;
            tutor.Education = "Master's Degree in English";
            tutor.Skill = "5 years of teaching experience";
            tutor.Description = "Experienced English tutor";
            tutor.Price = 500;
            tutor.Trial = true;
            tutor.Checked = false;
            tutor.Email = "john.doe@example.com";
            tutor.Phone = "+1234567890";
            Assert.Equal(1, tutor.Id);
            Assert.Equal("John Doe", tutor.Name);
            Assert.Equal("johndoe.jpg", tutor.Image);
            Assert.Equal(Subjects.English, tutor.Subjects);
            Assert.Equal("Master's Degree in English", tutor.Education);
            Assert.Equal("5 years of teaching experience", tutor.Skill);
            Assert.Equal("Experienced English tutor", tutor.Description);
            Assert.Equal(500, tutor.Price);
            Assert.True(tutor.Trial);
            Assert.False(tutor.Checked);
            Assert.Equal("john.doe@example.com", tutor.Email);
            Assert.Equal("+1234567890", tutor.Phone);
        }

        [Fact]
        public void DefaultValuesAreSetCorrectly()
        {
            var tutor = new TutorsModel();
            Assert.Equal(0, tutor.Id);
            Assert.Null(tutor.Name);
            Assert.Null(tutor.Image);
            Assert.Equal((Subjects)0, tutor.Subjects);
            Assert.Null(tutor.Education);
            Assert.Null(tutor.Skill);
            Assert.Null(tutor.Description);
            Assert.Equal(0, tutor.Price);
            Assert.False(tutor.Trial);
            Assert.False(tutor.Checked);
            Assert.Null(tutor.Email);
            Assert.Null(tutor.Phone);
        }

        [Theory]
        [InlineData(Subjects.English)]
        [InlineData(Subjects.Mathematics)]
        [InlineData(Subjects.Ukrainian)]
        [InlineData(Subjects.Japanese)]
        [InlineData(Subjects.Painting)]
        public void CanSetDifferentSubjects(Subjects subject)
        {
            var tutor = new TutorsModel();
            tutor.Subjects = subject;
            Assert.Equal(subject, tutor.Subjects);
        }
    }
}
