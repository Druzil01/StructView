using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using StructView.Framework;

namespace StructView.Data
{
    public enum DataType
    {
        None,
        Integer,
        Float,
        String,
        Pointer,
        Byte,
        Bit,
    }

    [Serializable]
    public class cField
    {
        /// <summary>
        /// Offset of Field
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// Simple Desription
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Datatype to display
        /// </summary>
        public DataType Type { get; set; }
        /// <summary>
        /// if its a Pointer : Name of the Structur it points to
        /// </summary>
        public string Structure { get; set; } 
        public cField()
        {
            Offset = 0;
            Description = "";
            Type = DataType.None;
            Structure = null;
        }

        public cField(int offs, string desc, DataType type)
            : this()
        {
            Offset = offs;
            Description = desc;
            Type = type;
        }
    }

    [Serializable]
    public class cStructure
    {
        public string Name { get; set; }
        public List<cField> Fields { get; set; }

        public cStructure()
        {
            Name = "";
            Fields = new List<cField>();
        }
    }

    [Serializable]
    public class cOffset
    {
        public int Offset { get; set; }
        [XmlIgnore]
        public cOffset Parent { get; set; }
        public string description { get; set; }
        public List<cOffset> Children { get; set; }
        public string Structure { get; set; }

        public cOffset()
        {
            Offset = 0;
            description = "";
            Parent = null;
            Children = new List<cOffset>();
        }

        public cOffset(String desc, int offs) : this()
        {
            description = desc;
            Offset = offs;
        }

        public cOffset(String desc, int offs,string structure)
            : this(desc,offs)
        {
            Structure = structure;
        }

        public cOffset(cOffset Source)
        {
            Offset = Source.Offset;
            Parent = Source.Parent;
            Structure = Source.Structure;
            description = "copy from" + Source.description;
            Children = new List<cOffset>();
            foreach (cOffset c in Source.Children)
                Children.Add( new cOffset(c));
        }

        public string getOffsChain()
        {
            if (Parent != null)
                return Parent.getOffsChain() + "," + Offset.ToString("X8").TrimStart('0');
            else
                return Offset.ToString("X8").TrimStart('0');
        }

        public int Adress(Memory mem)
        {
            if (mem != null)
                if (Parent != null)
                    return mem.ReadInt(Parent.Adress(mem) + Offset);
                else
                    return mem.ReadInt(mem.BaseAddress + Offset);
            else
                return 0;
        }

        public override string ToString()
        {
            return Offset.ToString("X4") + " - >" + description;
        }
    }

    [Serializable]
    public class PoeProject
    {
        public List<cOffset> Offsets = null;
        public List<cStructure> Structs = null;

        public PoeProject()
        {
            Offsets = new List<cOffset>();
            Structs = new List<cStructure>();
        }
    }

    public static class Project
    {
        public static PoeProject Poe = null;
        public static string Filename = "";

        public static void Load(string fname)
        {
            if (File.Exists(fname))
            {
                Filename = fname;
                XmlSerializer ser = new XmlSerializer(typeof(PoeProject));
                StreamReader sr = new StreamReader(fname);
                PoeProject p = (PoeProject)ser.Deserialize(sr);
                Poe = p;
                sr.Close();
                CalcParents(null, Poe.Offsets);
            }
            else
            {
                Poe = new PoeProject();
            }
        }

        private static void CalcParents(cOffset Parent, List<cOffset> Childs)
        {
            foreach (cOffset o in Childs)
            {
                o.Parent = Parent;
                CalcParents(o, o.Children);
            }
        }

        public static void Save()
        {
            if (Filename != "")
                Save(Filename);
        }

        public static void Save(string fname)
        {
            XmlSerializer ser = new XmlSerializer(typeof(PoeProject));
            FileStream str = new FileStream(fname, FileMode.Create);
            ser.Serialize(str, Poe);
            str.Close();
        }

    }

}
