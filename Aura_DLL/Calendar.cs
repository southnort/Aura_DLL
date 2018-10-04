using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Model
{
    [Serializable]
    public class Calendar : Dictionary<DateTime, DayInCalendar>
    {
        //класс, описывающий календарь

        public Calendar(List<Purchase> purchases)
        {
            foreach (var purchase in purchases)
            {
                Add(purchase);
            }
        }

        public List<DayInCalendar> GetDays(int month,int year)
        {
            //создаем лист дней для выбранного месяца
            List<DayInCalendar> days = new List<DayInCalendar>();

            //добавляем в нужные пустые дни события из календаря
            foreach (var pair in this)
            {
                if (pair.Key.Month == month)
                    days.Add(pair.Value);
            }

            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                var date = new DayInCalendar(new DateTime(year, month, i + 1));
                if (!days.Contains(date))
                {
                    days.Add(date);
                }
            }

            return days;
        }      
               
        private void Add(Purchase purchase)
        {
            if (purchase == null) return;
            if (purchase.statusID == 9) return;

            Add(purchase.purchaseEisDate, purchase);
            Add(purchase.bidsStartDate, purchase);
            Add(purchase.bidsEndDate, purchase);
            Add(purchase.bidsOpenDate, purchase);
            Add(purchase.bidsFirstPartDate, purchase);
            Add(purchase.auctionDate, purchase);
            Add(purchase.bidsSecondPartDate, purchase);
            Add(purchase.bidsFinishDate, purchase);

            Add(purchase.bidsReviewDate, purchase);
            Add(purchase.bidsRatingDate, purchase);

            Add(purchase.contractDatePlan, purchase);
            Add(purchase.contractDateLast, purchase);
            Add(purchase.contractDateReal, purchase);
            Add(purchase.reestrDateLast, purchase);

        }




        private void Add(DateTime date, Purchase purchase)
        {
            DateTime tempDateTime = new DateTime(date.Year, date.Month, date.Day);

            if (!ContainsKey(tempDateTime))
            {
                Add(tempDateTime, new DayInCalendar(tempDateTime));
            }

            this[tempDateTime].Add(purchase);

        }


    }

    internal static class ExtensionsMethods
    {
        //статический класс для расширящих методов
        public static DateTime ToDateTime(this string str)
        {
            return Convert.ToDateTime(str);

        }
    }
}
