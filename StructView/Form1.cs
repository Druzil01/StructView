using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using StructView.Framework;
namespace StructView
{
    public partial class Form1 : Form
    {
        private int pid;
        private Memory mem;

        private void FindPoeProcess()
        {
            var clients = Process.GetProcessesByName("PathOfExile").Select(p => Tuple.Create(p, "PathOfExile")).ToList(); // more than one Instance ? 
            // i dont care. i only use 1st one 
            pid= clients.Count > 0 ? clients[0].Item1.Id : 0;
            if (clients.Count > 0)
                mem = new Memory(pid);
        
        }

        public Form1()
        {
            InitializeComponent();
            dta.Columns.Add("Offset");
            dta.Columns.Add("Descrition");
            dta.Columns.Add("Datatype");
            dta.Columns.Add("Current Value");
            Project.Load(Environment.CurrentDirectory + "\\Poe.xml");
            if (Project.Poe.Offsets.Count == 0) 
            {
                initializeDemoTree();
                initializeDemoStruct();
            }
            BuildTree();
            tv.ExpandAll();
            //4,7c,9c,13c,220,f8,a50,988,a44 <<- path to inventory by Alk 
            FindPoeProcess();
            if (pid != 0) // Process found : calc Adresses
            {
                CalcAdress(mem.BaseAddress, Project.Poe.Offsets);
            }
        }

        private void initializeDemoStruct()
        {
            cStructure s = new cStructure();
            s.Name = "UiElement";
            s.Fields.Add (new cField(0x86C, "x-Position",DataType.Float));
            s.Fields.Add (new cField(0x870, "x-Position",DataType.Float));
            s.Fields.Add (new cField(0x8F8, "Widht",DataType.Float));
            s.Fields.Add (new cField(0x8FC, "Height",DataType.Float));
            s.Fields.Add (new cField(0x8a4, "isClickable -> not sure!!", DataType.Float));
            Project.Poe.Structs.Add(s);
        }

        private void initializeDemoTree()
        {
            cOffset o = new cOffset();
            Project.Poe.Offsets.Add(o);
            o.description = "Path Of Exile";
            o.Offset = 8833876;

            //o.Children.Add(new cOffset());
            //o = o.Children[0];
            //o.description = "BaseAdress";
            //o.Offset = 8833876;

            o.Children.Add(new cOffset());
            o = o.Children[0];
            o.description = "---";
            o.Offset = 0x4;

            o.Children.Add(new cOffset());
            o = o.Children[0];
            o.description = "TheGame";
            o.Offset = 0x7c;

            o.Children.Add(new cOffset());
            o = o.Children[0];
            o.description = "IngameState/Framebase";
            o.Offset = 0x9c;

            cOffset a = null;
            o.Children.Add(new cOffset());
            a = o.Children[0];
            a.description = "IngameData";
            a.Offset = 0x138;
            a.Structure = "IngameData";

            cOffset i;
            i = new cOffset("CurrentArea", 0x8, "AreaTemplate"); a.Children.Add(i);
            i = new cOffset("LocalPlayer", 0x5A0, "LocalPlayer"); a.Children.Add(i);
            i = new cOffset("Entity-List", 0x5C0, "EntitList"); a.Children.Add(i);


            o.Children.Add(new cOffset());
            a = o.Children[1];
            a.description = "ServerData";
            a.Offset = 0x13c;

            a.Children.Add (new cOffset("Unknown ... ", 0x220, ""));
            //4,7c,9c,13c,220,f8,a50,988,a44 <<- path to inventory by Alk 
            a.Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0xF8, ""));
            a.Children[0].Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0xa50, ""));
            a.Children[0].Children[0].Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0x988, ""));
            a.Children[0].Children[0].Children[0].Children[0].Children.Add(new cOffset("Inventory", 0xA44, ""));

            a.Children[0].Children.Add (new cOffset("Unknown ... Path to Flask", 0x4c, ""));
            a.Children[0].Children[1].Children.Add(new cOffset("Unknown ... Path to Flask", 0x968, ""));
            a.Children[0].Children[1].Children[0].Children.Add(new cOffset("Unknown ... Path to Flask", 0x984, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children.Add(new cOffset("Unknown ... Path to Flask", 0x20, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 1", 0x0, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 2", 0x4, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 3", 0x8, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 4", 0xc, ""));
            a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 5", 0x10, "")); 

            o.Children.Add(new cOffset());
            a = o.Children[2];
            a.description = "IngameUIElements";
            a.Offset = 0x5E8;

            
            i = new cOffset("HpGlobe", 0x40,"UiElement"); a.Children.Add(i);
            i = new cOffset("ManaGlobe", 0x44,"UiElement"); a.Children.Add(i);
            i = new cOffset("Flasks", 0x4C,"UiElement"); a.Children.Add(i);
            i = new cOffset("XpBar", 0x50,"UiElement"); a.Children.Add(i);
            i = new cOffset("MenuButton", 0x54,"UiElement"); a.Children.Add(i);
            i = new cOffset("ShopButton", 0x7C,"UiElement"); a.Children.Add(i);
            i = new cOffset("HideoutEditButton", 0x84,"UiElement"); a.Children.Add(i);
            i = new cOffset("HideoutStashButton", 0x88,"UiElement"); a.Children.Add(i);
            i = new cOffset("SkillPointAvailable", 0x8C,"UiElement"); a.Children.Add(i);
            i = new cOffset("ChatButton", 0x9C,"UiElement"); a.Children.Add(i);
            i = new cOffset("Mouseposition", 0xA0,"UiElement"); a.Children.Add(i);
            i = new cOffset("ActionButtons", 0xA4,"UiElement"); a.Children.Add(i);
            i = new cOffset("SkillSelectWindow", 0xA8,"UiElement"); a.Children.Add(i);
            i = new cOffset("Chat", 0xDC,"UiElement"); a.Children.Add(i);
            i = new cOffset("QuestTracker", 0xEC,"UiElement"); a.Children.Add(i);
            i = new cOffset("MtxInventory", 0xF0,"UiElement"); a.Children.Add(i);
            i = new cOffset("MtxShop", 0xF4,"UiElement"); a.Children.Add(i);
            i = new cOffset("InventoryPanel", 0xF8,"UiElement"); a.Children.Add(i);
            i = new cOffset("StashPanel", 0xFc,"UiElement"); a.Children.Add(i);
            i = new cOffset("SocialPanel", 0x108,"UiElement"); a.Children.Add(i);
            i = new cOffset("TreePanel", 0x10c,"UiElement"); a.Children.Add(i);
            i = new cOffset("CharacterPanel", 0x110,"UiElement"); a.Children.Add(i);
            i = new cOffset("OptionsPanel", 0x114,"UiElement"); a.Children.Add(i);
            i = new cOffset("AchievementsPanel", 0x118,"UiElement"); a.Children.Add(i);
            i = new cOffset("WorldPanel", 0x11c,"UiElement"); a.Children.Add(i);
            i = new cOffset("Minimap", 0x120,"UiElement"); a.Children.Add(i);
            i = new cOffset("ItemsOnGroundLabels", 0x124,"UiElement"); a.Children.Add(i);
            i = new cOffset("MonsterHpLabels", 0x128,"UiElement"); a.Children.Add(i);
            i = new cOffset("Buffs", 0x134,"UiElement"); a.Children.Add(i);
            i = new cOffset("Buffs2", 0x190,"UiElement"); a.Children.Add(i);
            i = new cOffset("OpenLeftPanel", 0x158,"UiElement"); a.Children.Add(i);
            i = new cOffset("OpenRightPanel", 0x15c,"UiElement"); a.Children.Add(i);
            i = new cOffset("OpenNpcDialogPanel", 0x164,"UiElement"); a.Children.Add(i);
            i = new cOffset("CreatureInfoPanel", 0x188,"UiElement"); a.Children.Add(i);
            i = new cOffset("InstanceManagerPanel", 0x19c,"UiElement"); a.Children.Add(i);
            i = new cOffset("InstanceManagerPanel2", 0x1a0,"UiElement"); a.Children.Add(i);
            i = new cOffset("SwitchingZoneInfo", 0x1C8,"UiElement"); a.Children.Add(i);
            i = new cOffset("GemLvlUpPanel", 0x1Fc,"UiElement"); a.Children.Add(i);
            i = new cOffset("ItemOnGroundTooltip", 0x20C,"UiElement"); a.Children.Add(i);

            o.Children.Add(new cOffset());
            a = o.Children[3];
            a.description = "UiRoot";
            a.Offset = 0xC0C;

            o.Children.Add(new cOffset());
            a = o.Children[4];
            a.description = "UiHover";
            a.Offset = 0xC20;

            o.Children.Add(new cOffset());
            a = o.Children[5];
            a.description = "EntityLabelmap-";
            a.Offset = 0x44;

            a.Children.Add(new cOffset());
            a = a.Children[0];
            a.description = "EntityLabelmap";
            a.Offset = 0x9E0;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.Save(Environment.CurrentDirectory + "\\Poe.xml");
        }

        private void AddOffsToTv(TreeNodeCollection tn, List<cOffset> oList)
        {
            if (oList != null && oList.Count>0)
            {
                foreach (cOffset c in oList)
                {
                    TreeNode n = new TreeNode(c.description);
                    n.Tag = c;
                    tn.Add(n);
                    AddOffsToTv(n.Nodes, c.Children);
                }
            }
        }

        private void BuildTree()
        {
            tv.Nodes.Clear();
            AddOffsToTv(tv.Nodes,Project.Poe.Offsets);
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cOffset o = (cOffset)e.Node.Tag;
            txt_desc.Text = o.description;
            txt_offs.Text = o.Offset.ToString("X8");//.TrimStart('0');
            txt_adr.Text = o.adress.ToString("X8");//.TrimStart('0');
            dta.Items.Clear();
            if (!string.IsNullOrEmpty(o.Structure))
            {
                cStructure str = (cStructure)Project.Poe.Structs.FirstOrDefault(s => s.Name == o.Structure);
                if (str != null)
                {
                    foreach (cField f in str.Fields)
                    {
                        ListViewItem row = new ListViewItem(f.Offset.ToString("X8").TrimStart('0'));
                        row.SubItems.Add(f.Description); 
                        row.SubItems.Add(f.Type.ToString()); 
                        dta.Items.Add(row);
                    }
                }
            }
        }

        private void calcMemAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (cOffset o in Project.Poe.Offsets)
            {

            }
        }

        private void CalcAdress(int adress, List<cOffset> Base)
        {
            foreach (cOffset c in Base)
            {
                c.adress = mem.ReadInt(adress + c.Offset);
                CalcAdress(c.adress, c.Children);
            }
        }
    }
}
