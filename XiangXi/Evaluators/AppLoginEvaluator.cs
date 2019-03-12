using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using XiangXi.Models;

namespace XiangXi.Evaluators
{
    public class AppLoginEvaluator : Evaluator
    {
        private const int MAX_LOGIN_TIMES = 20;

        private static readonly Dictionary<string, int> failedLogin = new Dictionary<string, int>();

        private static bool CheckMultiLogin(string loginName)
        {
            if (!failedLogin.ContainsKey(loginName)) return true;
            return failedLogin[loginName] <= MAX_LOGIN_TIMES;
        }

        private static void FailedLogin(string loginName)
        {
            if (!failedLogin.ContainsKey(loginName))
            {
                failedLogin.Add(loginName, 1);
            }
            else
            {
                failedLogin[loginName]++;
            }
        }

        protected override object Evaluate(CommonRequest request)
        {
            return Redirect("login");
        }
    }
}