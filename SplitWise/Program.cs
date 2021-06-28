using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\sathvika_admin\source\repos\SplitWise_c#\SplitWisedata.csv");

            var friends = new List<Friend>();
            Calculate(csvLines, friends);

            System.IO.File.WriteAllLines(@"C:\Users\sathvika_admin\source\repos\SplitWise_c#\SplitWisedata.csv", csvLines);
        }

        private static void Calculate(string[] csvLines, List<Friend> friends)
        {
            //adding other 2 columns
            csvLines[0] += ",actual amount to be spent" + ",amount yet to be recieved";

            int count = 0;

            for (int i = 1; i < csvLines.Length; i++)
            {
                Friend fd = new Friend(csvLines[i]);
                if (fd.name.Length == 0)
                {
                    count++;
                }
                friends.Add(fd);
            }
            count++;
            float[] totalAmountPerGroup = new float[count];
            int groupCount = 0;
            int j = 0;
            float amountPerGroup = 0;
            while (j < friends.Count)
            {
                if (friends[j].name.Length == 0)
                {
                    totalAmountPerGroup[groupCount] = amountPerGroup;
                    amountPerGroup = 0;
                    groupCount++;
                }
                else
                {
                    amountPerGroup += friends[j].spent;
                }
                j++;
            }
            totalAmountPerGroup[groupCount] = amountPerGroup;

            groupCount = 0;

            for (int i = 0; i < friends.Count; i++)
            {
                if (friends[i].name.Length == 0)
                {
                    groupCount++;
                }
                else
                {
                    float toBeSpent = (friends[i].share * totalAmountPerGroup[groupCount]) / 100;
                    float toBeRecieved = friends[i].spent - toBeSpent;
                    csvLines[i + 1] += "," + toBeSpent.ToString() + "," + toBeRecieved.ToString();
                }

            }
        }  
    }
}
