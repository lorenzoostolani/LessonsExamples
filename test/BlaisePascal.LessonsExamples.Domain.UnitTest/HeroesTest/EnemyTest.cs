namespace BlaisePascal.LessonsExamples.Domain.UnitTest
{
    public class EnemyTest
    {

        //SetName tests

        [Fact]
        public void EnemyName_WhenTheNameIsValid_NameMustBeAssignedCorrectly()
        {
            //Arrange
            Enemy newEnemy = new Enemy();

            //Act
            newEnemy.SetName("Stefano");

            //Assert
            Assert.Equal("Stefano", newEnemy.Name);


        }

        [Fact]
        public void EnemyName_TheNameCannotBeNull()
        {
            //Arrange
            Enemy newEnemy = new Enemy();

            //Assert
            Assert.Null(newEnemy.Name);

        }
        [Fact]
        public void EnemyName_TheNameCannotBeEmpty()
        {
            //Arrange
            Enemy newEnemy = new Enemy();


            //Assert
            Assert.Throws<ArgumentException>(() => newEnemy.SetName(""));


        }
        [Fact]
        public void EnemyName_TheNameCannotBeWhiteSpace()
        {
            //Arrange
            Enemy newEnemy = new Enemy();

            //Assert
            Assert.Throws<ArgumentException>(() => newEnemy.SetName("   "));    
        }



        // SetHealth tests

        [Fact]
        public void SetHealth_WhenTheHealthIsValid_HealthMustBeAssignedCorrectly()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(50);
            //Assert
            Assert.Equal(50, newEnemy.Health);
            Assert.True(newEnemy.IsAlive);
        }
        [Fact]
        public void SetHealth_TheHealthCannotBeNegative()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEnemy.SetHealth(-10));
        }
        [Fact]
        public void SetHealth_TheHealthCannotBeGreaterThan100()
        {
            //Arrange
            Enemy newEnemy = new Enemy();

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => newEnemy.SetHealth(150));
        }



        // Take damage tests

        [Fact]
        public void TakeDamage_WhenDamageIsValid_HealthMustDecrease()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 100);
            int damage = 30;

            //Act
            newEnemy.TakeDamage(damage);
            //Assert
            Assert.Equal(70, newEnemy.Health);
            Assert.True(newEnemy.IsAlive);
        }
        [Fact]
        public void TakeDamage_WhenDamageIsNegative_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 100);
            int damage = -20;

            //Assert & Act
            Assert.Throws<ArgumentException>(() => newEnemy.TakeDamage(damage));
        }
        [Fact]
        public void TakeDamage_WhenDamageIsGreaterThanCurrentHealth_HealthMustBeZero()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 50);
            int damage = 70;
            //Act
            newEnemy.TakeDamage(damage);
            //Assert
            Assert.Equal(0, newEnemy.Health);
            Assert.False(newEnemy.IsAlive);
        }


        // Heal tests

        [Fact]
        public void Heal_WhenHealAmountIsValid_HealthMustIncrease()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 50);
            int healAmount = 30;
            //Act
            newEnemy.Heal(healAmount);
            //Assert
            Assert.Equal(80, newEnemy.Health);
            Assert.True(newEnemy.IsAlive);
        }
        [Fact]
        public void Heal_WhenHealAmountIsNegative_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 100);
            int healAmount = -20;

            //Assert & Act
            Assert.Throws<ArgumentException>(() => newEnemy.Heal(healAmount));
        }

        [Fact]
        public void Heal_WhenHealAmountExceedsMaxHealth_HealthMustBeCappedAt100()
        {
            //Arrange
            Enemy newEnemy = new Enemy("Goblin", 90);
            int healAmount = 20;

            //Act
            newEnemy.Heal(healAmount);

            //Assert
            Assert.Equal(100, newEnemy.Health);
            Assert.True(newEnemy.IsAlive);
        }
    }
}