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
    class TriangularFace : Entity
    {

        float[][] vertices = new float[3][];

        // allow Zoom Fit
        float[][] vertices2D = new float[3][];

        // allow fast redrawing
        Vector normal;

        public TriangularFace(float[] p1, float[] p2, float[] p3, Color color) : base (color)
        {

            vertices[0] = new float[3];
            vertices[1] = new float[3];
            vertices[2] = new float[3];

            vertices[0] = p1;
            vertices[1] = p2;
            vertices[2] = p3;

            normal = Vector.GetNormal(vertices[0], vertices[1], vertices[2]);


        }

        // born for ReadBinarySTL
        public TriangularFace(float[] n, float[] p1, float[] p2, float[] p3, Color color)
            : base(color)
        {

            vertices[0] = new float[3];
            vertices[1] = new float[3];
            vertices[2] = new float[3];

            vertices[0] = p1;
            vertices[1] = p2;
            vertices[2] = p3;

            normal.x = n[0];
            normal.y = n[1];
            normal.z = n[2];


        }

        public override void ScaleNormal(float scale)
        {

            normal.Normalize();

            normal.x *= scale;
            normal.y *= scale;
            normal.z *= scale;

        }

        public override void Draw()
        {

            // Color selection in base class
            base.Draw();

            gl.Normal3f(normal.x, normal.y, normal.z);
            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);

        }

        public void DrawEdges()
        {

            // NORMAL AND PROJECTION NOT NEEDED

            // Color selection in base class
            base.Draw();

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);

        }

        public override void DrawForShadow()
        {

            gl.Vertex3fv(vertices[0]);
            gl.Vertex3fv(vertices[1]);
            gl.Vertex3fv(vertices[2]);

        }

        void ProjectVerticesOnScreen()
        {

            byte count = 0;

            foreach (float[] vertex in vertices)
            {

                float winX, winY, winZ;

                Label.Project(vertex[0], vertex[1], vertex[2], out winX, out winY, out winZ);

                vertices2D[count] = new float[2];

                vertices2D[count][0] = winX;
                vertices2D[count][1] = winY;

                count++;

            }

        }

        public override void BoundingBox(ref float xMin, ref float yMin, ref float zMin, ref float xMax, ref float yMax, ref float zMax)
        {

            foreach (float[] vertex in vertices)
            {

                if (vertex[0] < xMin)

                    xMin = vertex[0];

                if (vertex[0] > xMax)

                    xMax = vertex[0];

                if (vertex[1] < yMin)

                    yMin = vertex[1];

                if (vertex[1] > yMax)

                    yMax = vertex[1];

                if (vertex[2] < zMin)

                    zMin = vertex[2];

                if (vertex[2] > zMax)

                    zMax = vertex[2];


            }

        }

    }
}
