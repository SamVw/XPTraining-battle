using Battle.Weapons;
using System;

namespace Battle
{
    public class Soldier
    {
        public string Name { get; }
        public Weapon Weapon { get; set; }

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
    }
}