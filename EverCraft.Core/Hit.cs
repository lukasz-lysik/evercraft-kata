using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public class Hit
    {
        public Hit(int againstArmor, int againstHitPoints = 0, bool isCritical = false)
        {
            AgainstArmor = againstArmor;
            AgainstHitPoints = againstHitPoints;
            IsCritical = isCritical;
        }

        public int AgainstArmor { get; private set; }
        public int AgainstHitPoints { get; private set; }
        public bool IsCritical { get; private set; }
    }
}
