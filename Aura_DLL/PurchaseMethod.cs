using System.Collections.Generic;
using System.Data;
using System;

namespace Aura.Model
{
    [System.Serializable]
    public class PurchaseMethod
    {
        //класс, описывающий метод закупки
        public int id { get; set; }
        public string name { get; set; }
        public int isActual;    //0 - неактуальный 1- актуальный

        public PurchaseMethod() { }
        public PurchaseMethod(DataRow row)
        {
            id = row[0] is DBNull ? 0 : (int)(long)row[0];
            isActual = row[1] is DBNull ? 0 : (int)(long)row[1];
            name = row[2] is DBNull ? "" : (string)row[2];
        }

        public Dictionary<int, string> purchaseStages;
      
        protected void CreateDictionary(List<int> stageIndexes)
        {
            //добавляем в словарь все доступные этапы по указанным индексам
            purchaseStages = new Dictionary<int, string>();
            foreach (var item in stageIndexes)
            {
                purchaseStages.Add(item, Catalog.allStages[item]);

            }

        }

    }

    public class EmptyPurchaseMethod : PurchaseMethod
    {
        //пустой метод определения поставщика
        public EmptyPurchaseMethod()
        {
            name = "<не указано>";
            var stageIndexes = new List<int>() { 0, };
            CreateDictionary(stageIndexes);
        }

    }

    public class AloneProvider : PurchaseMethod
    {
        //Единственный поставщик
        public AloneProvider()
        {
            name = "Единственный поставщик";
            var stageIndexes = new List<int>()
            {
                0,
            };
            CreateDictionary(stageIndexes);
        }
    }


    public class DemandOfQuotation : PurchaseMethod
    {
        //запрос котировок
        public DemandOfQuotation()
        {
            name = "Запрос котировок";
            var stageIndexes = new List<int>()
            {
                0, 1, 2, 3,
            };
            CreateDictionary(stageIndexes);
        }
    }

    public class DemandOfQuotationEF : PurchaseMethod
    {
        //запрос котировок в электронной форме
        public DemandOfQuotationEF()
        {
            name = "Открытый запрос котировок в электронной форме";
            var stageIndexes = new List<int>()
            {
                0, 1, 2, 3,
            };
            CreateDictionary(stageIndexes);
        }
    }


    public class Auction : PurchaseMethod
    {
        //Электронный аукцион
        public Auction()
        {
            name = "Электронный аукцион";
            var stageIndexes = new List<int>()
            {
                0, 4, 5, 6,
            };
            CreateDictionary(stageIndexes);
        }
    }


    public class Konkurs : PurchaseMethod
    {
        //Обычный конкурс
        public Konkurs()
        {
            name = "Конкурс";
            var stageIndexes = new List<int>()
            {                
                0, 1, 2, 3, 
            };
            CreateDictionary(stageIndexes);
        }
    }

    public class KonkursEF : PurchaseMethod
    {
        //Конкурс в электронной форме
        public KonkursEF()
        {
            name = "Конкурс в электронной форме";
            var stageIndexes = new List<int>()
            {
                0, 1, 2, 3,
            };
            CreateDictionary(stageIndexes);
        }
    }

    public class AuctionEF : PurchaseMethod
    {
        //Электронный аукцион
        public AuctionEF()
        {
            name = "Открытый аукцион в электронной форме";
            var stageIndexes = new List<int>()
            {
                0, 4, 5, 6,
            };
            CreateDictionary(stageIndexes);
        }
    }

    public class AuctionEF_SMP : PurchaseMethod
    {
        //Аукцион в электронной форме, участниками которого могут быть только субъекты малого и среднего предпринимательства
        public AuctionEF_SMP()
        {
            name = "Аукцион в электронной форме, участниками которого могут быть только субъекты малого и среднего предпринимательства";
            var stageIndexes = new List<int>()
            {
                0, 4, 5, 6,
            };
            CreateDictionary(stageIndexes);
        }
    }


}

