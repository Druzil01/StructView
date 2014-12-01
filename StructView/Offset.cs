using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace StructView
{
    public enum DataType
    {
        None,
        Integer,
        Float,
        String,
        Pointer
    }

    [Serializable]
    public class cField
    {
        public int Offset { get; set; }
        public string Description { get; set; }
        public DataType Type { get; set; }

        public cField()
        {
            Offset = 0;
            Description = "";
            Type = DataType.None;
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
        [XmlIgnore] // Adress is calculated. no need to save
        public int adress { get; set; }
        public int Offset { get; set; }
        public cOffset Parent { get; set; }
        public string description { get; set; }
        public List<cOffset> Children { get; set; }
        public string Structure { get; set; }

        public cOffset()
        {
            adress = 0;
            Offset = 0;
            description = "";
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
            }
            else
            {
                Poe = new PoeProject();
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
