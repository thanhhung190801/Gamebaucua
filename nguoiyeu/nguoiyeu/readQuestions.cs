using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace nguoiyeu
{
    class readQuestions
    {
        public ArrayList docFile()
        {
            ArrayList arr = new ArrayList();
            string all = System.IO.File.ReadAllText(@"C:\Users\Administrator\Downloads\long_dotnet\long_dotnet\nguoiyeu\nguoiyeu\TextFile1.txt");
            string[] splitQ = all.Split('\n');
            int i = 0;
            while (true)
            {
                cauhoi c = new cauhoi(splitQ[5 * i], splitQ[5 * i + 1], splitQ[5 * i + 2], splitQ[5 * i + 3], splitQ[5 * i+4]);
                i++;
                arr.Add(c);
                if (i * 5 >= splitQ.Length) break;
            }
            return arr;
        }
    }
}
