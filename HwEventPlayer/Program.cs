using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwEventPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            Player emcey = new Player();
            emcey.Nickname = "emcey";

            emcey.PointControlEvent += (o , e) =>
            {
                Console.WriteLine("levelup");
                Console.WriteLine(e.CurrentValue);
            }
            ;
            
            emcey.LevelControlEvent += Player_LevelControlEvent;

            for (int i = 0; i < 10; i++)
            {
                emcey.LevelUp(25);
                Console.WriteLine("{0} Points = {1}  Level = {2}", emcey.Nickname, emcey.Points, emcey.Level);
            }

            Console.ReadLine();

        }

        private static void Player_LevelControlEvent(object ob, LevelEventArgs args)
        {
            Console.WriteLine("Congratulation");
            Console.WriteLine("old Value= {0} current value = {1}", args.OldLevel, args.CurrentLevel);

        }

    }
}
