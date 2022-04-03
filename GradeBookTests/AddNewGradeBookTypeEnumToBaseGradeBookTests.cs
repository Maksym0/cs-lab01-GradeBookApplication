using System;
using System.IO;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    public class AddNewGradeBookTypeEnumToBaseGradeBookTests
    {
        [Fact(DisplayName = "Create New Enum GradeBookType Tests @create-a-new-enum-gradebooktype")]
        public void CreateNewEnumGradeBookTypeTests()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "GradeBook" + Path.DirectorySeparatorChar + "Enums" + Path.DirectorySeparatorChar + "GradeBookType.cs";
            Assert.True(File.Exists(filePath), "`GradeBookType.cs` was not found in the `Enums` directory.");
            var gradebookEnum = TestHelpers.GetUserType("GradeBook.Enums.GradeBookType");
            Assert.True(gradebookEnum.IsPublic, "`GradeBook.Enums.GradeBookType` exists, but isn't `public`.");
            Assert.True(gradebookEnum.IsEnum, "`GradeBook.Enums.GradeBookType` exists, but isn't an enum.");
            Assert.True(gradebookEnum != null, "`GradeBookType` wasn't found in the `GradeBooks.Enums` namespace.");
            Assert.True(Enum.IsDefined(gradebookEnum, "ESNU"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `ESNU`.");
            Assert.True(Enum.IsDefined(gradebookEnum, "OneToFour"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `OneToFour`.");
            Assert.True(Enum.IsDefined(gradebookEnum, "SixPoint"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `SixPoint`.");
            Assert.True(Enum.IsDefined(gradebookEnum, "Standard"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `Standard`.");
            Assert.True(Enum.IsDefined(gradebookEnum, "Ranked"), "`GradeBook.Enums.GradeBookType` doesn't contain the value `Ranked`.");

        }
        [Fact(DisplayName = "Add property Type to BaseGradeBook Tests @add-a-gradebooktype-property-to-basegradebook")]
        public void AddPropertyTypeToBaseGradeBookTests()
        {
            var typeProperty = typeof(BaseGradeBook).GetProperty("Type");
            Assert.True(typeProperty != null, "`GradeBook.GradeBooks.BaseGradeBook` doesn't contain a property `Type` or `Type` is not `public`.");
            var gradebookEnum = TestHelpers.GetUserType("GradeBook.Enums.GradeBookType");
            Assert.True(typeProperty.PropertyType == gradebookEnum, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it is not of type `GradeBookType`.");
            Assert.True(typeProperty.GetGetMethod() != null, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it's getter is not `public`.");
            Assert.True(typeProperty.GetSetMethod() != null, "`GradeBook.GradeBooks.BaseGradeBook` contains a property `Type` but it's setter is not `public`.");
        }
    }
}
