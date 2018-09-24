using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SqlSugarEx.Provider
{
   public class ExSqlServerProvider : SqlServerProvider
    {
        private readonly ConnectionType _connectionType;
        public ExSqlServerProvider(ConnectionType connectionType)
        {
            _connectionType = connectionType;

        }
        public override void BeginTran()
        {
            if (ConnectionType.Local == _connectionType)
            {
                base.BeginTran();
            }
            else
            {
                //记录开始事务
            }
        }

        public override void BeginTran(IsolationLevel iso)
        {
            if (ConnectionType.Local == _connectionType)
            {
                base.BeginTran(iso);
            }
            else
            {
                //记录开始事务
            }
        }

        public override void CommitTran()
        {
            if (ConnectionType.Local == _connectionType)
            {
                base.CommitTran();
            }
            else
            {
                //记录提交事务
            }
        }

        public new void UseStoredProcedure(Action action)
        {
            if (ConnectionType.Local == _connectionType)
            {
                base.UseStoredProcedure(action);
            }
            else
            {
                //action转sql
                //远程事务执行sql
            }
        }

        public new T UseStoredProcedure<T>(Func<T> action)
        {
            if (ConnectionType.Local == _connectionType)
            {
                return base.UseStoredProcedure(action);
            }
            else
            {
                //action转sql
                //远程事务执行sql
                return base.UseStoredProcedure(action);
            }
        }

        public new IAdo UseStoredProcedure()
        {
            if (ConnectionType.Local == _connectionType)
            {
                return base.UseStoredProcedure();
            }
            else
            {
                //action转sql
                //远程事务执行sql
                return base.UseStoredProcedure();
            }
        }
    }
}
