using System;
using Battle.Weapons;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierTest
    {

        [Fact]
        public void Construction_ASoldierMustHaveAName()
        {
            var soldier = new Soldier("name"); 

            soldier.Name.Should().Be("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Construction_ASoldierMustHaveAName_CannotBeBlank(string name)
        {
            Action act = () => new Soldier(name);
             
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Construction_ASoldierMustHaveAWeapon()
        {
            var spear = new Spear();
            var soldier = new Soldier("name", spear);

            soldier.Weapon.Should().BeEquivalentTo(spear);
        }

        [Fact]
        public void Construction_ASoldierMustHaveBareFistWeaponByDefault()
        {
            var soldier = new Soldier("name");

            soldier.Weapon.Should().BeOfType(typeof(BareFist));
        }
    }
}