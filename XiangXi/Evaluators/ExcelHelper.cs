using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace XiangXi.Evaluators
{
    public static class ExcelHelper
    {
        #region Excel导入

        public static List<T> ExcelToNewEntityList<T>(Dictionary<string, string> cellHeard, string filePath,
            out StringBuilder errorMsg) where T : new()
        {
            var list = ExcelToEntityList<T>(cellHeard, filePath, out errorMsg);
            var propertyInfo = typeof(T).GetProperty("id");
            if (propertyInfo != null && propertyInfo.PropertyType == typeof(string))
            {
                foreach (var entity in list)
                {
                    propertyInfo.SetValue(entity, Guid.NewGuid().ToString());
                }
            }

            return list;
        }

        /// <summary>
        /// 从Excel取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的值和名称：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换后的List对象集合</returns>
        public static List<T> ExcelToEntityList<T>(Dictionary<string, string> cellHeard, string filePath,
            out StringBuilder errorMsg) where T : new()
        {
            List<T> enlist = new List<T>();
            errorMsg = new StringBuilder();
            if (Regex.IsMatch(filePath, ".xls$")) // 2003
            {
                enlist = Excel2003ToEntityList<T>(cellHeard, filePath).ToList();
            }
            else if (Regex.IsMatch(filePath, ".xlsx$")) // 2007
            {
                //return FailureResultMsg("请选择Excel文件"); // 未设计
            }

            return enlist;
        }

        private static object[][][] ParseExcelToArray(string path)
        {
            object[][][] book = null;
            using (FileStream fs = File.OpenRead(path))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                book = new object[workbook.NumberOfSheets][][];
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    var sheet = workbook.GetSheetAt(i);
                    if (sheet != null)
                    {
                        book[i] = new object[sheet.PhysicalNumberOfRows][];
                        for (int j = 0; j < sheet.PhysicalNumberOfRows; j++)
                        {
                            var row = sheet.GetRow(j);
                            if (row != null)
                            {
                                book[i][j] = new object[row.PhysicalNumberOfCells];
                                for (int k = 0; k < row.PhysicalNumberOfCells; k++)
                                {
                                    var cell = row.GetCell(k);
                                    if (cell != null)
                                        switch (cell.CellType)
                                        {
                                            case CellType.Numeric:
                                                book[i][j][k] = cell.NumericCellValue;
                                                break;
                                            case CellType.String:
                                                book[i][j][k] = cell.StringCellValue;
                                                break;
                                        }
                                }
                            }
                        }
                    }
                }
            }

            return book;
        }

        /// <summary>
        /// 从Excel2003取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的Key和Value：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换好的List对象集合</returns>
        private static IEnumerable<T> Excel2003ToEntityList<T>(Dictionary<string, string> cellHeard, string filePath)
            where T : new()
        {
            var array = ParseExcelToArray(filePath);
            var map = cellHeard.ToDictionary(t => t.Value, t => t.Key);
            var propertyInfos = typeof(T).GetProperties().ToDictionary(t => t.Name, t => t);
            if (array != null)
                foreach (object[][] objects in array)
                {
                    if (objects != null && objects.Length > 0)
                    {
                        var max = objects.Max(t => t.Length);
                        List<string> head = objects.Where(t => t?.Length == max)
                            .Select(t => t?.Select(c => c?.ToString())?.ToList()).FirstOrDefault();
                        foreach (object[] row in objects)
                        {
                            if (head != null)
                            {
                                bool hasSetValue = false;
                                T one = new T();
                                if (row != null)
                                    for (var i = 0; i < row.Length; i++)
                                    {
                                        var chs = head[i];
                                        var val = row[i];
                                        if (chs != null
                                            && val != null
                                            && map.ContainsKey(chs)
                                            && val?.ToString() != chs.ToString())
                                        {
                                            var en = map[chs];
                                            if (en != null && propertyInfos.ContainsKey(en))
                                            {
                                                hasSetValue = true;
                                                propertyInfos[en]?.SetValue(one, val);
                                            }
                                        }
                                    }

                                if (hasSetValue) yield return one;
                            }
                        }
                    }
                }
        }

        #endregion Excel导入

        #region Excel导出

        /// <summary>
        /// 实体类集合导出到EXCLE2003
        /// </summary>
        /// <param name="cellHeard">单元头的Key和Value：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="enList">数据源</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns>文件的下载地址</returns>
        public static string EntityListToExcel2003(Dictionary<string, string> cellHeard, IList enList, string sheetName)
        {
            string fileName = sheetName + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls"; // 文件名称
            string urlPath = "UpFiles/ExcelFiles/" + fileName; // 文件下载的URL地址，供给前台下载
            string filePath = HttpContext.Current.Server.MapPath("\\" + urlPath); // 文件路径

            // 1.检测是否存在文件夹，若不存在就建立个文件夹
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            // 2.解析单元格头部，设置单元头的中文名称
            HSSFWorkbook workbook = new HSSFWorkbook(); // 工作簿
            ISheet sheet = workbook.CreateSheet(sheetName); // 工作表
            IRow row = sheet.CreateRow(0);
            List<string> keys = cellHeard.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                row.CreateCell(i).SetCellValue(cellHeard[keys[i]]); // 列名为Key的值
            }

            // 3.List对象的值赋值到Excel的单元格里
            int rowIndex = 1; // 从第二行开始赋值(第一行已设置为单元头)
            foreach (var en in enList)
            {
                IRow rowTmp = sheet.CreateRow(rowIndex);
                for (int i = 0; i < keys.Count; i++) // 根据指定的属性名称，获取对象指定属性的值
                {
                    var key = keys[i];
                    var enType = en.GetType();
                    string cellValue = ""; // 单元格的值
                    object propertyValue = null; // 属性的值
                    PropertyInfo propertyInfo = null; // 属性的信息

                    // 3.1 若属性头的名称包含'.',就表示是子类里的属性，那么就要遍历子类，eg：UserEn.UserName
                    if (key.IndexOf(".", StringComparison.Ordinal) < 0)
                    {
                        // 3.2 若不是子类的属性，直接根据属性名称获取对象对应的属性
                        propertyInfo = enType.GetProperty(key);
                        if (propertyInfo != null)
                        {
                            propertyValue = propertyInfo.GetValue(en, null);
                        }
                    }
                    else
                    {
                        // 3.1.1 解析子类属性(这里只解析1层子类，多层子类未处理)
                        string[] propertyArray =
                            key.Split(new string[] {"."}, StringSplitOptions.RemoveEmptyEntries);
                        string subClassName = propertyArray[0]; // '.'前面的为子类的名称
                        string subClassPropertyName = propertyArray[1]; // '.'后面的为子类的属性名称
                        PropertyInfo subClassInfo = enType.GetProperty(subClassName); // 获取子类的类型
                        if (subClassInfo != null)
                        {
                            // 3.1.2 获取子类的实例
                            var subClassEn = enType.GetProperty(subClassName).GetValue(en, null);
                            // 3.1.3 根据属性名称获取子类里的属性类型
                            propertyInfo = subClassInfo.PropertyType.GetProperty(subClassPropertyName);
                            if (propertyInfo != null)
                            {
                                propertyValue = propertyInfo.GetValue(subClassEn, null); // 获取子类属性的值
                            }
                        }
                    }

                    // 3.3 属性值经过转换赋值给单元格值
                    if (propertyValue != null)
                    {
                        cellValue = propertyValue.ToString();
                        // 3.3.1 对时间初始值赋值为空
                        if (cellValue.Trim() == "0001/1/1 0:00:00" || cellValue.Trim() == "0001/1/1 23:59:59")
                        {
                            cellValue = "";
                        }
                    }

                    // 3.4 填充到Excel的单元格里
                    rowTmp.CreateCell(i).SetCellValue(cellValue);
                }

                rowIndex++;
            }

            // 4.生成文件
            FileStream file = new FileStream(filePath, FileMode.Create);
            workbook.Write(file);
            file.Close();

            // 5.返回下载路径
            return urlPath;
        }

        #endregion Excel导出

        /// <summary>
        /// 保存Excel文件
        /// <para>Excel的导入导出都会在服务器生成一个文件</para>
        /// <para>路径：UpFiles/ExcelFiles</para>
        /// </summary>
        /// <param name="file">传入的文件对象</param>
        /// <returns>如果保存成功则返回文件的位置;如果保存失败则返回空</returns>
        public static string SaveExcelFile(HttpPostedFile file)
        {
            var fileName = file.FileName.Insert(file.FileName.LastIndexOf('.'),
                "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            var filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UpFiles/ExcelFiles"), fileName);
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            file.SaveAs(filePath);
            return filePath;
        }

        /// <summary>
        /// 从Excel获取值传递到对象的属性里
        /// </summary>
        /// <param name="distanceType">目标对象类型</param>
        /// <param name="sourceCell">对象属性的值</param>
        private static Object GetExcelCellToProperty(Type distanceType, ICell sourceCell)
        {
            object rs = distanceType.IsValueType ? Activator.CreateInstance(distanceType) : null;

            // 1.判断传递的单元格是否为空
            if (sourceCell == null || string.IsNullOrEmpty(sourceCell.ToString()))
            {
                return rs;
            }

            // 2.Excel文本和数字单元格转换，在Excel里文本和数字是不能进行转换，所以这里预先存值
            object sourceValue = null;
            switch (sourceCell.CellType)
            {
                case CellType.Blank:
                    break;

                case CellType.Boolean:
                    break;

                case CellType.Error:
                    break;

                case CellType.Formula:
                    break;

                case CellType.Numeric:
                    if (distanceType == typeof(DateTime) || distanceType == typeof(DateTime?))
                        return sourceCell.DateCellValue;
                    sourceValue = sourceCell.NumericCellValue;
                    break;

                case CellType.String:
                    sourceValue = sourceCell.StringCellValue;
                    break;

                case CellType.Unknown:
                    break;

                default:
                    break;
            }

            string valueDataType = distanceType.Name;

            // 在这里进行特定类型的处理
            switch (valueDataType.ToLower()) // 以防出错，全部小写
            {
                case "string":
                    rs = sourceValue.ToString();
                    break;
                case "int":
                case "int16":
                case "int32":
                    rs = (int) Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "float":
                case "single":
                    rs = (float) Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "datetime":
                    rs = sourceCell.DateCellValue;
                    break;
                case "guid":
                    rs = (Guid) Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    return rs;
            }

            return rs;
        }
    }
}