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

        public List<TableTennisSet> Matches { get; set; }


        [BindProperty]
        public TableTennisSet CurrentSet { get; set; }

        [BindProperty]
        public string Winner { get; set; }

        public void OnGet()
        {
            // Initialiserar en ny match om det �r f�rsta g�ngen sidan bes�ks
            if (CurrentSet == null)
                CurrentSet = new TableTennisSet();

            _dbContext.Matches.Add(CurrentSet);
            _dbContext.SaveChanges();
        }

        public IActionResult OnPostAddPointToPlayer1(int Id)
        {
            var MatchToUpdate = _dbContext.Matches.Find(CurrentSet.Id);
            MatchToUpdate.AddPointToPlayer1();
            Winner = MatchToUpdate.CheckEndOfSet();
            MatchToUpdate.UpdateServe();
            _dbContext.SaveChanges();

            if (Winner != null)
            {
                // ResetSet();
            }

            CurrentSet = MatchToUpdate;
            return Page(); // Returnerar samma sida f�r att uppdatera visningen
        }

        public IActionResult OnPostAddPointToPlayer2(int Id)
        {
            var MatchToUpdate = _dbContext.Matches.Find(CurrentSet.Id);
            MatchToUpdate.AddPointToPlayer2();
            Winner = MatchToUpdate.CheckEndOfSet();
            MatchToUpdate.UpdateServe();
            _dbContext.SaveChanges();

            CurrentSet = MatchToUpdate;
            return Page(); // Returnerar samma sida f�r att uppdatera visningen
        }
    }
}
