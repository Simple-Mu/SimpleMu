using Silk.NET.GLFW;
using Silk.NET.OpenGL;

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
                glfw.SetWindowTitle(WindowHandle, value);
                _title = value;
            }
        }
    }

    public unsafe void Focus()
    {
        glfw.FocusWindow(WindowHandle);
    }

    internal unsafe WindowHandle*   WindowHandle;
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
    
    private static Glfw glfw = Glfw.GetApi();
    private static GL   gl;

    //Creates windows and starts render thread
    private unsafe void StartRenderThread()
    {
        glfw.Init();
        glfw.SetErrorCallback((error, description) => Console.WriteLine($"GLFW Error({error}): {description}"));

        //Window hints
        glfw.WindowHint(WindowHintBool.TransparentFramebuffer, true);
        glfw.WindowHint(WindowHintBool.Decorated,              false);
        glfw.WindowHint(WindowHintBool.Focused,                true);
        glfw.WindowHint(WindowHintBool.Visible,                false);
        glfw.WindowHint(WindowHintBool.Resizable,              false);
        glfw.WindowHint(WindowHintBool.Floating,               true);

        //Configuring OpenGL
        glfw.WindowHint(WindowHintClientApi.ClientApi,         ClientApi.OpenGL);
        glfw.WindowHint(WindowHintInt.ContextVersionMajor,     4);
        glfw.WindowHint(WindowHintInt.ContextVersionMinor,     0);
        glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile, OpenGlProfile.Any);
        glfw.WindowHint(WindowHintBool.OpenGLForwardCompat,    true);
        glfw.WindowHint(WindowHintBool.OpenGLDebugContext,     true);

        //Configuring Monitor
        var primaryMonitor = glfw.GetPrimaryMonitor();
        var videoMode      = glfw.GetVideoMode(primaryMonitor);

        glfw.WindowHint(WindowHintInt.RedBits,     videoMode->RedBits);
        glfw.WindowHint(WindowHintInt.GreenBits,   videoMode->GreenBits);
        glfw.WindowHint(WindowHintInt.BlueBits,    videoMode->BlueBits);
        glfw.WindowHint(WindowHintInt.RefreshRate, videoMode->RefreshRate);

        Width = videoMode->Width;
        Height= videoMode->Height - 1;

        //Create window
        WindowHandle = glfw.CreateWindow(Width, Height, _title, null, null);

        //Creates OpenGL context and IMGUI
        glfw.MakeContextCurrent(WindowHandle);
        var context = new GlfwContext(glfw, WindowHandle);
        gl = GL.GetApi(context);
        //GL.LoadBindings(provider);
        //_imGuiController = new ImGuiController(Width, Height);
        
        LoadAssets();
        
        //VSync ON
        glfw.SwapInterval(1);
        
        //Show window
        glfw.ShowWindow(WindowHandle);
        NativeMethods.InitTransparency(WindowHandle);

        //Input
        //glfw.SetKeyCallback(WindowHandle, OnKey);
        //glfw.SetMouseButtonCallback(WindowHandle, OnMouseButton);
        //glfw.SetScrollCallback(WindowHandle, OnScroll);
        
        PostStart();
        
        //Render loop
        while (!glfw.WindowShouldClose(WindowHandle))
        {
            glfw.PollEvents();
            //_imGuiController.Update(this, 1f);
            Frame();
            //_imGuiController.Render();
            glfw.SwapBuffers(WindowHandle);

            if (glfw.GetKey(WindowHandle, Keys.Escape) == (int)InputAction.Press)
            {
                glfw.SetWindowShouldClose(WindowHandle, true);
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
        gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
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
}