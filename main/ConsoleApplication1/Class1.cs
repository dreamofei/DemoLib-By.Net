using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    delegate string DTT();
    class Class1 : ICloneable
    {
        public Class1 member;
        public int a;
        public event DTT treeLis;
        public DTT treeLis2;

        string fun2()
        {
            if (a==5)
                return treeLis();
            else
                return treeLis2();
        }

        public Class1(int a)
        {
            this.a = a;
        }
        public override bool Equals(object obj)
        {
            if (a == (obj as Class1).a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public object DeepClone()
        {
            Class1 c = new Class1(this.a);
            c.member = (Class1)this.member.Clone();
            return c;
        }
    }
    public interface tt
    {
        int I
        {
            get;
            set;
        }
        void T();
        int this[int i]
        {
            get;
            set;
        }
    }
}
