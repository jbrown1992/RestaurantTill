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
        [Description("Given I have an Order List" +
            "When I add a Starter" +
            "Then order size is 1")]
        public void AddStarterToList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            Assert.AreEqual(1, orderList.GetCountOfItems());
        }

        [Test]
        [Description("Given I have an Order List" +
            "And I add a Starter" +
            "When I delete a Starter" +
            "Then order size is 0")]
        public void DeleteStarterFromList()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            orderList.DeleteStarter(StarterMenu.Chips);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        [Description("Given I have an Order List" +
            "When I add a Main" +
            "Then order size is 1")]
        public void AddMainToList()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            Assert.AreEqual(1, orderList.GetCountOfItems());
        }

        [Test]
        [Description("Given I have an Order List" +
            "And I add a Main" +
            "When I delete a Main" +
            "Then order size is 0")]
        public void DeleteMainFromList()
        {
            OrderList orderList = new OrderList();
            orderList.AddMain(MainMenu.CheeseBurger);
            orderList.DeleteMain(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }


        [Test]
        [Description("Given I have an Order List" +
            "When I delete a Starter" +
            "Then order size is 0")]
        public void AttemptToDeleteStarterInEmptyList()
        {
            OrderList orderList = new OrderList();
            orderList.DeleteStarter(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }


        [Test]
        [Description("Given I have an Order List" +
            "When I delete a Main" +
            "Then order size is 0")]
        public void AttemptToDeleteMainInEmptyList()
        {
            OrderList orderList = new OrderList();
            orderList.DeleteMain(MainMenu.CheeseBurger);
            Assert.AreEqual(0, orderList.GetCountOfItems());
        }

        [Test]
        [Description("Given I have an Order List" +
            "When I add 2 Starters" +
            "And I add 3 Mains" +
            "Then order size is 5")]
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
        [Description("Given I have an Order List" +
            "And I add 2 Starters" +
            "And I add 4 Mains" +
            "When I delete 1 Starter" +
            "And I delete 2 Mains" +
            "Then order size is 3")]
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
        [Description("Given I have an Order List" +
            "When I get Total Cost" +
            "Then Total Cost is £0.00")]
        public void GetTotalOfEmptyList()
        {
            OrderList orderList = new OrderList();
            Till till = new Till(orderList);
            Assert.AreEqual("£0.00", till.GetTotalFromList());
        }


        [Test]
        [Description("Given I have an Order List" +
            "And I add 1 Starter" +
            "When I get Total Cost" +
            "Then Total Cost is £4.40")]
        public void GetTotalOfOneStarter()
        {
            OrderList orderList = new OrderList();
            orderList.AddStarter(StarterMenu.Chips);
            Till till = new Till(orderList);
            Assert.AreEqual("£4.40", till.GetTotalFromList());
        }

        [Test]
        [Description("Given I have an Order List" +
            "And I add 1 Main" +
            "When I get Total Cost" +
            "Then Total Cost is £7.00")]
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
        [Description("Given I have an Order List" +
            "And I add 8 Starters" +
            "And I add 11 Mains" +
            "When I get Total Cost" +
            "Then Total Cost is £112.20")]
        public void GetTotalOfMultipleFoodItems()
        {
            OrderList orderList = new OrderList();
            for (int i = 0; i < 8; i++)
            {
                orderList.AddStarter(StarterMenu.Chips);
            }

            for (int i = 0; i < 11; i++)
            {
                orderList.AddMain(MainMenu.CheeseBurger);
            }

            Till till = new Till(orderList);
            Assert.AreEqual("£112.20", till.GetTotalFromList());
        }


        [Test]
        [Description("Given I have an Order List" +
            "And I add 8 Starters" +
            "And I add 11 Mains" +
            "When I get Total Cost" +
            "Then Total Cost is £112.20")]
        public void GetTotalOfMultipleFoodItemsAfterMultipleDeletes()
        {
            OrderList orderList = new OrderList();
            for (int i = 0; i < 8; i++)
            {
                orderList.AddStarter(StarterMenu.Chips);
            }

            for (int i = 0; i < 11; i++)
            {
                orderList.AddMain(MainMenu.CheeseBurger);
            }

            Till till = new Till(orderList);
            orderList.DeleteStarter(StarterMenu.Chips);
            orderList.DeleteStarter(StarterMenu.Chips);
            orderList.DeleteMain(MainMenu.CheeseBurger);

            Assert.AreEqual("£96.40", till.GetTotalFromList());
        }
    }
}