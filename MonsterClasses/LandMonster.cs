using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    class LandMonster : Monster
    {
        private string _attackType;
        private string _ancestor = "Sea Monster";
        private bool _hasFood;
        private int _numberOfKids;
        private string _mothersName;
        private bool _canFly;

        public bool CanFly
        {
            get { return _canFly; }
            set { _canFly = value; }
        }

        public string MothersName
        {
            get { return _mothersName; }
            set { _mothersName = value; }
        }
        
        public int NumberOfKids
        {
            get { return _numberOfKids; }
            set { _numberOfKids = value; }
        }
       
        public bool HasFood
        {
            get { return _hasFood; }
            set { _hasFood = value; }
        }

        public string Ancestor
        {
            get { return _ancestor; }
            set { _ancestor = value; }
        }

        public string AttackType
        {
            get { return _attackType; }
            set { _attackType = value; }
        }
        

        public virtual string MonsterYell()
        {
            return $"{Name} screams Ah!";
        }
        public override bool IsHappy()
        {
            return _hasFood ? true : false;
        }
         
    }
}
