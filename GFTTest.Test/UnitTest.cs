using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFTTest.Business;
using GFTTest.Entities;
using GFTTest.Helpers;


namespace GFTTest.Test
{
    /// <summary>
    /// Summary description for DishTeste
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TimeOfDayMustBeMorningOrNight()
        {
            const bool expectedValue = true;
            const string command = "morning, 1, 2, 3";

            ITimeOfDayBLL business = new TimeOfDayBLL();
            string currentTimeOfDay = Parser.GetTimeOfDay(command);
            bool actualValue = business.ValidateTimeOfDay(currentTimeOfDay);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TimeOfDayIsNotCaseSensitive()
        {
            const bool expectedValue = true;
            const string command = "MoRnInG, 1, 2, 3";

            ITimeOfDayBLL business = new TimeOfDayBLL();
            string currentTimeOfDay = Parser.GetTimeOfDay(command);
            bool actualValue = business.ValidateTimeOfDay(currentTimeOfDay);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void TheDishesMustFollowTheCorrectOrder()
        {
            const string expectedValue = "morning, eggs, toast, coffee";
            const string command = "morning, 2, 3, 1";

            ITimeOfDayBLL timeBusiness = new TimeOfDayBLL();
            TimeOfDay currentTimeOfDay = Parser.GetTimeOfDay(command).ToTimeOfDay();

            IDishBLL business = new DishBLL();
            List<string> inputedDishes = Parser.GetDishes(command).ToDishName(currentTimeOfDay);
            List<Dish> handledList = business.CheckDuplicated(currentTimeOfDay, inputedDishes);
            string actualValue = handledList.ToOutputString(currentTimeOfDay);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenItsMorningAndInputDessertReturnError()
        {
            const string expectedValue = "error";
            const string command = "4";

            IDishBLL business = new DishBLL();
            string actualValue = business.ConvertCodeToDish(TimeOfDay.morning, command);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenItsMorningAndOrderMultiplesEggsReturnError()
        {
            const bool expectedValue = false;
            const string command = "morning, 1, 1";

            bool actualValue = true;
            try
            {
                IDishBLL business = new DishBLL();
                List<string> inputedDishes = Parser.GetDishes(command).ToDishName(TimeOfDay.morning);
                List<Dish> handledList = business.CheckDuplicated(TimeOfDay.morning, inputedDishes);
            }
            catch (Exception)
            {
                actualValue = false;
            }
            
            Assert.AreEqual(expectedValue, actualValue);
        }


        [TestMethod]
        public void WhenItsNightAndOrderMultiplesPotatoesReturnSuccess()
        {
            const bool expectedValue = true;
            const string command = "night, 2, 2";

            bool actualValue = true;
            try
            {
                IDishBLL business = new DishBLL();
                List<string> inputedDishes = Parser.GetDishes(command).ToDishName(TimeOfDay.night);
                List<Dish> handledList = business.CheckDuplicated(TimeOfDay.night, inputedDishes);
            }
            catch (Exception)
            {
                actualValue = false;
            }

            Assert.AreEqual(expectedValue, actualValue);
        }

    }
}
