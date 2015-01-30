//==================================================================
// C# OpenGL Framework (http://www.csharpopenglframework.com)
// Copyright (c) 2005-2006 devDept (http://www.devdept.com)
// All rights reserved.
//
// For more information on this program, please visit: 
// http://www.csharpopenglframework.com
//
// For licensing information, please visit: 
// http://www.csharpopenglframework.com/licensing.html
//==================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Collections;
using System.Globalization;

namespace openglFramework
{
    public partial class OpenGLControl : UserControl
    {

        protected Context renderingContext;
        public ArrayList entities = new ArrayList();
        public ArrayList labels   = new ArrayList();

        // Lights Settings
        float[] ambientLight        = {0.10f, 0.10f, 0.10f, 1.00f};
        float[] mainLightDiffuse    = {0.75f, 0.75f, 0.75f, 1.00f};
        float[] sideLightDiffuse    = {0.20f, 0.20f, 0.20f, 1.00f};

        float[] mainLightPos        = { -50.0f, +150.0f, +100.0f, 0.0f};	// x z y
        float[] sideLightPos        = {+100.0f,  -50.0f, +100.0f, 0.0f};	// x z y

        float[] specular            = {0.75f, 0.75f, 0.75f, 1.00f};
        float[] specref             = {1.00f, 1.00f, 1.00f, 1.00f};

        // Focus
        bool hasFocus = false;

        // Model extents
        protected float[] globalMin = new float[3];
        protected float[] globalMax = new float[3];

        // Model size
        protected float xSize;
        protected float ySize;
        protected float zSize;

        protected static float openglVersion;
        protected int stencilBits;
        protected bool lighting;
        protected bool heavyModel = false;

        // bounding rectangle (parallel projection)
        protected float globalLeft;
        protected float globalBottom;
        protected float globalRight;
        protected float globalTop;

        // true zooming TM
        protected RectangleF viewportRect, prevZoomRect, zoomRect;
        protected bool firstRedraw = true;


        public OpenGLControl()
        {

            InitializeStyles();
            InitializeComponent();

            backgroundTopColor      = Color.FromArgb(0xff, 0x9e, 0x9b, 0x92);
            backgroundBottomColor   = Color.FromArgb(0xff, 0xe3, 0xe1, 0xd4);

            renderingContext    = new Context(this, 32, 16, 8);
            OpenGLSetup();

            zoomCursor          = new Cursor(GetType(), "zoom.cur");
            panCursor           = new Cursor(GetType(), "pan.cur");
            rotateCursor        = new Cursor(GetType(), "rotate.cur");

            xUcsLabel           = new Label("X");
            yUcsLabel           = new Label("Y");
            zUcsLabel           = new Label("Z");
            originLabel         = new Label("Origin");

            cameraQuat          = new Quaternion(0, 0, 0, 1.0f);

            entities            = new ArrayList();

            openglVersion       = GetOpenGLVersion();

            int[] stencil       = new int[1];
            gl.GetIntegerv(gl.STENCIL_BITS, stencil);

            stencilBits = stencil[0];

            Console.WriteLine("Version      : " + gl.GetString(gl.VERSION));
            Console.WriteLine("Renderer     : " + gl.GetString(gl.RENDERER));
            Console.WriteLine("Vendor       : " + gl.GetString(gl.VENDOR));
            Console.WriteLine("Stencil bits : " + stencilBits);

            //zoomRect.X = 10;
            //zoomRect.Y = 10;
            //zoomRect.Width = 600;
            //zoomRect.Height = 600;

        }


        #region Properties

        public shadingType ShadingMode
        {
            get { return renderMode; }
            set {

                renderMode = value;

                
            
                }
        }

        public projectionType ProjectionMode
        {
            get { return projectionMode; }
            set {
                projectionMode = value;
                Invalidate();
            }
        }

        public float FieldOfView
        {
            get { return fieldOfView; }
            set { 
                fieldOfView = value;
                Invalidate();
            }
        }

        

        public static float OpenglVersion
        {
            get { return OpenGLControl.openglVersion; }
        }

        [CategoryAttribute("Lighting")]
        public float[] AmbientLight
        {
            get { return ambientLight; }
            set
            {
                ambientLight = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Lighting")]
        public float[] MainLightDiffuse
        {
            get { return mainLightDiffuse; }
            set
            {
                mainLightDiffuse = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Lighting")]
        public float[] SideLightDiffuse
        {
            get { return sideLightDiffuse; }
            set
            {
                sideLightDiffuse = value;
                Invalidate();

            }
        }

        public bool HeavyModel
        {
            get { return heavyModel; }

        }
        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {

            if (this.DesignMode)
            {

                e.Graphics.Clear(this.BackColor);

                e.Graphics.Flush();

                return;

            }

            if (renderingContext.DC == 0 || renderingContext.RC == 0)
            {
             
                MessageBox.Show("No device or rendering context available!");
                return;

            }

            base.OnPaint(e);

            int errorCode = gl.NO_ERROR;                             // The GL error code

            errorCode = gl.GetError();

            if (errorCode != gl.NO_ERROR)
            {
                switch (errorCode)
                {
                    case gl.INVALID_ENUM:
                        MessageBox.Show("GL_INVALID_ENUM - An unacceptable value has been specified for an enumerated argument.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.INVALID_VALUE:
                        MessageBox.Show("GL_INVALID_VALUE - A numeric argument is out of range.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.INVALID_OPERATION:
                        MessageBox.Show("GL_INVALID_OPERATION - The specified operation is not allowed in the current state.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.STACK_OVERFLOW:
                        MessageBox.Show("GL_STACK_OVERFLOW - This function would cause a stack overflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.STACK_UNDERFLOW:
                        MessageBox.Show("GL_STACK_UNDERFLOW - This function would cause a stack underflow.  The offending function has been ignored.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    case gl.OUT_OF_MEMORY:
                        MessageBox.Show("GL_OUT_OF_MEMORY - There is not enough memory left to execute the function.  The state of OpenGL has been left undefined.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Unknown GL error.  This should never happen.", "OpenGL Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }

            }
            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        #endregion

        #region Setup

        protected virtual void OpenGLSetup()
        {

            gl.ClearColor(1, 1, 1, 1); 
            gl.ShadeModel(gl.SMOOTH);
            gl.FrontFace(gl.CCW);

            // Correct illumination of the inside of the model
            gl.LightModeli(gl.LIGHT_MODEL_TWO_SIDE, (BackFaceCulling == false) ? gl.TRUE : gl.FALSE);

            // Setup and enable main light
            gl.Lightfv(gl.LIGHT0,  gl.AMBIENT, ambientLight);
            gl.Lightfv(gl.LIGHT0,  gl.DIFFUSE, mainLightDiffuse);
            gl.Lightfv(gl.LIGHT0, gl.SPECULAR, specular);
            gl.Lightfv(gl.LIGHT0, gl.POSITION, mainLightPos);
            gl.Enable( gl.LIGHT0);

            // Setup and enable side light
            gl.Lightfv(gl.LIGHT1,  gl.AMBIENT, ambientLight);
            gl.Lightfv(gl.LIGHT1,  gl.DIFFUSE, sideLightDiffuse);
            gl.Lightfv(gl.LIGHT1, gl.POSITION, sideLightPos);
            gl.Enable( gl.LIGHT1);

            // Enable color tracking
            gl.Enable(gl.COLOR_MATERIAL);

            // Set Material properties to follow glColor values
            gl.ColorMaterial(gl.FRONT_AND_BACK, gl.AMBIENT_AND_DIFFUSE);

            // All materials hereafter have full specular reflectivity
            // with a high shine
            gl.Materialfv(gl.FRONT,  gl.SPECULAR, specref);
            gl.Materiali (gl.FRONT, gl.SHININESS, 128);


            FontMapping();

            quadric = glu.NewQuadric();

            glu.QuadricDrawStyle(quadric, glu.FILL);
            glu.QuadricNormals  (quadric, gl.SMOOTH);
            glu.QuadricTexture  (quadric, gl.TRUE);

            texNames = new uint[8];

            // Generate 8 texture names
            gl.GenTextures(8, texNames);

            LoadTextureFromResources(texNames[0], "origin.jpg", gl.LINEAR);



        }

        #region dllimports

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        #endregion

        protected void FontMapping()
        {

            Graphics g = this.CreateGraphics();

            IntPtr hdc = new IntPtr();

            hdc = g.GetHdc();

            Font font = new Font("Tahoma", 8.25f);

            SelectObject(hdc, font.ToHfont());

            if (wgl.UseFontBitmaps(hdc, 0, 255, 1000) == false)

                Console.WriteLine("wglUseFontBitmaps failed: font");

            Font boldFont = new Font("Tahoma", 8.25f, FontStyle.Bold);

            SelectObject(hdc, boldFont.ToHfont());

            if (wgl.UseFontBitmaps(hdc, 0, 255, 2000) == false)

                Console.WriteLine("wglUseFontBitmaps failed: boldFont");

            Font welcomeFont = new Font("Georgia", 14.0f, FontStyle.Bold);

            SelectObject(hdc, welcomeFont.ToHfont());

            if (wgl.UseFontBitmaps(hdc, 0, 255, 3000) == false)

                Console.WriteLine("wglUseFontBitmaps failed: welcomeFont");


            g.ReleaseHdc(hdc);

        }

        private void ViewportSetup()
        {

            int w = this.Width;
            int h = this.Height;

            if (h == 0)

                h = 1;

            // Set Viewport to window dimensions
            gl.Viewport(0, 0, w, h);

            aspect = (float)w / (float)h;

        }

        protected void SceneSetup2D(float zNear, float zFar)
        {

            gl.Enable(gl.LIGHT0);
            gl.Enable(gl.LIGHT1);

            gl.MatrixMode(gl.PROJECTION);
            gl.LoadIdentity();

            gl.Ortho(0, this.Width, 0, this.Height, zNear, zFar);

        }

        protected void SceneSetupOrtho3D()
        {

            gl.Enable(gl.LIGHT0);
            gl.Disable(gl.LIGHT1);

            gl.MatrixMode(gl.PROJECTION);
            gl.LoadIdentity();

            ApplyZoom();

            gl.Ortho(-this.Width/2, this.Width/2, -this.Height/2, this.Height/2, zNearOrtho, zFarOrtho);

        }

        protected void SceneSetupPerispective3D()
        {

            gl.Enable(gl.LIGHT0);
            gl.Disable(gl.LIGHT1);

            gl.MatrixMode(gl.PROJECTION);
            gl.LoadIdentity();

            ApplyZoom();

            glu.Perspective(fieldOfView, aspect, zNearPerspective, zFarPerspective);


        }

        void ApplyZoom()
        {

            int[] viewport = new int[4];
            gl.GetIntegerv(gl.VIEWPORT, viewport);

            viewportRect.X = viewport[0];
            viewportRect.Y = viewport[1];
            viewportRect.Width = viewport[2];
            viewportRect.Height = viewport[3];

            if (firstRedraw)
            {

                zoomRect = viewportRect;
                firstRedraw = false;

            }

            float widthScale  = viewportRect.Width  / zoomRect.Width;
            float heightScale = viewportRect.Height / zoomRect.Height;

            if (widthScale < heightScale)
            {

                float prevHeight = zoomRect.Height;

                zoomRect.Height  = zoomRect.Width / aspect;
                zoomRect.Y      -= (zoomRect.Height - prevHeight) / 2;
            
            }
            else
            {

                float prevWidth = zoomRect.Width;

                zoomRect.Width  = zoomRect.Height * aspect;
                zoomRect.X     -= (zoomRect.Width - prevWidth) / 2;

            }

            if (zoomRect.Width < 0.1f)
            {

                zoomRect.Width = 0.1f;
                zoomRect.Height = zoomRect.Width / aspect;
            }

            if (zoomRect.Height < 0.1f)
            {

                zoomRect.Height = 0.1f;
                zoomRect.Width = zoomRect.Height * aspect;

            }

            glu.PickMatrix(zoomRect.X + zoomRect.Width / 2, zoomRect.Y + zoomRect.Height / 2, zoomRect.Width, zoomRect.Height, viewport);

            prevZoomRect = zoomRect;

        }

        // param can be gl.LINEAR or gl.NEAREST
        protected void LoadTextureFromResources(uint id, string name, int param)
        {

            gl.Enable(gl.TEXTURE_2D);

            using (Bitmap bitmap = new Bitmap(this.GetType(), name))
            {

                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                gl.BindTexture(gl.TEXTURE_2D, id);

                gl.TexParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, param);
                gl.TexParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, param);

                gl.TexImage2D(gl.TEXTURE_2D, 0, gl.RGB8,
                                bitmapData.Width, bitmapData.Height, 0,
                                gl.BGR_EXT, gl.UNSIGNED_BYTE,
                                bitmapData.Scan0);

                bitmap.UnlockBits(bitmapData);

            }

            gl.Disable(gl.TEXTURE_2D);

        }

        #endregion

        #region Focus handling

        protected override void OnLostFocus(EventArgs e)
        {

            hasFocus = false;

            action = actionType.None;

            Invalidate();

        }
        protected override void OnGotFocus(EventArgs e)
        {

            hasFocus = true;
            Invalidate();

        }

        #endregion

        #region Zoom/Pan/Rotate


        #endregion

        /// <summary>
        /// Make the OpenGLControl rendering context current, 
        /// used when there are more OpenGLControls on the same form.
        /// </summary>
        public void MakeRenderingContextCurrent()
        {

            renderingContext.MakeCurrent();

        }

        public float GetOpenGLVersion()
        {

            string versionString1 = gl.GetString(gl.VERSION);

            string versionString2 = versionString1.Substring(0, 3);

            float version = 0.0f;

            try
            {
                version = (float) Convert.ToDouble(versionString2);
            }
            catch (Exception ex)
            {

                version = 1.0f;

                Console.WriteLine(ex.Message);

            }

            return version;

        }

        private void InitializeStyles()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                Int32 CS_VREDRAW = 0x1;
                Int32 CS_HREDRAW = 0x2;
                Int32 CS_OWNDC   = 0x20;
                CreateParams cp  = base.CreateParams;
                cp.ClassStyle    = cp.ClassStyle | CS_VREDRAW | CS_HREDRAW | CS_OWNDC;

                return cp;
            }
        }

        public void SetZoomCursor()
        {

            if (zoomButtonDown)
                this.Cursor = zoomCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        public void SetPanCursor()
        {

            if (panButtonDown)
                this.Cursor = panCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        public void SetRotateCursor()
        {

            if (rotateButtonDown)
                this.Cursor = rotateCursor;
            else
                this.Cursor = Cursors.Arrow;

        }

        public void CheckModelWeight()
        {

            if (entities.Count > 512)

                heavyModel = true;

        }
        
        void DrawBoundingRect() {
            
                gl.PushMatrix();

                gl.Color3ub(0xff, 0, 0);

                gl.LineStipple(1, 0x0808);
                gl.Enable(gl.LINE_STIPPLE);

                gl.Begin(gl.LINE_LOOP);

                gl.Vertex2f( globalLeft, globalBottom);
                gl.Vertex2f(globalRight, globalBottom);
                gl.Vertex2f(globalRight, globalTop);
                gl.Vertex2f( globalLeft, globalTop);

                gl.End();

                gl.Disable(gl.LINE_STIPPLE);

                gl.PopMatrix();
            
        }

        public void UpdateNormals()
        {

            foreach (Entity ent in entities)

                if (ent.GetType() == typeof(TriangularFace))

                    ent.ScaleNormal(scaleTo100);

        }

        protected void NormalizeBox(ref int x1, ref int y1, ref int x2, ref int y2)
        {

            int firstX;
            int firstY;
            int secondX;
            int secondY;

            firstX = Math.Min(x1, x2);
            secondX = Math.Max(x1, x2);
            firstY = Math.Min(y1, y2);
            secondY = Math.Max(y1, y2);

            x1 = firstX;
            y1 = firstY;
            x2 = secondX;
            y2 = secondY;

        }

        public virtual void ZoomFit() {}

        public virtual void ZoomWindow(int x1, int y1, int x2, int y2) {}

    }
}