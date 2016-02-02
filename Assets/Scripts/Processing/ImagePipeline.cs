using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ImagePipeline
{
    public class ImagePipeline : MonoBehaviour
    {
        //Height of pixel intensity in nanometers rounded to nearest int
        public float pixel_height = 1;

        //Width to search for neighbour
        public int searchwidth = 1;

        //Minimum number of pixels to make a shape
        public int minPixelInShapeThreshold = 3;

        //Height of slice in nanometers
        public int slice_height = 5000;

        public int pixel_threshold = 200;

        public Vector2[] debugvectors;

        public string filetypefilter = "*.jpeg";

        public Mesh mesh;
        public Vector2[] uvs;
        public int[] triangles;

        public Texture2D heightmap, image;

        public Material material;

        public List<List<Vector3>> vertices;
        public List<List<Vector2>> vertices2D;

        public bool image_loaded = false, outputtextfile = false;

        public gg.Mesh.Form1 delaunay;

        public int verticespermesh, mesh_generatelimit;

        public Mesh[] meshes;

        public int counter, pixels_perframe;
        public List<Color> imagepixels;

        public int height, width;

        List<List<Color>> shapes;

        public void Init()
        {
            vertices = new List<List<Vector3>>();
            vertices2D = new List<List<Vector2>>();

            mesh = new Mesh();
            delaunay = new gg.Mesh.Form1();
        }

        public void Start()
        {
            Init();

            //Extract shapes
            Shapes shapeprocessing = new Shapes();
            shapeprocessing.ProcessImage(searchwidth, minPixelInShapeThreshold, heightmap, image, ref shapes, ref vertices, ref vertices2D);

			//Output to text file
			Utilities.WriteVertices2DToText (vertices2D);


            //Triangulate
            Triangulation triangulationprocessing = new Triangulation();
			triangulationprocessing.defaultMaterial = new Material (Shader.Find ("Diffuse"));
            triangulationprocessing.Triangulate(ref shapes, outputtextfile, ref vertices, ref vertices2D);
        }

        void Update()
        {
        }
    }
}