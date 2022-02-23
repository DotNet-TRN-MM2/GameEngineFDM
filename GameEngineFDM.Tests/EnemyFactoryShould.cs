using System;
using Xunit;

namespace GameEngineFDM.Tests
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //  Assert and get case result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object

            Assert.Equal("Zombie King",boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            // this won't work because IsType is a strict comparison.
            // this is actually of type BossEnemy
            //Assert.IsType<Enemy>(enemy);

            // you can use this instead of IsType; takes into account inheritance
            Assert.IsAssignableFrom<Enemy>(enemy);


        }

        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
            //Assert.Same(enemy1, enemy2); // will fail because they are 2 separate references


        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));

            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));

            //won't pass.  check create function exception.  isBoss is not part of it.
            //Assert.Throws<ArgumentNullException>("isBoss", () => sut.Create(null));
        }


        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();


            // because we are capturing the EnemyCreationException in this variable,
            // we can make further Asserts against it.
            // In this example, method will throw an exception.  isBoss will be false because "Zombie" does not have
            // King or Queen after it.  See Enemy Factory Create method
            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);


        }


    }
}
