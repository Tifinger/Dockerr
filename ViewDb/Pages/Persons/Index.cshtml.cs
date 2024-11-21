using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ViewDb.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly PersonDbContext _context;

        public List<Person> Persons { get; set; }

        public IndexModel(PersonDbContext context)
        {
            Console.WriteLine("IndexModel konstruktora");
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Console.WriteLine("OnGetAsync hivas ELEJE");
            Persons = await _context.Persons.ToListAsync();
        }
    }
}
