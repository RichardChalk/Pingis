using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pingis.Models;

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
            // Initialisera en ny match om det �r f�rsta g�ngen sidan bes�ks
            if (CurrentSet == null)
            {
                StartNewSet();
            }
        }

        public IActionResult OnPostAddPointToPlayer1()
        {
            DatabaseSet = _dbContext.Sets.Find(CurrentSet.Id);
            DatabaseSet.AddPointToPlayer1();

            UpdateGame();
            return Page();
        }

        public IActionResult OnPostAddPointToPlayer2()
        {
            DatabaseSet = _dbContext.Sets.Find(CurrentSet.Id);
            DatabaseSet.AddPointToPlayer2();

            UpdateGame();
            return Page();
        }

        public IActionResult OnPostStartNewGame()
        {
            StartNewSet();
            return Page();
        }

        private void StartNewSet()
        {
            // Rensa ModelState f�r att undvika att gamla v�rden �terkommer
            ModelState.Clear();

            // Skapa ett nytt set och l�gg till det i databasen
            CurrentSet = new TableTennisSet();
            _dbContext.Sets.Add(CurrentSet);
            _dbContext.SaveChanges();

            // �terst�ll Winner till null f�r n�sta omg�ng
            Winner = null;
        }

        private void UpdateGame()
        {
            Winner = DatabaseSet.CheckEndOfSet();
            DatabaseSet.UpdateServe();
            _dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(Winner))
            {
                // Stoppa spelet och v�nta p� att anv�ndaren startar ett nytt spel manuellt
            }
            else
            {
                CurrentSet = DatabaseSet;
            }
        }
    }
}
