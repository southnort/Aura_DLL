using System;
using System.Collections.Generic;
using System.Globalization;

namespace AuraDLL.Methods
{
    //класс, хранящий в себе общие методы для библиотеки Aura
    internal class Methods
    {
        private static List<string> dateFormats = new List<string>()
        {
            "yyyy-MM-dd-HH-mm",
            "yyyy-MM-dd",
            "dd.MM.yyyy HH.mm.ss",
        };

        static internal DateTime ToDateTime(object ob)
        {
            //проверить строку на соответствие какому-либо формату, отпарсить её в DateTime и вернуть
            try
            {
                string str = (string)ob;
                DateTime returnDateTime = DateTime.MinValue;

                foreach (var format in dateFormats)
                {
                    if (DateTime.TryParseExact(str, format,
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out returnDateTime))
                    {
                        return returnDateTime;

                    }

                }

                return returnDateTime;

            }

            catch
            {
                return DateTime.MinValue;
            }


        }


    }
}
