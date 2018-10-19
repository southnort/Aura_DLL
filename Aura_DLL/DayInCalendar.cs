using System;
using System.Collections.Generic;

namespace Aura.Model
{
    [Serializable]
    public class DayInCalendar
    {
        //класс описывающий один день из календаря. 
        //хранит в себе список закупок, для которых этот день важен 
        public DayInCalendar(DateTime date)
        {
            this.date = date;
        }


        public DateTime date { get; private set; }
        private List<Purchase> purchases = new List<Purchase>();

        public Dictionary<Purchase, string> events =
        new Dictionary<Purchase, string>(); //описание событий в этот день 


        public void Add(Purchase purchase)
        {
            //добавить новую закупку, если она еще не добавлена 
            if (!purchases.Contains(purchase))
            {
                purchases.Add(purchase);
                handlePurchase(purchase);
            }

        }

        private void handlePurchase(Purchase pur)
        {
            //метод проверяет, какое именно событие назначено на эту дату 
            // и добавляет соответствующее описание 

            string eventStr = "";


            if (DateEqual(pur.bidsFinishDate))
                eventStr = "Подведение итогов";
            else if (DateEqual(pur.auctionDate) && pur.protocolStatusID != 1)
                eventStr = "Аукцион";
            else if (DateEqual(pur.bidsSecondPartDate) && pur.protocolStatusID != 1)
                eventStr = "Вторые части";
            else if (DateEqual(pur.bidsFirstPartDate))
                eventStr = "Первые части";

            else if (DateEqual(pur.bidsRatingDate))
                eventStr = "Оценка";
            else if (DateEqual(pur.bidsReviewDate))
                eventStr = "Рассмотрение";
            else if (DateEqual(pur.bidsOpenDate))
                eventStr = "Вскрытие конвертов";

            else if (DateEqual(pur.bidsEndDate))
                eventStr = "Окончание подачи заявок";
            else if (DateEqual(pur.bidsStartDate))
                eventStr = "Начало подачи заявок";

            if (eventStr != "")
                events.Add(pur, eventStr);

        }

        private bool DateEqual(DateTime purDate)
        {
            return (
                date.Year == purDate.Year &&
                date.Month == purDate.Month &&
                date.Day == purDate.Day
                );
        }

    }
}