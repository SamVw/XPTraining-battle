using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        public IHeadquarters _headquarters;

        public ArmyTest()
        {
            _headquarters = Substitute.For<IHeadquarters>();
        }

        [Fact]
        public void Enlist_GivenOneSoldier_AddsSoldierToArmy()
        {
            var soldier = new Soldier("name");
            var army = new Army("army", _headquarters);
            army.EnlistSoldier(soldier);

            var soldiers = army.GetEnlistedSoldiers();

            soldiers.Should().BeEquivalentTo(soldier);
        }

        [Fact]
        public void Enlist_GivenMultipleSoldiers_AddsSoldiersToArmy()
        {
            var soldier1 = new Soldier("name1");
            var soldier2 = new Soldier("name2");
            var army = new Army("army", _headquarters);
            army.EnlistSoldier(soldier1);
            army.EnlistSoldier(soldier2);

            var soldiers = army.GetEnlistedSoldiers();

            soldiers.Should().BeEquivalentTo(soldier1, soldier2);
        }

        [Fact]
        public void Frontman_GivenMultipleSoldiers_ReturnsFirstSoldier()
        {
            var soldier1 = new Soldier("name1");
            var soldier2 = new Soldier("name2");
            var army = new Army("army", _headquarters);
            army.EnlistSoldier(soldier1);
            army.EnlistSoldier(soldier2);

            var frontman = army.Frontman;

            frontman.Should().BeEquivalentTo(soldier1);
        }

        [Fact]
        public void Frontman_GivenNoSoldiers_ReturnsNull()
        {
            var army = new Army("army", _headquarters);
            var frontman = army.Frontman;

            frontman.Should().BeNull();
        }

        [Fact]
        public void Constructor_GivenName_SetsTheNameOfTheArmy()
        {
            const string name = "test";
            var army = new Army(name, _headquarters);

            army.Name.Should().Be(name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_GivenNameIsNullOrWhiteSpace_ThrowsException(string name)
        {
            Assert.Throws<Exception>(() => new Army(name, _headquarters));
        }

        [Fact]
        public void EnlistSoldier_ReportsToHQWithEnlistedSoldierName()
        {
            var army = new Army("army", _headquarters);
            var soldier = new Soldier("Wilfried");

            army.EnlistSoldier(soldier);

            _headquarters.Received().ReportEnlistment(soldier.Name);
        }

        [Fact]
        public void EnlistSoldier_AssignsIdToEnlistedSoldier()
        {
            var soldierId = Guid.NewGuid();
            var army = new Army("army", _headquarters);
            var enlistedSoldier = new Soldier("Wilfried");
            _headquarters.ReportEnlistment(enlistedSoldier.Name).Returns(soldierId);

            army.EnlistSoldier(enlistedSoldier);
            enlistedSoldier.Id.Should().Be(soldierId);
        }

        [Fact]
        public void GivenEnlistingMultipleSoldiers_AssignsDistinctIdsToEnlistedSoldiers()
        {
            var soldierId1 = Guid.NewGuid();
            var soldierId2 = Guid.NewGuid();

            var army = new Army("army", _headquarters);

            var enlistedSoldier1 = new Soldier("Wilfried");
            var enlistedSoldier2 = new Soldier("Sheldon");

            _headquarters.ReportEnlistment(enlistedSoldier1.Name).Returns(soldierId1);
            _headquarters.ReportEnlistment(enlistedSoldier2.Name).Returns(soldierId2);

            army.EnlistSoldier(enlistedSoldier1);
            army.EnlistSoldier(enlistedSoldier2);
            enlistedSoldier1.Id.Should().NotBe(enlistedSoldier2.Id);
        }
    }
}
