using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RestaurantTill
{
    class Till
    {
        private OrderList _orderList;

        public Till (OrderList orderList)
        {
            _orderList = orderList;
        }

        public string GetTotalFromList()
        {
            decimal total = 0;

            foreach (var item in _orderList.GetList())
            {
                    total += item.Price;
            }

            return convertToPounds(total);
        }

        public string convertToPounds(decimal total)
        {
            return total.ToString("C", CultureInfo.GetCultureInfo("en-gb"));
        }

    }
}
