using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nguoiyeu
{
    class cauhoi
    {
        public string content;
        public string A;
        public string B;
        public string C;
        public string D;
        public int result;
        public int answer = -1;

        public cauhoi(string content, string A, string B, string C, string D)
        {
            this.content = content;
            if (A.StartsWith("*"))
            {
                this.result = 0;
                this.A = A.Substring(1);
            }
            else
                this.A = A;
            if (B.StartsWith("*"))
            {
                this.result = 0;
                this.B = B.Substring(1);
            }
            else
                this.B = B;
            if (C.StartsWith("*"))
            {
                this.result = 0;
                this.C = C.Substring(1);
            }
            else
                this.C = C;
            if (D.StartsWith("*"))
            {
                this.result = 0;
                this.D = D.Substring(1);
            }
            else
                this.D= D;
            this.answer = -1;
        }
    }

}
