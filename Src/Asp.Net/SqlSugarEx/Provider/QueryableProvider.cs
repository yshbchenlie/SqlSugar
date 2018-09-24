using System;
using System.Collections.Generic;
using SqlSugarEx.Interface;

namespace SqlSugarEx.Provider
{
    public partial class QueryableProvider<T> : ISugarQueryable<T>
    {
        public string BothToJson()
        {
            throw new NotImplementedException();
        }

        public List<T> BothToList()
        {
            throw new NotImplementedException();
        }
    }
}
