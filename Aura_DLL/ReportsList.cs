using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura.Model
{

    /// <summary>
    /// класс, для работы с отчетами
    /// </summary>
    [Serializable]
    public class ReportsList : ILoggable
    {
        public List<Report> reports = new List<Report>();
        public string LogObjectName { get { return "Журнал обработки отчетов"; } }

        public string GetSqlStringForLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Logs WHERE tableName = 'Reports'");
            return sb.ToString();
        }
    }
}
