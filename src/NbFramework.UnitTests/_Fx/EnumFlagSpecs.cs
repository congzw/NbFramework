using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NbFramework._Fx
{
    [TestClass]
    public class EnumFlagSpecs
    {
        [TestMethod]
        public void demos_for_all_flags()
        {
            // Display all possible combinations of values.
            Console.WriteLine(
                 "All possible combinations of values without FlagsAttribute:");
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (SingleHue)val);

            // Display all combinations of values, and invalid values.
            Console.WriteLine(
                 "\nAll possible combinations of values with FlagsAttribute:");
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (MultiHue)val);
        }

        [TestMethod]
        public void demos_for_flags_check()
        {
            // Define three variables representing the types of phone service
            // in three households.
            var household1 = PhoneService.LandLine | PhoneService.Cell | PhoneService.Internet;
            var household2 = PhoneService.None;
            var household3 = PhoneService.Cell | PhoneService.Internet;

            // Store the variables in an array for ease of access.
            PhoneService[] households = { household1, household2, household3 };

            // Which households have no service?
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has phone service: {1}",
                                  ctr + 1,
                                  households[ctr] == PhoneService.None ?
                                      "No" : "Yes");
            Console.WriteLine();

            // Which households have cell phone service?
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has cell phone service: {1}",
                                  ctr + 1,
                                  (households[ctr] & PhoneService.Cell) == PhoneService.Cell ?
                                     "Yes" : "No");
            Console.WriteLine();

            // Which households have cell phones and land lines?
            var cellAndLand = PhoneService.Cell | PhoneService.LandLine;
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has cell and land line service: {1}",
                                  ctr + 1,
                                  (households[ctr] & cellAndLand) == cellAndLand ?
                                     "Yes" : "No");
            Console.WriteLine();

            // List all types of service of each household?//
            for (int ctr = 0; ctr < households.Length; ctr++)
                Console.WriteLine("Household {0} has: {1:G}",
                                  ctr + 1, households[ctr]);
            Console.WriteLine();
        }
    }

    // Define an Enum without FlagsAttribute.
    enum SingleHue : short
    {
        None = 0,
        Black = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    };

    // Define an Enum with FlagsAttribute.
    [Flags]
    enum MultiHue : short
    {
        None = 0,
        Black = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    };

    [Flags]
    public enum PhoneService
    {
        None = 0,
        LandLine = 1,
        Cell = 2,
        Fax = 4,
        Internet = 8,
        Other = 16
    }
}
