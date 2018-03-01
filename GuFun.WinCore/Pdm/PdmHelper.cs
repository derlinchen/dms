using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GuFun.WinCore.Pdm
{
    public class PdmHelper
    {
        public const string a = "attribute", c = "collection", o = "object";

        public const string cClasses = "c:Classes";
        public const string oClass = "o:Class";

        public const string cAttributes = "c:Attributes";
        public const string oAttribute = "o:Attribute";

        public const string cTables = "c:Tables";
        public const string oTable = "o:Table";

        public const string cColumns = "c:Columns";
        public const string oColumn = "o:Column";


        XmlDocument xmlDoc;
        XmlNamespaceManager xmlnsManager;
        /// <summary>构造函数 </summary>
        public PdmHelper()
        {
            // TODO: 在此处添加构造函数逻辑
            xmlDoc = new XmlDocument();
        }
        /// <summary>构造函数 </summary>
        public PdmHelper(string pdm_file)
        {
            PdmFile = pdm_file;
        }

        string pdmFile;

        public string PdmFile
        {
            get { return pdmFile; }
            set
            {
                pdmFile = value;
                if (xmlDoc == null)
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(pdmFile);
                    xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                    xmlnsManager.AddNamespace("a", "attribute");
                    xmlnsManager.AddNamespace("c", "collection");
                    xmlnsManager.AddNamespace("o", "object");
                }
            }
        }

        IList<PdmTable> tables;

        public IList<PdmTable> Tables
        {
            get
            {
                if (tables == null)
                    tables = new List<PdmTable>();

                return tables;
            }
        }

        public void InitData()
        {
            this.Tables.Clear();

            XmlNode xnTables = xmlDoc.SelectSingleNode("//" + cTables, xmlnsManager);
            foreach (XmlNode xnTable in xnTables.ChildNodes)
            {
                Tables.Add(GetTable(xnTable));
            }
        }

        //初始化"o:Table"的节点
        private PdmTable GetTable(XmlNode xnTable)
        {
            PdmTable mTable = new PdmTable();
            XmlElement xe = (XmlElement)xnTable;

            mTable.PdmID = xe.GetAttribute("Id");

            XmlNodeList xnTProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnTProperty)
            {
                switch (xnP.Name)
                {
                    case "a:Name": mTable.TableName = xnP.InnerText;
                        break;
                    case "a:Code": mTable.TableCode = xnP.InnerText;
                        break;
                    case "a:Comment": mTable.Comment = xnP.InnerText;
                        break;
                    case "c:Columns": InitColumns(xnP, mTable);
                        break;
                    case "c:Keys": InitKeys(xnP, mTable);
                        break;
                    case "c:PrimaryKey": InitPrimaryKey(xnP, mTable);
                        break;
                    case "c:Indexes": InitIndexes(xnP, mTable);
                        break;
                }
            }
            return mTable;
        }
        //初始化"c:Columns"的节点
        private void InitColumns(XmlNode xnColumns, PdmTable pTable)
        {
            int i = 1;
            pTable.Columns.Clear();

            foreach (XmlNode xnColumn in xnColumns)
            {
                PdmColumn item = GetColumn(xnColumn);
                item.ColumnID = i;
                pTable.AddColumn(item);
                i++;
            }
        }

        //初始化c:Keys"的节点
        private void InitKeys(XmlNode xnKeys, PdmTable pTable)
        {
            int i = 1;
            pTable.Keys.Clear();

            foreach (XmlNode xnKey in xnKeys)
            {
                PdmKey item = GetKey(xnKey, pTable);
                item.KeyID = i;
                pTable.AddKey(item);
                i++;
            }
        }

        private PdmColumn GetColumn(XmlNode xnColumn)
        {
            PdmColumn mColumn = new PdmColumn();
            XmlElement xe = (XmlElement)xnColumn;
            mColumn.PdmID = xe.GetAttribute("Id");
            XmlNodeList xnCProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnCProperty)
            {
                switch (xnP.Name)
                {
                    case "a:Name": mColumn.ColumnName = xnP.InnerText;
                        break;
                    case "a:Code": mColumn.ColumnCode = xnP.InnerText;
                        break;
                    case "a:Comment": mColumn.ColumnComment = String.IsNullOrEmpty(xnP.InnerText) ? String.Empty : xnP.InnerText;
                        break;
                    case "a:DataType": mColumn.DataType = xnP.InnerText;
                        break;
                    case "a:Length": mColumn.Length = String.IsNullOrEmpty(xnP.InnerText) ? 0 : Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Precision": mColumn.Precision = String.IsNullOrEmpty(xnP.InnerText) ? 0 : Convert.ToInt32(xnP.InnerText);
                        break;
                    case "a:Identity": mColumn.Identity = ConvertToBooleanPG(xnP.InnerText);
                        break;
                    case "a:Mandatory": mColumn.NotNull = ConvertToBooleanPG(xnP.InnerText);
                        break;
                }
            }

            return mColumn;
        }

        private PdmKey GetKey(XmlNode xnKey, PdmTable pTable)
        {
            PdmKey mKey = new PdmKey();
            XmlElement xe = (XmlElement)xnKey;
            mKey.PdmID = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:Name": mKey.KeyName = xnP.InnerText;
                        break;
                    case "a:Code": mKey.KeyCode = xnP.InnerText;
                        break;
                    case "c:Key.Columns": InitKeyColumns(xnP, pTable, mKey);
                        break;
                }
            }
            return mKey;
        }

        private void InitKeyColumns(XmlNode xnKeys, PdmTable pTable, PdmKey pKey)
        {
            int i = 1;
            pKey.Columns.Clear();

            foreach (XmlNode xnKey in xnKeys)
            {
                XmlElement xe = (XmlElement)xnKey;
                foreach (PdmColumn column in pTable.Columns)
                {
                    if (column.PdmID == xe.GetAttribute("Ref"))
                    {
                        pKey.AddColumn(column);
                        i++;
                        break;
                    }
                }
            }
        }

        private void InitPrimaryKey(XmlNode xnKeys, PdmTable pTable)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                PdmKey item = GetKey(xnKey, pTable);

                foreach (PdmKey key in pTable.Keys)
                {
                    XmlElement xe = (XmlElement)xnKey;
                    if (key.PdmID == xe.GetAttribute("Ref"))
                    {
                        key.IsPrimary = true;
                        break;
                    }
                }
            }
        }

        private void InitIndexes(XmlNode xnKeys, PdmTable pTable)
        {
            int i = 1;
            pTable.Indexs.Clear();

            foreach (XmlNode xnKey in xnKeys)
            {
                PdmIndex item = GetIndex(xnKey, pTable);
                item.IndexID = i;
                pTable.AddIndex(item);
                i++;
            }
        }

        private PdmIndex GetIndex(XmlNode xnKey, PdmTable pTable)
        {
            PdmIndex mIndex = new PdmIndex();
            XmlElement xe = (XmlElement)xnKey;
            mIndex.PdmID = xe.GetAttribute("Id");
            XmlNodeList xnKProperty = xe.ChildNodes;
            foreach (XmlNode xnP in xnKProperty)
            {
                switch (xnP.Name)
                {
                    case "a:Name": mIndex.IndexName = xnP.InnerText;
                        break;
                    case "a:Code": mIndex.IndexCode = xnP.InnerText;
                        break;
                    case "a:Unique": mIndex.IsUnique = ConvertToBooleanPG(xnP.InnerText);
                        break;
                    case "c:IndexColumns": InitIndexColumns(xnP, pTable, mIndex);
                        break;
                }
            }
            return mIndex;
        }

        private void InitIndexColumns(XmlNode xnKeys, PdmTable pTable, PdmIndex pIndex)
        {
            pIndex.Columns.Clear();

            foreach (XmlNode xnKey in xnKeys)
            {
                XmlElement xe = (XmlElement)xnKey;
                XmlNodeList xnKProperty = xe.ChildNodes;

                foreach (XmlNode xnP in xnKProperty)
                {
                    switch (xnP.Name)
                    {
                        case "c:Column": InitIndexColumn(xnP, pTable, pIndex);
                            break;
                    }
                }
            }
        }

        private void InitIndexColumn(XmlNode xnKeys, PdmTable pTable, PdmIndex pIndex)
        {
            foreach (XmlNode xnKey in xnKeys)
            {
                XmlElement xe = (XmlElement)xnKey;
                foreach (PdmColumn column in pTable.Columns)
                {
                    if (column.PdmID == xe.GetAttribute("Ref"))
                    {
                        pIndex.AddColumn(column);
                        break;
                    }
                }
            }
        }

        public static Boolean ConvertToBooleanPG(Object obj)
        {
            if (obj != null)
            {
                string mStr = obj.ToString();
                mStr = mStr.ToLower();
                if ((mStr.Equals("y") || mStr.Equals("1")) || mStr.Equals("true"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
