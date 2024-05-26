using Test_Site.Models;
using Xunit;

namespace Test_Site.Tests
{
    public class ViewProfileViewModelTests
    {
        [Fact]
        public void NameProperty_SetAndGet_ReturnsCorrectValue()
        {
            // Arrange
            var viewModel = new ViewProfileViewModel();
            var expectedName = "John Doe";

            // Act
            viewModel.Name = expectedName;
            var actualName = viewModel.Name;

            // Assert
            Assert.Equal(expectedName, actualName);
        }

        [Fact]
        public void PhoneNumberProperty_SetAndGet_ReturnsCorrectValue()
        {
            // Arrange
            var viewModel = new ViewProfileViewModel();
            var expectedPhoneNumber = "123-456-7890";

            // Act
            viewModel.PhoneNumber = expectedPhoneNumber;
            var actualPhoneNumber = viewModel.PhoneNumber;

            // Assert
            Assert.Equal(expectedPhoneNumber, actualPhoneNumber);
        }

        [Fact]
        public void EmailProperty_SetAndGet_ReturnsCorrectValue()
        {
            // Arrange
            var viewModel = new ViewProfileViewModel();
            var expectedEmail = "john.doe@example.com";

            // Act
            viewModel.Email = expectedEmail;
            var actualEmail = viewModel.Email;

            // Assert
            Assert.Equal(expectedEmail, actualEmail);
        }

        [Fact]
        public void ChangedProperty_DefaultValue_IsFalse()
        {
            // Arrange
            var viewModel = new ViewProfileViewModel();

            // Act
            var actualChanged = viewModel.Changed;

            // Assert
            Assert.False(actualChanged);
        }

        [Fact]
        public void ChangedProperty_SetAndGet_ReturnsCorrectValue()
        {
            // Arrange
            var viewModel = new ViewProfileViewModel();
            var expectedChanged = true;

            // Act
            viewModel.Changed = expectedChanged;
            var actualChanged = viewModel.Changed;

            // Assert
            Assert.Equal(expectedChanged, actualChanged);
        }
    }
}
