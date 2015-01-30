using System.Drawing;

namespace openglFramework
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.perspectiveButton = new openglFramework.ToggleButton();
            this.fieldOfView = new System.Windows.Forms.NumericUpDown();
            this.parallelButton = new openglFramework.ToggleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rotateButton = new openglFramework.ToggleButton();
            this.panButton = new openglFramework.ToggleButton();
            this.zoomButton = new openglFramework.ToggleButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.springToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadingProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.selectedCountStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openglVersionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fpsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.oglfVersionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.wireframeButton = new openglFramework.ToggleButton();
            this.edgesButton = new openglFramework.ToggleButton();
            this.shadedButton = new openglFramework.ToggleButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.showLabelsButton = new openglFramework.ToggleButton();
            this.showOriginButton = new openglFramework.ToggleButton();
            this.showBoundingBoxButton = new openglFramework.ToggleButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.oddB = new System.Windows.Forms.NumericUpDown();
            this.oddG = new System.Windows.Forms.NumericUpDown();
            this.oddR = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.evenB = new System.Windows.Forms.NumericUpDown();
            this.evenG = new System.Windows.Forms.NumericUpDown();
            this.evenR = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sideLength = new System.Windows.Forms.NumericUpDown();
            this.cornerY = new System.Windows.Forms.NumericUpDown();
            this.cornerX = new System.Windows.Forms.NumericUpDown();
            this.openGLControl1 = new openglFramework.OpenGLControl();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOfView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oddB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.perspectiveButton);
            this.groupBox2.Controls.Add(this.fieldOfView);
            this.groupBox2.Controls.Add(this.parallelButton);
            this.groupBox2.Location = new System.Drawing.Point(440, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 45);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Projection";
            // 
            // perspectiveButton
            // 
            this.perspectiveButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.perspectiveButton.Location = new System.Drawing.Point(102, 17);
            this.perspectiveButton.Name = "perspectiveButton";
            this.perspectiveButton.Size = new System.Drawing.Size(94, 22);
            this.perspectiveButton.TabIndex = 1;
            this.perspectiveButton.Text = "Perspective";
            this.perspectiveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.perspectiveButton.Click += new System.EventHandler(this.perspectiveButton_Click);
            // 
            // fieldOfView
            // 
            this.fieldOfView.Enabled = false;
            this.fieldOfView.Location = new System.Drawing.Point(199, 18);
            this.fieldOfView.Name = "fieldOfView";
            this.fieldOfView.Size = new System.Drawing.Size(93, 21);
            this.fieldOfView.TabIndex = 2;
            this.fieldOfView.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fieldOfView.ValueChanged += new System.EventHandler(this.fieldOfView_ValueChanged);
            // 
            // parallelButton
            // 
            this.parallelButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.parallelButton.Location = new System.Drawing.Point(6, 17);
            this.parallelButton.Name = "parallelButton";
            this.parallelButton.Size = new System.Drawing.Size(94, 22);
            this.parallelButton.TabIndex = 0;
            this.parallelButton.Text = "Parallel";
            this.parallelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.parallelButton.Click += new System.EventHandler(this.parallelButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rotateButton);
            this.groupBox4.Controls.Add(this.panButton);
            this.groupBox4.Controls.Add(this.zoomButton);
            this.groupBox4.Location = new System.Drawing.Point(440, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 45);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ZPR";
            // 
            // rotateButton
            // 
            this.rotateButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.rotateButton.Location = new System.Drawing.Point(198, 17);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(94, 22);
            this.rotateButton.TabIndex = 2;
            this.rotateButton.Text = "Rotate";
            this.rotateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // panButton
            // 
            this.panButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.panButton.Location = new System.Drawing.Point(102, 17);
            this.panButton.Name = "panButton";
            this.panButton.Size = new System.Drawing.Size(94, 22);
            this.panButton.TabIndex = 1;
            this.panButton.Text = "Pan";
            this.panButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.panButton.Click += new System.EventHandler(this.panButton_Click);
            // 
            // zoomButton
            // 
            this.zoomButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.zoomButton.Location = new System.Drawing.Point(6, 17);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(94, 22);
            this.zoomButton.TabIndex = 0;
            this.zoomButton.Text = "Zoom";
            this.zoomButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.zoomButton.Click += new System.EventHandler(this.zoomButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel,
            this.springToolStripStatusLabel,
            this.loadingProgressBar,
            this.selectedCountStatusLabel,
            this.openglVersionStatusLabel,
            this.fpsStatusLabel,
            this.oglfVersionStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 673);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(744, 23);
            this.statusStrip1.TabIndex = 52;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(496, 18);
            this.mainStatusLabel.Text = "Middle Mouse Button = Rotate, Ctrl + Middle = Pan, Shift + Middle = Zoom, Mouse W" +
                "heel = Zoom +/-";
            // 
            // springToolStripStatusLabel
            // 
            this.springToolStripStatusLabel.Name = "springToolStripStatusLabel";
            this.springToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.springToolStripStatusLabel.Size = new System.Drawing.Size(95, 18);
            this.springToolStripStatusLabel.Spring = true;
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.loadingProgressBar.Size = new System.Drawing.Size(105, 17);
            this.loadingProgressBar.Visible = false;
            // 
            // selectedCountStatusLabel
            // 
            this.selectedCountStatusLabel.AutoSize = false;
            this.selectedCountStatusLabel.AutoToolTip = true;
            this.selectedCountStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.selectedCountStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.selectedCountStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.selectedCountStatusLabel.Name = "selectedCountStatusLabel";
            this.selectedCountStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.selectedCountStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.selectedCountStatusLabel.Text = "0";
            this.selectedCountStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectedCountStatusLabel.ToolTipText = "Selected count";
            // 
            // openglVersionStatusLabel
            // 
            this.openglVersionStatusLabel.AutoSize = false;
            this.openglVersionStatusLabel.AutoToolTip = true;
            this.openglVersionStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.openglVersionStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.openglVersionStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.openglVersionStatusLabel.Name = "openglVersionStatusLabel";
            this.openglVersionStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.openglVersionStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.openglVersionStatusLabel.Text = "toolStripStatusLabel2";
            this.openglVersionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.openglVersionStatusLabel.ToolTipText = "OpenGL version";
            // 
            // fpsStatusLabel
            // 
            this.fpsStatusLabel.AutoSize = false;
            this.fpsStatusLabel.AutoToolTip = true;
            this.fpsStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.fpsStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.fpsStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.fpsStatusLabel.Name = "fpsStatusLabel";
            this.fpsStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.fpsStatusLabel.Size = new System.Drawing.Size(64, 18);
            this.fpsStatusLabel.Text = "toolStripStatusLabel1";
            this.fpsStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fpsStatusLabel.ToolTipText = "Frames per second";
            // 
            // oglfVersionStatusLabel
            // 
            this.oglfVersionStatusLabel.AutoSize = false;
            this.oglfVersionStatusLabel.AutoToolTip = true;
            this.oglfVersionStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.oglfVersionStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.oglfVersionStatusLabel.Name = "oglfVersionStatusLabel";
            this.oglfVersionStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.oglfVersionStatusLabel.Size = new System.Drawing.Size(64, 13);
            this.oglfVersionStatusLabel.Text = "toolStripStatusLabel1";
            this.oglfVersionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oglfVersionStatusLabel.ToolTipText = "C# OpenGL Framework version";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.wireframeButton);
            this.groupBox6.Controls.Add(this.edgesButton);
            this.groupBox6.Controls.Add(this.shadedButton);
            this.groupBox6.Location = new System.Drawing.Point(440, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(298, 45);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Shading";
            // 
            // wireframeButton
            // 
            this.wireframeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.wireframeButton.Location = new System.Drawing.Point(6, 17);
            this.wireframeButton.Name = "wireframeButton";
            this.wireframeButton.Size = new System.Drawing.Size(94, 22);
            this.wireframeButton.TabIndex = 0;
            this.wireframeButton.Text = "Wireframe";
            this.wireframeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wireframeButton.Click += new System.EventHandler(this.wireframeButton_Click);
            // 
            // edgesButton
            // 
            this.edgesButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.edgesButton.Location = new System.Drawing.Point(198, 17);
            this.edgesButton.Name = "edgesButton";
            this.edgesButton.Size = new System.Drawing.Size(94, 22);
            this.edgesButton.TabIndex = 2;
            this.edgesButton.Text = "Shaded && Edges";
            this.edgesButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.edgesButton.Click += new System.EventHandler(this.edgesButton_Click);
            // 
            // shadedButton
            // 
            this.shadedButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.shadedButton.Location = new System.Drawing.Point(102, 17);
            this.shadedButton.Name = "shadedButton";
            this.shadedButton.Size = new System.Drawing.Size(94, 22);
            this.shadedButton.TabIndex = 1;
            this.shadedButton.Text = "Shaded";
            this.shadedButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shadedButton.Click += new System.EventHandler(this.shadedButton_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.showLabelsButton);
            this.groupBox9.Controls.Add(this.showOriginButton);
            this.groupBox9.Controls.Add(this.showBoundingBoxButton);
            this.groupBox9.Location = new System.Drawing.Point(440, 145);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(298, 45);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Hide/Show";
            // 
            // showLabelsButton
            // 
            this.showLabelsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showLabelsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showLabelsButton.Location = new System.Drawing.Point(199, 17);
            this.showLabelsButton.Name = "showLabelsButton";
            this.showLabelsButton.Size = new System.Drawing.Size(94, 22);
            this.showLabelsButton.TabIndex = 2;
            this.showLabelsButton.Text = "Labels";
            this.showLabelsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showLabelsButton.CheckedChanged += new System.EventHandler(this.showLabelsButton_CheckedChanged);
            // 
            // showOriginButton
            // 
            this.showOriginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showOriginButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showOriginButton.Location = new System.Drawing.Point(7, 17);
            this.showOriginButton.Name = "showOriginButton";
            this.showOriginButton.Size = new System.Drawing.Size(94, 22);
            this.showOriginButton.TabIndex = 0;
            this.showOriginButton.Text = "Origin";
            this.showOriginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showOriginButton.CheckedChanged += new System.EventHandler(this.showOriginButton_CheckedChanged);
            // 
            // showBoundingBoxButton
            // 
            this.showBoundingBoxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showBoundingBoxButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.showBoundingBoxButton.Location = new System.Drawing.Point(103, 17);
            this.showBoundingBoxButton.Name = "showBoundingBoxButton";
            this.showBoundingBoxButton.Size = new System.Drawing.Size(94, 22);
            this.showBoundingBoxButton.TabIndex = 1;
            this.showBoundingBoxButton.Text = "Extent Box";
            this.showBoundingBoxButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showBoundingBoxButton.CheckedChanged += new System.EventHandler(this.showBoundingBoxButton_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.oddB);
            this.groupBox1.Controls.Add(this.oddG);
            this.groupBox1.Controls.Add(this.oddR);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.evenB);
            this.groupBox1.Controls.Add(this.evenG);
            this.groupBox1.Controls.Add(this.evenR);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sideLength);
            this.groupBox1.Controls.Add(this.cornerY);
            this.groupBox1.Controls.Add(this.cornerX);
            this.groupBox1.Location = new System.Drawing.Point(483, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 330);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // oddB
            // 
            this.oddB.DecimalPlaces = 2;
            this.oddB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.oddB.Location = new System.Drawing.Point(64, 299);
            this.oddB.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddB.Name = "oddB";
            this.oddB.Size = new System.Drawing.Size(93, 21);
            this.oddB.TabIndex = 26;
            this.oddB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.oddB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddB.ValueChanged += new System.EventHandler(this.oddB_ValueChanged);
            // 
            // oddG
            // 
            this.oddG.DecimalPlaces = 2;
            this.oddG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.oddG.Location = new System.Drawing.Point(64, 273);
            this.oddG.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddG.Name = "oddG";
            this.oddG.Size = new System.Drawing.Size(93, 21);
            this.oddG.TabIndex = 25;
            this.oddG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.oddG.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddG.ValueChanged += new System.EventHandler(this.oddG_ValueChanged);
            // 
            // oddR
            // 
            this.oddR.DecimalPlaces = 2;
            this.oddR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.oddR.Location = new System.Drawing.Point(64, 247);
            this.oddR.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddR.Name = "oddR";
            this.oddR.Size = new System.Drawing.Size(93, 21);
            this.oddR.TabIndex = 24;
            this.oddR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.oddR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.oddR.ValueChanged += new System.EventHandler(this.oddR_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "G";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "R";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Odd:";
            // 
            // evenB
            // 
            this.evenB.DecimalPlaces = 2;
            this.evenB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.evenB.Location = new System.Drawing.Point(64, 207);
            this.evenB.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.evenB.Name = "evenB";
            this.evenB.Size = new System.Drawing.Size(93, 21);
            this.evenB.TabIndex = 19;
            this.evenB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.evenB.ValueChanged += new System.EventHandler(this.evenB_ValueChanged);
            // 
            // evenG
            // 
            this.evenG.DecimalPlaces = 2;
            this.evenG.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.evenG.Location = new System.Drawing.Point(64, 181);
            this.evenG.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.evenG.Name = "evenG";
            this.evenG.Size = new System.Drawing.Size(93, 21);
            this.evenG.TabIndex = 18;
            this.evenG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.evenG.ValueChanged += new System.EventHandler(this.evenG_ValueChanged);
            // 
            // evenR
            // 
            this.evenR.DecimalPlaces = 2;
            this.evenR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.evenR.Location = new System.Drawing.Point(64, 155);
            this.evenR.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.evenR.Name = "evenR";
            this.evenR.Size = new System.Drawing.Size(93, 21);
            this.evenR.TabIndex = 17;
            this.evenR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.evenR.ValueChanged += new System.EventHandler(this.evenR_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "G";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Even:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Colors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Side Length:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Corner (y):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Corner (x):";
            // 
            // sideLength
            // 
            this.sideLength.Location = new System.Drawing.Point(102, 73);
            this.sideLength.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sideLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sideLength.Name = "sideLength";
            this.sideLength.Size = new System.Drawing.Size(93, 21);
            this.sideLength.TabIndex = 5;
            this.sideLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sideLength.Value = new decimal(new int[] {
            325,
            0,
            0,
            0});
            this.sideLength.ValueChanged += new System.EventHandler(this.sideLength_ValueChanged);
            // 
            // cornerY
            // 
            this.cornerY.Location = new System.Drawing.Point(102, 46);
            this.cornerY.Name = "cornerY";
            this.cornerY.Size = new System.Drawing.Size(93, 21);
            this.cornerY.TabIndex = 4;
            this.cornerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cornerY.ValueChanged += new System.EventHandler(this.cornerY_ValueChanged);
            // 
            // cornerX
            // 
            this.cornerX.Location = new System.Drawing.Point(102, 17);
            this.cornerX.Name = "cornerX";
            this.cornerX.Size = new System.Drawing.Size(93, 21);
            this.cornerX.TabIndex = 3;
            this.cornerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cornerX.ValueChanged += new System.EventHandler(this.cornerX_ValueChanged);
            // 
            // openGLControl1
            // 
            this.openGLControl1.AmbientLight = new float[] {
        0.1F,
        0.1F,
        0.1F,
        1F};
            this.openGLControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.openGLControl1.BackFaceCulling = true;
            this.openGLControl1.BackgroundMode = openglFramework.OpenGLControl.backgroundType.Bitmap;
            this.openGLControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl1.CornerX = 0F;
            this.openGLControl1.CornerY = 0F;
            this.openGLControl1.EdgeWeight = 2F;
            this.openGLControl1.EvenB = 0F;
            this.openGLControl1.EvenG = 0F;
            this.openGLControl1.EvenR = 0F;
            this.openGLControl1.FieldOfView = 50F;
            this.openGLControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openGLControl1.Location = new System.Drawing.Point(8, 9);
            this.openGLControl1.MainLightDiffuse = new float[] {
        0.75F,
        0.75F,
        0.75F,
        1F};
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OddB = 1F;
            this.openGLControl1.OddG = 1F;
            this.openGLControl1.OddR = 1F;
            this.openGLControl1.PanButtonDown = false;
            this.openGLControl1.PointSize = 4F;
            this.openGLControl1.ProjectionMode = openglFramework.OpenGLControl.projectionType.Parallel;
            this.openGLControl1.RotateButtonDown = false;
            this.openGLControl1.ShadingMode = openglFramework.OpenGLControl.shadingType.ShadedAndEdges;
            this.openGLControl1.ShadowMode = openglFramework.OpenGLControl.shadowType.Transparent;
            this.openGLControl1.ShowBoundingBox = true;
            this.openGLControl1.ShowLabels = true;
            this.openGLControl1.ShowLegend = true;
            this.openGLControl1.ShowOrigin = true;
            this.openGLControl1.ShowProgress = true;
            this.openGLControl1.ShowUCSIcon = true;
            this.openGLControl1.SideLength = 400F;
            this.openGLControl1.SideLightDiffuse = new float[] {
        0.2F,
        0.2F,
        0.2F,
        1F};
            this.openGLControl1.Size = new System.Drawing.Size(426, 654);
            this.openGLControl1.TabIndex = 1;
            this.openGLControl1.WireframeWeight = 1.5F;
            this.openGLControl1.ZoomButtonDown = false;
            this.openGLControl1.ZoomWindowButtonDown = false;
            this.openGLControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 696);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Shyam Guthikonda - Wallpaper Algorithm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldOfView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oddB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.NumericUpDown fieldOfView;
        /*private*/
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripStatusLabel openglVersionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel fpsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel springToolStripStatusLabel;
        /*private*/
        public System.Windows.Forms.ToolStripStatusLabel selectedCountStatusLabel;
        private System.Windows.Forms.GroupBox groupBox9;
        private ToggleButton perspectiveButton;
        private ToggleButton parallelButton;
        private ToggleButton rotateButton;
        private ToggleButton panButton;
        private ToggleButton zoomButton;
        private ToggleButton wireframeButton;
        private ToggleButton edgesButton;
        private ToggleButton shadedButton;
        private ToggleButton showLabelsButton;
        private ToggleButton showOriginButton;
        private ToggleButton showBoundingBoxButton;
        private OpenGLControl openGLControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripProgressBar loadingProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel oglfVersionStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sideLength;
        private System.Windows.Forms.NumericUpDown cornerY;
        private System.Windows.Forms.NumericUpDown cornerX;
        private System.Windows.Forms.NumericUpDown evenR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown evenB;
        private System.Windows.Forms.NumericUpDown evenG;
        private System.Windows.Forms.NumericUpDown oddB;
        private System.Windows.Forms.NumericUpDown oddG;
        private System.Windows.Forms.NumericUpDown oddR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
     
    }
}

