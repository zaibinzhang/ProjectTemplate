using System;

namespace ProjectTemplate.Common
{
    public static class RandomHelper
    {
        private static object _lock = new object();

        private static int _count = 1;

        public static string GetRandom(string head)
        {
            lock (_lock)
            {
                if (_count >= 10000)
                {
                    _count = 1;
                }
                var number = head + DateTime.Now.ToString("yyMMddHHmmss") + _count.ToString("0000");
                _count++;
                return number;
            }
        }
    }
}