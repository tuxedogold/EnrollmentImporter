using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStrategy.LoadDataStrategy
{
    public class LoadDataStrategyEnrolleeCSV : ILoadDataStrategy<Enrollee>
    {
        public List<Enrollee> Load(string csvRawData)
        {
            csvRawData = csvRawData.Replace("\r", String.Empty);
            var splitLines = csvRawData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var splitRows = splitLines.Select(e => e.Split(new[] { ',' }));

            IEnumerable<Enrollee> Enrollees = splitRows
                .Select(e =>
                      new Enrollee(e)
                  );
            return Enrollees.ToList();
        }
    }

}
