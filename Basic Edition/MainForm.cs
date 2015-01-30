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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;

namespace openglFramework
{
    public partial class MainForm : Form
    {

        public MainForm()
        {

            // To set decimal separator as point
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            InitializeComponent();

            MinimumSize = Size;            
            
            #region Buttons status

            // Shading
            switch (openGLControl1.ShadingMode)
            {

                case OpenGLControl.shadingType.Wireframe:
                    wireframeButton.Checked = true;
                    break;

                case OpenGLControl.shadingType.Shaded:
                    shadedButton.Checked = true;
                    break;

                case OpenGLControl.shadingType.ShadedAndEdges:
                    edgesButton.Checked = true;
                    break;

            }

            // Hide/Show
            showOriginButton.Checked = openGLControl1.ShowOrigin;
            showBoundingBoxButton.Checked = openGLControl1.ShowBoundingBox;
            showLabelsButton.Checked    = openGLControl1.ShowLabels;

            // Projection
            switch (openGLControl1.ProjectionMode)
            {

                case OpenGLControl.projectionType.Parallel:
                    parallelButton.Checked = true;
                    perspectiveButton.Checked = false;
                    fieldOfView.Enabled = false;
                    break;
                case OpenGLControl.projectionType.Perspective:
                    parallelButton.Checked = false;
                    perspectiveButton.Checked = true;
                    fieldOfView.Enabled = true;
                    break;
            }

            fieldOfView.Value = (int)openGLControl1.FieldOfView;
            openGLControl1.SideLength = (float)sideLength.Value;

            openglVersionStatusLabel.Text = openGLControl1.GetOpenGLVersion().ToString("f1");
            oglfVersionStatusLabel.Text = ProductVersion;

            #endregion

            #region Jet drawing
            // Line
            openGLControl1.entities.Add(new RichLine(new float[] { 0, 0, -10 },
                                     new float[] { 0, 0, +25 }, Color.White, 1, 0xf5ff));
            #endregion

            openGLControl1.UpdateModelSize();

        }

        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {

            openGLControl1.MakeRenderingContextCurrent();
            openGLControl1.DrawScene(false, false);

            fpsStatusLabel.Text = openGLControl1.Fps + " fps";

        }

        #region Zoom/Pan/Rotate

        private void zoomButton_Click(object sender, EventArgs e)
        {

//            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
            panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
            rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;

            openGLControl1.SetZoomCursor();
        }

        private void panButton_Click(object sender, EventArgs e)
        {
            
            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
     //       panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
            rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;

            openGLControl1.SetPanCursor();

        }

        private void rotateButton_Click(object sender, EventArgs e)
        {

            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
            panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
  //          rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;

            openGLControl1.SetRotateCursor();
        }

        private void zoomAllButton_Click(object sender, EventArgs e)
        {
            openGLControl1.ZoomFit();
        }

        private void zoomWindowButton_Click(object sender, EventArgs e)
        {

            zoomButton.Checked = false;
            openGLControl1.ZoomButtonDown = zoomButton.Checked;
            panButton.Checked = false;
            openGLControl1.PanButtonDown = panButton.Checked;
            rotateButton.Checked = false;
            openGLControl1.RotateButtonDown = rotateButton.Checked;

  //          zoomWindowButton.Checked = false;
        }

        #endregion

        #region Shading

        private void wireframeButton_Click(object sender, EventArgs e)
        {

                wireframeButton.Checked = true;

                openGLControl1.ShadingMode = OpenGLControl.shadingType.Wireframe;

                shadedButton.Checked = false;
                edgesButton.Checked = false;

        }

        private void shadedButton_Click(object sender, EventArgs e)
        {

                shadedButton.Checked = true;
        
                openGLControl1.ShadingMode = OpenGLControl.shadingType.Shaded;

                wireframeButton.Checked = false;
                edgesButton.Checked = false;
        
        }

        private void edgesButton_Click(object sender, EventArgs e)
        {
                edgesButton.Checked = true;
        
                openGLControl1.ShadingMode = OpenGLControl.shadingType.ShadedAndEdges;

                wireframeButton.Checked = false;
                shadedButton.Checked = false;
       
        }

        #endregion

        #region Projection

        private void parallelButton_Click(object sender, EventArgs e)
        {

            parallelButton.Checked = true;

            openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Parallel;

            perspectiveButton.Checked = false;
            fieldOfView.Enabled = false;


        }

        private void perspectiveButton_Click(object sender, EventArgs e)
        {

            perspectiveButton.Checked = true;

            openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Perspective;

            parallelButton.Checked = false;
            fieldOfView.Enabled = true;
        }

        private void fieldOfView_ValueChanged(object sender, EventArgs e)
        {

            openGLControl1.FieldOfView = (int)fieldOfView.Value;

        }

        private void cornerX_ValueChanged(Object sender, EventArgs e)
        {
            openGLControl1.CornerX = (float)cornerX.Value;
        }

        private void cornerY_ValueChanged(Object sender, EventArgs e)
        {
            openGLControl1.CornerY = (float)cornerY.Value;
        }

        private void sideLength_ValueChanged(Object sender, EventArgs e)
        {
            openGLControl1.SideLength = (float)sideLength.Value;
        }

        #endregion

        #region Show/Hide

        private void showOriginButton_CheckedChanged(object sender, EventArgs e)
        {
            openGLControl1.ShowOrigin = showOriginButton.Checked;
        }

        private void showBoundingBoxButton_CheckedChanged(object sender, EventArgs e)
        {

            openGLControl1.ShowBoundingBox = showBoundingBoxButton.Checked;

        }

        private void showLabelsButton_CheckedChanged(object sender, EventArgs e)
        {
            openGLControl1.ShowLabels = showLabelsButton.Checked;
        }

        #endregion

        #region File Open / Save

        private void openButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog myOpenFileDialog = new OpenFileDialog();

            myOpenFileDialog.InitialDirectory = ".";
            myOpenFileDialog.Filter = "Design files (*.design)|*.design|All files (*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)

                OpenFile(myOpenFileDialog.FileName);


        }

        void OpenFile(string name)
        {

            FileInfo f = new FileInfo(name);

            Stream myStream = f.OpenRead();

            if (myStream != null)
            {

                StatusText("Loading...");
                Cursor = Cursors.WaitCursor;

                BinaryFormatter myBinaryFormat = new BinaryFormatter();
                try
                {

                    openGLControl1.entities = (ArrayList)myBinaryFormat.Deserialize(myStream);

                    myStream.Close();

                    openGLControl1.UpdateModelSize();

                    openGLControl1.Invalidate();

                    StatusText("");
                    Cursor = Cursors.Arrow;
                }
                catch (Exception e)
                {
                    StatusText(e.GetType().Name);
                }
                finally
                {
                    myStream.Close();
                    Cursor = Cursors.Arrow;
                }

            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {

            SaveFileDialog mySaveFileDialog = new SaveFileDialog();

            mySaveFileDialog.InitialDirectory = ".";
            mySaveFileDialog.Filter = "Design files (*.design)|*.design|All files (*.*)|*.*";
            mySaveFileDialog.FilterIndex = 1;
            mySaveFileDialog.RestoreDirectory = true;
            mySaveFileDialog.FileName = "";

            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {

                Stream myStream = null;

                StatusText("Saving...");
                Cursor = Cursors.WaitCursor;

                if ((myStream = mySaveFileDialog.OpenFile()) != null)
                {

                    BinaryFormatter myBinaryFormat = new BinaryFormatter();
                    try
                    {

                        myBinaryFormat.Serialize(myStream, openGLControl1.entities);

                        myStream.Close();

                        StatusText("");
                        Cursor = Cursors.Arrow;

                    }
                    catch (Exception e)
                    {
                        StatusText(e.GetType().Name);
                    }
                    finally
                    {
                        myStream.Close();
                        Cursor = Cursors.Arrow;
                    }




                }

            }
        }

        #endregion

        public void StatusText(string str)
        {

            this.mainStatusLabel.Text = str;

        }

        private void sourceCodeButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.devdept.com/code/oglf");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void evenR_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.EvenR = (float)evenR.Value;
        }

        private void evenG_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.EvenG = (float)evenG.Value;
        }

        private void evenB_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.EvenB = (float)evenB.Value;
        }

        private void oddR_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.OddR = (float)oddR.Value;
        }

        private void oddG_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.OddG = (float)oddG.Value;
        }

        private void oddB_ValueChanged(object sender, EventArgs e)
        {
            openGLControl1.OddB = (float)oddB.Value;
        }


    }
}