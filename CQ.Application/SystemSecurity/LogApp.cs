﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQ.Core;
using CQ.Domain.Entity.SystemSecurity;
using CQ.Domain.IRepository.SystemSecurity;
using CQ.Repository.SystemSecurity;

namespace CQ.Application.SystemSecurity
{
    public class LogApp
    {
        private ILogRepository service = new LogRepository();

        public List<LogEntity> GetList(Pagination pagination, string queryJson)
        {
            var expression = ExtLinq.True<LogEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["keyword"].IsEmpty())
            {
                string keyword = queryParam["keyword"].ToString();
                expression = expression.And(t => t.F_Account.Contains(keyword));
            }
            if (!queryParam["timeType"].IsEmpty())
            {
                string timeType = queryParam["timeType"].ToString();
                DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
                DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7);
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1);
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        break;
                }
                expression = expression.And(t => t.F_Date >= startTime && t.F_Date <= endTime);
            }
            return service.FindList(expression, pagination);
        }
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = ExtLinq.True<LogEntity>();
            expression = expression.And(t => t.F_Date <= operateTime);
            service.Delete(expression);
        }
        public void WriteDbLog(bool result, string resultLog)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_Account = OperatorProvider.Provider.GetCurrent().UserCode;
            logEntity.F_NickName = OperatorProvider.Provider.GetCurrent().UserName;
            logEntity.F_IPAddress = Net.Ip;
            logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress);
            logEntity.F_Result = result;
            logEntity.F_Description = resultLog;
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            if (loginInfo != null)
            {
                logEntity.F_CreatorUserId = loginInfo.UserId;
            }
            logEntity.F_CreatorTime = DateTime.Now;
            service.Insert(logEntity);
        }
        public void WriteDbLog(LogEntity logEntity)
        {
            logEntity.F_Date = DateTime.Now;
            logEntity.F_IPAddress = Net.Ip;
            logEntity.F_IPAddressName = Net.GetLocation(logEntity.F_IPAddress);
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            if (loginInfo != null)
            {
                logEntity.F_CreatorUserId = loginInfo.UserId;
            }
            logEntity.F_CreatorTime = DateTime.Now;
            service.Insert(logEntity);
        }
    }
}
