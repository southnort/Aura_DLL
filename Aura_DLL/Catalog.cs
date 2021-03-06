﻿using System.Collections.Generic;

namespace Aura.Model
{
    static public class Catalog
    {
        //класс-хранилище для списков в формах

        public static List<string> allStatuses = new List<string>()
        {
            "<не указано>",         //0
            "Опубликована",         //1  
            "Завершена",            //2   
            "Отменена",             //3

        };

        //public static List<string> allStages = new List<string>()
        //{
        //    "<не указано>",         //0

        //    "Вскрытие конвертов",   //1
        //    "Рассмотрение",         //2
        //    "Оценка",               //3

        //    "Первые части",         //4
        //    "Вторые части",         //5
        //    "Итоговый протокол",    //6

        //};

        public static List<string> countOfBidsTexts = new List<string>()
        {
            "<не указано>",         //0
            "одна заявка",          //1
            "две и более заявок",   //2
            "нет заявок",           //3

        };


        //public static List<PurchaseMethod> purchaseMethods = new List<PurchaseMethod>()
        //{
        //    //методы осуществления закупок
        //    //статусы закупок тоже здесь
        //    new EmptyPurchaseMethod(),  //0
        //    new AloneProvider(),        //1
        //    new DemandOfQuotation(),    //2
        //    new DemandOfQuotationEF(),  //3
        //    new Auction(),              //4
        //    new Konkurs(),              //5
        //    new KonkursEF(),            //6                
        //    new AuctionEF(),            //7
        //    new AuctionEF_SMP(),        //8

        //};

        public static List<string> protocolStatuses = new List<string>()
        {
            //статусы протоколов
            "<не указано>",     //0             
            "Жду скан",         //1
            "Опубликовано",     //2

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

                //класс закупки
                { "id", "id" },
                { "employeID", "Ответственный за размещение" },
                { "organizationID", "Организация-заказчик" },
                { "purchaseMethodID", "Способ размещения" },
                { "purchaseName", "Наименование объекта закупки" },
                { "statusID", "Статус" },
                { "purchacePrice", "НМЦК" },

                { "purchaseEisNum", "Номер извещения в ЕИСе" },
                { "purchaseEisDate", "Дата публикации извещения в ЕИС" },
                { "bidsStartDate", "Дата начала подачи заявок" },
                { "bidsEndDate", "Дата окончания подачи заявок" },
                { "bidsOpenDate", "Дата вскрытия конвертов" },
                { "bidsFirstPartDate", "Дата рассмотрения первых частей" },
                { "auctionDate", "Дата проведения аукциона" },
                { "bidsSecondPartDate", "Дата рассмотрения вторых частей" },
                { "bidsFinishDate", "Дата подведения итогов" },

                { "contractPrice", "Цена заключенного контракта" },
                { "contractDateReal", "Дата подписания контракта" },
                { "reestrDateLast", "Дата внесения контракта в реестр" },
                { "reestrNumber", "Реестровый номер контракта в ЕИС" },
                { "comments", "Комментарии" },
                { "law", "Закон" },
                { "withAZK", "С АЦК или нет" },
                { "employeDocumentationID", "Ответственный за подготовку документации" },
                { "resultOfControl", "Результаты проверки" },

                { "protocolStatusID", "Статус протокола закупки" },
                { "bidsReviewDate", "Дата рассмотрения заявок" },
                { "bidsRatingDate", "Дата оценки заявок" },
                { "controlStatus", "Проверено" },
                { "colorMark", "Метка" },
                { "commentsFontColor", "Цвет комментария" },
                { "resultOfControlColor", "цвет результата контроля" },
                { "employeReestID", "Ответственный за занесение в реест" },
                { "reestrStatus", "Внесено в реест" },
                { "withoutPurchase", "Только договор" },
                { "organisationInn", "ИНН организации заказчика" },


                //класс организации
                { "name", "Наименование" },
                { "inn", "ИНН" },
                { "phoneNumber", "Номер телефона" },
                { "contactName", "Контактное лицо" },
                { "email", "e-mail" },
                { "originalID", "Оригинал договора" },
                { "contractNumber", "Номер договора" },
                { "contractStart", "Срок действия с" },
                { "contractEnd", "Срок действия по" },
                { "contractCondition", "Состояние договора" },
                { "contractType", "Тип" },
                { "contractsIDs", "ID договоров" },
                { "number", "Редактируемый номер организации" },

        };
    }

}
