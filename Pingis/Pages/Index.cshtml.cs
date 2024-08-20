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

        public List<TableTennisSet> Sets { get; set; }


        [BindProperty]
        public TableTennisSet CurrentSet { get; set; }
        public TableTennisSet DatabaseSet { get; set; }

        [BindProperty]
        public string Winner { get; set; }

        public void OnGet()
        {
            // Initialiserar en ny match om det är första gången sidan besöks
            if (CurrentSet == null)
                CurrentSet = new TableTennisSet();

            _dbContext.Sets.Add(CurrentSet);
            _dbContext.SaveChanges();
        }

        public IActionResult OnPostAddPointToPlayer1()
        {
            DatabaseSet = _dbContext.Sets.Find(CurrentSet.Id);
            DatabaseSet.AddPointToPlayer1();

            UpdateGame();

            return Page(); // Returnerar samma sida för att uppdatera visningen
        }
            

        public IActionResult OnPostAddPointToPlayer2()
        {
            DatabaseSet = _dbContext.Sets.Find(CurrentSet.Id);
            DatabaseSet.AddPointToPlayer2();

            UpdateGame();

            return Page(); // Returnerar samma sida för att uppdatera visningen
        }

        private void StartNewSet()
        {
            // Rensa ModelState för att undvika att gamla värden återkommer
            ModelState.Clear();

            // Skapa ett nytt set och lägg till det i databasen
            CurrentSet = new TableTennisSet();
            _dbContext.Sets.Add(CurrentSet);
            _dbContext.SaveChanges();

            // Återställ Winner till null för nästa omgång
            Winner = null;
        }

        private void UpdateGame()
        {
            Winner = DatabaseSet.CheckEndOfSet();
            DatabaseSet.UpdateServe();
            _dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(Winner))
            {
                StartNewSet();
            }
            else
            {
                CurrentSet = DatabaseSet;
            }
        }
    }
}
