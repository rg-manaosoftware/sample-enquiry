using Sample.Enquiry.Core;
using Sample.Enquiry.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sample.Enquiry.Api.Pages.ToDoRazorPage
{
    public class PopulateModel : PageModel
    {
        private readonly IRepository _repository;

        public PopulateModel(IRepository repository)
        {
            _repository = repository;
        }

        public int RecordsAdded { get; set; }

        public void OnGet()
        {
            RecordsAdded = DatabasePopulator.PopulateDatabase(_repository);
        }
    }
}
