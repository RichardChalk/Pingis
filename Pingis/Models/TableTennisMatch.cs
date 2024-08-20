﻿namespace Pingis.Models
{
    public class TableTennisMatch
    {
        public int Id { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
        public bool IsPlayer1Serve { get; set; } = true;
        public int ServeCounter { get; set; } = 0;

        public void AddPointToPlayer1()
        {
            Player1Score++;
            CheckEndOfSet();
        }

        public void AddPointToPlayer2()
        {
            Player2Score++;
            CheckEndOfSet();
        }

        public string CheckEndOfSet()
        {
            if (Player1Score >= 11 && Math.Abs(Player1Score - Player2Score) >= 2)
            {
                // Markera set som över och hantera logik
                return "Player1";
            }
            if ((Player2Score >= 11) && Math.Abs(Player1Score - Player2Score) >= 2)
            {
                return "Player2";
            }
            return "Game in progress";
        }

        public void UpdateServe()
        {
            // Öka ServeCounter varje gång en poäng läggs till
            ServeCounter++;

            // När ServeCounter når 2, växla servern och nollställ räknaren
            if (ServeCounter >= 2)
            {
                IsPlayer1Serve = !IsPlayer1Serve; // Växla servern
                ServeCounter = 0; // Nollställ räknaren
            }
        }
    }
}
