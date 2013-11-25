using System;

namespace Crash
{
    [EntryType(3,GameVersion.Crash2)]
    [EntryType(3,GameVersion.Crash3)]
    public sealed class SceneryEntryLoader : EntryLoader
    {
        public override Entry Load(byte[][] items,int eid)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            if (items.Length != 7)
            {
                ErrorManager.SignalError("SceneryEntry: Wrong number of items");
            }
            if (items[0].Length != 76)
            {
                ErrorManager.SignalError("SceneryEntry: First item length is wrong");
            }
            // TODO :: Get vertexcount from info
            int vertexcount = items[1].Length / 6;
            // TODO :: Check vertex list size
            SceneryVertex[] vertices = new SceneryVertex [vertexcount];
            for (int i = 0;i < vertexcount;i++)
            {
                byte[] xydata = new byte [4];
                byte[] zdata = new byte [2];
                Array.Copy(items[1],(vertexcount - 1 - i) * 4,xydata,0,xydata.Length);
                Array.Copy(items[1],vertexcount * 4 + i * 2,zdata,0,zdata.Length);
                vertices[i] = SceneryVertex.Load(xydata,zdata);
            }
            // TODO :: Get polygoncount from info
            int polygoncount = items[3].Length / 8;
            // TODO :: Check polygon list size
            SceneryPolygon[] polygons = new SceneryPolygon [polygoncount];
            for (int i = 0;i < polygoncount;i++)
            {
                byte[] polygondata = new byte [8];
                Array.Copy(items[3],i * 8,polygondata,0,polygondata.Length);
                polygons[i] = SceneryPolygon.Load(polygondata);
            }
            // TODO :: Get colorcount from info
            int colorcount = items[5].Length / 4;
            // TODO :: Check color list size
            SceneryColor[] colors = new SceneryColor [colorcount];
            for (int i = 0;i < colorcount;i++)
            {
                byte red = items[5][i * 4];
                byte green = items[5][i * 4 + 1];
                byte blue = items[5][i * 4 + 2];
                byte extra = items[5][i * 4 + 3];
                colors[i] = new SceneryColor(red,green,blue,extra);
            }
            return new SceneryEntry(items[0],vertices,items[2],polygons,items[4],colors,items[6],eid);
        }
    }
}
