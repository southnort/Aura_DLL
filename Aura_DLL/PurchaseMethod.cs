using System.Collections.Generic;

namespace Aura.Model
{
    public abstract class PurchaseMethod
    {
        //класс, описывающий метод закупки


        public string name { get; protected set; }
        public Dictionary<int, string> purchaseStatuses;

        protected void CreateDictionary(List<int> statusIndexes)
        {
            //добавляем в словарь все доступные статусы по указанным индексам
            purchaseStatuses = new Dictionary<int, string>();
            foreach (var item in statusIndexes)
            {
                purchaseStatuses.Add(item, Catalog.allStatuses[item]);

            }

        }


    }

    public class EmptyPurchaseMethod : PurchaseMethod
    {
        //пустой метод определения поставщика
        public EmptyPurchaseMethod()
        {
            name = "<не указано>";
            var statusIndexes = new List<int>() { 0, };
            CreateDictionary(statusIndexes);
        }

    }

    public class AloneProvider : PurchaseMethod
    {
        //Единственный поставщик
        public AloneProvider()
        {
            name = "Единственный поставщик";
            var statusIndexes = new List<int>()
            {
                0, 1, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }


    public class DemandOfQuotation : PurchaseMethod
    {
        //запрос котировок
        public DemandOfQuotation()
        {
            name = "Запрос котировок";
            var statusIndexes = new List<int>()
            {
                0, 1, 2, 3, 4, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }

    public class DemandOfQuotationEF : PurchaseMethod
    {
        //запрос котировок в электронной форме
        public DemandOfQuotationEF()
        {
            name = "Запрос котировок в ЭФ";
            var statusIndexes = new List<int>()
            {
                0, 1, 2, 3, 4, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }


    public class Auction : PurchaseMethod
    {
        //Электронный аукцион
        public Auction()
        {
            name = "Электронный аукцион";
            var statusIndexes = new List<int>()
            {
                0, 1, 5, 6, 7, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }


    public class Konkurs : PurchaseMethod
    {
        //Обычный конкурс
        public Konkurs()
        {
            name = "Конкурс";
            var statusIndexes = new List<int>()
            {
                0, 1, 2, 3, 4, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }

    public class KonkursEF : PurchaseMethod
    {
        //Конкурс в электронной форме
        public KonkursEF()
        {
            name = "Конкурс в электронной форме";
            var statusIndexes = new List<int>()
            {
                0, 1, 2, 3, 4, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }

    public class AuctionEF : PurchaseMethod
    {
        //Электронный аукцион
        public AuctionEF()
        {
            name = "Открытый аукцион в электронной форме";
            var statusIndexes = new List<int>()
            {
                0, 1, 5, 6, 7, 8, 9,
            };
            CreateDictionary(statusIndexes);
        }
    }


}

