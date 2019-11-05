using Crash;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace CrashEdit
{
    public sealed class AnimationEntryViewer : ThreeDimensionalViewer
    {
        private static readonly int[] SignTable = { -1, -2, -4, -8, -16, -32, -64, -128 }; // used for decompression

        private List<Frame> frames;
        private ModelEntry model;
        private int frameid;
        private Timer animatetimer;
        private int interi;

        public AnimationEntryViewer(Frame frame,ModelEntry model)
        {
            frames = new List<Frame>();
            this.model = model;
            if (model.Positions != null)
                frames.Add(UncompressFrame(frame));
            else
                frames.Add(LoadFrame(frame));
            frameid = 0;
        }

        public AnimationEntryViewer(IEnumerable<Frame> frames,ModelEntry model)
        {
            this.frames = new List<Frame>();
            this.model = model;
            frameid = 0;
            interi = 0;
            if (model.Positions != null)
            {
                foreach (Frame frame in frames)
                {
                    this.frames.Add(UncompressFrame(frame));
                    frameid++;
                }
            }
            else
            {
                foreach (Frame frame in frames)
                {
                    this.frames.Add(LoadFrame(frame));
                    frameid++;
                }
            }
            frameid = 0;
            animatetimer = new Timer
            {
                Interval = 1000 / OldMainForm.GetRate() / 2,
                Enabled = true
            };
            animatetimer.Tick += delegate (object sender,EventArgs e)
            {
                animatetimer.Interval = 1000 / OldMainForm.GetRate() / 2;
                interi = ++interi % 2;
                frameid = (frameid + (interi == 1 ? 1 : 0)) % this.frames.Count;
                if (frameid == 0) interi = 0;
                Refresh();
            };
        }

        protected override int CameraRangeMargin
        {
            get
            {
                int i = Math.Max(BitConv.FromInt32(model.Info, 8),Math.Max(BitConv.FromInt32(model.Info,0),BitConv.FromInt32(model.Info,4))) * 400;
                if (model != null && model.Positions != null)
                    i /= 4;
                return i;
            }
        }

        protected override IEnumerable<IPosition> CorePositions
        {
            get
            {
                foreach (Frame frame in frames)
                {
                    foreach (FrameVertex vertex in frame.Vertices)
                    {
                        int x = (vertex.X + frame.XOffset / 4) * BitConv.FromInt32(model.Info,0);
                        int y = (vertex.Z + frame.YOffset / 4) * BitConv.FromInt32(model.Info,4);
                        int z = (vertex.Y + frame.ZOffset / 4) * BitConv.FromInt32(model.Info,8);
                        yield return new Position(x,y,z);
                    }
                }
            }
        }

        protected override void RenderObjects()
        {
            if (interi == 0)
            {
                RenderFrame(frames[frameid]);
            }
            else
            {
                RenderInterpolatedFrames(frames[frameid-1], frames[frameid]);
            }
        }

        private void RenderFrame(Frame frame)
        {
            if (model != null)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                GL.Begin(PrimitiveType.Triangles);
                for (int i = 0; i < model.PositionIndices.Count; ++i)
                {
                    int c = Math.Min(model.ColorIndices[i], model.ColorIndices.Count);
                    GL.Color3(model.Colors[c].Red, model.Colors[c].Green, model.Colors[c].Blue);
                    RenderVertex(frame, frame.Vertices[model.PositionIndices[i] + frame.SpecialVertexCount]);
                }
                GL.End();
            }
            else
            {
                GL.Begin(PrimitiveType.Points);
                foreach (FrameVertex vertex in frame.Vertices)
                {
                    RenderVertex(frame, vertex);
                }
                GL.End();
            }
        }

        private void RenderInterpolatedFrames(Frame f1, Frame f2)
        {
            if (model != null)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                GL.Begin(PrimitiveType.Triangles);
                for (int i = 0; i < model.PositionIndices.Count; ++i)
                {
                    int c = Math.Min(model.ColorIndices[i], model.ColorIndices.Count);
                    GL.Color3(model.Colors[c].Red, model.Colors[c].Green, model.Colors[c].Blue);
                    RenderInterpolatedVertices(f1,f2,f1.Vertices[model.PositionIndices[i] + f1.SpecialVertexCount], f2.Vertices[model.PositionIndices[i] + f2.SpecialVertexCount]);
                }
                GL.End();
            }
            else
            {
                GL.Begin(PrimitiveType.Points);
                for (int i = 0; i < f1.Vertices.Count; ++i)
                {
                    RenderInterpolatedVertices(f1,f2,f1.Vertices[i], f2.Vertices[i]);
                }
                GL.End();
            }
        }

        private void RenderVertex(Frame f, FrameVertex vertex)
        {
            GL.Vertex3((vertex.X + f.XOffset / 4) * BitConv.FromInt32(model.Info,0),(vertex.Z + f.YOffset / 4) * BitConv.FromInt32(model.Info,4),(vertex.Y + f.ZOffset / 4) * BitConv.FromInt32(model.Info,8));
        }

        private void RenderInterpolatedVertices(Frame f1, Frame f2, FrameVertex v1, FrameVertex v2)
        {
            int x1 = v1.X + f1.XOffset / 4;
            int x2 = v2.X + f2.XOffset / 4;
            int y1 = v1.Z + f1.YOffset / 4;
            int y2 = v2.Z + f2.YOffset / 4;
            int z1 = v1.Y + f1.ZOffset / 4;
            int z2 = v2.Y + f2.ZOffset / 4;
            GL.Vertex3((x1+x2)/2f * BitConv.FromInt32(model.Info,0),(y1+y2)/2f * BitConv.FromInt32(model.Info,4),(z1+z2)/2f * BitConv.FromInt32(model.Info,8));
        }

        private Frame UncompressFrame(Frame frame)
        {
            if (frame.Decompressed) return frame; // already decompressed
            int x_alu = 0;
            int y_alu = 0;
            int z_alu = 0;
            int bi = 0;
            for (int i = 0; i < model.Positions.Count; ++i)
            {
                int bx = model.Positions[i].X << 1;
                int by = model.Positions[i].Y;
                int bz = model.Positions[i].Z;
                if (model.Positions[i].XBits == 7)
                {
                    x_alu = 0;
                }
                if (model.Positions[i].YBits == 7)
                {
                    y_alu = 0;
                }
                if (model.Positions[i].ZBits == 7)
                {
                    z_alu = 0;
                }
                
                // XZY frame data
                int vx = frame.Temporals[bi++] ? SignTable[model.Positions[i].XBits] : 0;
                for (int j = 0; j < model.Positions[i].XBits; ++j)
                {
                    vx |= Convert.ToByte(frame.Temporals[bi++]) << (model.Positions[i].XBits - 1 - j);
                }

                int vz = frame.Temporals[bi++] ? SignTable[model.Positions[i].ZBits] : 0;
                for (int j = 0; j < model.Positions[i].ZBits; ++j)
                {
                    vz |= Convert.ToByte(frame.Temporals[bi++]) << (model.Positions[i].ZBits - 1 - j);
                }

                int vy = frame.Temporals[bi++] ? SignTable[model.Positions[i].YBits] : 0;
                for (int j = 0; j < model.Positions[i].YBits; ++j)
                {
                    vy |= Convert.ToByte(frame.Temporals[bi++]) << (model.Positions[i].YBits - 1 - j);
                }

                x_alu = (x_alu + vx + bx) % 256;
                y_alu = (y_alu + vy + by) % 256;
                z_alu = (z_alu + vz + bz) % 256;

                frame.Vertices[i] = new FrameVertex((byte)x_alu, (byte)y_alu, (byte)z_alu);
            }
            frame.Decompressed = true;
            return frame;
        }

        private Frame LoadFrame(Frame frame)
        {
            if (frame.Decompressed) return frame; // already loaded (no decompression was necessary though)
            bool[] uncompressedbitstream = new bool[frame.Temporals.Length];
            for (int i = 0; i < uncompressedbitstream.Length / 32;++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 8; ++k)
                    {
                        uncompressedbitstream[32*i+24-j*8+k] = frame.Temporals[32*i+j*8+k]; // replace this with a cool formula one day
                    }
                }
            }
            int bi = frame.SpecialVertexCount * 8 * 3;
            for (int i = frame.SpecialVertexCount; i < frame.Vertices.Count; ++i)
            {
                byte x = 0;
                for (int j = 0; j < 8; ++j)
                {
                    x |= (byte)(Convert.ToByte(uncompressedbitstream[bi++]) << (7-j));
                }
                
                byte y = 0;
                for (int j = 0; j < 8; ++j)
                {
                    y |= (byte)(Convert.ToByte(uncompressedbitstream[bi++]) << (7-j));
                }
                
                byte z = 0;
                for (int j = 0; j < 8; ++j)
                {
                    z |= (byte)(Convert.ToByte(uncompressedbitstream[bi++]) << (7-j));
                }
                
                frame.Vertices[i] = new FrameVertex(x,y,z);
            }
            frame.Decompressed = true;
            return frame;
        }

        protected override void Dispose(bool disposing)
        {
            if (animatetimer != null)
            {
                animatetimer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
