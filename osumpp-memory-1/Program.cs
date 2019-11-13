using OsuMemoryDataProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace osumpp_memory_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OsuMemoryReader> readers = new List<OsuMemoryReader>();

            var procs = System.Diagnostics.Process.GetProcessesByName("osu!");

            foreach (Process p in procs)
            {
                var reader = new OsuMemoryReader(p.Id);
                readers.Add(reader);
            }

            while (true)
            {

                foreach ( OsuMemoryReader mr in readers)
                {
                    Thread.Sleep(5);
                    int score = 0;
                    string playerName = "";
                    try
                    {
                        score = mr.ReadScore();
                        playerName = mr.PlayerName();

                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("Player: " + playerName + ", Score:" + score);
                }

                Thread.Sleep(1000); //ms
                Console.Clear();
            }

        }

    }
}
