using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pingis.Models;

namespace Pingis.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public TableTennisMatch Match { get; set; }

        public void OnGet()
        {
            // Initialiserar en ny match om det �r f�rsta g�ngen sidan bes�ks
            if (Match == null)
            {
                Match = new TableTennisMatch();
            }
        }

        public IActionResult OnPostAddPointToPlayer1()
        {
            if (Match == null)
            {
                Match = new TableTennisMatch();
            }
            Match.AddPointToPlayer1();
            return Page(); // Returnerar samma sida f�r att uppdatera visningen
        }

        public IActionResult OnPostAddPointToPlayer2()
        {
            if (Match == null)
            {
                Match = new TableTennisMatch();
            }
            Match.AddPointToPlayer2();
            return Page(); // Returnerar samma sida f�r att uppdatera visningen
        }
    }
}
