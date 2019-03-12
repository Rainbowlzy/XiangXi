using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using XiangXi.Evaluators;

namespace XiangXiENtities.CodeTemplates
{
    public class DefaultResponse<T>
    {
        public int total { get; set; }
        public string message { get; set; }
        public bool success { get; set; }
        public List<T> rows { get; set; }
    }

    public class DropdownDef
    {
        public string tableName { get; set; }
        public string tableNameEn { get; set; }
        public string fieldName { get; set; }
        public string fieldNameEn { get; set; }
        public List<string> vals { get; set; }
        public List<string> buttons { get; set; }
    }

    public partial class SYS_Code
    {
        public Nullable<int> id { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string title { get; set; }
        public string val { get; set; }
        public Nullable<int> ord { get; set; }
    }

    public class V_Column
    {
        /// <summary>
        /// 
        /// </summary>
        public string column_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string column_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dbtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public short max_length { get; set; }

        public string pascal_column_name { get; set; }
    }

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

    public partial class V_Table_Comments
    {
        /// <summary>
        /// 
        /// </summary>
        public string r { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string table_name { get; set; }
        public string table_name_en { get; set; }
        public string table_name_ch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string column_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string column_description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dbtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public short max_length { get; set; }
    }


    public partial class MenuConfigurationTT
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MCTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MCLink { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MCPicture { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MCParentTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MCMenuType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> VersionNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TransactionID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> CreateOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<System.DateTime> UpdateOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> IsDeleted { get; set; }
    }
    #region DbTable
    /// <summary>
    /// 表结构
    /// </summary>
    public sealed class DbTable
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 表的架构
        /// </summary>
        public string SchemaName { get; set; }
        /// <summary>
        /// 表的记录数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 是否含有主键
        /// </summary>
        public bool HasPrimaryKey { get; set; }
    }
    #endregion

    #region DbColumn
    /// <summary>
    /// 表字段结构
    /// </summary>
    public sealed class DbColumn
    {
        /// <summary>
        /// 字段ID
        /// </summary>
        public int ColumnID { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 数据库类型对应的C#类型
        /// </summary>
        public string CSharpType
        {
            get
            {
                return SqlServerDbTypeMap.MapCsharpType(ColumnType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Type CommonType
        {
            get
            {
                return SqlServerDbTypeMap.MapCommonType(ColumnType);
            }
        }

        /// <summary>
        /// 字节长度
        /// </summary>
        public int ByteLength { get; set; }

        /// <summary>
        /// 字符长度
        /// </summary>
        public int CharLength { get; set; }

        /// <summary>
        /// 小数位
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 是否自增列
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
    }
    #endregion

    #region SqlServerDbTypeMap
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
    #endregion


    #region Config 

    public class Config
    {
        public static string ConnectionString;

        public static string DbDatabase;

        static Config()
        {
            var dbName = "XiangXi";

            DbDatabase = dbName;

            ConnectionString = string.Format("server=.;database={0};User ID=sa;Password=Sa123456;", dbName);
        }
    }

    #endregion

    public class Generator
    {
        private const string DOMAIN_FILE_PATH = @"E:\code\XiangXi\XiangXiENtities\sql\domain.txt";
        private const string TT_GENERATION_FOLDER = @"E:\code\XiangXi\TT_GENERATION_FOLDER\";

        public Generator()
        {
            if (!File.Exists(DOMAIN_FILE_PATH)) return;
            if (!Directory.Exists(TT_GENERATION_FOLDER)) Directory.CreateDirectory(TT_GENERATION_FOLDER);
            var input = File.ReadAllText(DOMAIN_FILE_PATH);

            var cacheDropdowns = $"{TT_GENERATION_FOLDER}dropdowns_{File.GetLastWriteTime(DOMAIN_FILE_PATH).Ticks}.txt";
            var cache_table_schema = $"{TT_GENERATION_FOLDER}table_schema_{File.GetLastWriteTime(DOMAIN_FILE_PATH).Ticks}.txt";
            var cache_table_schema2 = $"{TT_GENERATION_FOLDER}table_schema2_{File.GetLastWriteTime(DOMAIN_FILE_PATH).Ticks}.txt";
            
            if (File.Exists(cache_table_schema2))
            {
                table_schema = File.ReadAllText(cache_table_schema).Deserialize<Dictionary<string, List<V_Table_Comments>>>();
                dropdowns = File.ReadAllText(cacheDropdowns).Deserialize<List<DropdownDef>>();
                table_schema2 = File.ReadAllText(cache_table_schema2).Deserialize<Dictionary<string, V_Table_Comments2>>();
                return;
            }
            var lines = input.Split(new []{ '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());

            foreach (var line in lines.Where(s => !string.IsNullOrEmpty(s) && s.IndexOf("=>", StringComparison.Ordinal) != -1).AsParallel().Cast<string>())
            {
                var fieldName = line.Substring(line.IndexOf(".", StringComparison.Ordinal) + 1, line.IndexOf("=>", StringComparison.Ordinal) - line.IndexOf(".") - 1).Trim();
                var fieldNameEn = PascalCase(fieldName).Trim();
                var tableName = line.Substring(0, line.IndexOf(".", StringComparison.Ordinal)).Trim();
                var tableNameEn = PascalCase(line.Substring(0, line.IndexOf(".", StringComparison.Ordinal)));
                var prefix = string.Concat(tableNameEn.Where(c => c >= 'A' && c <= 'Z')).Trim();
                var dd = new DropdownDef
                {
                    tableName = tableName,
                    tableNameEn = tableNameEn,
                    fieldName = fieldName,
                    fieldNameEn = prefix + fieldNameEn,
                    vals = Regex.Matches(line.Substring(line.IndexOf("=>", StringComparison.Ordinal), line.LastIndexOf("=>", StringComparison.Ordinal) - line.IndexOf("=>", StringComparison.Ordinal)), @"\w+\d*").Cast<Match>().Select(p => p.Value).ToList(),
                    buttons = Regex.Matches(line.Substring(line.LastIndexOf("=>", StringComparison.Ordinal)), @"\w+\d*").Cast<Match>().Select(p => p.Value).ToList(),
                };
                dropdowns.Add(dd);
            }

            foreach (var line in lines.Where(s => !string.IsNullOrEmpty(s) && s.IndexOf("->", StringComparison.Ordinal) != -1).AsParallel().Cast<string>())
            {
                var rawChTableName = line.Substring(0, line.IndexOf("->", StringComparison.Ordinal));
                var pascalEnTableName = PascalCase(rawChTableName);
                var fields = Regex.Matches(line.Substring(line.IndexOf("->", StringComparison.Ordinal)), @"@*\w+\d*").Cast<Match>().Select(p => p.Value).ToList();
                var prefix = string.Concat(pascalEnTableName.Where(c => c >= 'A' && c <= 'Z'));

                if (table_schema_ch.ContainsKey(rawChTableName))
                {
                    table_schema_ch[rawChTableName] = fields;
                }
                else
                {
                    table_schema_ch.Add(rawChTableName, fields);
                }
                if (table_schema_en.ContainsKey(pascalEnTableName))
                {
                    table_schema_en[pascalEnTableName] = fields;
                }
                else
                {
                    table_schema_en.Add(pascalEnTableName, fields);
                }

                var fs = fields.Select(f =>
                {
                    string regularColumnName = prefix + PascalCase(f);
                    string dbType = parseType(f);
                    return new V_Table_Comments
                    {
                        table_name = pascalEnTableName,
                        table_name_ch = rawChTableName,
                        table_name_en = pascalEnTableName,
                        column_name = regularColumnName,
                        column_description = f,
                        dbtype = dbType
                    };
                }).ToList();
                if (table_schema.ContainsKey(pascalEnTableName))
                {
                    table_schema[pascalEnTableName] = fs;
                }
                else
                {
                    table_schema.Add(pascalEnTableName, fs);
                }

                var table = new V_Table_Comments2
                {
                    table_name = pascalEnTableName,
                    table_name_ch = rawChTableName,
                    table_name_en = pascalEnTableName,
                    Columns = fields.Select(t =>
                    {
                        var pascal_column_name = PascalCase(t);
                        string regular_column_name = prefix + pascal_column_name;
                        string db_type = parseType(t);
                        return new V_Column
                        {
                            pascal_column_name= pascal_column_name,
                            column_name = regular_column_name,
                            column_description = t,
                            dbtype = db_type
                        };
                    }).ToList()
                };
                if (table_schema2.ContainsKey(pascalEnTableName))
                {
                    table_schema2[pascalEnTableName] = table;
                }
                else
                {
                    table_schema2.Add(pascalEnTableName, table);
                }
            }

            foreach (var t in table_schema2.Values)
            {
                foreach (var k in t.Columns.Where(k => k.column_description.StartsWith("@")))
                {
                    var column_en_name = k.pascal_column_name;
                    var key = column_en_name;
                    var column_name_chs = k.column_description.Trim('@');
                    t.debug = column_name_chs;
                    var tbl = table_schema2.Values.FirstOrDefault(q=>q.table_name_ch== column_name_chs);
                    if (tbl != null)
                    {
                        if(tbl.Children==null) tbl.Children = new List<V_Table_Comments2>();
                        tbl.Children.Add((V_Table_Comments2) t.Clone());
                        t.Parent = (V_Table_Comments2) tbl.Clone();
                    }
                }
            }

            File.WriteAllText(cache_table_schema2, table_schema2.ToJson());
            File.WriteAllText(cacheDropdowns, dropdowns.ToJson());
            File.WriteAllText(cache_table_schema, table_schema.ToJson());
        }
        
        public List<DropdownDef> dropdowns { get; set; } = new List<DropdownDef>();

        public Dictionary<string, List<V_Table_Comments>> table_schema { get; set; } = new Dictionary<string, List<V_Table_Comments>>();

        public Dictionary<string, V_Table_Comments2> table_schema2 { get; set; } = new Dictionary<string, V_Table_Comments2>();

        public Dictionary<string, List<string>> table_schema_ch { get; set; } = new Dictionary<string, List<string>>();

        public Dictionary<string, List<string>> table_schema_en { get; set; } = new Dictionary<string, List<string>>();

        public Func<string, string> parseType = (string field) =>
        {
            var nvarcharFields = "图片，照片，上传，摘要，备注，报告，头像，内容，标题，地址，企业名称，身份证，链接，理由，原因，说明";
            var intFields = "年龄，顺序，排序";
            //var decimalFields = "小数";
            var realFields = "面积";
            var moneyFields = "金额";
            var textFields = "备注，内容，正文";
            var datetimeFields = "时间，日期";

            if (datetimeFields.Split(new []{ '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "DATETIME";
            if (realFields.Split(new[] { '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "REAL";
            if (intFields.Split(new[] { '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "INT";
            if (moneyFields.Split(new[] { '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "MONEY";
            //if (decimalFields.Split(new []{ '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "DECIMAL(18,18)";
            if (textFields.Split(new[] { '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "NVARCHAR(4000)";
            if (nvarcharFields.Split(new[] { '，' }, StringSplitOptions.RemoveEmptyEntries).Any(s => field.IndexOf(s) != -1)) return "NVARCHAR(4000)";
            return "NVARCHAR(50)";
        };

        public static string nottranslate = "PM2.5，PM10，SO2，NO2，O3，CO";

        public HttpWebResponse CreateGetHttpResponse(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            return request.GetResponse() as HttpWebResponse;
        }

        public string CamelCase(string key)
        {
            if (nottranslate.IndexOf(key) != -1) return key;
            return HttpGet(string.Format("http://localhost/Translator/api/CamelCase?key={0}", key))
                .Replace("-", string.Empty)
                .Replace("=", string.Empty)
                .Replace("+", string.Empty)
                .Replace("{", string.Empty)
                .Replace("}", string.Empty)
                .Replace("/", string.Empty)
                .Replace(".", string.Empty)
                .Replace("\\", string.Empty)
                .Replace(" ", string.Empty)
                .Replace(",", string.Empty)
                .Replace("-", string.Empty)
                .Replace(" ", string.Empty)
                .Replace(" ", string.Empty).Trim('"');
        }

        public string PascalCase(string key)
        {
            key = key?.Trim("@,?.|\\/".ToCharArray());
            if (nottranslate.IndexOf(key) != -1) return key;
            return HttpGet(string.Format("http://localhost/Translator/api/PascalCase?key={0}", key))
                .Replace("-",string.Empty)
                .Replace("=",string.Empty)
                .Replace("+",string.Empty)
                .Replace("{",string.Empty)
                .Replace("}",string.Empty)
                .Replace("/",string.Empty)
                .Replace(".",string.Empty)
                .Replace("\\",string.Empty)
                .Replace(" ", string.Empty)
                .Replace(",", string.Empty)
                .Replace("-", string.Empty)
                .Replace(" ", string.Empty)
                .Replace(" ", string.Empty)
                .Trim('"', '.', '?');
        }

        public string HttpGet(string url)
        {
            try
            {
                Stream responseStream = CreateGetHttpResponse(url).GetResponseStream();
                string buf = string.Empty;
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
                    {
                        buf = reader.ReadToEnd();
                    }
                    responseStream.Close();
                }
                return buf;
            }
            catch (Exception e)
            {
                return e.Message + "\n" + url;
            }
        }
    }
}
