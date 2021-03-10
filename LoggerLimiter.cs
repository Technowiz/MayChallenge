namespace LoggerLimiter
{
    class Program
    {
        public static Dictionary<string, LinkedList<DateTime>> timeMap;
        public static SortedDictionary<int, List<string>> freqMap;
        public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                return y.CompareTo(x);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            string[] logs = new string[] { "2021-03-10T07:22:16.0000000Z [ERROR] ErrorMessage1",
                "2021-03-10T07:23:16.0000000Z [ERROR] ErrorMessage1"
                ,"2021-03-10T07:30:16.0000000Z [ERROR] ErrorMessage2"
            ,"2021-03-10T08:23:16.0000000Z [ERROR] ErrorMessage1"
            ,"2021-03-10T08:24:16.0000000Z [ERROR] ErrorMessage2"
            ,"2021-03-10T08:26:16.0000000Z [ERROR] ErrorMessage2"};
      
            timeMap = new Dictionary<string, LinkedList<DateTime>>();
            IComparer<int> comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            freqMap = new SortedDictionary<int, List<string>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            foreach (var log in logs)
            {
                p.ReadInput(log);
            }
           
            
            printMostFrequent(1);// print first frequent 
        }
        public void ReadInput(string logMessage)
        {
            
            string[] inputs = logMessage.Split(' ');
            string message = inputs[2];
            
         
            if (!timeMap.ContainsKey(message))
            {
                timeMap.Add(message, new LinkedList<DateTime>());
                timeMap[message].AddFirst(DateTime.Parse(inputs[0]));
                if (freqMap.ContainsKey(1))
                    freqMap[1].Add(message);
                else
                    freqMap.Add(1, new List<string> { message });
            }
            else
            {
                int prevFreq=timeMap[message].Count;
                timeMap[message].AddFirst(DateTime.Parse(inputs[0]));
                var diff = (DateTime.Now.Subtract(timeMap[message].Last.Value).TotalMinutes);
                while(diff>60)
                {
                    diff = (DateTime.Now.Subtract(timeMap[message].Last.Value).TotalMinutes);
                    timeMap[message].RemoveLast();
                }
                int currFreq = timeMap[message].Count;
                if (prevFreq !=currFreq)
                {
                    freqMap[prevFreq].Remove(message);
                    if (freqMap[prevFreq].Count == 0)
                        freqMap.Remove(prevFreq);
               
                    if (!freqMap.ContainsKey(currFreq))
                        freqMap.Add(currFreq, new List<string> { message});
                    else
                        freqMap[currFreq].Add(message);
                }
            }
        }
        public static void printMostFrequent(int n)
        {
            // find the top n freq message 
            var kvpairs = freqMap.Take(n);
            foreach(var kv in kvpairs)
            {
                Console.WriteLine(kv.Value);
            }
            
        }
    }
}
