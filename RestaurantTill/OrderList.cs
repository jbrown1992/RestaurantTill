using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantTill
{
    class OrderList
    {

        List<FoodItem> orderList;

        public OrderList()
        {
            orderList = new List<FoodItem>();
        }

        public void AddStarter(string name)
        {
            orderList.Add(new Starter(name));
        }

        public void AddMain(string name)
        {
            orderList.Add(new Main(name));
        }

        public int GetCountOfItems()
        {
            return orderList.Count();
        }

        public List<FoodItem> GetList()
        {
            return orderList;
        }

        public void DeleteStarter(string name)
        {
                var starterToRemove = orderList.FirstOrDefault(item => item is Starter && item.Meal == name);
                orderList.Remove(starterToRemove);
        }

        public void DeleteMain(string name)
        {
                var mainToRemove = orderList.FirstOrDefault(item => item is Main && item.Meal == name);
                orderList.Remove(mainToRemove);
        }

        public void UpdateStarter(string name, string newName)
        {
            orderList.FirstOrDefault(item => item is Starter && item.Meal == name).Meal = newName;
        }

        public void UpdateMain(string name, string newName)
        {
            orderList.FirstOrDefault(item => item is Main && item.Meal == name).Meal = newName;
        }
    }
}