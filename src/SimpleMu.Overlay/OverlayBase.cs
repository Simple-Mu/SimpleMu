using Windows.Win32.Foundation;
using Windows.Win32.UI.Controls;
using Windows.Win32.UI.WindowsAndMessaging;
using Silk.NET.GLFW;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using static Windows.Win32.PInvoke;

namespace SimpleMu.Overlay;

public abstract class OverlayBase
{
    private string _title = "test";
    public string Title
    {
        get => _title;
        set
        {
            unsafe
            {
                _glfw.SetWindowTitle(GlfwWindow, value);
                _title = value;
            }
        }
    }

    public unsafe void Focus()
    {
        _glfw.FocusWindow(GlfwWindow);
    }

    internal unsafe WindowHandle*   GlfwWindow;
    internal HWND           Win32Window;
    //private         ImGuiController _imGuiController;

    public void Start()
    {
        var renderThread = new Thread(StartRenderThread)
        {
            IsBackground = true
        };
        
        renderThread.Start();
    }

    public virtual void PostStart()
    {
        
    }
    
    public int Width { get; set; }
    public int Height { get; set; }
    
    private static Glfw _glfw = Glfw.GetApi();
    private static GL   gl;

    //Creates windows and starts render thread
    private unsafe void StartRenderThread()
    {
        _glfw.Init();
        _glfw.SetErrorCallback((error, description) => Console.WriteLine($"GLFW Error({error}): {description}"));

        //Window hints
        _glfw.WindowHint(WindowHintBool.TransparentFramebuffer, true);
        _glfw.WindowHint(WindowHintBool.Decorated,              false);
        _glfw.WindowHint(WindowHintBool.Focused,                true);
        _glfw.WindowHint(WindowHintBool.Visible,                false);
        _glfw.WindowHint(WindowHintBool.Resizable,              false);
        _glfw.WindowHint(WindowHintBool.Floating,               true);

        //Configuring OpenGL
        _glfw.WindowHint(WindowHintClientApi.ClientApi,         ClientApi.OpenGL);
        _glfw.WindowHint(WindowHintInt.ContextVersionMajor,     4);
        _glfw.WindowHint(WindowHintInt.ContextVersionMinor,     0);
        _glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, OpenGlProfile.Any);
        _glfw.WindowHint(WindowHintBool.OpenGLForwardCompat,    true);
        _glfw.WindowHint(WindowHintBool.OpenGLDebugContext,     true);

        //Configuring Monitor
        var primaryMonitor = _glfw.GetPrimaryMonitor();
        var videoMode      = _glfw.GetVideoMode(primaryMonitor);

        _glfw.WindowHint(WindowHintInt.RedBits,     videoMode->RedBits);
        _glfw.WindowHint(WindowHintInt.GreenBits,   videoMode->GreenBits);
        _glfw.WindowHint(WindowHintInt.BlueBits,    videoMode->BlueBits);
        _glfw.WindowHint(WindowHintInt.RefreshRate, videoMode->RefreshRate);

        Width = videoMode->Width;
        Height= videoMode->Height - 1;

        //Create window
        GlfwWindow = _glfw.CreateWindow(Width, Height, _title, null, null);

        //Creates OpenGL context and IMGUI
        _glfw.MakeContextCurrent(GlfwWindow);
        var context = new GlfwContext(_glfw, GlfwWindow);
        gl = GL.GetApi(context);
        //_imGuiController = new ImGuiController(Width, Height);
        
        LoadAssets();
        
        //VSync ON
        _glfw.SwapInterval(1);
        
        //Show window
        _glfw.ShowWindow(GlfwWindow);
        Win32Window = FindWindow(null, _title);
        InitTransparency(Win32Window);

        //Input
        //glfw.SetKeyCallback(WindowHandle, OnKey);
        //glfw.SetMouseButtonCallback(WindowHandle, OnMouseButton);
        //glfw.SetScrollCallback(WindowHandle, OnScroll);
        
        PostStart();
        
        //Render loop
        while (!_glfw.WindowShouldClose(GlfwWindow))
        {
            _glfw.PollEvents();
            //_imGuiController.Update(this, 1f);
            Frame();
            //_imGuiController.Render();
            _glfw.SwapBuffers(GlfwWindow);

            if (_glfw.GetKey(GlfwWindow, Keys.Escape) == (int)InputAction.Press)
            {
                _glfw.SetWindowShouldClose(GlfwWindow, true);
            }
        }
    }

    public void LoadAssets()
    {

    }

    private const uint ClearCommand = (uint) ClearBufferMask.ColorBufferBit | (uint) ClearBufferMask.DepthBufferBit;

    public virtual void Frame()
    {
        gl.Clear(ClearCommand);
        gl.ClearColor(0.1f, 0.0f, 0.0f, 0.0f);
    }

    /*public MouseState MouseState { get; } = new();
    public KeyboardState KeyboardState { get; } = new();
    
    private unsafe void OnMouseButton(Window* window, MouseButton button, InputAction action, KeyModifiers mods)
    {
        switch (button)
        {
            case MouseButton.Left:
                MouseState.LeftButton = action == InputAction.Press;
                break;
            case MouseButton.Right:
                MouseState.RightButton = action == InputAction.Press;
                break;
            case MouseButton.Middle:
                MouseState.MiddleButton = action == InputAction.Press;
                break;
        }
    }
    
    private unsafe void OnScroll(Window* window, double offsetx, double offsety)
    {
        _imGuiController.MouseScroll(new Vector2((float)offsetx, (float)offsety));
    }

    private unsafe void OnKey(Window* window, Keys key, int scancode, InputAction action, KeyModifiers mods)
    {
        KeyboardState.SetKey(key, action is InputAction.Press or InputAction.Repeat);
        _imGuiController.PressChar((char)scancode);
    }*/
    
    private static int _gwlClickable   ;
    private static int _gwlNotClickable;
    
    internal static bool IsClickable { get; private set; }
    
    internal static void InitTransparency(HWND handle)
    {
        var windowLong = (WINDOW_EX_STYLE)GetWindowLong(handle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE);
        
        windowLong |= WINDOW_EX_STYLE.WS_EX_TOOLWINDOW;
        windowLong &= ~WINDOW_EX_STYLE.WS_EX_APPWINDOW;

        _gwlClickable    = (int)windowLong;
        _gwlNotClickable = (int)(windowLong | WINDOW_EX_STYLE.WS_EX_LAYERED | WINDOW_EX_STYLE.WS_EX_TRANSPARENT);

        var margins = new MARGINS
        {
            cxLeftWidth    = -1,
            cxRightWidth   = -1,
            cyBottomHeight = -1,
            cyTopHeight    = -1
        };
        
        DwmExtendFrameIntoClientArea(handle, margins);
        
        //SetWindowLongPtr(handle, GWL_EXSTYLE, GWL_EXSTYLE_NOT_CLICKABLE);
        SetWindowLong(handle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, _gwlNotClickable);
        IsClickable = false;
    }
    
    internal static void SetWindowClickable(HWND handle, bool wantClickable)
    {
        if (!IsClickable && wantClickable)
        {
            SetWindowLong(handle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, _gwlClickable);
            SetFocus(handle);
            IsClickable = true;
            //Console.WriteLine("Clickable");
            return;
        }

        if (IsClickable && !wantClickable)
        {
            SetWindowLong(handle, WINDOW_LONG_PTR_INDEX.GWL_EXSTYLE, _gwlNotClickable);
            IsClickable = false;
            //Console.WriteLine("Not clickable");
        }
    }
    
    internal static Vector2D<int> GetCursorPosition(HWND hWnd)
    {
        if (!GetCursorPos(out var lpPoint))
        {
            return Vector2D<int>.Zero;
        }

        ScreenToClient(hWnd, ref lpPoint);
        var point = new Vector2D<int>(lpPoint.x, lpPoint.y);
        return point;
    }
}