using System;
using System.Collections.Generic;

namespace XiangXiENtities.CodeTemplates
{
    public class V_Table_Comments2 : V_Table_Comments, ICloneable
    {
        public string debug;
        public List<V_Column> Columns { get; set; }
        public List<V_Table_Comments2> Children { get; internal set; }
        public V_Table_Comments2 Parent { get; set; }

        public object Clone()
        {
            return new V_Table_Comments2
            {
                debug = debug,
                Columns = Columns,
                table_name = table_name,
                table_name_ch = table_name_ch,
                table_name_en = table_name_en,
            };
        }
    }
}