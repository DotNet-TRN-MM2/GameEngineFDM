using Xunit;

namespace GameEngineFDM.Tests
{
    public class NonPlayerCharacterShould
    {
        [Theory]
        // this is inline:  then we set up a class to share
        //[InlineData(0, 100)]
        //[InlineData(1, 99)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)]

        // using internal central data
        //[MemberData(nameof(InternalHealthDamageTestData.TestData),
        //    MemberType = typeof(InternalHealthDamageTestData))]

        // using external data
        //[MemberData(nameof(ExternalHealthDamageTestData.TestData),
        //    MemberType = typeof(ExternalHealthDamageTestData))]

        // using attribute (from a created class)
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
