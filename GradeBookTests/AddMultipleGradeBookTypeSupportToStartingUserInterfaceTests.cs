using System;
using System.IO;
using System.Linq;
using GradeBook.UserInterfaces;
using Xunit;

namespace GradeBookTests
{
    public class AddMultipleGradeBookTypeSupportToStartingUserInterfaceTests
    {
        [Fact(DisplayName = "Increase Parts Check To 3 Test @set-parts-check-to-3")]
        public void IncreasePartsCheckToThreeTest()
        {
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var ctor = rankedGradeBook.GetConstructors().FirstOrDefault();

            var parameters = ctor.GetParameters();
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                return;

            var output = string.Empty;
            
            try
            {
                using (var consoleInputStream = new StringReader("close"))
                {
                    Console.SetIn(consoleInputStream);
                    using (var consolestream = new StringWriter())
                    {
                        Console.SetOut(consolestream);
                        StartingUserInterface.CreateCommand("create test");
                        output = consolestream.ToString().ToLower();
                        Assert.True(output.Contains("command not valid"), "`GradeBook.UserInterfaces.StartingUserInterface` didn't write a message to the console when the create command didn't contain both a name and type.");
                    }
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }
        }
        [Fact(DisplayName = "Update Validation Message Test @createcommand-type-error-message")]
        public void UpdateValidationMessageTest()
        {
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var ctor = rankedGradeBook.GetConstructors().FirstOrDefault();

            var parameters = ctor.GetParameters();
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                return;
            var output = string.Empty;
            
            try
            {
                using (var consoleInputStream = new StringReader("close"))
                {
                    Console.SetIn(consoleInputStream);
                    using (var consolestream = new StringWriter())
                    {
                        Console.SetOut(consolestream);
                        StartingUserInterface.CreateCommand("create test");
                        output = consolestream.ToString().ToLower();
                        Assert.True(output.Contains("command not valid, create requires a name and type of gradebook."), "`GradeBook.UserInterfaces.StartingUserInterface` didn't write 'Command not valid, Create requires a name and type of gradebook.' to the console when the create command didn't contain both a name and type.");
                    }
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }
        }
        [Fact(DisplayName = "Instantiate GradeBook Test @createcommand-instantiate")]
        public void InstantiateGradeBookTest()
        {
            var rankedGradeBook = TestHelpers.GetUserType("GradeBook.GradeBooks.RankedGradeBook");
            Assert.True(rankedGradeBook != null, "`RankedGradeBook` wasn't found in the `GradeBooks.GradeBook` namespace.");

            var ctor = rankedGradeBook.GetConstructors().FirstOrDefault();

            var parameters = ctor.GetParameters();
            if (parameters.Count() == 2 && parameters[0].ParameterType == typeof(string) && parameters[1].ParameterType == typeof(bool))
                return;
            var output = string.Empty;
            

            try
            {
                using (var consoleInputStream = new StringReader("close"))
                {
                    Console.SetIn(consoleInputStream);
                    using (var consolestream = new StringWriter())
                    {
                        Console.SetOut(consolestream);
                        StartingUserInterface.CreateCommand("create test standard");
                        output = consolestream.ToString().ToLower();

                        Assert.True(output.Contains("standard"), "`GradeBook.UserInterfaces.StartingUserInterface` didn't create a `StandardGradeBook` when 'standard' was used with the `CreateCommand`.");
                    }
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }
            output = string.Empty;
            

            try
            {
                using (var consoleInputStream = new StringReader("close"))
                {
                    Console.SetIn(consoleInputStream);
                    using (var consolestream = new StringWriter())
                    {
                        Console.SetOut(consolestream);
                        StartingUserInterface.CreateCommand("create test ranked");
                        output = consolestream.ToString().ToLower();

                        Assert.True(output.Contains("ranked"), "`GradeBook.UserInterfaces.StartingUserInterface` didn't create a `RankedGradeBook` when 'ranked' was used with the `CreateCommand`.");
                    }
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }
            output = string.Empty;
            

            try
            {
                using (var consolestream = new StringWriter())
                {
                    Console.SetOut(consolestream);
                    StartingUserInterface.CreateCommand("create test incorrect");
                    output = consolestream.ToString().ToLower();

                    Assert.True(output.Contains("incorrect is not a supported type of gradebook, please try again"), "`GradeBook.UserInterfaces.StartingUserInterface` write the entered type followed by ' is not a supported type of gradebook, please try again' when an unknown value was used with the `CreateCommand`.");
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }
        }
        [Fact(DisplayName = "Update StartingUserInterface's HelpCommand Method Test @update-startinguserinterface-s-helpcommand-method")]
        public void UpdateHelpCommandTest()
        {
            var output = string.Empty;

            try
            {
                using (var consoleInputStream = new StringReader("close"))
                {
                    Console.SetIn(consoleInputStream);

                    using (var consolestream = new StringWriter())
                    {
                        Console.SetOut(consolestream);
                        StartingUserInterface.HelpCommand();
                        output = consolestream.ToString().ToLower();
                        if (output.Contains("create 'name' 'type' 'weighted' - creates a new gradebook where 'name' is the name of the gradebook, 'type' is what type of grading it should use, and 'weighted' is whether or not grades should be weighted (true or false)."))
                            return;
                        Assert.True(output.Contains("create 'name' 'type' - creates a new gradebook where 'name' is the name of the gradebook and 'type' is what type of grading it should use."), "`GradeBook.UserInterfaces.StartingUserInterface.HelpCommand` didn't write \"Create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type' is what type of grading it should use.\"");
                    }
                }
            }
            finally
            {
                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(standardOutput);
                StreamReader standardInput = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(standardInput);
            }

        }
    }
}
