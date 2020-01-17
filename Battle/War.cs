using System;
using System.Linq;

namespace Battle
{
    public class War
    {
        private Army _army1;
        private Army _army2;

        public War(Army army1, Army army2)
        {
            this._army1 = army1;
            this._army2 = army2;
        }

        public string Engage()
        {
            while (AtWar())
            {
                var victoriousSoldier = _army1.Frontman.Fight(this._army2.Frontman);
                RemoveFallenSoldier(victoriousSoldier);
            }

            return _army1.GetEnlistedSoldiers().Any() ? _army1.Name : _army2.Name;
        }

        private void RemoveFallenSoldier(Soldier victoriousSoldier)
        {
            if (_army1.GetEnlistedSoldiers().Contains(victoriousSoldier))
            {
                this._army2.GetEnlistedSoldiers().Remove(_army2.Frontman);
            }
            else
            {
                this._army1.GetEnlistedSoldiers().Remove(_army1.Frontman);
            }
        }

        private bool AtWar()
        {
            return _army1.GetEnlistedSoldiers().Count() != 0 && _army2.GetEnlistedSoldiers().Count() != 0;
        }
    }
}
