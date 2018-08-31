using System;
using System.Data;


namespace Aura.Model
{
    [Serializable]
    public class Report
    {
        //класс, описывающий разные ежемесячные отчеты заказчиков
        public Report(DataRow row)
        {
            organisationID = row[0] is DBNull ? 0 : (int)(long)row[0];
            commonPurchasesContractsReport = row[1] is DBNull ? "" : (string)row[1];
            singleSupplierContractsReport = row[2] is DBNull ? "" : (string)row[2];
            failedPurchasesContractsReport = row[3] is DBNull ? "" : (string)row[3];


        }

        public Report()
        {
        }


        public int organisationID;      //ИД заказчика, для которого делается отчет

        /// <summary>
        /// каждый вид отчета хранится одной строкой для заказчика
        /// Хранится в виде перечисления "Месяц-Год". Например
        ///  1.2018, 2.2018, 3.2018
        /// Если месяц год есть в строке - значит, отчет за этот месяц есть
        /// </summary>
        public string commonPurchasesContractsReport;       //договоры, заключенные по результатам закупок
        public string singleSupplierContractsReport;        //договоры, заключенные у единственного поставщика
        public string failedPurchasesContractsReport;       //договоры, заключенные по несостоявшимся процедурам

      


    }
}
