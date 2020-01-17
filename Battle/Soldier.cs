using Battle.Weapons;
using System;

namespace Battle
{
    public class Soldier
    {
        public string Name { get; }
        public Weapon Weapon { get; private set; }
        public Guid Id { get; private set; }

        private bool IsBlank(string name) => string.IsNullOrEmpty(name?.Trim());

        public Soldier(string name, Weapon weapon = null)
        {
            ValidateNameisNotBlank(name);
            Name = name;
            Weapon = weapon == null ? new BareFist(): weapon;
        }

        private void ValidateNameisNotBlank(string name)
        {
            if (IsBlank(name))
            {
                throw new ArgumentException("name can not be blank");
            }
        }

        public void ChooseWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public Soldier Fight(Soldier defender)
        {
            return Weapon.GetDamage() >= defender.Weapon.GetDamage() ?
                this :
                defender;
        }
    }
}