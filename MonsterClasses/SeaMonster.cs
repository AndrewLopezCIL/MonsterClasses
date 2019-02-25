using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterClasses
{
    public class SeaMonster : Monster
    {
        private string _homeSea;
        private bool _hasGills; 
        public bool HasGills
        {
            get { return _hasGills; }
            set { _hasGills = value; }
        }

        public string HomeSea
        {
            get { return _homeSea; }
            set { _homeSea = value; }
        }

        public override bool IsHappy()
        {
            return _hasGills ? true : false;
        }
    }
}
