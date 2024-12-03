namespace AdventOfCode2024
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class DayOne
    {
        private List<int> _list1 = new List<int>();
        private List<int> _list2 = new List<int>();

        public async Task<int> CalcDistnaceAsync()
        {
            await ReadFile();
            var returnList = new List<int>();

            _list1 = _list1.OrderBy(x => x).ToList();
            _list2 = _list2.OrderBy(x => x).ToList();

            for (var i = 0; i < _list1.Count; i++)
            {
                returnList.Add(Math.Abs(_list1[i] - _list2[i]));
            }

            return returnList.Sum();
        }

        public async Task<int> CalcSimilarityScoreAsync()
        {
            await ReadFile();
            var returnList = new List<int>();
            var group = _list2.GroupBy(i => i).Select(g => new { g.Key, Count = g.Count() });

            foreach (var val in _list1)
            {
                var groupValue = group.FirstOrDefault(x => x.Key == val);
                if (groupValue != null)
                {
                    returnList.Add(val * groupValue.Count);
                }
                else
                {
                    returnList.Add(val * 0);
                }
            }

            return returnList.Sum();
        }

        private async Task ReadFile()
        {
            try
            {
                var lines = await File.ReadAllLinesAsync("DayOneInput.txt");
                foreach (var line in lines)
                {
                    var split = line.Split(' ');

                    _list1.Add(int.Parse(split[0]));
                    _list2.Add(int.Parse(split[3]));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
