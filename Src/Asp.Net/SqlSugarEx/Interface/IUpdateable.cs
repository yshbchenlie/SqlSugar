using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugarEx.Interface
{
    public partial interface IUpdateable<T> where T : class, new()
    {
    }
}
