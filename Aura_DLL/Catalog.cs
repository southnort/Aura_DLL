using System.Collections.Generic;

namespace Aura.Model
{
    static public class Catalog
    {
        //класс-хранилище для списков в формах
        public static List<string> allStatuses = new List<string>()
        {
            "<не указано>",         //0
            "Опубликована",         //1

            "Вскрытие конвертов",   //2
            "Рассмотрение",         //3
            "Оценка",               //4

            "Первые части",         //5
            "Вторые части",         //6
            "Подведение итогов",    //7

            "Завершена",            //8    
            "Отменена",             //9

        };


        public static List<PurchaseMethod> purchaseMethods = new List<PurchaseMethod>()
        {
            //методы осуществления закупок
            //статусы закупок тоже здесь
            new EmptyPurchaseMethod(),  //0
            new AloneProvider(),        //1
            new DemandOfQuotation(),    //2
            new DemandOfQuotationEF(),  //3
            new Auction(),              //4
            new Konkurs(),              //5
            new KonkursEF(),            //6                
            new AuctionEF(),            //7

        };

        public static List<string> protocolStatuses = new List<string>()
        {
            //статусы протоколов
            "<не указано>",     //0 
            "0 заявок",         //1
            "1 заявка",         //2
            "2 и более заявок", //3
            "Жду скан",         //4
            "Опубликовано",     //5

        };

        public static List<string> contractConditions = new List<string>
        {
            //состояние заключенного договора с заказчиком на обслуживание
            "<не указано>",
            "действует",
            "расторгнут",
            "без договора",

        };

        public static List<string> contractOriginalConditions = new List<string>
        {
            //есть ли оригинал договора на обслуживание с заказчиком, или только копия
            "<не указано>",
            "оригинал",
            "нет оригинала",
            "подписан ЭЦП",
            "без договора",

        };

        public static List<string> laws = new List<string>()
        {
            //названия законов
            "<не указано>",
            "44-ФЗ",
            "223-ФЗ",
            "44-ФЗ и 223-ФЗ",

        };

        public static List<string> contractTypes = new List<string>()
        {
            //типы договоров с заказчиками
            "<не указано>",
            "постоянный",
            "разовый",
        };

        public static Dictionary<string, string> dataTableHeaders
            = new Dictionary<string, string>()
        {
                //технические названия колонок в классах переводятся в русский текст
                { "id", "id" },
                { "employeID", "Ответственный за размещение" },

        };
    }

}
