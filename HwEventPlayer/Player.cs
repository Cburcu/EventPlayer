using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwEventPlayer
{
    public delegate void PointControl(object source, PointEventArgs args);

    class Player
    {
        //public event PlayerLevelChangedDelegate LevelDecreased;
        public event PointControl PointControlEvent;
        public event EventHandler<LevelEventArgs> LevelControlEvent;
        
        public string Nickname { get; set; }

        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                if (PointControlEvent != null && value % 100 == 0)
                {
                    Level += 1;
                    PointControlEvent(this, new PointEventArgs(){ CurrentValue = value});
                }
            }
        }

        private int _level;
        private int _points;

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                int oldLevet = _level;
                _level = value;

                if ((value - oldLevet) == 1 && LevelControlEvent != null)
                {
                    Console.WriteLine("Level up {0} => {1}", value, Level);
                    LevelControlEvent(this, new LevelEventArgs(){ CurrentLevel =_level, OldLevel = oldLevet });
                }
            }
        }

        public void LevelUp(int experience)
        {
            Points += experience;
            Console.WriteLine("New point = {0}", Points);
        }
    }

    public class PointEventArgs
    {
        public int CurrentValue { get; set; }
    }

    public class LevelEventArgs:EventArgs
    {
        public int CurrentLevel { get; set; }
        public int OldLevel { get; set; }
    }
}
