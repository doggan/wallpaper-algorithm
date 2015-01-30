/**********************************************************************
 * Name  : Shyam M Guthikonda
 * Date  : 13. Jan. 06.
 * Class : COMP 460
 * Asgt  : Asgt #1, P. 01
 * Desc  : - Performs the "Wallpaper Algorithm" as described in 'The New
 *             Turing Omnibus' by A.K. Dewdney.
 *         - Built on C# OpenGL Framework v1.7.5.0
 *             http://www.csharpopenglframework.com/
 **********************************************************************/

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

namespace openglFramework
{
    public partial class OpenGLControl : UserControl
    {
        #region memberData_dontPrint

        // Background Gradient colors
        protected Color backgroundTopColor;
        protected Color backgroundBottomColor;
        protected float edgeWeight       = 2.0f;
        protected float wireframeWeight  = 1.5f;

        // Frustum Settings
        private   float fieldOfView      = 50.0f;

        protected float zNearPerspective = 100;
        protected float zFarPerspective  = 2000;
        protected float aspect;

        protected float zNearOrtho       = 100;
        protected float zFarOrtho        = 2000;

        protected float zModel           = -800;

        protected float zBackground      = -1500;
        protected float zZoomAndSelBox   = 0;
        protected float zUcsIcon         = +100;
        protected float zLabels          = +200;

        protected float m_cornerX = 0.0f;
        protected float m_cornerY = 0.0f;
        protected float m_sideLength = 325.0f;
        protected float m_evenR = 0.0f;
        protected float m_evenG = 0.0f;
        protected float m_evenB = 0.0f;
        protected float m_oddR = 1.0f;
        protected float m_oddG = 1.0f;
        protected float m_oddB = 1.0f;

        public enum projectionType
        {

            Parallel,
            Perspective
        }
        protected projectionType projectionMode = projectionType.Perspective;

        // Hide/Show
        protected bool showBoundingBox  = false;
        protected bool showUCSIcon      = true;
        protected bool showOrigin       = false;
        protected bool showLabels       = true;
        protected bool showLegend       = true;
        protected bool showProgress     = true;

        // Quadrics: spheres, cones, cylinders, etc...
        protected IntPtr quadric;
        
        // Textures
        protected uint[] texNames;

        // Labels
        Label xUcsLabel;
        Label yUcsLabel;
        Label zUcsLabel;
        Label originLabel;

        public enum shadingType
        {

            Wireframe,
            Shaded,
            ShadedAndEdges

        }
        protected shadingType renderMode = shadingType.ShadedAndEdges;
        public enum backgroundType
        {

            None,
            Gradient,
            Bitmap

        }
        protected backgroundType backgroundMode = backgroundType.Gradient;
        public enum shadowType
        {

            None,
            Opaque,
            Transparent

        }
        protected shadowType shadowMode = shadowType.None;

        // Scale to obtain a fixed size model of 100 units
        protected float scaleTo100;
        // frames per second
        protected int fps;

        protected bool backFaceCulling;
        protected float pointSize = 4;

        public int Fps
        {
            get { return fps; }
        }
        public bool BackFaceCulling
        {

            get { return backFaceCulling; }
            set { backFaceCulling = value; }

        }
        public float EdgeWeight
        {

            get { return edgeWeight; }
            set { edgeWeight = value; }

        }
        public float WireframeWeight
        {

            get { return wireframeWeight; }
            set { wireframeWeight = value; }

        }
        public float PointSize
        {

            get { return pointSize; }
            set { pointSize = value; }

        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowBoundingBox
        {
            get { return showBoundingBox; }
            set
            {
                showBoundingBox = value;
                Invalidate();
            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowOrigin
        {
            get { return showOrigin; }
            set
            {
                showOrigin = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowLabels
        {
            get { return showLabels; }
            set
            {
                showLabels = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowLegend
        {

            get { return showLegend; }
            set { showLegend = value; }

        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowProgress
        {
            get { return showProgress; }
            set
            {
                showProgress = value;
                Invalidate();

            }
        }
        [CategoryAttribute("Hide/Show")]
        public bool ShowUCSIcon
        {

            get { return showUCSIcon; }
            set { showUCSIcon = value; }

        }
        public backgroundType BackgroundMode
        {
            get { return backgroundMode; }
            set
            {
                backgroundMode = value;
                Invalidate();
            }
        }
        [CategoryAttribute("Shadow")]
        public shadowType ShadowMode
        {
            get { return shadowMode; }
            set
            {
                shadowMode = value;
                Invalidate();
            }
        }
        #endregion
        
        public float CornerX
        {
            get { return m_cornerX; }
            set { m_cornerX = value;Invalidate(); }
        }
        public float CornerY
        {
            get { return m_cornerX; }
            set { m_cornerX = value; Invalidate();}
        }
        public float SideLength
        {
            get { return m_sideLength; }
            set { m_sideLength = value; Invalidate();}
        }
        public float EvenR
        {
            get { return m_evenR; }
            set { m_evenR = value; Invalidate(); }
        }
        public float EvenG
        {
            get { return m_evenG; }
            set { m_evenG = value; Invalidate(); }
        }
        public float EvenB
        {
            get { return m_evenB; }
            set { m_evenB = value; Invalidate(); }
        }
        public float OddR
        {
            get { return m_oddR; }
            set { m_oddR = value; Invalidate(); }
        }
        public float OddG
        {
            get { return m_oddG; }
            set { m_oddG = value; Invalidate(); }
        }
        public float OddB
        {
            get { return m_oddB; }
            set { m_oddB = value; Invalidate(); }
        }

        public void DrawScene(bool forSelection, bool onlyOnBackBuffer)
        {
            int StartTickCount = Environment.TickCount;
       
            gl.Enable(gl.DEPTH_TEST);
            gl.Clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);

            ViewportSetup();

            #region 1: Background.
            if (backgroundMode != backgroundType.None && forSelection != true)
            {
                SceneSetup2D((-zBackground) - 10, (-zBackground) + 10);
                DrawBackground();
            }
            #endregion
                
            #region 2: Models.
            gl.Clear(gl.DEPTH_BUFFER_BIT);

            switch (projectionMode)
            {
                case projectionType.Parallel:
                    SceneSetupOrtho3D();
                    break;

                case projectionType.Perspective:
                    SceneSetupPerispective3D();
                    break;
            }  

            Draw3D(forSelection);
            #endregion

            #region 3: Zoom, selection boxes, UCS icon, labels
            gl.Clear(gl.DEPTH_BUFFER_BIT);

            if (!forSelection)
            {
                SceneSetup2D((-zLabels) -10, (-zZoomAndSelBox) + 10);
                Draw2D();
            }
            #endregion

            gl.Flush();

            if (!onlyOnBackBuffer)
                renderingContext.SwapBuffers();

            // FPS.
            int MS = Environment.TickCount - StartTickCount;
            if (MS > 0)     fps = (int) (1000.0f / MS);
        }
        protected void DrawOrigin(float radius)
        {

            gl.Enable(gl.LIGHTING);

            gl.Color3ub(255, 255, 255);

            gl.Enable(gl.TEXTURE_2D);

            gl.BindTexture(gl.TEXTURE_2D, texNames[0]);

            glu.Sphere(quadric, radius, 32, 32);

            originLabel.UpdatePos(0, 0, 0);

            gl.Disable(gl.TEXTURE_2D);

        }
        protected void DrawEntities()
        {
            gl.Disable(gl.LIGHTING);
             
            #region Points
            gl.PointSize(pointSize);
            gl.Begin(gl.POINTS);

            /* Wallpaper Algorithm.
             */
            int iMax = 100;
            int jMax = 100;
            for (int i = 0; i < iMax; ++i)
            {
                for (int j = 0; j < jMax; ++j)
                {
                    float x = m_cornerX + (float)i * m_sideLength / 100.0f;
                    float y = m_cornerY + (float)j * m_sideLength / 100.0f;
                    int c = (int)(Math.Pow(x, 2) + Math.Pow(y, 2));

                    if ( (c % 2) == 0 )
                    {
                        // Subtract to center the points.
                        gl.Color3f( m_evenR, m_evenG, m_evenB );
                        gl.Vertex3f( i - iMax / 2, 0, j - jMax / 2 );
                    }
                    else {
                        // Subtract to center the points.
                        gl.Color3f( m_oddR, m_oddG, m_oddB );
                        gl.Vertex3f(i - iMax / 2, 0, j - jMax / 2);
                    }
                }
            }
            gl.End();
            #endregion

            #region Lines

            gl.Begin(gl.LINES);

            // draw a fake line to avoid troubles if there 
            // are NOT lines entities. Calling gl.Begin(...)
            // gl.End() without something inside causes problems
            gl.Color3ub(0xff, 0xff, 0xff);  // white to blend with background during selection (it could anyway hide some entitites)
            gl.Vertex3f(0, 0, 0);
            gl.Vertex3f(0.1f, 0, 0);

            gl.End();

            #endregion
            #region RichLines

            gl.Enable(gl.LINE_STIPPLE);

            gl.Disable(gl.LINE_STIPPLE); 

            #endregion
            #region Shading
            if (renderMode == shadingType.ShadedAndEdges)
            {
                gl.Enable(gl.POLYGON_OFFSET_FILL);
                gl.PolygonOffset(1.0f, 1.0f);
            }

            if (backFaceCulling) 
                gl.Enable(gl.CULL_FACE);

            gl.Enable(gl.LIGHTING);
            #region TriangularFaces

            switch (renderMode)
            {

                case shadingType.Wireframe:
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.LINE);
                    gl.Disable(gl.LIGHTING);
                    gl.LineWidth(wireframeWeight);
                    gl.Disable(gl.CULL_FACE);
                    break;

                case shadingType.Shaded:
                case shadingType.ShadedAndEdges:
                    gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);
                    break;

            }

            gl.Begin(gl.TRIANGLES);

            gl.End();

            #endregion
            gl.Disable(gl.LIGHTING);
            #endregion
            #region Edges

            if (renderMode == shadingType.ShadedAndEdges)
            {

                gl.Disable(gl.POLYGON_OFFSET_FILL);

                gl.PolygonMode(gl.FRONT_AND_BACK, gl.LINE);
                gl.LineWidth(edgeWeight);
                gl.Begin(gl.TRIANGLES);

                gl.End();

            } 

            #endregion
        }
        protected void DrawUcsIcon()
        {

            gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);
            gl.Disable(gl.CULL_FACE);

            if (openglVersion >= 1.2f)
                gl.Enable(gl.RESCALE_NORMAL);
            else
                gl.Enable(gl.NORMALIZE);

            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(255, 0, 0);

            else

                gl.Color3ub(0xBF, 0x40, 0x40);

            glu.Sphere(quadric, 4, 16, 16);

            DrawAxisArrow(xUcsLabel);

            gl.PopMatrix();


            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(0, 255, 0);

            else

                gl.Color3ub(0x40, 0xBF, 0x40);

            gl.Rotatef(90F, 0.0F, 0.0F, 1.0F);

            DrawAxisArrow(yUcsLabel);

            gl.PopMatrix();


            gl.PushMatrix();

            if (hasFocus)

                gl.Color3ub(0, 0, 255);

            else

                gl.Color3ub(0x40, 0x40, 0xBF);

            gl.Rotatef(-90F, 0.0F, 1.0F, 0.0F);

            DrawAxisArrow(zUcsLabel);

            gl.PopMatrix();

            if (openglVersion >= 1.2f)
                gl.Disable(gl.RESCALE_NORMAL);
            else
                gl.Disable(gl.NORMALIZE);


        }
        protected void DrawAxisArrow(Label label)
        {

            // Cylinder
            gl.PushMatrix();

            gl.Rotatef(90F, 0F, 1F, 0F);
            glu.Cylinder(quadric, 1.75, 1.75, 20, 16, 1);

            gl.PopMatrix();

            // Cone
            gl.PushMatrix();

            gl.Translatef(20, 0.0f, 0.0f);
            gl.Rotatef(90F, 0F, 1F, 0F);
            glu.Cylinder(quadric, 5, 0, 14, 16, 1);

            gl.PopMatrix();

            // Cone tapping
            gl.PushMatrix();

            gl.Translatef(20, 0.0f, 0.0f);
            gl.Rotatef(-90F, 0F, 1F, 0F);
            glu.Disk(quadric, 1.75, 5, 16, 1);

            gl.PopMatrix();

            // Label
            label.UpdatePos(40, 0, 0);

        }
        #region Overridables

        protected virtual void DrawBackground()
        {

            gl.MatrixMode(gl.MODELVIEW);
            gl.LoadIdentity();

            gl.Disable(gl.LIGHTING);


            gl.PolygonMode(gl.FRONT, gl.FILL);
            gl.Begin(gl.POLYGON);

            gl.Color3ub(backgroundBottomColor.R, backgroundBottomColor.G, backgroundBottomColor.B);
            gl.Vertex3f(0.0f, 0.0f, zBackground);

            gl.Vertex3f(this.Width, 0.0f, zBackground);

            gl.Color3ub(backgroundTopColor.R, backgroundTopColor.G, backgroundTopColor.B);
            gl.Vertex3f(this.Width, this.Height, zBackground);

            gl.Vertex3f(0.0f, this.Height, zBackground);

            gl.End();

        }

        protected virtual void Draw2D()
        {

            gl.MatrixMode(gl.MODELVIEW);

            gl.LoadIdentity();

            // An optimum compromise that allows all primitives to be specified 
            // at integer positions, while still ensuring predictable rasterization, 
            // is to translate x and y by 0.375
            gl.Translatef(0.375f, 0.375f, 0.0f);

            gl.Disable(gl.LIGHTING);
            gl.LineWidth(1.0f);
         
            if (action == actionType.ZoomWindow)

                DrawZoomWindowBox();

            if (action == actionType.SelectByBox)

                DrawSelectionBox();


       //     DrawBoundingRect();


            gl.Enable(gl.LIGHTING);

            if (showUCSIcon)
            {

                gl.PushMatrix();

                // axis icon position
                gl.Translatef(50.0f, 50.0f, zUcsIcon);

                // axis icon rotation
                gl.Rotatef(MU.radToDeg(rotAngle), rotAxis.x, rotAxis.y, rotAxis.z);		// multiply into matrix

                // swaps axis Y with Z
                gl.Rotatef(-90.0f, 1.0f, 0.0f, 0.0f);

                DrawUcsIcon();

                gl.PopMatrix();


                gl.Disable(gl.LIGHTING);

                gl.PushMatrix();

                gl.Color3ub(63, 63, 63);

                if (hasFocus)
                {

                    xUcsLabel.Draw(zLabels);
                    yUcsLabel.Draw(zLabels);
                    zUcsLabel.Draw(zLabels);

                }

            }

            if (showLabels)
            {

                gl.Disable(gl.LIGHTING);

                originLabel.Draw(0, 20);

                gl.Color3ub(255, 255, 255);

                foreach (Label l in labels)

                    l.Draw(zLabels);

            }

            if (showLegend)
                
                DrawLegend();

            if (showProgress)

                DrawProgressBar();
            
            gl.Color3ub(180, 180, 180);

            if (stencilBits == 0)
            
                DrawText(Width-366, Height-50, "Stencil buffer not available. Transparent shadow will not be rendered.");

            gl.PopMatrix();
         
        }

        protected virtual void Draw3D(bool forSelection)
        {

            gl.MatrixMode(gl.MODELVIEW);
            gl.LoadIdentity();
      
            // Move out Z axis so we can see everything (needed only for Perspective view)
            gl.Translatef(0, 0, zModel);

            if (projectionMode == projectionType.Perspective && // we see it only in perspective mode
                shadowMode != shadowType.None &&                
                forSelection != true)

                DrawShadow();

            gl.Rotatef(MU.radToDeg(rotAngle), rotAxis.x, rotAxis.y, rotAxis.z);		// multiply into matrix

            // this command swaps the Y and Z axis
            gl.Rotatef(-90.0f, 1.0f, 0.0f, 0.0f);

            CenterTheModel();

            if (showOrigin)

                DrawOrigin(10);

            // give to the model a fixed size: 100 units
            gl.Scalef(scaleTo100, scaleTo100, scaleTo100);

            foreach (LeaderLabel l in labels)

                l.UpdatePos();

            if (forSelection) {

                gl.Disable(gl.LIGHTING);
                gl.PolygonMode(gl.FRONT_AND_BACK, gl.FILL);
                DrawSelectableEntities();

            }

            else {
                DrawEntities();
            }

        }

        protected virtual void DrawShadow()
        {


        }

        protected virtual void DrawLegend()
        {


        }

        protected virtual void DrawProgressBar()
        {


        }

        protected virtual void DrawSelectableEntities()
        {

        }

        #endregion
        protected void CenterTheModel()
        {

            gl.Translatef(-(globalMin[0] + xSize / 2) * scaleTo100,
                          -(globalMin[1] + ySize / 2) * scaleTo100,
                          -(globalMin[2] + zSize / 2) * scaleTo100);

        }
        public void UpdateModelSize()
        {

            globalMin[0] = float.MaxValue;
            globalMin[1] = float.MaxValue;
            globalMin[2] = float.MaxValue;
            globalMax[0] = float.MinValue;
            globalMax[1] = float.MinValue;
            globalMax[2] = float.MinValue;

            foreach (Entity e in entities)

                e.BoundingBox(ref globalMin[0], ref globalMin[1], ref globalMin[2], ref globalMax[0], ref globalMax[1], ref globalMax[2]);

            xSize = globalMax[0] - globalMin[0];
            ySize = globalMax[1] - globalMin[1];
            zSize = globalMax[2] - globalMin[2];

            float modelSize = (float)Math.Sqrt(xSize * xSize + ySize * ySize + zSize * zSize);

            // originally was 100 but with the True Zooming TM everything has changed
            // Now the model size is 900 units of diameter and never changes
            scaleTo100 = 900 / modelSize;

            Console.WriteLine("  ");
            Console.WriteLine("Model dimensions");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Model min : {0,15}, {1,15}, {2,15}", globalMin[0], globalMin[1], globalMin[2]);
            Console.WriteLine("Model max : {0,15}, {1,15}, {2,15}", globalMax[0], globalMax[1], globalMax[2]);
            Console.WriteLine("Model size: {0,15}, {1,15}, {2,15}", xSize, ySize, zSize);

            UpdateNormals();

        }
        protected void DrawBox(int firstX, int firstY, int secondX, int secondY, int zOffset)
        {

//            gl.Begin(gl.POLYGON);

            gl.Vertex3i( firstX,  firstY, (int) zZoomAndSelBox + zOffset);
            gl.Vertex3i(secondX,  firstY, (int) zZoomAndSelBox + zOffset);

            gl.Vertex3i(secondX, secondY, (int) zZoomAndSelBox + zOffset);
            gl.Vertex3i( firstX, secondY, (int) zZoomAndSelBox + zOffset);

  //          gl.End();

        }
        protected void DrawText(int x, int y, string text)
        {

            gl.ListBase(1000); // normal

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

        }
        protected void DrawBoldText(int x, int y, string text)
        {

            gl.ListBase(2000); // bold

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

        }
        protected void DrawWelcomeText(int x, int y, string text)
        {

            gl.ListBase(3000); // welcome

            gl.Color3ub(0xff, 0xff, 0xff);

            gl.RasterPos2f(x, y);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);

            gl.Color3ub(0, 0, 0);

            gl.RasterPos2f(x + 1, y + 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x + 1, y - 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x - 1, y - 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


            gl.RasterPos2f(x - 1, y + 1);

            gl.CallLists(text.Length, gl.UNSIGNED_BYTE, text);


        }
    }
}
