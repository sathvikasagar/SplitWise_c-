using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise
{
    class Friend
    {
        public string name;
        public float spent;
        public float share;
        public Friend(string rowData)
        {
            string[] data = rowData.Split(',');

            // Parse data 
            this.name = data[0];
            try
            {
                this.spent = float.Parse(data[1]);
                this.share = float.Parse(data[2]);
            }
            catch (Exception)
            {
                Console.WriteLine("Group Exit");
            }
        }
    }
}
