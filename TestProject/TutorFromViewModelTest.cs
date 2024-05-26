using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Test_Site.Models;
using Test_Site.Models.Enum;

namespace Test_Site.Tests
{
    public class TutorFormViewModelTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Name_Required(string name)
        {
            var model = new TutorFormViewModel { Name = name };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Name)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Description_Required(string description)
        {
            var model = new TutorFormViewModel { Description = description };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Description)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Education_Required(string education)
        {
            var model = new TutorFormViewModel { Education = education };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Education)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Skill_Required(string skill)
        {
            var model = new TutorFormViewModel { Skill = skill };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Skill)));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Price_NonNegative(int price)
        {
            var model = new TutorFormViewModel { Price = price };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Price)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("invalid_email")]
        public void Email_Valid(string email)
        {
            var model = new TutorFormViewModel { Email = email };
            var result = ValidateModel(model);

            Assert.Contains(result, v => v.MemberNames.Contains(nameof(TutorFormViewModel.Email)));
        }

        private static System.Collections.Generic.List<ValidationResult> ValidateModel(TutorFormViewModel model)
        {
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
