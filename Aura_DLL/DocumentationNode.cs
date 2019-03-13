using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AuraDLL.Methods;

namespace Aura.Model
{
    public class DocumentationNode : ILoggable
    {
        public DocumentationNode()
        {
        }

        public DocumentationNode(DataRow row)
        {
            id = row[0] is DBNull ? 0 : (int)(long)row[0];
            nodeDate = Methods.ToDateTime(row[1]);
            text = row[2] is DBNull ? "" : (string)row[2];
        }

        public int id;
        public DateTime nodeDate;
        public string text;


        public string LogObjectName { get { return "Журнал рдактирования документации"; } }

        public string GetSqlStringForLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Logs WHERE tableName = 'Documentation'");
            sb.Append(" AND id = '");
            sb.Append(id);
            sb.Append("'");

            return sb.ToString();

        }
    }
}
