using System;

namespace ex3_working_with_delegates_and_events
{
    // create a delegate
    public delegate void WinnerAnnouncement(int winner);

    public class Race
    {
        // create a delegate event object
        public event WinnerAnnouncement OnWinnerAnnounced;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champion = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {
                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champion = i;
                        done = true;
                        continue;
                    }
                }
            }

            TheWinner(champion);
        }

        private void TheWinner(int championion)
        {
            Console.WriteLine("We have a winner!");
            OnWinnerAnnounced?.Invoke(championion);
        }
    }

    class Program
    {
        public static void Main()
        {
            
            Race round1 = new Race();

            
            WinnerAnnouncement raceDelegate;

            
            round1.OnWinnerAnnounced += raceDelegate = new WinnerAnnouncement(footRace);

            
            round1.OnWinnerAnnounced += footRace;
            round1.Racing(5, 10);

            
            round1.OnWinnerAnnounced += carRace;
            round1.Racing(3, 10);

            
            round1.OnWinnerAnnounced += winner => Console.WriteLine($"Biker number {winner} is the winner.");
            round1.Racing(4, 10);
        }

       
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}