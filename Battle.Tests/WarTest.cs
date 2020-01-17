using Battle.Weapons;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Battle.Tests
{
    public class WarTest
    {
        private readonly IHeadquarters _headquarters;

        public WarTest()
        {
            _headquarters = Substitute.For<IHeadquarters>();
        }

        [Fact]
        public void EngageWar_GivenArmyWithStrongerFrontmen_ReturnsNameOfArmyWithStrongerFrontmen()
        {
            var winningArmy = new Army("army1", _headquarters);
            winningArmy.EnlistSoldier(new Soldier("1", new Axe()));
            winningArmy.EnlistSoldier(new Soldier("2", new BareFist()));
            winningArmy.EnlistSoldier(new Soldier("3", new Axe()));
            var losingArmy = new Army("army2", _headquarters);
            losingArmy.EnlistSoldier(new Soldier("1", new Sword()));
            losingArmy.EnlistSoldier(new Soldier("2", new Sword()));
            losingArmy.EnlistSoldier(new Soldier("3", new Spear()));

            var war = new War(winningArmy, losingArmy);
            var winner = war.Engage();

            winner.Should().Be(winningArmy.Name);
        }
    }
}
