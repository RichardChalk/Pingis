using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pingis.Models;
using System.Net;

namespace Pingis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<TableTennisMatch> Matches { get; set; }


        [BindProperty]
        public TableTennisMatch CurrentMatch { get; set; }

        public void OnGet()
        {
            // Initialiserar en ny match om det är första gången sidan besöks
            if (CurrentMatch == null)
                CurrentMatch = new TableTennisMatch();

            _dbContext.Matches.Add(CurrentMatch);
            _dbContext.SaveChanges();
        }

        public IActionResult OnPostAddPointToPlayer1(int Id)
        {
            var MatchToUpdate = _dbContext.Matches.Find(CurrentMatch.Id);
            MatchToUpdate.AddPointToPlayer1();
            CurrentMatch = MatchToUpdate;
            _dbContext.SaveChanges();
            return Page(); // Returnerar samma sida för att uppdatera visningen
        }

        public IActionResult OnPostAddPointToPlayer2(int Id)
        {
            var MatchToUpdate = _dbContext.Matches.Find(CurrentMatch.Id);
            MatchToUpdate.AddPointToPlayer2();
            CurrentMatch = MatchToUpdate;
            _dbContext.SaveChanges();
            return Page(); // Returnerar samma sida för att uppdatera visningen
        }
    }
}
