// 
// WindowBackend.cs
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
using Xwt.Engine;
using Efl.Elementary;

namespace Xwt.EflBackend
{
	public class WindowBackend : IWindowBackend
	{
		Efl.Elementary.Window window;
		IWindowFrameEventSink eventSink;
		
		public WindowBackend ()
		{
			
		}

		#region IWindowBackend implementation
		public void SetChild (IWidgetBackend child)
		{
			throw new NotImplementedException ();
		}

		public void SetMainMenu (IMenuBackend menu)
		{
			throw new NotImplementedException ();
		}

		public void SetPadding (double left, double top, double right, double bottom)
		{
			//TODO Correct
			//throw new NotImplementedException ();
		}
		#endregion

		#region IWindowFrameBackend implementation
		public void Initialize (IWindowFrameEventSink eventSink)
		{
			this.eventSink = eventSink;
			window = new Efl.Elementary.Window(null, "window", Elm_Win_Type.ELM_WIN_BASIC);
			window.Show();
		}

		public void Dispose (bool disposing)
		{
			throw new NotImplementedException ();
		}

		public Rectangle Bounds {
			get {	
				int x, y, w, h;
				this.window.GetGeometry(out x, out y, out w, out h);
				
				return new Rectangle(x,y,w,h);
			}
			set {
				this.window.Resize(Convert.ToInt32(value.Width), Convert.ToInt32(value.Height));
				this.window.Move(Convert.ToInt32 (value.X), Convert.ToInt32 ( value.Y));
				Toolkit.Invoke (delegate {
					eventSink.OnBoundsChanged (Bounds);
				});
			}
		}

		public bool Visible {
			get {
				return window.Visible;
			}
			set {
				window.Visible = value;
				if (value)
					window.Show();
			}
		}

		public string Title {
			get {
				return window.Title;
			}
			set {
				window.Title = value;
			}
		}

		public bool Decorated {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool ShowInTaskbar {
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
			//throw new NotImplementedException ();
		}

		public void EnableEvent (object eventId)
		{
			//TODO correct
			//throw .new NotImplementedException ();
		}

		public void DisableEvent (object eventId)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

