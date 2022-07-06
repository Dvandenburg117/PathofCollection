using System;
using System.Collections.Generic;
using System.Text;

namespace PathofExile2
{
    public class WeaponGroup : List<Weapon>
    {
        public string weaponClass { get; set; }

        public WeaponGroup(string title)
        {
            weaponClass = title;
        }
    }
}
