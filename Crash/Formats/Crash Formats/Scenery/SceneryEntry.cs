using System.IO;
using System.Collections.Generic;

namespace Crash
{
    public sealed class SceneryEntry : Entry
    {
        private byte[] info;
        private List<SceneryVertex> vertices;
        private List<SceneryTriangle> triangles;
        private List<SceneryQuad> quads;
        private List<ModelTexture> textures;
        private List<SceneryColor> colors;
        private List<ModelAnimatedTexture> animatedtextures;

        public SceneryEntry(byte[] info,IEnumerable<SceneryVertex> vertices,IEnumerable<SceneryTriangle> triangles,IEnumerable<SceneryQuad> quads,IEnumerable<ModelTexture> textures,IEnumerable<SceneryColor> colors,IEnumerable<ModelAnimatedTexture> animatedtextures,int eid,int size)
            : base(eid,size)
        {
            this.info = info;
            this.vertices = new List<SceneryVertex>(vertices);
            this.triangles = new List<SceneryTriangle>(triangles);
            this.quads = new List<SceneryQuad>(quads);
            this.textures = new List<ModelTexture>(textures);
            this.colors = new List<SceneryColor>(colors);
            this.animatedtextures = new List<ModelAnimatedTexture>(animatedtextures);
        }

        public override int Type
        {
            get { return 3; }
        }

        public byte[] Info
        {
            get { return info; }
        }

        public IList<SceneryVertex> Vertices
        {
            get { return vertices; }
        }

        public IList<SceneryTriangle> Triangles
        {
            get { return triangles; }
        }

        public IList<SceneryQuad> Quads
        {
            get { return quads; }
        }

        public IList<ModelTexture> Textures
        {
            get { return textures; }
        }

        public IList<SceneryColor> Colors
        {
            get { return colors; }
        }

        public IList<ModelAnimatedTexture> AnimatedTextures
        {
            get { return animatedtextures; }
        }

        public int XOffset
        {
            get { return BitConv.FromInt32(info,0); }
            set { XOffset = BitConv.FromInt32(info,0); ; }
        }

        public int YOffset
        {
            get { return BitConv.FromInt32(info,4); }
            set { YOffset = BitConv.FromInt32(info,4); ; }
        }

        public int ZOffset
        {
            get { return BitConv.FromInt32(info,8); }
            set { ZOffset = BitConv.FromInt32(info,8); ; }
        }

        public override UnprocessedEntry Unprocess()
        {
            byte[][] items = new byte [7][];
            items[0] = info;
            items[1] = new byte [vertices.Count * 6];
            for (int i = 0;i < vertices.Count;i++)
            {
                vertices[i].SaveXY().CopyTo(items[1],(vertices.Count - 1 - i) * 4);
                vertices[i].SaveZ().CopyTo(items[1],vertices.Count * 4 + i * 2);
            }
            items[2] = new byte [triangles.Count * 6];
            for (int i = 0;i < triangles.Count;i++)
            {
                triangles[i].SaveA().CopyTo(items[2],(triangles.Count - 1 - i) * 4);
                triangles[i].SaveB().CopyTo(items[2],triangles.Count * 4 + i * 2);
            }
            items[3] = new byte [quads.Count * 8];
            for (int i = 0;i < quads.Count;i++)
            {
                quads[i].Save().CopyTo(items[3],i * 8);
            }
            items[4] = new byte[textures.Count * 12];
            for (int i = 0; i < textures.Count; i++)
            {
                textures[i].Save().CopyTo(items[4], i * 12);
            }
            items[5] = new byte[colors.Count * 4];
            for (int i = 0; i < colors.Count; i++)
            {
                items[5][i * 4] = Colors[i].Red;
                items[5][i * 4 + 1] = Colors[i].Green;
                items[5][i * 4 + 2] = Colors[i].Blue;
                items[5][i * 4 + 3] = Colors[i].Extra;
            }
            items[6] = new byte[animatedtextures.Count * 4];
            for (int i = 0; i < animatedtextures.Count; i++)
            {
                animatedtextures[i].Save().CopyTo(items[6], i * 4);
            }
            return new UnprocessedEntry(items,EID,Type,Size);
        }

        public byte[] ToOBJ()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter obj = new StreamWriter(stream))
                {
                    obj.WriteLine("# Vertices");
                    foreach (SceneryVertex vertex in vertices)
                    {
                        if (vertex.Color < Colors.Count)
                        {
                            SceneryColor color = Colors[vertex.Color];
                            obj.WriteLine("v {0} {1} {2} {3} {4} {5}", vertex.X + XOffset / 4, vertex.Y + YOffset / 4, vertex.Z + ZOffset / 4, color.Red / 255.0, color.Green / 255.0, color.Blue / 255.0);
                        }
                        else
                        {
                            obj.WriteLine("v {0} {1} {2}", vertex.X + XOffset / 4, vertex.Y + YOffset / 4, vertex.Z + ZOffset / 4);
                        }
                    }
                    obj.WriteLine();
                    obj.WriteLine("# Triangles");
                    foreach (SceneryTriangle triangle in triangles)
                    {
                        obj.WriteLine("f {0} {1} {2}", triangle.VertexA + 1, triangle.VertexB + 1, triangle.VertexC + 1);
                    }
                    obj.WriteLine();
                    obj.WriteLine("# Quads");
                    foreach (SceneryQuad quad in quads)
                    {
                        obj.WriteLine("f {0} {1} {2} {3}", quad.VertexA + 1, quad.VertexB + 1, quad.VertexC + 1, quad.VertexD + 1);
                    }
                }
                return stream.ToArray();
            }
        }

        public byte[] ToPLY()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter ply = new StreamWriter(stream))
                {
                    int polycount = 0;
                    foreach (SceneryTriangle triangle in triangles)
                    {
                        if (triangle.VertexA < vertices.Count)
                        {
                            if (triangle.VertexB < vertices.Count)
                            {
                                if (triangle.VertexC < vertices.Count)
                                {
                                    polycount++;
                                }
                            }
                        }
                    }
                    foreach (SceneryQuad quad in quads)
                    {
                        if (quad.VertexA < vertices.Count)
                        {
                            if (quad.VertexB < vertices.Count)
                            {
                                if (quad.VertexC < vertices.Count)
                                {
                                    if (quad.VertexD < vertices.Count)
                                    {
                                        polycount++;
                                    }
                                }
                            }
                        }
                    }
                    ply.WriteLine("ply");
                    ply.WriteLine("format ascii 1.0");
                    ply.WriteLine("element vertex {0}",Vertices.Count);
                    ply.WriteLine("property int x");
                    ply.WriteLine("property int y");
                    ply.WriteLine("property int z");
                    ply.WriteLine("property uchar red");
                    ply.WriteLine("property uchar green");
                    ply.WriteLine("property uchar blue");
                    ply.WriteLine("element face {0}",polycount);
                    ply.WriteLine("property list uchar int vertex_index");
                    ply.WriteLine("end_header");
                    foreach (SceneryVertex vertex in vertices)
                    {
                        if (vertex.Color < Colors.Count)
                        {
                            SceneryColor color = Colors[vertex.Color];
                            ply.WriteLine("{0} {1} {2} {3} {4} {5}", vertex.X + XOffset / 4, vertex.Y + YOffset / 4, vertex.Z + ZOffset / 4, color.Red, color.Green, color.Blue);
                        }
                        else
                        {
                            ply.WriteLine("{0} {1} {2} 255 0 255", vertex.X + XOffset / 4, vertex.Y + YOffset / 4, vertex.Z + ZOffset / 4);
                        }
                    }
                    foreach (SceneryTriangle triangle in triangles)
                    {
                        if (triangle.VertexA < vertices.Count)
                        {
                            if (triangle.VertexB < vertices.Count)
                            {
                                if (triangle.VertexC < vertices.Count)
                                {
                                    ply.WriteLine("3 {0} {1} {2}", triangle.VertexA, triangle.VertexB, triangle.VertexC);
                                }
                            }
                        }
                    }
                    foreach (SceneryQuad quad in quads)
                    {
                        if (quad.VertexA < vertices.Count && quad.VertexB < vertices.Count && quad.VertexC < vertices.Count && quad.VertexD < vertices.Count)
                        {
                            ply.WriteLine("4 {0} {1} {2} {3}", quad.VertexA, quad.VertexB, quad.VertexC, quad.VertexD);
                        }
                    }
                }
                return stream.ToArray();
            }
        }

        /*public byte[] ToCOLLADA()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter textwriter = new StreamWriter(stream))
                using (XmlTextWriter xmlwriter = new XmlTextWriter(textwriter))
                {
                    xmlwriter.WriteStartDocument();
                    xmlwriter.WriteStartElement("COLLADA");
                    xmlwriter.WriteAttributeString("xmlns", "http://www.collada.org/2005/11/COLLADASchema");
                    xmlwriter.WriteAttributeString("version", "1.4.1");
                    xmlwriter.WriteStartElement("library_geometries");
                    xmlwriter.WriteStartElement("geometry");
                    xmlwriter.WriteStartElement("mesh");
                    xmlwriter.WriteStartElement("source");
                    xmlwriter.WriteAttributeString("id", "positions");
                    xmlwriter.WriteStartElement("float_array");
                    xmlwriter.WriteAttributeString("id", "positions-array");
                    xmlwriter.WriteAttributeString("count", (vertices.Count * 3).ToString());
                    foreach (NewSceneryVertex vertex in vertices)
                    {
                        xmlwriter.WriteValue(vertex.X + XOffset / 4);
                        xmlwriter.WriteWhitespace(" ");
                        xmlwriter.WriteValue(vertex.Y + YOffset / 4);
                        xmlwriter.WriteWhitespace(" ");
                        xmlwriter.WriteValue(vertex.Z + ZOffset / 4);
                        xmlwriter.WriteWhitespace(" ");
                    }
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("technique_common");
                    xmlwriter.WriteStartElement("accessor");
                    xmlwriter.WriteAttributeString("source", "#positions-array");
                    xmlwriter.WriteAttributeString("count", vertices.Count.ToString());
                    xmlwriter.WriteAttributeString("stride", "3");
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "X");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "Y");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "Y");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("source");
                    xmlwriter.WriteAttributeString("id", "colors");
                    xmlwriter.WriteStartElement("float_array");
                    xmlwriter.WriteAttributeString("id", "colors-array");
                    xmlwriter.WriteAttributeString("count", (vertices.Count * 3).ToString());
                    foreach (NewSceneryVertex vertex in vertices)
                    {
                        if (vertex.Color < Colors.Count)
                        {
                            SceneryColor color = Colors[vertex.Color];
                            xmlwriter.WriteValue(color.Red / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                            xmlwriter.WriteValue(color.Green / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                            xmlwriter.WriteValue(color.Blue / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                        }
                        else
                        {
                            xmlwriter.WriteValue(256.0 / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                            xmlwriter.WriteValue(0 / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                            xmlwriter.WriteValue(256.0 / 256.0);
                            xmlwriter.WriteWhitespace(" ");
                        }
                    }
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("technique_common");
                    xmlwriter.WriteStartElement("accessor");
                    xmlwriter.WriteAttributeString("source", "#colors-array");
                    xmlwriter.WriteAttributeString("count", vertices.Count.ToString());
                    xmlwriter.WriteAttributeString("stride", "3");
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "R");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "G");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("param");
                    xmlwriter.WriteAttributeString("name", "B");
                    xmlwriter.WriteAttributeString("type", "float");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("vertices");
                    xmlwriter.WriteAttributeString("id", "vertices");
                    xmlwriter.WriteStartElement("input");
                    xmlwriter.WriteAttributeString("semantic", "POSITION");
                    xmlwriter.WriteAttributeString("source", "positions");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("input");
                    xmlwriter.WriteAttributeString("semantic", "COLOR");
                    xmlwriter.WriteAttributeString("source", "colors");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("triangles");
                    xmlwriter.WriteAttributeString("count", triangles.Count.ToString());
                    xmlwriter.WriteStartElement("input");
                    xmlwriter.WriteAttributeString("semantic", "VERTEX");
                    xmlwriter.WriteAttributeString("source", "vertices");
                    xmlwriter.WriteAttributeString("offset", "0");
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteStartElement("p");
                    foreach (SceneryTriangle triangle in triangles)
                    {
                        xmlwriter.WriteValue(triangle.VertexA);
                        xmlwriter.WriteWhitespace(" ");
                        xmlwriter.WriteValue(triangle.VertexB);
                        xmlwriter.WriteWhitespace(" ");
                        xmlwriter.WriteValue(triangle.VertexC);
                        xmlwriter.WriteWhitespace(" ");
                    }
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndElement();
                    xmlwriter.WriteEndDocument();
                }
                return stream.ToArray();
            }
        }*/
    }
}
