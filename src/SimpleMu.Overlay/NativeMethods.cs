using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SimpleMu.Overlay;

internal static class NativeMethods
{
    private const int GWL_EXSTYLE       = -20;
    private const int WS_EX_LAYERED     = 0x80000;
    private const int WS_EX_TRANSPARENT = 0x20;
    private const int WS_EX_APPWINDOW   = 0x00040000;
    private const int WS_EX_TOOLWINDOW  = 0x00000080;

    private static IntPtr GWL_EXSTYLE_CLICKABLE   ;
    private static IntPtr GWL_EXSTYLE_NOT_CLICKABLE;
    
    internal static bool IsClickable { get; private set; }
    
    internal static void InitTransparency(IntPtr handle)
    {
        var windowLongPtr = GetWindowLongPtr(handle, GWL_EXSTYLE).ToInt64();

        //Removing from alt+tab WS_EX_TOOLWINDOW
        windowLongPtr |= WS_EX_TOOLWINDOW;
        windowLongPtr &= ~WS_EX_APPWINDOW;

        GWL_EXSTYLE_CLICKABLE     = new IntPtr(windowLongPtr);
        GWL_EXSTYLE_NOT_CLICKABLE = new IntPtr(windowLongPtr | WS_EX_LAYERED | WS_EX_TRANSPARENT);

        var margins = new Margins(-1, -1, -1, -1);
        DwmExtendFrameIntoClientArea(handle, ref margins);
        
        SetWindowLongPtr(handle, GWL_EXSTYLE, GWL_EXSTYLE_NOT_CLICKABLE);
        IsClickable = false;
    }
    
    internal static void SetWindowClickable(IntPtr handle, bool wantClickable)
    {
        if (!IsClickable && wantClickable)
        {
            SetWindowLongPtr(handle, GWL_EXSTYLE, GWL_EXSTYLE_CLICKABLE);
            SetFocus(handle);
            IsClickable = true;
            //Console.WriteLine("Clickable");
            return;
        }

        if (IsClickable && !wantClickable)
        {
            SetWindowLongPtr(handle, GWL_EXSTYLE, GWL_EXSTYLE_NOT_CLICKABLE);
            IsClickable = false;
            //Console.WriteLine("Not clickable");
        }
    }
    
    internal static Vector2 GetCursorPosition(IntPtr hWnd)
    {
        if (!GetCursorPos(out var lpPoint))
        {
            return Vector2.Zero;
        }

        ScreenToClient(hWnd, ref lpPoint);
        return lpPoint;
    }
    
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out POINT lpPoint);
    
    [DllImport("user32.dll")]
    private static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetFocus(IntPtr hWnd);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
    private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    
    [DllImport("dwmapi.dll")]
    private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct Margins
    {
        internal readonly int _left;
        internal readonly int _right;
        internal readonly int _top;
        internal readonly int _bottom;
        
        internal Margins(int left, int right, int top, int bottom)
        {
            _left = left;
            _right = right;
            _top = top;
            _bottom = bottom;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT p)
        {
            return new Point(p.X, p.Y);
        }

        public static implicit operator Vector2(POINT p)
        {
            return new Vector2(p.X, p.Y);
        }
    }
}