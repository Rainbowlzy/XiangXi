using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using XiangXi.Evaluators;

namespace XiangXiENtities.CodeTemplates
{
    public class Generator
    {
        //private const string DOMAIN_FILE_PATH = @"E:\code\XiangXi\XiangXiENtities\sql\domain.txt";
        private string TT_GENERATION_FOLDER = @"TT_GENERATION_FOLDER\";
        public DateTime DomainVersionTime { get; set; }
        public Generator(string DOMAIN_FILE_PATH)
        {
            if (!File.Exists(DOMAIN_FILE_PATH)) throw new FileNotFoundException(DOMAIN_FILE_PATH);
            TT_GENERATION_FOLDER = Directory.GetParent(DOMAIN_FILE_PATH).FullName + TT_GENERATION_FOLDER;
            if (!Directory.Exists(TT_GENERATION_FOLDER)) Directory.CreateDirectory(TT_GENERATION_FOLDER);
            var input = File.ReadAllText(DOMAIN_FILE_PATH);

            DomainVersionTime = File.GetLastWriteTime(DOMAIN_FILE_PATH);
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

        private static readonly string nottranslate = "PM2.5，PM10，SO2，NO2，O3，CO";

        private HttpWebResponse CreateGetHttpResponse(string url)
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
            return HttpGet(string.Format("http://localhost/Translator/api/CamelCase?key={0}", key)).Trim('"');
        }

        public string PascalCase(string key)
        {
            key = key?.Trim("@,?.|\\/".ToCharArray());
            if (nottranslate.IndexOf(key) != -1) return key;
            return HttpGet(string.Format("http://localhost/Translator/api/PascalCase?key={0}", key))
                .Trim('"', '.', '-', '+', ',', '\'', '?')
                .Replace("'",string.Empty);
        }

        private string HttpGet(string url)
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
                File.WriteAllText($"D:\\log\\Generator_Err_{DateTime.Now.ToString("yyyy MMMM dd")}_{DateTime.Now.Ticks}.log",JsonConvert.SerializeObject(new
                {
                    project="Generator",
                    method=nameof(HttpGet),
                    url,
                    e
                }));
                return string.Empty;
            }
        }
    }
}
