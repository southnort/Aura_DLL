using System;
using System.Data;
using AuraDLL.Methods;
using System.Text;


namespace Aura.Model
{
    [Serializable]
    public class Purchase : ILoggable
    {
        //класс, описывающий объект закупки

        public Purchase()
        {
            purchaseEisDate = bidsStartDate = bidsEndDate =
                bidsOpenDate = bidsFirstPartDate = auctionDate =
                bidsSecondPartDate = bidsFinishDate = contractDatePlan =
                contractDateLast = contractDateReal = reestrDateLast =

                DateTime.MinValue;

            colorMark = -1;

        }


        public Purchase(DataRow row)
        {
            //создать закупку из строки БД

            id = row[0] is DBNull ? 0 : (int)(long)row[0];
            employeID = row[1] is DBNull ? 0 : (int)(long)row[1];
            organizationID = row[2] is DBNull ? 0 : (int)(long)row[2];
            purchaseMethodID = row[3] is DBNull ? 0 : (int)(long)row[3];
            purchaseName = row[4] is DBNull ? "" : (string)row[4];
            statusID = row[5] is DBNull ? 0 : (int)(long)row[5];
            purchacePrice = row[6] is DBNull ? 0 : (double)row[6];

            purchaseEisNum = row[7] is DBNull ? "" : (string)row[7];
            purchaseEisDate = ToDateTime(row[8]);
            bidsStartDate = ToDateTime(row[9]);
            bidsEndDate = ToDateTime(row[10]);
            bidsOpenDate = ToDateTime(row[11]);
            bidsFirstPartDate = ToDateTime(row[12]);
            auctionDate = ToDateTime(row[13]);
            bidsSecondPartDate = ToDateTime(row[14]);
            bidsFinishDate = ToDateTime(row[15]);

            contractPrice = row[16] is DBNull ? 0 : (double)row[16];
            contractDatePlan = ToDateTime(row[17]);
            contractDateLast = ToDateTime(row[18]);
            contractDateReal = ToDateTime(row[19]);
            reestrDateLast = ToDateTime(row[20]);
            reestrNumber = row[21] is DBNull ? "" : (string)row[21];

            comments = row[22] is DBNull ? "" : (string)row[22];
            law = row[23] is DBNull ? 0 : (int)(long)row[23];
            withAZK = row[24] is DBNull ? 0 : (int)(long)row[24];
            employeDocumentationID = row[25] is DBNull ? 0 : (int)(long)row[25];
            resultOfControl = row[26] is DBNull ? "" : (string)row[26];
            protocolStatusID1 = row[27] is DBNull ? 0 : (int)(long)row[27];
            bidsReviewDate = ToDateTime(row[28]);
            bidsRatingDate = ToDateTime(row[29]);
            controlStatus = row[30] is DBNull ? 0 : (int)(long)row[30];
            colorMark = row[31] is DBNull ? 0 : (int)(long)row[31];

            commentsFontColor = row[32] is DBNull ? 0 : (int)(long)row[32];
            resultOfControlColor = row[33] is DBNull ? 0 : (int)(long)row[33];
            employeReestID = row[34] is DBNull ? 0 : (int)(long)row[34];
            reestrStatus = row[35] is DBNull ? 0 : (int)(long)row[35];
            withoutPurchase = row[36] is DBNull ? 0 : (int)(long)row[36];
            organisationInn = row[37] is DBNull ? "" : (string)row[37];

            stageID = row[38] is DBNull ? 0 : (int)(long)row[38];
            try
            {
                bidsCount1 = row[39] is DBNull ? 0 : (int)(long)row[39];
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n_______________");
                Console.WriteLine(row[39].GetType() + " #" + row[39] + "#");
                Console.WriteLine("_______________\n\n");
                throw ex;
            }
            bidsCount2 = row[40] is DBNull ? 0 : (int)(long)row[40];
            bidsCount3 = row[41] is DBNull ? 0 : (int)(long)row[41];

            protocolStatusID2 = row[42] is DBNull ? 0 : (int)(long)row[42];
            protocolStatusID3 = row[43] is DBNull ? 0 : (int)(long)row[43];

        }

        /*
                public int id;                      //ИД закупки в БД
                public int employeID;               //индекс юзера, ответственного за размещение
                public int organizationID;          //индекс организации - заказчика
                public int purchaseMethodID;        //индекс способа определения поставщика
                public string purchaseName;         //наименование объекта закупки
                public int statusID;                //идентификатор статуса. Опубликована, завершена, отменена
                public double purchacePrice;        //НМЦК, начальная цена

                public string purchaseEisNum;       //номер извещения в ЕИСе
                public DateTime purchaseEisDate;    //дата публикации извещения в ЕИС
                public DateTime bidsStartDate;      //дата начала подачи заявок
                public DateTime bidsEndDate;        //дата окончания подачи заявок
                public DateTime bidsOpenDate;       //дата вскрытия конвертов
                public DateTime bidsFirstPartDate;  //дата рассмотрения первых частей
                public DateTime auctionDate;        //дата проведения аукциона
                public DateTime bidsSecondPartDate; //дата рассмотрения вторых частей
                public DateTime bidsFinishDate;     //дата подведения итогов

                public double contractPrice;         //цена заключенного контракта
                public DateTime contractDatePlan;     //НЕ ИСПОЛЬЗУЕТСЯ
                public DateTime contractDateLast;     //НЕ ИСПОЛЬЗУЕТСЯ
                public DateTime contractDateReal;     //дата подписания контракта (фактическая)
                public DateTime reestrDateLast;       //дата внесения контракта в реестр (фактическая)
                public string reestrNumber;         //реестровый номер контракта в ЕИС

                public string comments;             //комментарии к закупке

                /// <summary>
                /// Закон, по которой проводится процедура. 
                /// 0 - не указано,
                /// 1 - 44 ФЗ, 
                /// 2 - 223 ФЗ, 
                /// </summary>
                public int law;                     //закон, по которой проводится процедура
                public int withAZK;                 //занесена ли закупка в АЦК. 0 - занесена, 1- нет
                public int employeDocumentationID;  //ID юзера, ответственного за подготовку документации
                public string resultOfControl;      //результаты проверки


                public int protocolStatusID1;
                public DateTime bidsReviewDate;       //дата рассмотрения заявок
                public DateTime bidsRatingDate;       //дата оценки заявок
                public int controlStatus;           //проверено или не проверено
                public int colorMark;               //цветовая отметка закупки. Берется из Color.ToArgb()

                public int commentsFontColor;       //цвет комментариев. Берется из Color.ToArgbs()
                public int resultOfControlColor;    //цвет текста результата контроля. Берется из Color.ToArgbs()
                public int employeReestID;          //ID юзера, ответственного за занесение в реест
                public int reestrStatus;            //внесено или не внесено в реестр

                /// <summary>
                /// внесена через реестр закупок или напрямую договор 
                /// если == 1, значит внесена напрямую через реестр договоров
                /// </summary>
                public int withoutPurchase;
                public string organisationInn;      //ИНН организации заказчика

                public int stageID;                 //этап закупки. Вскрытие, рассмотрение итд        
                public int bidsCount1;
                public int bidsCount2;
                public int bidsCount3;
                public int protocolStatusID2;
                public int protocolStatusID3;

            */


        private int _id;
        private int _employeID;
        private int _employeDocumentationID;
        private int _organisationID;
        private string _organisationInn;
        private int _purchaseMethodID;

        private double _purchacePrice;
        private string _purchaseEisNum;
        private DateTime _purchaseEisDate;
        private DateTime _bidsStartDate;
        private DateTime _bidsEndDate;
        private DateTime _bidsOpenDate;
        private DateTime _bidsReviewDate;
        private DateTime _bidsRatingDate;
        private DateTime _bidsFirstPartDate;
        private DateTime _auctionDate;
        private DateTime _bidsSecondPartDate;
        private DateTime _bidsFinishDate;

        private int _statusID;
        private int _stageID;
        private int _protocolStatusID1;
        private int _protocolStatusID2;
        private int _protocolStatusID3;
        private int _bidsCount1;
        private int _bidsCount2;
        private int _bidsCount3;

        private string _purchaseName;
        private int _law;
        private int _withAZK;
        private int _withoutPurchase;

        private string _comments;
        private string _resultOfControl;
        private int _controlStatus;
        private int _colorMark;

        private int _employeReestID;
        private double _contractPrice;
        private DateTime _contractDateReal;
        private DateTime _reestrDateLast;
        private string _reestrNumber;
        private int _reestrStatus;
        




        public int id
        {
            get { return _id; }

            set
            {
                _id = value;
                ValueChanged("id", value);
            }
        }
        public int employeID
        {
            get { return _employeID; }

            set
            {
                _employeID = value;
                ValueChanged("employeID", value);
            }
        }
        public int organisationID
        {
            get { return _organisationID; }

            set
            {
                _organisationID = value;
                ValueChanged("organisationID", value);
            }
        }
        public string organisationInn
        {
            get { return _organisationInn; }

            set
            {
                _organisationInn = value;
                ValueChanged("organisationInn", value);
            }
        }
        public int purchaseMethodID
        {
            get { return _purchaseMethodID; }

            set
            {
                _purchaseMethodID = value;
                ValueChanged("purchaseMethodID", value);
            }
        }
        public string purchaseName
        {
            get { return _purchaseName; }

            set
            {
                _purchaseName = value;
                ValueChanged("purchaseName", value);
            }
        }
        public int statusID
        {
            get { return _statusID; }

            set
            {
                _statusID = value;
                ValueChanged("statusID", value);
            }
        }
        public int stageID
        {
            get { return _stageID; }

            set
            {
                _stageID = value;
                ValueChanged("stageID", value);
            }
        }
        public double purchacePrice
        {
            get { return _purchacePrice; }

            set
            {
                _purchacePrice = value;
                ValueChanged("purchacePrice", value);
            }
        }
        public string purchaseEisNum
        {
            get { return _purchaseEisNum; }

            set
            {
                _purchaseEisNum = value;
                ValueChanged("purchaseEisNum", value);
            }
        }
        public DateTime purchaseEisDate
        {
            get { return _purchaseEisDate; }

            set
            {
                _purchaseEisDate = value;
                ValueChanged("purchaseEisDate", value);
            }
        }
        public DateTime bidsStartDate
        {
            get { return _bidsStartDate; }

            set
            {
                _bidsStartDate = value;
                ValueChanged("bidsStartDate", value);
            }
        }
        public DateTime bidsEndDate
        {
            get { return _bidsEndDate; }

            set
            {
                _bidsEndDate = value;
                ValueChanged("bidsEndDate", value);
            }
        }
        public DateTime bidsOpenDate
        {
            get { return _bidsOpenDate; }

            set
            {
                _bidsOpenDate = value;
                ValueChanged("bidsOpenDate", value);
            }
        }
        public DateTime bidsFirstPartDate
        {
            get { return _bidsFirstPartDate; }

            set
            {
                _bidsFirstPartDate = value;
                ValueChanged("bidsFirstPartDate", value);
            }
        }
        public DateTime auctionDate
        {
            get { return _auctionDate; }

            set
            {
                _auctionDate = value;
                ValueChanged("auctionDate", value);
            }
        }
        public DateTime bidsSecondPartDate
        {
            get { return _bidsSecondPartDate; }

            set
            {
                _bidsSecondPartDate = value;
                ValueChanged("bidsSecondPartDate", value);
            }
        }
        public DateTime bidsFinishDate
        {
            get { return _bidsFinishDate; }

            set
            {
                _bidsFinishDate = value;
                ValueChanged("bidsFinishDate", value);
            }
        }
        public double contractPrice
        {
            get { return _contractPrice; }

            set
            {
                _contractPrice = value;
                ValueChanged("contractPrice", value);
            }
        }
        public DateTime contractDateReal
        {
            get { return _contractDateReal; }

            set
            {
                _contractDateReal = value;
                ValueChanged("contractDateReal", value);
            }
        }
        public DateTime reestrDateLast
        {
            get { return _reestrDateLast; }

            set
            {
                _reestrDateLast = value;
                ValueChanged("reestrDateLast", value);
            }
        }
        public string reestrNumber
        {
            get { return _reestrNumber; }

            set
            {
                _reestrNumber = value;
                ValueChanged("reestrNumber", value);
            }
        }
        public string comments
        {
            get { return _comments; }

            set
            {
                _comments = value;
                ValueChanged("comments", value);
            }
        }
        public int law
        {
            get { return _law; }

            set
            {
                _law = value;
                ValueChanged("law", value);
            }
        }
        public int withAZK
        {
            get { return _withAZK; }

            set
            {
                _withAZK = value;
                ValueChanged("withAZK", value);
            }
        }
        public int employeDocumentationID
        {
            get { return _employeDocumentationID; }

            set
            {
                _employeDocumentationID = value;
                ValueChanged("employeDocumentationID", value);
            }
        }
        public string resultOfControl
        {
            get { return _resultOfControl; }

            set
            {
                _resultOfControl = value;
                ValueChanged("resultOfControl", value);
            }
        }
        public int protocolStatusID
        {
            get { return _protocolStatusID; }

            set
            {
                _protocolStatusID = value;
                ValueChanged("protocolStatusID", value);
            }
        }
        public int bidsCount
        {
            get { return _bidsCount; }

            set
            {
                _bidsCount = value;
                ValueChanged("bidsCount", value);
            }
        }
        public DateTime bidsReviewDate
        {
            get { return _bidsReviewDate; }

            set
            {
                _bidsReviewDate = value;
                ValueChanged("bidsReviewDate", value);
            }
        }
        public DateTime bidsRatingDate
        {
            get { return _bidsRatingDate; }

            set
            {
                _bidsRatingDate = value;
                ValueChanged("bidsRatingDate", value);
            }
        }
        public int controlStatus
        {
            get { return _controlStatus; }

            set
            {
                _controlStatus = value;
                ValueChanged("controlStatus", value);
            }
        }
        public int colorMark
        {
            get { return _colorMark; }

            set
            {
                _colorMark = value;
                ValueChanged("colorMark", value);
            }
        }
        public int employeReestID
        {
            get { return _employeReestID; }

            set
            {
                _employeReestID = value;
                ValueChanged("employeReestID", value);
            }
        }
        public int reestrStatus
        {
            get { return _reestrStatus; }

            set
            {
                _reestrStatus = value;
                ValueChanged("reestrStatus", value);
            }
        }
        public int withoutPurchase
        {
            get { return _withoutPurchase; }

            set
            {
                _withoutPurchase = value;
                ValueChanged("withoutPurchase", value);
            }
        }






        //public int ProtocolStatus
        //{
        //    get
        //    {
        //        switch (stageID)
        //        {
        //            case 2: return protocolStatusID2;
        //            case 3: return protocolStatusID3;

        //            case 5: return protocolStatusID2;
        //            case 6: return protocolStatusID3;

        //            default: return protocolStatusID1;
        //        }
        //    }


        //    set
        //    {
        //        switch (stageID)
        //        {
        //            case 2: protocolStatusID2 = value; break;
        //            case 3: protocolStatusID3 = value; break;

        //            case 5: protocolStatusID2 = value; break;
        //            case 6: protocolStatusID3 = value; break;

        //            default: protocolStatusID1 = value; break;
        //        }
        //    }
        //}

        //public int BidsCountIndex
        //{
        //    get
        //    {
        //        switch (stageID)
        //        {
        //            case 2: return bidsCount2;
        //            case 3: return bidsCount3;

        //            case 5: return bidsCount2;
        //            case 6: return bidsCount3;

        //            default: return bidsCount1;
        //        }

        //    }

        //    set
        //    {
        //        switch (stageID)
        //        {
        //            case 2: bidsCount2 = value; break;
        //            case 3: bidsCount3 = value; break;

        //            case 5: bidsCount2 = value; break;
        //            case 6: bidsCount3 = value; break;

        //            default: bidsCount1 = value; break;
        //        }

        //    }

        //}

        private void ValueChanged(string fieldName, object value)
        {
        }


        public string LogObjectName { get { return "Журнал редактирования\n" + purchaseName; } }

        private DateTime ToDateTime(object ob)
        {
            return Methods.ToDateTime(ob);
        }

        public string GetSqlStringForLog()
        {
            //строка для запроса логов объекта
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Logs WHERE tableName = 'Purchases'");
            sb.Append(" AND itemID = '");
            sb.Append(id);
            sb.Append("'");

            return sb.ToString();

        }
    }

}
