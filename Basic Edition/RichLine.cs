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
using System.Text;
using OpenGL;
using System.Drawing;
using System.IO;

namespace openglFramework
{
    [Serializable]
    class RichLine : Line
    {

        protected float weight;
        protected ushort pattern;

        public RichLine(float[] p1, float[] p2, Color color, float weight, ushort pattern) : base (p1, p2, color)
        {

            this.weight = weight;
            this.pattern = pattern;

        }

        public override void Draw()
        {

            // Color selection in base class
            base.Draw();

            gl.LineWidth(weight);
            gl.LineStipple(3, pattern);

            gl.Begin(gl.LINES);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.End();
        
        }


    }
}
