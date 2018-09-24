using System.Collections.Generic;

namespace SqlSugarEx.Interface
{
    public partial interface ISugarQueryable<T>
    {
        List<T> BothToList();
        string BothToJson();
    }
}
