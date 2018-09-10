using System;
using System.Data;
using System.Globalization;

namespace Aura.Model
{
    [Serializable]
   public class Contract
    {
        //класс, описывающий договор с заказчиком.
        //223 или 44 указывается в самой организации
        //здесь хранится только номер и срок действия

        public Contract()
        {
        }

        public Contract(DataRow row)
        {
            try
            {
                id = row[0] is DBNull ? 0 : (long)row[0];
                organisationID = row[1] is DBNull ? 0 : (long)row[1];
                contractNumber = row[2] is DBNull ? "" : (string)row[2];
                contractStart = ToDateTime(row[3]);
                contractEnd = ToDateTime(row[4]);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }




        public long id;
        public long organisationID;
        public string contractNumber;
        public DateTime contractStart;
        public DateTime contractEnd;

        private DateTime ToDateTime(object ob)
        {
            if (ob is DBNull)
                return DateTime.MinValue;
            else
                return DateTime.Parse((string)ob);

            //try
            //{
            //    return DateTime.Parse((string)ob);
            //}

            //catch
            //{
            //    return DateTime.MinValue;
            //}
        }
    }
}
