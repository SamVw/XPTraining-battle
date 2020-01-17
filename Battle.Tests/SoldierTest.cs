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

        [Fact]
        public void ChooseWeapon_ChangesWeaponToChosenWeapon()
        {
            var soldier = new Soldier("name");
            var chosenWeapon = new Sword();
            soldier.ChooseWeapon(chosenWeapon);

            soldier.Weapon.Should().BeEquivalentTo(chosenWeapon);
        }

        [Fact]
        public void Fight_GivenTwoSoldiersWithDifferentWeaponDamage_ThenReturnsSoldierWithHighestWeaponDamage()
        {
            var winningSoldier = new Soldier("Strong guy", new Axe());
            var losingSoldier = new Soldier("Weak guy", new BareFist());

            var winner = winningSoldier.Fight(losingSoldier);

            winner.Should().BeEquivalentTo(winningSoldier.Name);
        }

        [Fact]
        public void Fight_GivenTwoSoldiersWithSameWeaponDamage_ThenReturnsSoldierWhoFights()
        {
            var winningSoldier = new Soldier("Frodo", new Axe());
            var losingSoldier = new Soldier("Samwise", new Axe());

            var winner = winningSoldier.Fight(losingSoldier);

            winner.Should().BeEquivalentTo(winningSoldier.Name);
        }
    }
}