using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorsDataLib
{
    [Serializable]
    public class SensorData
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Int32 cnt;
        public Int32 Cnt
        {
            get { return cnt; }
            set { cnt = value; }
        }
        [NonSerialized]
        public int age;
    }

}
