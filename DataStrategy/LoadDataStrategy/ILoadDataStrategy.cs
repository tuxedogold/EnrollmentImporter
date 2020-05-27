using System.Collections.Generic;

namespace DataStrategy.LoadDataStrategy
{
    interface ILoadDataStrategy<T>
    {
        List<T> Load(string rawdata);
    }
}
