// 
// ListStoreBackend.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
// 
// Copyright (c) 2011 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Xwt.Backends;
using Xwt.Drawing;

namespace Xwt.GtkBackend
{
	public class ListStoreBackend: TableStoreBackend, IListStoreBackend
	{
		Type[] columnTypes;
		
		public override Gtk.TreeModel InitializeModel (Type[] columnTypes)
		{
			this.columnTypes = columnTypes;
			return new Gtk.ListStore (columnTypes);
		}
		
		public event EventHandler<ListRowEventArgs> RowInserted;
		public event EventHandler<ListRowEventArgs> RowDeleted;
		public event EventHandler<ListRowEventArgs> RowChanged;
		public event EventHandler<ListRowOrderEventArgs> RowsReordered;

		public Gtk.ListStore List {
			get { return (Gtk.ListStore) Store; }
		}
		
		public object GetValue (int row, int column)
		{
			Gtk.TreeIter it;
			if (!List.IterNthChild (out it, row))
				return null;
			return GetValue (it, column);
		}

		public void SetValue (int row, int column, object value)
		{
			Gtk.TreeIter it;
			if (!List.IterNthChild (out it, row))
				return;
			SetValue (it, column, value);
		}

		public int RowCount {
			get {
				return List.IterNChildren ();
			}
		}
		
		public Type[] ColumnTypes {
			get {
				return columnTypes;
			}
		}
		
		public int AddRow ()
		{
			List.Append ();
			return RowCount - 1;
		}
		
		public int InsertRowAfter (int row)
		{
			List.Insert (row + 1);
			return row + 1;
		}
		
		public int InsertRowBefore (int row)
		{
			List.Insert (row);
			return row;
		}
		
		public void RemoveRow (int row)
		{
			Gtk.TreeIter it;
			if (!List.IterNthChild (out it, row))
				return;
			List.Remove (ref it);
		}
		
		public void EnableEvent (object eventId)
		{
		}
		
		public void DisableEvent (object eventId)
		{
		}
	}
}

