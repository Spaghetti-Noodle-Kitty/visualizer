using System.Collections.Generic;

namespace ReportVisualizer
{
    class Math
    {
        public static float GetAverage(float[] initialNumbers)
        {
            float sum = 0;
            float avg = 0;

            for (int i = 0; i < initialNumbers.Length; i++)
                sum += initialNumbers[i];

            return (sum / initialNumbers.Length);

        }

        public static string[] GetAllExistingOnce(string[] Items)
        {
            List<string> ls = new List<string>();

            foreach (string s in Items)
                if (!ls.Contains(s))
                    ls.Add(s);

            return ls.ToArray();
        }
    }
}
