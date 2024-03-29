using System;

namespace Test
    {
    [TestFixture]
    public class AxeTest
        {
        [Test]
        public void AxeGettersTest()
            {
            Axe axe = new Axe(10, 10);

            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
            }

        [Test]
        public void TestIfAttackWithNoDurabilityThrowsError()
            {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
            {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack");
            }
        }
    }