using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructView.Framework;

namespace StructView.Data
{
    public class memAdr
    {
        public Memory mem { get; set; }
        public int Adr { get; set; }

        public memAdr(int adr)
        {
            Adr = adr;
        }

        public int Value
        {
            get
            {
                return mem.ReadInt(Adr);
            }
        }
    }
}
