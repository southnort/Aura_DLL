using System;
using System.Data;
using AuraDLL.Methods;


namespace Aura.Model
{
    [Serializable]
    public class User
    {
        //класс, описывающий пользователя системы

        public User()
        {
            
        }

        public User(DataRow row)
        {
            ID = row[0] is DBNull ? 0 : (int)(long)row[0];
            login = row[1] is DBNull ? "" : (string)row[1];
            password = row[2] is DBNull ? "" : (string)row[2];
            name = row[3] is DBNull ? "" : (string)row[3];
            roleID = row[4] is DBNull ? -1 : (int)(long)row[4];
            dateOfCreation = Methods.ToDateTime(row[5]);
            dateOfLastEnter = Methods.ToDateTime(row[6]);
            law = row[7] is DBNull ? 0 : (int)(long)row[7];
        }

                   
        public int ID;
        public string login;
        public string password;
        public string name;                 //отображаемое в системе имя
        public int roleID;                  //ИД роли пользователя в системе (Админ, размещающий, проверяющий итд)
        public DateTime dateOfCreation;     //дата создания юзера
        public DateTime dateOfLastEnter;    //дата последнего успешного входа
        /// <summary>
        /// закон, для которого заведен пользователь. 
        /// 0 - не указано,
        /// 1 - 44-ФЗ, 
        /// 2 - 223-ФЗ, 
        /// 3 - 44 и 223, 
        /// </summary>
        public int law;     //закон, для которого заведен пользователь


    }

}
