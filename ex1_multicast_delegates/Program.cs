using System;

namespace ex1_multicast_delegates
    
{
    class Program
    {
        // Define a delegate for the song parts
        public delegate void SongSect();

        // Define a class to hold the methods
        public class HereComesTheSun
        {
            public static void Chorus()
            {
                Console.Write("Here comes the sun, doo-doo-doo-doo\r\n");
                Console.WriteLine("Here comes the sun, and I say\r\nIt's alright");
                Console.WriteLine();
            }

            public static void ChorusAlternate()
            {
                Console.WriteLine("Here comes the sun\r\nHere comes the sun, and I say\r\nIt's alright");
                Console.WriteLine();
                Console.Write("Sun, sun, sun, here it comes\r\nSun, sun, sun, here it comes\r\n");
                Console.Write("Sun, sun, sun, here it comes\r\nSun, sun, sun, here it comes\r\n");
                Console.WriteLine("Sun, sun, sun, here it comes");
                Console.WriteLine();
            }

            public static void FirstVerse()
            {
                Console.Write("Little darlin', it's been a long, cold, lonely winter\r\n");
                Console.WriteLine("Little darlin', it feels like years since it's been here");
                Console.WriteLine();
            }

            public static void SecondVerse()
            {
                Console.Write("Little darlin', the smile's returning to their faces\r\n");
                Console.WriteLine("Little darlin', it seems like years since it's been here");
                Console.WriteLine();
            }

            public static void ThirdVerse()
            {
                Console.Write("Little darlin', I feel that ice is slowly melting\r\n");
                Console.WriteLine("Little darlin', it seems like years since it's been clear");
                Console.WriteLine();
            }

            public static void End()
            {
                Console.WriteLine("It's alright");
            }
        }

        static void Main(string[] args)
        {

            SongSect songDelegate = null;


            songDelegate += HereComesTheSun.Chorus;
            songDelegate += HereComesTheSun.FirstVerse;
            songDelegate += HereComesTheSun.Chorus;
            songDelegate += HereComesTheSun.SecondVerse;
            songDelegate += HereComesTheSun.ChorusAlternate;
            songDelegate += HereComesTheSun.ThirdVerse;
            songDelegate += HereComesTheSun.Chorus;
            songDelegate += HereComesTheSun.Chorus;
            songDelegate += HereComesTheSun.End;

            songDelegate.Invoke();
        }
    }
}