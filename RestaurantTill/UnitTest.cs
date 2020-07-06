using NUnit.Framework;
using RestaurantTill.Menu;
using System;

namespace RestaurantTill
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddStarterToList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            Assert.AreEqual(1, orderList.GetCountOfItems());
        }

        [Test]
        public void DeleteStarterFromList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            orderList.DeleteStarter(StarterMenu.Chips);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        public void AddMainToList()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            Assert.AreEqual(1, orderList.GetCountOfItems());
        }

        [Test]
        public void DeleteMainFromList()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.DeleteMain(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        public void UpdateStarter()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            orderList.UpdateStarter(StarterMenu.Chips, StarterMenu.HotWings);
            Assert.AreEqual(1, orderList.GetCountOfItems());
            Assert.AreEqual(StarterMenu.HotWings, orderList.GetList()[0].Meal);
        }

        [Test]
        public void UpdateMain()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.UpdateMain(MainMenu.CheeseBurger, MainMenu.SteakChips);
            Assert.AreEqual(1, orderList.GetCountOfItems());
            Assert.AreEqual(MainMenu.SteakChips, orderList.GetList()[0].Meal);
        }

        [Test]
        public void StarterPriceIsReturned()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            Assert.AreEqual(4.40, orderList.GetList()[0].Price);
        }

        [Test]
        public void MainPriceIsReturned()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            Assert.AreEqual(7.00, orderList.GetList()[0].Price);
        }


        [Test]
        public void AttemptToDeleteStarterInEmptyList()
        {
            OrderList orderList = new OrderList();
            orderList.DeleteStarter(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        public void AttemptToDeleteMainInEmptyList()
        {
            OrderList orderList = new OrderList();
            orderList.DeleteMain(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        public void AddMultipleFoodItemsToList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            orderList.AddStarter(StarterMenu.HotWings);
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.PepperoniPizza);
            Assert.AreEqual(5, orderList.GetCountOfItems());
        }

        [Test]
        public void DeletingMultipleFoodItemsFromList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            orderList.AddStarter(StarterMenu.Chips);
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.CheeseBurger);

            orderList.DeleteStarter(StarterMenu.Chips);
            orderList.DeleteMain(MainMenu.CheeseBurger);
            orderList.DeleteMain(MainMenu.CheeseBurger);
            Assert.AreEqual(3, orderList.GetCountOfItems());
        }

        [Test]
        [TestCase(0.00, "£0.00")]
        [TestCase(0.01, "£0.01")]
        [TestCase(1.00, "£1.00")]
        [TestCase(10.99, "£10.99")]
        [TestCase(1234567.89, "£1,234,567.89")]
        public void DecimalConvertedToPounds(decimal total, string poundValue)
        {
            Till till = new Till(new OrderList());
            Assert.AreEqual(poundValue, till.convertToPounds(total));

        }

        [Test]
        public void GetTotalOfEmptyList()
        {
            OrderList orderList = new OrderList();
            Till till = new Till(orderList);
            Assert.AreEqual("£0.00", till.GetTotalFromList());
        }


        [Test]
        public void GetTotalOfOneStarter()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            Till till = new Till(orderList);
            Assert.AreEqual("£4.40", till.GetTotalFromList());
        }

        [Test]
        public void GetTotalOfOneMain()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            Till till = new Till(orderList);
            Assert.AreEqual("£7.00", till.GetTotalFromList());
        }


        [Test]
        public void GetTotalOfOneMainAfterDelete()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.AddMain(MainMenu.PepperoniPizza);

            Till till = new Till(orderList);
            orderList.DeleteMain(MainMenu.PepperoniPizza);
            Assert.AreEqual("£7.00", till.GetTotalFromList());
        }

        [Test]
        [TestCase(2, 2, "£22.80")]
        [TestCase(2, 0, "£8.80")]
        [TestCase(0, 2, "£14.00")]
        [TestCase(5, 11, "£99.00")]
        [TestCase(11, 5, "£83.40")]
        [TestCase(15, 15, "£171.00")]
        public void GetTotalOfMultipleFoodItems(int numOfStarters, int numOfMains, string expectedCost)
        {
            OrderList orderList = new OrderList();
            for (int i = 0; i < numOfStarters; i++)
            {
                orderList.AddStarter(StarterMenu.Chips);
            }

            for (int i = 0; i < numOfMains; i++)
            {
                orderList.AddMain(MainMenu.CheeseBurger);
            }

            Till till = new Till(orderList);
            Assert.AreEqual(expectedCost, till.GetTotalFromList());
        }

        [Test]
        [TestCase(3, 3, "£18.40")]
        [TestCase(3, 0, "£4.40")]
        [TestCase(0, 2, "£7.00")]
        [TestCase(5, 11, "£83.20")]
        [TestCase(11, 5, "£67.60")]
        [TestCase(15, 15, "£155.20")]
        public void GetTotalOfMultipleFoodItemsAfterMultipleDeletes(int numOfStarters, int numOfMains, string expectedCost)
        {
            OrderList orderList = new OrderList();
            for (int i = 0; i < numOfStarters; i++)
            {
                orderList.AddStarter(StarterMenu.Chips);
            }

            for (int i = 0; i < numOfMains; i++)
            {
                orderList.AddMain(MainMenu.CheeseBurger);
            }

            Till till = new Till(orderList);
            orderList.DeleteStarter(StarterMenu.Chips);
            orderList.DeleteStarter(StarterMenu.Chips);
            orderList.DeleteMain(MainMenu.CheeseBurger);

            Assert.AreEqual(expectedCost, till.GetTotalFromList());
        }
    }
}