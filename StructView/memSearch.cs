using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StructView.Data;
using StructView.Framework;


namespace StructView
{
    public partial class memSearch : Form
    {
        public Memory Mem { get; set; }

        private List<memAdr> Found = new List<memAdr>();

        public memSearch()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            findMemValue(int.Parse(txt_search.Text, System.Globalization.NumberStyles.HexNumber));
        }

        private int SearchBytes(byte[] haystack, byte[] needle)
        {
            var len = needle.Length;
            var limit = haystack.Length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != haystack[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        private void findMemValue(int srch)
        {
            if (Mem != null)
            {
                Found.Clear();
                byte[] exeMem = Mem.ReadBytes(Mem.BaseAddress, 0x2000000);
                byte[] bsrch = BitConverter.GetBytes(srch);
                int s = SearchBytes(exeMem,bsrch);
                if (s>=0)
                    Found.Add(new memAdr(Mem.BaseAddress + s));
            }
            FoundAdr.DataSource = Found;
        }


        private void findMemValue2 (int srch)
        {
            if (Mem != null)
            {
                Found.Clear();
                byte[] exeMem = Mem.ReadBytes(Mem.BaseAddress, 0x2000000);
                byte[] bsrch = BitConverter.GetBytes(srch);

                srchBar.Maximum = exeMem.Length - bsrch.Length;

                for (int offset = 0; offset < exeMem.Length - bsrch.Length; offset += 1)
                {
                    srchBar.Value = offset;
                    bool f = true;
                    int k = 0;
                    while (k<bsrch.Length && f)
                    //for (int k = 0; k < bsrch.Length; k++)
                    {
                        f = f && bsrch[k] == exeMem[offset + k];
                        k++;
                    }
                    if (f)
                    {
                        Found.Add(new memAdr( Mem.BaseAddress + offset));
                    }
                    Application.DoEvents();
                }
                FoundAdr.DataSource = Found;
            }
        }

    }
}
