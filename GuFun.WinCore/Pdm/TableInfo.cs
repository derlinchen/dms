using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuFun.WinCore.Pdm
{
    public class TableInfo
    {
        public TableInfo()
        {
        }
        string tableId;

        public string TableId
        {
            get { return tableId; }
            set { tableId = value; }
        }
        string objectID;

        public string ObjectID
        {
            get { return objectID; }
            set { objectID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        int creationDate;

        public int CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        string creator;

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        int modificationDate;

        public int ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }
        string modifier;

        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }
        string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        string physicalOptions;

        public string PhysicalOptions
        {
            get { return physicalOptions; }
            set { physicalOptions = value; }
        }


        IList<ColumnInfo> columns;

        public IList<ColumnInfo> Columns
        {
            get { return columns; }
        }

        IList<KeyInfo> keys;

        public IList<KeyInfo> Keys
        {
            get { return keys; }
        }

        public void AddColumn(ColumnInfo mColumn)
        {
            if (columns == null)
                columns = new List<ColumnInfo>();
            columns.Add(mColumn);
        }

        public void AddKey(KeyInfo mKey)
        {
            if (keys == null)
                keys = new List<KeyInfo>();
            keys.Add(mKey);
        }
    }
}
