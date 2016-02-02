﻿namespace gg.Mesh
{
    using System;
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Vertex class
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// Vertex default constructor.
        /// </summary>
        public Vertex()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// Vertex constructor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// X coordinate.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y coordinate.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Z coordinate.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Index of this vertex.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Delta distance squared between this and other vertex t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public float DeltaSquaredXY(Vertex t)
        {
            float dx = (X - t.X);
            float dy = (Y - t.Y);
            return (dx * dx) + (dy * dy);
        }

        /// <summary>
        /// Delta distance squared between this and other vertex t
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public float DeltaSquared(Vertex t)
        {
            float dx = (X - t.X);
            float dy = (Y - t.Y);
            float dz = (Z - t.Z);
            return (dx * dx) + (dy * dy) + (dz * dz);
        }

        /// <summary>
        /// The distance between this and t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public float DistanceXY(Vertex t)
        {
            return (float)System.Math.Sqrt(DeltaSquaredXY(t));
        }

        /// <summary>
        /// The distance between this and t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public float Distance(Vertex t)
        {
            return (float)System.Math.Sqrt(DeltaSquared(t));
        }

        /// <summary>
        /// Is this rectangle within the region.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public bool InsideXY(Rect region)
        {
            if (X < region.xMin) return false;
            if (X > region.xMax) return false;
            if (Y < region.yMin) return false;
            if (Y > region.yMax) return false;
            return true;
        }

        /// <summary>
        /// To string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return X + ", " + Y;
        }
    }
}
