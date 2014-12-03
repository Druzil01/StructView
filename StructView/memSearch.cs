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


        private void findMemValue (int srch)
        {
            if (Mem != null)
            {
                Found.Clear();
                int max = Mem.MemorySize();
                max -= 4;
                srchBar.Maximum = max;

                for (int i = 0; i < max; i+=4)
                {
                    srchBar.Value = i;
                    srchBar.Refresh();
                    if (Mem.ReadInt(Mem.BaseAddress + i) == srch)
                    {
                        Found.Add(new memAdr(i));
                    }
                    Application.DoEvents();
                }
                FoundAdr.DataSource = Found;
            }
        }

    }
}
