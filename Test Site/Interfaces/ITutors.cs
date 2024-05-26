using Microsoft.AspNetCore.Mvc;
using Test_Site.Models.Enum;

namespace Test_Site.Interfaces
{
    public interface ITutors
    {
        public IActionResult Create();
        public Task<IActionResult> Edit(int Id);
        public Task<IActionResult> Delete(int Id);
        public IActionResult IndexTutors();
        public Task<IActionResult> Filter(Subjects subject);
        public Task<IActionResult> FilterByPrice(int minPrice, int maxPrice);

    }
}
