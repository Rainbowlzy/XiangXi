using System;

namespace XiangXiENtities.CodeTemplates
{
    /// <summary>
    /// SqlServerDbTypeMap.MapCsharpType(dbtype)
    /// </summary>
    public class SqlServerDbTypeMap
    {
        public static string MapCsharpType(string dbtype)
        {
            //Nullable<bool>
            if (string.IsNullOrEmpty(dbtype)) return dbtype;
            dbtype = dbtype.ToLower();
            string csharpType = "object";
            switch (dbtype)
            {
                case "bigint": csharpType = "Nullable<long>"; break;
                case "binary": csharpType = "byte[]"; break;
                case "bit": csharpType = "Nullable<bool>"; break;
                case "char": csharpType = "string"; break;
                case "date": csharpType = "Nullable<DateTime>"; break;
                case "datetime": csharpType = "Nullable<DateTime>"; break;
                case "datetime2": csharpType = "Nullable<DateTime>"; break;
                case "datetimeoffset": csharpType = "DateTimeOffset"; break;
                case "decimal": csharpType = "Nullable<decimal>"; break;
                case "float": csharpType = "Nullable<double>"; break;
                case "image": csharpType = "byte[]"; break;
                case "int": csharpType = "Nullable<int>"; break;
                case "money": csharpType = "Nullable<decimal>"; break;
                case "nchar": csharpType = "string"; break;
                case "ntext": csharpType = "string"; break;
                case "numeric": csharpType = "Nullable<decimal>"; break;
                case "nvarchar": csharpType = "string"; break;
                case "real": csharpType = "Nullable<Single>"; break;
                case "smalldatetime": csharpType = "Nullable<DateTime>"; break;
                case "smallint": csharpType = "Nullable<short>"; break;
                case "smallmoney": csharpType = "Nullable<decimal>"; break;
                case "sql_variant": csharpType = "object"; break;
                case "sysname": csharpType = "object"; break;
                case "text": csharpType = "string"; break;
                case "time": csharpType = "TimeSpan"; break;
                case "timestamp": csharpType = "byte[]"; break;
                case "tinyint": csharpType = "Nullable<byte>"; break;
                case "uniqueidentifier": csharpType = "Guid"; break;
                case "varbinary": csharpType = "byte[]"; break;
                case "varchar": csharpType = "string"; break;
                case "xml": csharpType = "string"; break;
                default: csharpType = "object"; break;
            }
            return csharpType;
        }

        public static Type MapCommonType(string dbtype)
        {
            if (string.IsNullOrEmpty(dbtype)) return Type.Missing.GetType();
            dbtype = dbtype.ToLower();
            Type commonType = typeof(object);
            switch (dbtype)
            {
                case "bigint": commonType = typeof(long); break;
                case "binary": commonType = typeof(byte[]); break;
                case "bit": commonType = typeof(bool); break;
                case "char": commonType = typeof(string); break;
                case "date": commonType = typeof(DateTime); break;
                case "datetime": commonType = typeof(DateTime); break;
                case "datetime2": commonType = typeof(DateTime); break;
                case "datetimeoffset": commonType = typeof(DateTimeOffset); break;
                case "decimal": commonType = typeof(decimal); break;
                case "float": commonType = typeof(double); break;
                case "image": commonType = typeof(byte[]); break;
                case "int": commonType = typeof(int); break;
                case "money": commonType = typeof(decimal); break;
                case "nchar": commonType = typeof(string); break;
                case "ntext": commonType = typeof(string); break;
                case "numeric": commonType = typeof(decimal); break;
                case "nvarchar": commonType = typeof(string); break;
                case "real": commonType = typeof(Single); break;
                case "smalldatetime": commonType = typeof(DateTime); break;
                case "smallint": commonType = typeof(short); break;
                case "smallmoney": commonType = typeof(decimal); break;
                case "sql_variant": commonType = typeof(object); break;
                case "sysname": commonType = typeof(object); break;
                case "text": commonType = typeof(string); break;
                case "time": commonType = typeof(TimeSpan); break;
                case "timestamp": commonType = typeof(byte[]); break;
                case "tinyint": commonType = typeof(byte); break;
                case "uniqueidentifier": commonType = typeof(Guid); break;
                case "varbinary": commonType = typeof(byte[]); break;
                case "varchar": commonType = typeof(string); break;
                case "xml": commonType = typeof(string); break;
                default: commonType = typeof(object); break;
            }
            return commonType;
        }
    }
}