using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace vbAccelerator.Components.Win32
{

	/// <summary>
	/// Enumerated flag values for the mouse gestures supported by 
	/// the MouseGesture class.
	/// </summary>
	[FlagsAttribute()]
	public enum MouseGestureTypes : int
	{
		/// <summary>
		/// No mouse gesture.
		/// </summary>
		NoGesture = 0x0,
		/// <summary>
		/// Mouse Gesture move north
		/// </summary>
		NorthGesture = 0x1,
		/// <summary>
		/// Mouse Gesture move south
		/// </summary>
		SouthGesture = 0x2,
		/// <summary>
		/// Mouse Gesture move east
		/// </summary>
		EastGesture = 0x4,
		/// <summary>
		/// Mouse Gesture move west
		/// </summary>
		WestGesture = 0x8,
		/// <summary>
		/// Mouse Gesture move north-east
		/// </summary>
		NorthThenEastGesture = 0x10,
		/// <summary>
		/// Mouse Gesture move south-east
		/// </summary>
		SouthThenEastGesture = 0x20,
		/// <summary>
		/// Mouse Gesture move south-west
		/// </summary>
		SouthThenWestGesture = 0x40,
		/// <summary>
		/// Mouse Gesture move north-west
		/// </summary>		
		NorthThenWestGesture = 0x80,
		/// <summary>
		/// Mouse Gesture move north-east
		/// </summary>
		EastThenNorthGesture = 0x100,
		/// <summary>
		/// Mouse Gesture move south-east
		/// </summary>
		EastThenSouthGesture = 0x200,
		/// <summary>
		/// Mouse Gesture move south-west
		/// </summary>
		WestThenSouthGesture = 0x400,
		/// <summary>
		/// Mouse Gesture move north-west
		/// </summary>		
		WestThenNorthGesture = 0x800,
		/// <summary>
		/// All mouse gestures
		/// </summary>
		AllGestureTypes = 0xFFF
	}

	/// <summary>
	/// Holds the arguments for a gesture event.  The <c>acceptGesture</c>
	/// property is used to tell the class which raises the message whether
	/// the consuming application acknowledged the gesture and therefore to 
	/// cancel the right mouse up event.
	/// </summary>
	public class MouseGestureEventArgs : EventArgs
	{
		private MouseGestureTypes gestureType;
		private Point gestureStartPosition;
		private Point gestureEndPosition;
		private bool acceptGesture;

		/// <summary>
		/// Gets the gesture type.
		/// </summary>
		public MouseGestureTypes GestureType
		{
			get
			{
				return this.gestureType;
			}
		}

		/// <summary>
		/// Gets the mouse location for the point at which the gesture
		/// was started, relative to the screen.
		/// </summary>
		public Point GestureStartPosition
		{
			get
			{
				return this.gestureStartPosition;
			}
		}

		/// <summary>
		/// Gets the mouse location for the point at which the gesture
		/// was ended, relative to the screen.
		/// </summary>
		public Point GestureEndPosition
		{
			get
			{
				return this.gestureEndPosition;
			}
		}

		/// <summary>
		/// Gets/sets whether the gesture has been processed by the 
		/// application.  By default, gestures are presumed to be unaccepted,
		/// in which case the standard right mouse up behaviour will be 
		/// activated.  By setting this property to <c>true</c> the right
		/// mouse up is filtered and the application can process the gesture.
		/// </summary>
		public bool AcceptGesture
		{
			get
			{
				return this.acceptGesture;
			}
			set
			{
				this.acceptGesture = value;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="gestureType">Type of gesture which was detected</param>
		/// <param name="gestureStartPosition">Position of mouse relative to screen when gesture
		/// was started</param>
		/// <param name="gestureEndPosition">Position of mouse relative to screen when gesture
		/// was completed</param>
		public MouseGestureEventArgs(
				MouseGestureTypes gestureType,
				Point gestureStartPosition,
				Point gestureEndPosition
			)
		{
			this.gestureType = gestureType;
			this.gestureStartPosition = gestureStartPosition;
			this.gestureEndPosition = gestureEndPosition;
			this.acceptGesture = false;
		}
	}

	/// <summary>
	/// Represents the method which handles the <c>MouseGesture</c> event
	/// raised by the <c>MouseGestureFilter</c> class.
	/// </summary>
	public delegate void MouseGestureEventHandler(object sender, MouseGestureEventArgs args);

	/// <summary>
	/// A Windows Message Loop filter which enables mouse gestures to 
	/// be detected over any control or window.
	/// </summary>
	/// <remarks>Controls which perform processing on Right Mouse
	/// Down (rather than the standard Right Mouse Up) will still
	/// perform the right mouse action regardless of whether a gesture
	/// is made.</remarks>
	public class MouseGestureFilter : IMessageFilter
	{
		/// <summary>
		/// 
		/// </summary>
		public event MouseGestureEventHandler MouseGesture;

		[DllImport("user32", CharSet = CharSet.Auto)]
		private extern static int PostMessage (
			IntPtr hwnd, 
			int wMsg, 
			int wParam, 
			int lParam);

		private const int WM_ACTIVATE = 0x6;
		private const int WM_RBUTTONDOWN = 0x204;
		private const int WM_MOUSEMOVE = 0x200;
		private const int WM_RBUTTONUP = 0x205;

		/// <summary>
		/// The default absolute number of pixels the mouse must travel
		/// in any direction for the gesture to be acknowledged.
		/// </summary>
		private const int DEFAULT_HYSTERESIS_PIXELS = 8;

		/// <summary>
		/// How far does the mouse have to move before it is 
		/// interpreted as a gesture?
		/// </summary>
		protected int hysteresis = DEFAULT_HYSTERESIS_PIXELS;
		/// <summary>
		/// The configured mouse gesture types
		/// </summary>
		private MouseGestureTypes gestureTypes = MouseGestureTypes.NoGesture;
		/// <summary>
		/// Whether we are checking for a gesture or not.
		/// </summary>
		private bool checkingGesture = false;
		/// <summary>
		/// The recorded mouse gesture during gesture checking
		/// </summary>
		private MouseGestureTypes recordedGesture = MouseGestureTypes.NoGesture;
		/// <summary>
		/// <c>ArrayList</c> of mouse points recorded during gesture.
		/// </summary>
		private ArrayList gesture = null;
		
		
		/// <summary>
		/// Gets/sets the mouse gesture types to look for.
		/// </summary>
		public MouseGestureTypes GestureTypes
		{
			get
			{
				return this.gestureTypes;
			}
			set
			{
				this.gestureTypes = value;
			}
		}

		
		/// <summary>
		/// Prefilters all application messages to check whether
		/// the message is a gesture or not.
		/// </summary>
		/// <param name="m">The Windows message to prefilter</param>
		/// <returns><c>true</c> if the message should be filtered (was a 
		/// processed gesture), <c>false</c> otherwise.</returns>
		public bool PreFilterMessage(
			ref Message m
			)
		{
			bool retValue = false;

			if (this.gestureTypes > 0)
			{
				if (this.checkingGesture)
				{
					if (m.Msg == WM_MOUSEMOVE)
					{
						AddToMouseGesture();
					}
					else if (m.Msg == WM_RBUTTONUP)
					{
						retValue = EndMouseGesture();
						if (retValue)
						{
							// Windows will skip the next mouse down if we consume
							// a mouse up.  m cannot be modified, despite being byref,
							// so post a new one to a location which is offscreen:
							int offScreen = 0x7fff7fff;
							PostMessage(m.HWnd, WM_RBUTTONUP, (int)m.WParam, offScreen);
						}
					}
					else if (m.Msg == WM_ACTIVATE)
					{
						this.checkingGesture = false;				
					}
				}
				else if (m.Msg == WM_RBUTTONDOWN)
				{
					BeginMouseGesture();
				}
			}
			return retValue;
		}

		/// <summary>
		/// 
		/// </summary>
		private void BeginMouseGesture()
		{
			
            gesture = new ArrayList();
			gesture.Add(Cursor.Position);
			this.checkingGesture = true;
		}

		/// <summary>
		/// 
		/// </summary>
		private void AddToMouseGesture()
		{
			gesture.Add(Cursor.Position);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool EndMouseGesture()
		{
			this.checkingGesture = false;

			bool retValue = false;

			// add the end point:
			gesture.Add(Cursor.Position);

			// get start and end:
			Point first = (Point) gesture[0];
			Point last = (Point) gesture[gesture.Count - 1];

			// check which directions we register a change in:
			int xDiff = first.X - last.X;
			int yDiff = first.Y - last.Y;

			bool north, south, east, west;
			north = south = east = west = false;

			if (Math.Abs(yDiff) > DEFAULT_HYSTERESIS_PIXELS)
			{
				north = (yDiff > 0);
				south = !north;
			}
			if (Math.Abs(xDiff) > DEFAULT_HYSTERESIS_PIXELS)
			{
				west = (xDiff > 0);
				east = !west;
			}
			// check for very narrow angles as these are probably not compound gestures
			if ((north || south) && (east || west))
			{
				if (Math.Abs(xDiff) > Math.Abs(yDiff))
				{
					if ((Math.Abs(xDiff) / (Math.Abs(yDiff) * 1.0)) > 7.0)
					{
						north = south = false;
					}
				}
				else
				{
					if ((Math.Abs(yDiff) / (Math.Abs(xDiff) * 1.0)) > 7.0)
					{
						east = west = false;
					}
				}
			}

			recordedGesture = MouseGestureTypes.NoGesture;

			if (north || south) 
			{
				if (east || west)
				{
					// compound gesture:
					recordedGesture = interpretCompoundGesture(first, last, north, south, east, west);
				}
				else
				{
					// pure vertical gesture:
					if (north)
					{
						recordedGesture = MouseGestureTypes.NorthGesture;
					}
					else
					{
						recordedGesture = MouseGestureTypes.SouthGesture;
					}
				}
			}
			else if (east || west)
			{
				// pure horizontal gesture
				if (east)
				{
					recordedGesture = MouseGestureTypes.EastGesture;
				}
				else
				{
					recordedGesture = MouseGestureTypes.WestGesture;
				}
			}

			if (recordedGesture != MouseGestureTypes.NoGesture)
			{				
				if ((gestureTypes & recordedGesture) != 0)
				{
					MouseGestureEventArgs args = new MouseGestureEventArgs(
						recordedGesture, first, last);
					if (this.MouseGesture != null)
					{
						this.MouseGesture(this, args);
						retValue = args.AcceptGesture;
					}
				}			
			}

			return retValue;
		}

		private MouseGestureTypes interpretCompoundGesture(
			Point first, Point last,
			bool north, bool south, bool east, bool west)
		{
			MouseGestureTypes retValue = MouseGestureTypes.NoGesture;

			// draw a diagonal line between start & end
			// and determine if most points are y above 
			// the line or not:
			int pointAbove = 0;
			int pointBelow = 0;
			
			foreach (Point point in gesture)
			{
				int diagY = ((point.X - first.X) * (first.Y - last.Y)) / (first.X - last.X) + first.Y;
				if (point.Y > diagY)
				{
					pointAbove++;
				}
				else
				{
					pointBelow++;
				}
			}

			if (north)
			{
				if (east)
				{
					if (pointAbove > pointBelow)
					{
						retValue = MouseGestureTypes.EastThenNorthGesture;
					}
					else
					{
						retValue = MouseGestureTypes.NorthThenEastGesture;
					}
				}
				else
				{
					if (pointAbove > pointBelow)
					{
						retValue = MouseGestureTypes.WestThenNorthGesture;
					}
					else
					{
						retValue = MouseGestureTypes.NorthThenWestGesture;
					}

				}
			}
			else if (south)
			{
				if (east)
				{
					if (pointAbove > pointBelow)
					{
						retValue = MouseGestureTypes.SouthThenEastGesture;
					}
					else
					{
						retValue = MouseGestureTypes.EastThenSouthGesture;
					}
				}
				else
				{
					if (pointAbove > pointBelow)
					{
						retValue = MouseGestureTypes.SouthThenWestGesture;
					}
					else
					{
						retValue = MouseGestureTypes.WestThenSouthGesture;
					}
				}
			}

			return retValue;
		}


		/// <summary>
		/// Constructs a default instance of this class.  The class
		/// checks for all <c>MouseGestureTypes</c>.
		/// </summary>		 
		public MouseGestureFilter()
		{
			this.gestureTypes =  MouseGestureTypes.AllGestureTypes;
		}

		/// <summary>
		/// Constructs a new instance of this class and starts checking for
		/// the specified mouse gestures.
		/// </summary>
		/// <param name="gestureTypes"></param>
		public MouseGestureFilter(MouseGestureTypes gestureTypes)
		{
			this.gestureTypes = gestureTypes;
		}

	}
}
