using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace XiangXi.Evaluators
{
    public class SPCall : DbContext
    {
        private string stringp(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s;
        }


        public SPCall()
            : base("name=DefaultContext")
        {
        }

        public virtual T[] SP_GET_ALL_LIST<T>(SPCallParameter para)
        {
            if(para==null) para = new SPCallParameter();
            var districtID = para.districtID;
            var type = para.type;
            var search = para.search;
            var condition = para.condition;
            var view = typeof (T).Name;
            var order = para.order;
            var asc = para.asc;
            int? offset = para.offset ?? 0;
            int? limit = para.limit ?? 5;
            var total = para.total;

            var districtIDParameter = new SqlParameter("@districtID", stringp(districtID));
            districtIDParameter.SqlDbType = SqlDbType.NVarChar;

            var typeParameter = new SqlParameter("@type", stringp(type));
            typeParameter.SqlDbType = SqlDbType.NVarChar;

            var conditionParameter = new SqlParameter("@condition", stringp(condition));
            conditionParameter.SqlDbType = SqlDbType.NVarChar;

            var searchParameter = new SqlParameter("@search", stringp(search));
            searchParameter.SqlDbType = SqlDbType.NVarChar;

            var viewParameter = new SqlParameter("@view", stringp(view));
            searchParameter.SqlDbType = SqlDbType.NVarChar;

            var orderParameter = new SqlParameter("@order", stringp(order));
            orderParameter.SqlDbType = SqlDbType.NVarChar;

            var ascParameter = new SqlParameter("@asc", stringp(asc));
            ascParameter.SqlDbType = SqlDbType.NVarChar;

            var offsetParameter = new SqlParameter("@offset", offset);
            offsetParameter.SqlDbType = SqlDbType.Int;

            var limitParameter = new SqlParameter("@limit", limit);
            limitParameter.SqlDbType = SqlDbType.Int;

            var totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.SqlDbType = SqlDbType.Int;
            totalParameter.Direction = ParameterDirection.Output;
            
            var results = Database.SqlQuery<T>(
                "exec SP_GET_ALL_LIST @districtID, @type,@condition, @search, @view, @order, @asc, @offset, @limit, @total out",
                districtIDParameter, typeParameter, conditionParameter,
                searchParameter, viewParameter, orderParameter, ascParameter, offsetParameter, limitParameter,
                totalParameter).ToArray();
            para.total = (int?) totalParameter.Value;
            return results;
        }
        public virtual T[] SP_GET_ALL_LIST<T>(string districtID, string type, string condition, string search, string order, string asc, Nullable<int> offset, Nullable<int> limit, out Nullable<int> total)
        {
            var districtIDParameter = new SqlParameter("@districtID", stringp(districtID));
            districtIDParameter.SqlDbType = SqlDbType.NVarChar;

            var typeParameter = new SqlParameter("@type", stringp(type));
            districtIDParameter.SqlDbType = SqlDbType.NVarChar;

            var conditionParameter = new SqlParameter("@condition", stringp(condition));
            conditionParameter.SqlDbType = SqlDbType.NVarChar;

            var searchParameter = new SqlParameter("@search", stringp(search));
            searchParameter.SqlDbType = SqlDbType.NVarChar;

            var viewParameter = new SqlParameter("@view", stringp(typeof(T).Name));
            searchParameter.SqlDbType = SqlDbType.NVarChar;

            var orderParameter = new SqlParameter("@order", stringp(order));
            orderParameter.SqlDbType = SqlDbType.NVarChar;

            var ascParameter = new SqlParameter("@asc", stringp(asc));
            ascParameter.SqlDbType = SqlDbType.NVarChar;

            var offsetParameter = new SqlParameter("@offset", offset);
            offsetParameter.SqlDbType = SqlDbType.Int;

            var limitParameter = new SqlParameter("@limit", limit);
            limitParameter.SqlDbType = SqlDbType.Int;

            var totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.SqlDbType = SqlDbType.Int;
            totalParameter.Direction = ParameterDirection.Output;

            var results = Database.SqlQuery<T>(
                "exec SP_GET_ALL_LIST @districtID, @type, @condition, @search, @view, @order, @asc, @offset, @limit, @total out", districtIDParameter, conditionParameter, typeParameter,
                searchParameter, viewParameter, orderParameter, ascParameter, offsetParameter, limitParameter, totalParameter).ToArray();
            total = (int?)totalParameter.Value;
            return results;
        }

    }
}
