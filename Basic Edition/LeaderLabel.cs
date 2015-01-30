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

namespace openglFramework
{
    class LeaderLabel : Label
    {
        float x, y, z;

        protected int yDistance;

        public LeaderLabel(float x, float y, float z, string text, int yDistance) : base(text)
        {

            this.x = x;
            this.y = y;
            this.z = z;

            this.text = text;
            this.yDistance = yDistance;

        }

        public override void Draw(float layer)
        {

            Draw(0, yDistance);

            gl.LineWidth(1.0f);

            gl.Begin(gl.LINES);

            gl.Vertex3f(xPos, yPos + 4, layer);
            gl.Vertex3f(xPos, yPos + yDistance - 4, layer);

            gl.End();

        }

        public void UpdatePos()
        {

            float winX, winY, winZ;

            Project(x, y, z, out winX, out winY, out winZ);

            xPos = (int)winX;
            yPos = (int)winY;

        }
           
    }
}
