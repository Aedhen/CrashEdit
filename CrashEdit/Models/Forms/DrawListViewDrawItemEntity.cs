namespace CrashEdit.Models.Forms
{
    public class DrawListViewDrawItemEntity
    {
        public DrawListViewDrawItemEntity()
        {
            LoadCount = 1;
        }

        public short? Position { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public int Subtype { get; set; }

        public int LoadCount { get; set; }

        public string NodeText
        {
            get
            {
                var nodeText = $"{Position} - ID {Id}, {Name} - {Type} {Subtype}";
                if (LoadCount > 1)
                {
                    nodeText += $" (times loaded: {LoadCount})";
                }

                return nodeText;
            }
        }
    }
}