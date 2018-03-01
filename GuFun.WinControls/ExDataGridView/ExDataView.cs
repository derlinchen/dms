using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.ComponentModel;
using System.Text;

namespace GuFun.WinControls
{
  public class ExDataView : IBindingListView, IBindingList, IList, ICollection, IEnumerable, ITypedList, ISupportInitializeNotification, ISupportInitialize 
  { 
    readonly DataView parent;    

    readonly ListSortDescription fixedSort; 
    
    public ExDataView(DataTable dataSource, string sortProperty, ListSortDirection sortDirection) 
    {
      if (dataSource == null) 
        throw new ArgumentNullException();

      this.parent = dataSource.DefaultView;

      this._dataSource = dataSource;

      if (!SupportsSorting || !SupportsAdvancedSorting) 
        throw new InvalidOperationException("Advanced sorting is required"); 

      fixedSort = new ListSortDescription(GetItemProperties(null)[sortProperty], sortDirection); 
      RemoveSort(); 
    }

    private DataTable _dataSource; 

    public DataTable DataSource
    {
      get { return _dataSource; }
    }

    #region IBindingListView Members 

    void IBindingListView.ApplySort(ListSortDescriptionCollection sorts) 
    { 
      ListSortDescription[] sortArray = new ListSortDescription[sorts.Count + 1]; 
      sorts.CopyTo(sortArray, 1); 
      sortArray[0] = fixedSort; 
      ApplySort(sortArray); 
    } 

    string IBindingListView.Filter 
    {
      get { return ((IBindingListView)parent).Filter; } 
      set { ((IBindingListView)parent).Filter = value; } 
    } 

    void IBindingListView.RemoveFilter() 
    { 
      ((IBindingListView)parent).RemoveFilter(); 
    } 

    ListSortDescriptionCollection IBindingListView.SortDescriptions 
    { 
      get 
      { 
        ListSortDescriptionCollection sorts = ((IBindingListView)parent).SortDescriptions; 
        
        if (sorts == null || sorts.Count == 0) 
          return sorts; 
        
        ListSortDescription[] sortArray = new ListSortDescription[sorts.Count - 1]; 
        
        for (int i = 1; i < sorts.Count; i++)  
          sortArray[i - 1] = sorts[i]; 

        return new ListSortDescriptionCollection(sortArray); 
      } 
    } 

    /// <summary>
    /// 是否支持高级排序
    /// </summary>
    public bool SupportsAdvancedSorting 
    { 
      get { return ((IBindingListView)parent).SupportsAdvancedSorting; } 
    } 

    bool IBindingListView.SupportsFiltering 
    { 
      get { return ((IBindingListView)parent).SupportsFiltering; } 
    }

    #endregion 

    #region IBindingList Members 

    void IBindingList.AddIndex(PropertyDescriptor property) 
    { 
      ((IBindingList)parent).AddIndex(property); 
    } 

    object IBindingList.AddNew() 
    { 
      return ((IBindingList)parent).AddNew(); 
    } 

    bool IBindingList.AllowEdit 
    { 
      get { return ((IBindingList)parent).AllowEdit; } 
    } 

    bool IBindingList.AllowNew 
    { 
      get { return ((IBindingList)parent).AllowNew; } 
    } 

    bool IBindingList.AllowRemove 
    { 
      get { return ((IBindingList)parent).AllowRemove; } 
    } 

    void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) 
    { 
      ApplySort(fixedSort, new ListSortDescription(property, direction)); 
    }
 
    void ApplySort(params ListSortDescription[] sorts) 
    { 
      ((IBindingListView)parent).ApplySort(new ListSortDescriptionCollection(sorts)); 
    } 

    int IBindingList.Find(PropertyDescriptor property, object key) 
    { 
      return ((IBindingList)parent).Find(property, key); 
    } 

    public bool IsSorted 
    { 
      get { return ((IBindingList)parent).IsSorted && ((IBindingListView)parent).SortDescriptions.Count > 1; } 
    } 

    event ListChangedEventHandler IBindingList.ListChanged 
    { 
      add { ((IBindingList)parent).ListChanged += value; } 
      remove { ((IBindingList)parent).ListChanged -= value; } 
    } 

    void IBindingList.RemoveIndex(PropertyDescriptor property) 
    { 
      ((IBindingList)parent).RemoveIndex(property); 
    } 

    public void RemoveSort() 
    { 
      ApplySort(fixedSort); 
    } 

    ListSortDirection IBindingList.SortDirection 
    {
      get
      {
        if (IsSorted)
          return ((IBindingListView)parent).SortDescriptions[1].SortDirection;
        else
          return ListSortDirection.Ascending;
      }    
    } 

    PropertyDescriptor IBindingList.SortProperty 
    { 
      get 
      { 
        if (IsSorted) 
          return ((IBindingListView)parent).SortDescriptions[1].PropertyDescriptor; 
        else
          return null; 
      } 
    } 

    bool IBindingList.SupportsChangeNotification 
    { 
      get { return ((IBindingList)parent).SupportsChangeNotification; } 
    } 

    bool IBindingList.SupportsSearching 
    { 
      get { return ((IBindingList)parent).SupportsSearching; } 
    } 

    /// <summary>
    /// 是否支持排序
    /// </summary>
    public bool SupportsSorting 
    {
      get { return ((IBindingList)parent).SupportsSorting; } 
    }

    #endregion 

    #region IList Members 
    
    int System.Collections.IList.Add(object value) 
    { 
      return ((IList)parent).Add(value); 
    } 

    void System.Collections.IList.Clear() 
    { 
      ((IList)parent).Clear(); 
    } 

    bool System.Collections.IList.Contains(object value) 
    { 
      return ((IList)parent).Contains(value); 
    } 

    int System.Collections.IList.IndexOf(object value) 
    { 
      return ((IList)parent).IndexOf(value); 
    } 
  
    void System.Collections.IList.Insert(int index, object value) 
    { 
      ((IList)parent).Insert(index, value); 
    } 

    bool System.Collections.IList.IsFixedSize 
    { 
      get { return ((IList)parent).IsFixedSize; } 
    } 

    bool System.Collections.IList.IsReadOnly 
    { 
      get { return ((IList)parent).IsReadOnly; } 
    }
    
    void System.Collections.IList.Remove(object value) 
    { 
      ((IList)parent).Remove(value); 
    } 

    void System.Collections.IList.RemoveAt(int index) 
    { 
      ((IList)parent).RemoveAt(index); 
    } 

    object System.Collections.IList.this[int index] 
    { 
      get { return ((IList)parent)[index]; } 
      set { ((IList)parent)[index] = value; } 
    } 

    #endregion 

    #region ICollection Members 

    void System.Collections.ICollection.CopyTo(Array array, int index) 
    { 
      ((ICollection)parent).CopyTo(array, index); 
    }
    
    int System.Collections.ICollection.Count 
    { 
      get { return ((ICollection)parent).Count; } 
    } 

    bool System.Collections.ICollection.IsSynchronized 
    { 
      get { return ((ICollection)parent).IsSynchronized; } 
    } 

    object System.Collections.ICollection.SyncRoot 
    { 
      get { return ((ICollection)parent).SyncRoot; } 
    } 

    #endregion 

    #region IEnumerable Members 

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() 
    { 
      return ((IEnumerable)parent).GetEnumerator(); 
    }
  
    #endregion 

    #region ITypedList Members 

    PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors) 
    { 
      return GetItemProperties(listAccessors); 
    } 
    
    private PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors) 
    { 
      return ((ITypedList)parent).GetItemProperties(listAccessors); 
    }
    
    string ITypedList.GetListName(PropertyDescriptor[] listAccessors) 
    { 
      return ((ITypedList)parent).GetListName(listAccessors); 
    }

    #endregion 

    #region ISupportInitializeNotification Members 

    event EventHandler ISupportInitializeNotification.Initialized 
    { 
      add { ((ISupportInitializeNotification)parent).Initialized += value; } 
      remove { ((ISupportInitializeNotification)parent).Initialized -= value; } 
    } 

    bool ISupportInitializeNotification.IsInitialized 
    { 
      get { return ((ISupportInitializeNotification)parent).IsInitialized; } 
    }

    #endregion 

    #region ISupportInitialize Members 

    void ISupportInitialize.BeginInit() 
    { 
      ((ISupportInitialize)parent).BeginInit(); 
    }
    
    void ISupportInitialize.EndInit() 
    { 
      ((ISupportInitialize)parent).EndInit(); 
    }

    #endregion 
    
  }
}
