namespace Pingis.Models
{
    public class TableTennisMatch
    {
        public int Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public bool IsPlayer1Serve { get; set; } = true;
        public int? Player3Score { get; set; } // För dubbelspel
        public int? Player4Score { get; set; } // För dubbelspel
        public int CurrentServe { get; set; }

        public void AddPointToPlayer1()
        {
            Player1Score++;
            //CheckEndOfSet();
        }

        public void AddPointToPlayer2()
        {
            Player2Score++;
            //CheckEndOfSet();
        }

        public void CheckEndOfSet()
        {
            if ((Player1Score >= 11 || Player2Score >= 11) && Math.Abs(Player1Score - Player2Score) >= 2)
            {
                // Markera set som över och hantera logik
            }
            UpdateServe();
        }

        public void UpdateServe()
        {
            // Logik för att hantera vem som servar, baserat på poängen
        }
    }

}
