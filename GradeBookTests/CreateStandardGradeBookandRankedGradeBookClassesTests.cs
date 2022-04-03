using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    public class CreateStandardGradeBookandRankedGradeBookClassesTests
    {
        [Fact(DisplayName = "Create the StandardGradeBook Class @create-the-standardgradebook-class")]
        public void StandardGradeBookExistsTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "GradeBooks" + Path.DirectorySeparatorChar + "StandardGradeBook.cs";
            Assert.True(File.Exists(filePath), "`StandardGradeBook.cs` was not found in the `GradeBooks` folder.");
            var gradebook = TestHelpers.GetUserType("GradeBook.GradeBooks.StandardGradeBook");

            Assert.True(gradebook != null, "`StandardGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            Assert.True(gradebook.IsPublic, "`GradeBook.GradeBooks.StandardGradeBook` exists, but isn't `public`.");

            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.StandardGradeBook` doesn't inherit `BaseGradeBook`");
        }
        [Fact(DisplayName = "Update StandardGradeBook Type @update-standardgradebook-type")]
        public void UpdateStandardGradeBookTypeTests()
        {
            var gradebook = TestHelpers.GetUserType("GradeBook.GradeBooks.StandardGradeBook");
            Assert.True(gradebook != null, "`StandardGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var constructor = gradebook.GetConstructors().FirstOrDefault();

            Assert.True(constructor != null, "No constructor found for GradeBook.GradeBooks.StandardGradeBook.");

            var gradebookEnum = TestHelpers.GetUserType("GradeBook.Enums.GradeBookType");
            Assert.True(gradebookEnum != null, "`GradeBookType` wasn't found in the `GradeBook.Enums` namespace.");

            var parameters = constructor.GetParameters();

            object standardGradeBook = null;
            if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                standardGradeBook = Activator.CreateInstance(gradebook, "LoadTest");

            else if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                standardGradeBook = Activator.CreateInstance(gradebook, "LoadTest", true);

            Assert.True(standardGradeBook.GetType().GetProperty("Type").GetValue(standardGradeBook).ToString() == Enum.Parse(gradebookEnum, "Standard", true).ToString(), "`Type` wasn't set to `GradeBookType.Standard` by the `GradeBook.GradeBooks.StandardGradeBook` Constructor.");

            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "GradeBooks" + Path.DirectorySeparatorChar + "StandardGradeBook.cs";
            var input = File.ReadAllText(filePath);

            var pattern = @"(Type\s?[=]\s?(GradeBook[.])?(Enums[.])?GradeBookType[.]Standard\s?;)";
            var rgx = new Regex(pattern);
            var matches = rgx.Matches(input);
            Assert.True(matches.Count > 0, "While `Type` was set to `GradeBookType.Standard`, it wasn't set by the `GradeBook.GradeBooks.StandardGradeBook` Constructor.");
        }

        [Fact(DisplayName = "Create RankedGradeBook Class @create-the-rankedgradebook-class")]
        public void CreateRankedGradeBookClassTest()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "GradeBooks" + Path.DirectorySeparatorChar + "RankedGradeBook.cs";
            Assert.True(File.Exists(filePath), "`RankedGradeBook.cs` was not found in the `GradeBooks` folder.");
        
            var gradebook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");

            Assert.True(gradebook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");
        
            Assert.True(gradebook.IsPublic, "`GradeBook.GradeBooks.RankedGradeBook` exists, but isn't `public`.");
        
            Assert.True(gradebook.BaseType == typeof(BaseGradeBook), "`GradeBook.GradeBooks.RankedGradeBook` doesn't inherit `BaseGradeBook`");
        }

        [Fact(DisplayName = "Update RankedGradeBook Type @update-rankedgradebook-type")]
        public void UpdateRankedGradeBookTypeTest()
        {
            var gradebook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(gradebook != null, "`RankedGradeBook` wasn't found in the `GradeBook.GradeBooks` namespace.");

            var constructor = gradebook.GetConstructors().FirstOrDefault();

            Assert.True(constructor != null, "No constructor found for GradeBook.GradeBooks.StardardGradeBook.");

            var gradebookEnum = TestHelpers.GetUserType("GradeBook.Enums.GradeBookType");
            Assert.True(gradebookEnum != null, "`GradeBookType` wasn't found in the `GradeBook.Enums` namespace.");

            var parameters = constructor.GetParameters();

            object rankedGradeBook = null;
            if (parameters.Count() == 1 && parameters[0].ParameterType == typeof(string))
                rankedGradeBook = Activator.CreateInstance(gradebook, "LoadTest");

            else if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                rankedGradeBook = Activator.CreateInstance(gradebook, "LoadTest", true);

            Assert.True(rankedGradeBook.GetType().GetProperty("Type").GetValue(rankedGradeBook).ToString() == Enum.Parse(gradebookEnum, "Ranked", true).ToString(), "`Type` wasn't set to `GradeBookType.Ranked` by the `GradeBook.GradeBooks.RankedGradeBook` Constructor.");
        }
    }
}
