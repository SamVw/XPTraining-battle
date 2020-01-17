using Battle.Weapons;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class WeaponTest
    {
        [Fact]
        public void Spear_GetDamage_ShouldBe2()
        {
            var spear = new Spear();
            spear.GetDamage().Should().Be(2.0);
        }

        [Fact]
        public void BareFist_GetDamage_ShouldBe1()
        {
            var bareFist = new BareFist();
            bareFist.GetDamage().Should().Be(1.0);
        }

        [Fact]
        public void Axe_GetDamage_ShouldBe3()
        {
            var axe = new Axe();
            axe.GetDamage().Should().Be(3.0);
        }

        [Fact]
        public void Sword_GetDamage_ShouldBe2()
        {
            var sword = new Sword();
            sword.GetDamage().Should().Be(2.0);
        }
    }
}
