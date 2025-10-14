namespace BlaisePascal.LessonsExamples.Domain.UnitTest
{
    public class EnemyTest
    {
        //IMPORTANTE: Il construttore non ha controlli su health e name?
        
        
        
        
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

            //Act
            newEnemy.SetName("");

            //Assert
            Assert.Null(newEnemy.Name);


        }
        [Fact]
        public void EnemyName_TheNameCannotBeWhiteSpace()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetName("   ");
            //Assert
            Assert.Null(newEnemy.Name);
        }







        [Fact]
        public void SetHealth_WhenTheHealthIsValid_HealthMustBeAssignedCorrectly()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(50);
            //Assert
            Assert.Equal(50, newEnemy.Health);
        }
        [Fact]
        public void SetHealth_TheHealthCannotBeNegative()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(-10);
            //Assert
            // IMPORTANTE: Come si fa a testare il lancio di un errore?
        }
        [Fact]
        public void SetHealth_TheHealthCannotBeGreaterThan100()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(150);
            //Assert
            // IMPORTANTE: Come si fa a testare il lancio di un errore?
        }
        [Fact]
        public void SetHealth_WhenHealthIsSetToPositiveValue_IsAliveMustBeTrue()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(50);
            //Assert
            Assert.True(newEnemy.IsAlive);
        }
        
        
        
        
        
        
        
        [Fact]
        public void TakeDamage_WhenDamageIsValid_HealthMustDecrease()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            newEnemy.SetHealth(100);
            //Act
            newEnemy.TakeDamage(30);
            //Assert
            Assert.Equal(70, newEnemy.Health);
        }
        [Fact]
        public void TakeDamage_WhenDamageIsNegative_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            //Act
            newEnemy.SetHealth(100);
            //Assert
            // IMPORTANTE: Come si fa a testare il lancio di un errore?
        }
        [Fact]
        public void TakeDamage_WhenDamageIsGreaterThanCurrentHealth_HealthMustBeZeroAndIsAliveMustBeFalse()
        {
            //Arrange
            Enemy newEnemy = new Enemy();
            newEnemy.SetHealth(50);
            //Act
            newEnemy.TakeDamage(70);
            //Assert
            Assert.Equal(0, newEnemy.Health);
            Assert.False(newEnemy.IsAlive);
        }
    }
}