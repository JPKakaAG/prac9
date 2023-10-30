using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    struct Baggage
    {
        public int NumberOfItems;      // Количество вещей
        public double TotalWeight;     // Общий вес вещей
    }
    public class BaggageData
    {
        public int BaggageId { get; set; }
        public int NumberOfItems { get; set; }
        public double TotalWeight { get; set; }
    }
    public class BaggageDataAverageWeightPerItem
    {
        public int BaggageId { get; set; }
        public double AverageWeightPerItem { get; set; }

    }
    public class BaggageDeviation
    {
        public int BaggageId { get; set; }
        public double Deviation { get; set; }
    }
}
