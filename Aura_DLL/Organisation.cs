using System;
using System.Data;
using AuraDLL.Methods;
using System.Text;

namespace Aura.Model
{
    [Serializable]
    public class Organisation : ILoggable
    {
        //класс, описывающий организацию-заказчика

        public Organisation()
        {
        }

        public Organisation(DataRow row)
        {
            try
            {
                id = row[0] is DBNull ? 0 : (int)(long)row[0];
                name = row[1] is DBNull ? "" : (string)row[1];
                inn = row[2] is DBNull ? "" : (string)row[2];
                phoneNumber = row[3] is DBNull ? "" : (string)row[3];
                contactName = row[4] is DBNull ? "" : (string)row[4];
                email = row[5] is DBNull ? "" : (string)row[5];

                originalID = row[6] is DBNull ? 0 : (int)(long)row[6];
                contractNumber = row[7] is DBNull ? "" : (string)row[7];
                contractStart = Methods.ToDateTime(row[8]);
                contractEnd = Methods.ToDateTime(row[9]);
                comments = row[10] is DBNull ? "" : (string)row[10];
                contractCondition = row[11] is DBNull ? 0 : (int)(long)row[11];
                law = row[12] is DBNull ? 0 : (int)(long)row[12];
                contractType = row[13] is DBNull ? 0 : (int)(long)row[13];

                contractsIDs = row[14] is DBNull ? "" : (string)row[14];
                number = row[15] is DBNull ? "" : (string)row[15];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }


        }




        public int id;
        public string name;
        public string inn;
        public string phoneNumber;
        public string contactName;
        public string email;

        /// <summary>
        /// Наличие оригинала договора,
        /// 0 - не указано,
        /// 1 - оригинал,
        /// 2 - нет оригинала,
        /// 3 - подписан ЭЦП
        /// 4 - без договора,
        /// </summary>
        public int originalID;              //ID наличия оригинала договора
        public string contractNumber;       //номер договора с заказчиком
        public DateTime contractStart;        //начало действия договора
        public DateTime contractEnd;          //окончание действия договора 
        public string comments;

        /// <summary>
        /// Состояние договора.
        /// 0 - не указано, 
        /// 1 - действует,
        /// 2 - расторгнут,
        /// 3 - без договора,
        /// </summary>
        public int contractCondition;       //состояние договора

        /// <summary>
        /// закон, по которому заключен договор обслуживания. 
        /// 0 - не указано,
        /// 1 - 44-ФЗ, 
        /// 2 - 223-ФЗ, 
        /// 3 - 44 и 223, 
        /// </summary>
        public int law;     //закон, по которому заключен договор обслуживания

        /// <summary>
        /// тип договора
        /// 0 - не указано,
        /// 1 - постоянный,
        /// 2 - разовый,
        /// </summary>
        public int contractType;    //тип договора (разовый или постоянный)

        public string contractsIDs;     //ID договоров из БД договоров
        public string number;           //редактируемый номер организации



        public string LogObjectName { get { return "Журнал обработки оргиназации\n" + name; } }

        public string GetSqlStringForLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Logs WHERE tableName = 'Organisations'");
            sb.Append(" AND itemID = '");
            sb.Append(id);
            sb.Append("'");

            return sb.ToString();

        }
    }
}
