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
using System.Drawing;
using OpenGL;
using System.IO;

namespace openglFramework
{
    [Serializable]
    abstract class Entity
    {

        protected Color color;

        public Entity(Color color)
        {

            this.color = color;

        }

        public virtual void Draw()
        {

            gl.Color4ub(color.R, color.G, color.B, 127);

        }

        public virtual void DrawForShadow()
        {


        }

        public virtual void ScaleNormal(float scale) { }
        
        public virtual void BoundingBox(ref float xMin, ref float yMin, ref float zMin, ref float xMax, ref float yMax, ref float zMax) { }

    }

}
