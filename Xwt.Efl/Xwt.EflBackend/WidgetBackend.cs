// 
// WidgetBackend.cs
//  
// Author:
//       Andreas Willich <sabotageandi@gmail.com>
// 
// Copyright (c) 2012 Andreas Willich
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
using Efl;
using Efl.Evas;

namespace Xwt.EflBackend
{
	public class WidgetBackend : IWidgetBackend
	{
		protected EvasObject Widget {get;set;}
		protected IWidgetEventSink eventSink;	
		
		
		#region IWidgetBackend implementation
		public void Initialize (IWidgetEventSink eventSink)
		{
			this.eventSink = eventSink;
		}

		public void Dispose (bool disposing)
		{
			EvasObject.Delete(Widget);
		}

		public Point ConvertToScreenCoordinates (Point widgetCoordinates)
		{
			throw new NotImplementedException();	
		}

		public void SetMinSize (double width, double height)
		{
			throw new NotImplementedException ();
		}

		public void SetNaturalSize (double width, double height)
		{
			throw new NotImplementedException ();
		}

		public void SetFocus ()
		{
			throw new NotImplementedException ();
		}

		public void UpdateLayout ()
		{
			throw new NotImplementedException ();
		}

		public WidgetSize GetPreferredWidth ()
		{
			throw new NotImplementedException ();
		}

		public WidgetSize GetPreferredHeightForWidth (double width)
		{
			throw new NotImplementedException ();
		}

		public WidgetSize GetPreferredHeight ()
		{
			throw new NotImplementedException ();
		}

		public WidgetSize GetPreferredWidthForHeight (double height)
		{
			throw new NotImplementedException ();
		}

		public void DragStart (TransferDataSource data, DragDropAction allowedDragActions, object imageBackend, double hotX, double hotY)
		{
			throw new NotImplementedException ();
		}

		public void SetDragSource (string[] types, DragDropAction dragAction)
		{
			throw new NotImplementedException ();
		}

		public void SetDragTarget (string[] types, DragDropAction dragAction)
		{
			throw new NotImplementedException ();
		}

		public bool Visible {
			get {
				return Widget.Visible;
			}
			set {
				Widget.Visible = value;
			}
		}

		public bool Sensitive {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool CanGetFocus {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool HasFocus {
			get {
				throw new NotImplementedException ();
			}
		}

		public Size Size {
			get {
				throw new NotImplementedException ();
			}
		}

		public object NativeWidget {
			get {
				return Widget;
			}
		}

		public object Font {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public Xwt.Drawing.Color BackgroundColor {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public string TooltipText {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		#endregion

		#region IBackend implementation
		public void Initialize (object frontend)
		{
			throw new NotImplementedException ();
		}

		public void EnableEvent (object eventId)
		{
			throw new NotImplementedException ();
		}

		public void DisableEvent (object eventId)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

