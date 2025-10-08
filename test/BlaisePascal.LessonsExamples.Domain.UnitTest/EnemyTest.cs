namespace BlaisePascal.LessonsExamples.Domain.UnitTest
{
    public class EnemyTest
    {
        [Fact]
        public void EnemyName_WhenTheNameIsValid_NameMustBeAssignedCorrectly()
        {
            //modifica
            //Arrange
            Enemy newEnemy = new Enemy();

            //Actit
            newEnemy.SetName("Stefano");

            //Assert
            Assert.Equal("Stefano", newEnemy.GetName());


        }

        [Fact]
        public void EnemyName_TheNameCannotBeNull()
        {
            //Arrange
            Enemy newEnemy = new Enemy();


            //Assert
            Assert.Equal("Stefano", newEnemy.GetName());


        }

    }
}