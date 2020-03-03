using System;
using System.Data;
using AuraDLL.Methods;
using System.Text;

namespace Aura.Model
{
    [Serializable]
    public class PurchaseStage
    {
        public PurchaseStage()
        { }

        public PurchaseStage(DataRow row)
        {
            try
            {
                id = row[0] is DBNull ? 0 : (int)(long)row[0];
                statusName = row[1] is DBNull ? "" : (string)row[1];
                isActual = row[2] is DBNull ? 0 : (int)(long)row[2];
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }


        public int id;
        public string statusName;
        public int isActual;    //0 - неактуальный статус 1- актуальный

    }
}
