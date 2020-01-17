using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class Army
    {
        private readonly List<Soldier> _soldiers = new List<Soldier>();
        private readonly IHeadquarters _headquarters;

        public Soldier Frontman => _soldiers.FirstOrDefault();
        public string Name { get; }

        public Army(string name, IHeadquarters headquarters)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception();
            Name = name;
            _headquarters = headquarters;
        }

        public void EnlistSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
            var id = _headquarters.ReportEnlistment(soldier.Name);
            soldier.SetId(id);
        }

        public List<Soldier> GetEnlistedSoldiers()
        {
            return _soldiers;
        }
    }
}
