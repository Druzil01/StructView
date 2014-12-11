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
using StructView.Data;

namespace StructView
{
    public partial class Main : Form
    {
        private int pid;
        private Memory mem;
        private int CurAdress;

        private void FindPoeProcess()
        {
            var clients = Process.GetProcessesByName("PathOfExile").Select(p => Tuple.Create(p, "PathOfExile")).ToList(); // more than one Instance ? 
            // i dont care. i only use 1st one 
            pid= clients.Count > 0 ? clients[0].Item1.Id : 0;
            if (clients.Count > 0)
                mem = new Memory(pid);
        
        }

        public Main()
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
            cmb_structure.Items.AddRange(Project.Poe.Structs.Select(s => s.Name).ToArray());
            BuildTree();
            tv.ExpandAll();
            //4,7c,9c,13c,220,f8,a50,988,a44 <<- path to inventory by Alk 
            FindPoeProcess();
        }

        private void initializeDemoStruct()
        {
            cStructure s = new cStructure();
            s.Name = "Element";
            s.Fields.Add(new cField(0x818, "List of ChildWindows-Start", DataType.Pointer));
            s.Fields.Add(new cField(0x81c, "List of ChildWindows-Start", DataType.Pointer));
            s.Fields.Add(new cField(0x864, "Root-Window", DataType.Pointer));
            s.Fields.Add(new cField(0x868, "Parent Window", DataType.Pointer));
            s.Fields.Add (new cField(0x86C, "X-Position",DataType.Float));
            s.Fields.Add (new cField(0x870, "Y-Position",DataType.Float));
            s.Fields.Add (new cField(0x8F8, "Widht",DataType.Float));
            s.Fields.Add (new cField(0x8FC, "Height",DataType.Float));
            s.Fields.Add (new cField(0x8a4, "isClickable -> not sure!!", DataType.Float));
            Project.Poe.Structs.Add(s);

            s = new cStructure();
            s.Name = "Inventory";
            s.Fields.Add(new cField(0xC, "Width", DataType.Integer));
            s.Fields.Add(new cField(0x10, "Height", DataType.Integer));
            s.Fields.Add(new cField(0x20, "ListStart", DataType.Pointer));
            s.Fields.Add(new cField(0x24, "ListEnd", DataType.Pointer));
            Project.Poe.Structs.Add(s);


            s = new cStructure();
            s.Name = "Entity";
            s.Fields.Add(new cField(0x4, "ComponentList-Start", DataType.Pointer));
            s.Fields.Add(new cField(0x8, "ComponentList-Start", DataType.Pointer));
            s.Fields.Add(new cField(0x18, "Id", DataType.Integer));
            s.Fields.Add(new cField(0x10, "Hostile", DataType.Bit));
            s.Fields.Add(new cField(0x20, "ListStart", DataType.Pointer));
            s.Fields.Add(new cField(0x24, "ListEnd", DataType.Pointer));
            Project.Poe.Structs.Add(s);

            s = new cStructure();
            s.Name = "Inventory-Set";
            s.Fields.Add(new cField(0x0,   "Player Inventory", DataType.Pointer));
            s.Fields.Add(new cField(0x10,  "Chest Item", DataType.Pointer));
            s.Fields.Add(new cField(0x20,  "Left Weapon", DataType.Pointer));
            s.Fields.Add(new cField(0x30,  "Right Weapon", DataType.Pointer));
            s.Fields.Add(new cField(0x00, "PlayerInventory", DataType.Pointer));
            s.Fields.Add(new cField(0x10, "Chest          ", DataType.Pointer));
            s.Fields.Add(new cField(0x20, "Left Weapon    ", DataType.Pointer));
            s.Fields.Add(new cField(0x30, "Right Weapon   ", DataType.Pointer));
            s.Fields.Add(new cField(0x40, "Helm           ", DataType.Pointer));
            s.Fields.Add(new cField(0x50, "Amulet         ", DataType.Pointer));
            s.Fields.Add(new cField(0x60, "Left Ring      ", DataType.Pointer));
            s.Fields.Add(new cField(0x70, "Right Ring     ", DataType.Pointer));
            s.Fields.Add(new cField(0x80, "Gloves         ", DataType.Pointer));
            s.Fields.Add(new cField(0x90, "Boots          ", DataType.Pointer));
            s.Fields.Add(new cField(0xa0, "Belt           ", DataType.Pointer));
            s.Fields.Add(new cField(0xb0, "Flasks         ", DataType.Pointer));
            s.Fields.Add(new cField(0xc0, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0xd0, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0xe0, "Left Weapon swap", DataType.Pointer));
            s.Fields.Add(new cField(0xf0, "Right Weapon swap", DataType.Pointer));
            s.Fields.Add(new cField(0x100, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x110, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x120, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x130, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x140, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x150, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x160, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x170, "unknown", DataType.Pointer));
            s.Fields.Add(new cField(0x180, "Stash 1", DataType.Pointer));
            s.Fields.Add(new cField(0x190, "Stash 2", DataType.Pointer));
            s.Fields.Add(new cField(0x1a0, "Stash 3", DataType.Pointer));
            s.Fields.Add(new cField(0x1b0, "Stash 4", DataType.Pointer));
            s.Fields.Add(new cField(0x1c0, "Stash 5", DataType.Pointer));
            s.Fields.Add(new cField(0x1d0, "Stash 6", DataType.Pointer));
            s.Fields.Add(new cField(0x1e0, "Stash 7", DataType.Pointer));
            s.Fields.Add(new cField(0x1f0, "Stash 8", DataType.Pointer));
            s.Fields.Add(new cField(0x200, "Stash 9", DataType.Pointer));
            s.Fields.Add(new cField(0x210, "Stash 10", DataType.Pointer));
            s.Fields.Add(new cField(0x220, "Stash 11", DataType.Pointer));
            s.Fields.Add(new cField(0x230, "Stash 12", DataType.Pointer));
            s.Fields.Add(new cField(0x240, "Stash 13", DataType.Pointer));
            s.Fields.Add(new cField(0x250, "Stash 14", DataType.Pointer));
            s.Fields.Add(new cField(0x260, "Stash 15", DataType.Pointer));
            s.Fields.Add(new cField(0x270, "Stash 16", DataType.Pointer));
            s.Fields.Add(new cField(0x280, "Stash 17", DataType.Pointer));
            s.Fields.Add(new cField(0x290, "Stash 18", DataType.Pointer));
            s.Fields.Add(new cField(0x2a0, "Stash 19", DataType.Pointer));
            s.Fields.Add(new cField(0x2b0, "Stash 20", DataType.Pointer));
            s.Fields.Add(new cField(0x2c0, "Stash 21", DataType.Pointer));
            s.Fields.Add(new cField(0x2d0, "Stash 22", DataType.Pointer));
            s.Fields.Add(new cField(0x2e0, "Stash 23", DataType.Pointer));
            s.Fields.Add(new cField(0x2f0, "Stash 24", DataType.Pointer));
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

            a.Children.Add (new cOffset("UIBase", 0x220, ""));
            //4,7c,9c,13c,220,f8,a50,988,a44 <<- path to inventory by Alk 
                a.Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0xF8, ""));
                a.Children[0].Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0xa50, ""));
                a.Children[0].Children[0].Children[0].Children.Add(new cOffset("Unknown ... Path to Inventory", 0x988, ""));
                a.Children[0].Children[0].Children[0].Children[0].Children.Add(new cOffset("Path to Inventory", 0x44, ""));
                a.Children[0].Children[0].Children[0].Children[0].Children[0].Children.Add(new cOffset("Ptr to Player-Inv", 0x4, "Inventory"));
                a.Children[0].Children[0].Children[0].Children[0].Children[0].Children[0].Children.Add(new cOffset("Inventory", 0x14, "Entity"));

                a.Children[0].Children.Add (new cOffset("Unknown ... Path to Flask", 0x4c, ""));
                a.Children[0].Children[1].Children.Add(new cOffset("Unknown ... Path to Flask", 0x968, ""));
                a.Children[0].Children[1].Children[0].Children.Add(new cOffset("Flask-Inventory", 0x984, "Inventory"));
                a.Children[0].Children[1].Children[0].Children[0].Children.Add(new cOffset("FlaskInventory List Start", 0x20, ""));
                a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 1", 0x0, ""));
                a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 2", 0x4, ""));
                a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 3", 0x8, ""));
                a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 4", 0xc, ""));
                a.Children[0].Children[1].Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 5", 0x10, ""));

                i = new cOffset("HpGlobe", 0x40, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ManaGlobe", 0x44, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Flasks Bottom Left", 0x4C, "Element"); a.Children[0].Children.Add(i);
                i.Children.Add (new cOffset("Unknown ... Path to Flask", 0x968, ""));
                i.Children[0].Children.Add(new cOffset("Flask-Inventory", 0x984, "Inventory"));
                i.Children[0].Children[0].Children.Add(new cOffset("FlaskInventory List Start", 0x20, ""));
                i.Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 1", 0x0, ""));
                i.Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 2", 0x4, ""));
                i.Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 3", 0x8, ""));
                i.Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 4", 0xc, ""));
                i.Children[0].Children[0].Children[0].Children.Add(new cOffset("Flask 5", 0x10, ""));
                i = new cOffset("XpBar", 0x50, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("MenuButton", 0x54, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ShopButton", 0x7C, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("HideoutEditButton", 0x84, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("HideoutStashButton", 0x88, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("SkillPointAvailable", 0x8C, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("QuestInfoButton", 0x90, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ChatButton", 0x9C, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Mouseposition", 0xA0, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ActionButtons", 0xA4, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("SkillSelectWindow", 0xA8, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Chat", 0xDC, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("QuestTracker", 0xEC, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("MtxInventory", 0xF0, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("MtxShop", 0xF4, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("InventoryPanel", 0xF8, "Element"); a.Children[0].Children.Add(i);
                i.Children.Add(new cOffset("List of child-Windows", 0x818, ""));
                i.Children[0].Children.Add(new cOffset("Child 1", 0x00, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 2", 0x04, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 3", 0x08, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 4", 0x0c, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 5", 0x10, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 6", 0x14, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 7", 0x18, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 8", 0x1c, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 9", 0x20, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 10", 0x24, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 11", 0x28, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 12", 0x2c, "Element"));
                i.Children[0].Children.Add(new cOffset("Child 13", 0x30, "Element"));

                i = new cOffset("StashPanel", 0xFc, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("SocialPanel", 0x108, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("TreePanel", 0x10c, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("CharacterPanel", 0x110, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("OptionsPanel", 0x114, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("AchievementsPanel", 0x118, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("WorldPanel", 0x11c, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Minimap", 0x120, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ItemsOnGroundLabels", 0x124, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("MonsterHpLabels", 0x128, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Buffs", 0x134, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("Buffs2", 0x190, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("OpenLeftPanel", 0x158, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("OpenRightPanel", 0x15c, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("OpenNpcDialogPanel", 0x164, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("CreatureInfoPanel", 0x188, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("InstanceManagerPanel", 0x19c, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("InstanceManagerPanel2", 0x1a0, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("SwitchingZoneInfo", 0x1C8, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("GemLvlUpPanel", 0x1Fc, "Element"); a.Children[0].Children.Add(i);
                i = new cOffset("ItemOnGroundTooltip", 0x20C, "Element"); a.Children[0].Children.Add(i);


            o.Children.Add(new cOffset());
            a = o.Children[2];
            a.description = "IngameUIElements";
            a.Offset = 0x5E8;

            i = new cOffset("HpGlobe", 0x40,"Element"); a.Children.Add(i);
            i = new cOffset("ManaGlobe", 0x44,"Element"); a.Children.Add(i);
            i = new cOffset("Flasks", 0x4C,"Element"); a.Children.Add(i);
            i = new cOffset("XpBar", 0x50,"Element"); a.Children.Add(i);
            i = new cOffset("MenuButton", 0x54,"Element"); a.Children.Add(i);
            i = new cOffset("ShopButton", 0x7C,"Element"); a.Children.Add(i);
            i = new cOffset("HideoutEditButton", 0x84,"Element"); a.Children.Add(i);
            i = new cOffset("HideoutStashButton", 0x88,"Element"); a.Children.Add(i);
            i = new cOffset("SkillPointAvailable", 0x8C,"Element"); a.Children.Add(i);
            i = new cOffset("QuestInfoButton", 0x90, "Element"); a.Children.Add(i);
            i = new cOffset("ChatButton", 0x9C,"Element"); a.Children.Add(i);
            i = new cOffset("Mouseposition", 0xA0,"Element"); a.Children.Add(i);
            i = new cOffset("ActionButtons", 0xA4,"Element"); a.Children.Add(i);
            i = new cOffset("SkillSelectWindow", 0xA8,"Element"); a.Children.Add(i);
            i = new cOffset("Chat", 0xDC,"Element"); a.Children.Add(i);
            i = new cOffset("QuestTracker", 0xEC,"Element"); a.Children.Add(i);
            i = new cOffset("MtxInventory", 0xF0,"Element"); a.Children.Add(i);
            i = new cOffset("MtxShop", 0xF4,"Element"); a.Children.Add(i);
            i = new cOffset("InventoryPanel", 0xF8,"Element"); a.Children.Add(i);
            i = new cOffset("StashPanel", 0xFc,"Element"); a.Children.Add(i);
            i = new cOffset("SocialPanel", 0x108,"Element"); a.Children.Add(i);
            i = new cOffset("TreePanel", 0x10c,"Element"); a.Children.Add(i);
            i = new cOffset("CharacterPanel", 0x110,"Element"); a.Children.Add(i);
            i = new cOffset("OptionsPanel", 0x114,"Element"); a.Children.Add(i);
            i = new cOffset("AchievementsPanel", 0x118,"Element"); a.Children.Add(i);
            i = new cOffset("WorldPanel", 0x11c,"Element"); a.Children.Add(i);
            i = new cOffset("Minimap", 0x120,"Element"); a.Children.Add(i);
            i = new cOffset("ItemsOnGroundLabels", 0x124,"Element"); a.Children.Add(i);
            i = new cOffset("MonsterHpLabels", 0x128,"Element"); a.Children.Add(i);
            i = new cOffset("Buffs", 0x134,"Element"); a.Children.Add(i);
            i = new cOffset("Buffs2", 0x190,"Element"); a.Children.Add(i);
            i = new cOffset("OpenLeftPanel", 0x158,"Element"); a.Children.Add(i);
            i = new cOffset("OpenRightPanel", 0x15c,"Element"); a.Children.Add(i);
            i = new cOffset("OpenNpcDialogPanel", 0x164,"Element"); a.Children.Add(i);
            i = new cOffset("CreatureInfoPanel", 0x188,"Element"); a.Children.Add(i);
            i = new cOffset("InstanceManagerPanel", 0x19c,"Element"); a.Children.Add(i);
            i = new cOffset("InstanceManagerPanel2", 0x1a0,"Element"); a.Children.Add(i);
            i = new cOffset("SwitchingZoneInfo", 0x1C8,"Element"); a.Children.Add(i);
            i = new cOffset("GemLvlUpPanel", 0x1Fc,"Element"); a.Children.Add(i);
            i = new cOffset("ItemOnGroundTooltip", 0x20C,"Element"); a.Children.Add(i);

            o.Children.Add(new cOffset());
            a = o.Children[3];
            a.description = "UiRoot";
            a.Structure = "Element";
            a.Offset = 0xC0C;

            o.Children.Add(new cOffset());
            a = o.Children[4];
            a.description = "UiHover-> noty yet correct";
            a.Offset = 0xC20;
            a.Structure = "Element";

            a.Children.Add (new cOffset("tooltip",0xAEC,""));
            a.Children.Add(new cOffset("Item", 0xB10, "Entity"));

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
            ObjRefresh((cOffset)e.Node.Tag);
        }

        private void ObjRefresh(cOffset ofs)
        {
            txt_desc.Text = ofs.description;
            txt_offs.Text = ofs.Offset == 0 ?"0":ofs.Offset.ToString("X8").TrimStart('0');
            CurAdress = ofs.Adress(mem);
            txt_adr.Text = ofs.Adress(mem).ToString("X8").TrimStart('0');//o.adress.ToString("X8").TrimStart('0');
            txt_ofsChain.Text = ofs.getOffsChain();
            cmb_structure.Text = ofs.Structure; // change event wird jetzt ausgeführt
        }

        private void calcMemAdressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (cOffset o in Project.Poe.Offsets)
            {

            }
        }

        private void addOffsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOffset offs = (cOffset)tv.SelectedNode.Tag;
            cOffset newOffs = new cOffset("New Offset",0);
            offs.Children.Add(newOffs);
            newOffs.Parent = offs;
            TreeNode n = new TreeNode(newOffs.description);
            n.Tag = newOffs;
            tv.SelectedNode.Nodes.Add(n);
            tv.SelectedNode.Expand();
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tv.SelectedNode = e.Node;
            }
        }

        private void txt_desc_Leave(object sender, EventArgs e)
        {
            cOffset ofs = (cOffset)tv.SelectedNode.Tag;
            ofs.description = txt_desc.Text;
            tv.SelectedNode.Text = ofs.description;

        }

        private void txt_offs_Leave(object sender, EventArgs e)
        {
            cOffset ofs = (cOffset)tv.SelectedNode.Tag;
            ofs.Offset = Convert.ToInt16(txt_offs.Text,16);
            ObjRefresh(ofs);
        }

        private void findValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memSearch win = new memSearch();
            win.Mem = mem;
            win.Show(this);
        }

        private void cmb_structure_TextChanged(object sender, EventArgs e)
        {
            cOffset ofs = (cOffset)tv.SelectedNode.Tag;
            ofs.Structure = cmb_structure.Text;
            dta.Items.Clear();
            if (!string.IsNullOrEmpty(cmb_structure.Text))
            {
                cStructure str = (cStructure)Project.Poe.Structs.FirstOrDefault(s => s.Name == cmb_structure.Text);
                if (str != null)
                {
                    foreach (cField f in str.Fields)
                    {
                        ListViewItem row = new ListViewItem(f.Offset.ToString("X8").TrimStart('0'));
                        row.SubItems.Add(f.Description);
                        row.SubItems.Add(f.Type.ToString());
                        string val = "";
                        switch (f.Type)
                        {
                            case DataType.Integer:
                                val = mem.ReadInt(CurAdress + f.Offset).ToString();
                                break;
                            case DataType.Float:
                                val = mem.ReadFloat(CurAdress + f.Offset).ToString();
                                break;
                            case DataType.Pointer:
                                val = "p->" + mem.ReadInt(CurAdress + f.Offset).ToString("X8");
                                break;
                            case DataType.String:
                                val = mem.ReadString(CurAdress + f.Offset, 255);
                                break;
                            case DataType.Bit:
                                val = (mem.ReadByte(CurAdress + f.Offset) & 1).ToString();
                                break;
                        }
                        row.SubItems.Add(val);
                        dta.Items.Add(row);
                    }
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOffset offs = (cOffset)tv.SelectedNode.Tag;
            cOffset newOffs = new cOffset(offs);
            offs.Parent.Children.Add(newOffs);
            TreeNode n = new TreeNode(newOffs.description);
            n.Tag = newOffs;
            tv.SelectedNode.Parent.Nodes.Add(n); 
            tv.SelectedNode.Expand();
            tv.SelectedNode = n;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cOffset offs = (cOffset)tv.SelectedNode.Tag;
            offs.Parent.Children.RemoveAt(offs.Parent.Children.IndexOf(offs));
            TreeNode n = tv.SelectedNode.PrevNode;
            tv.SelectedNode.Parent.Nodes.Remove(tv.SelectedNode);
            tv.SelectedNode = n;
        }
    }
}
