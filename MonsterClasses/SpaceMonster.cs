using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
   public class SpaceMonster : Monster, IBattle
    {
        private string _galaxy;
        private bool _hasFood;
         
        public bool HasFood
        {
            get { return _hasFood; }
            set { _hasFood = value; }
        }

        public string Galaxy
        {
            get { return _galaxy; }
            set { _galaxy = value; }
        }
        public virtual string Greeting()
        {
            return $"Hello, my name is {Name} and I am from the {_galaxy} galaxy.";
        }

        public override bool IsHappy()
        {
            return _hasFood ? true : false;
        }

        public MonsterAction MonsterBattleRepsonse()
        {
            Random randomNumber = new Random();
            int battleResponseNumber = randomNumber.Next(0, 101);

            if (battleResponseNumber >= 66)
            {
            return MonsterAction.Attack;
            }
            else if(battleResponseNumber >= 33)
            {
                return MonsterAction.Defend;
            }
            else
            {
                return MonsterAction.Retreat;
            }
        }
    }
}
