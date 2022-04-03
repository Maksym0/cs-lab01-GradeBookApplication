using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    public class MakeBaseGradeBookAbstractTests
    {
        [Fact(DisplayName = "Make BaseGradeBook Abstract @make-basegradebook-abstract")]
        public void MakeBaseGradeBookAbstract()
        {
            Assert.True(typeof(BaseGradeBook).IsAbstract == true, "`GradeBook.GradeBooks.BaseGradeBook` is not abstract.");
        }
    }
}
