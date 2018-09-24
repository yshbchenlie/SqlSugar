using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarEx.Interface
{
    public partial interface ISugarQueryable<T>
    {
        List<T> BothToList();
        string BothToJson();
    }
}
