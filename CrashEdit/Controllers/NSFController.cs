using Crash;
using System;

namespace CrashEdit
{
    public sealed class NSFController : Controller
    {
        private NSF nsf;
        private GameVersion gameversion;

        public NSFController(NSF nsf,GameVersion gameversion)
        {
            this.nsf = nsf;
            this.gameversion = gameversion;
            Node.Text = "NSF File";
            Node.ImageKey = "nsf";
            Node.SelectedImageKey = "nsf";
            foreach (Chunk chunk in nsf.Chunks)
            {
                if (chunk is NormalChunk)
                {
                    AddNode(new NormalChunkController(this,(NormalChunk)chunk));
                }
                else if (chunk is TextureChunk)
                {
                    AddNode(new TextureChunkController(this,(TextureChunk)chunk));
                }
                else if (chunk is OldSoundChunk)
                {
                    AddNode(new OldSoundChunkController(this,(OldSoundChunk)chunk));
                }
                else if (chunk is SoundChunk)
                {
                    AddNode(new SoundChunkController(this,(SoundChunk)chunk));
                }
                else if (chunk is WavebankChunk)
                {
                    AddNode(new WavebankChunkController(this,(WavebankChunk)chunk));
                }
                else if (chunk is SpeechChunk)
                {
                    AddNode(new SpeechChunkController(this,(SpeechChunk)chunk));
                }
                else if (chunk is UnprocessedChunk)
                {
                    AddNode(new UnprocessedChunkController(this,(UnprocessedChunk)chunk));
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            AddMenu("Add Chunk - Normal",Menu_Add_NormalChunk);
            AddMenu("Add Chunk - Sound",Menu_Add_SoundChunk);
            AddMenu("Add Chunk - Wavebank",Menu_Add_WavebankChunk);
            AddMenu("Add Chunk - Speech",Menu_Add_SpeechChunk);
        }

        public NSF NSF
        {
            get { return nsf; }
        }

        public GameVersion GameVersion
        {
            get { return gameversion; }
        }

        private void Menu_Add_NormalChunk()
        {
            NormalChunk chunk = new NormalChunk();
            nsf.Chunks.Add(chunk);
            NormalChunkController controller = new NormalChunkController(this,chunk);
            AddNode(controller);
        }

        private void Menu_Add_SoundChunk()
        {
            SoundChunk chunk = new SoundChunk();
            nsf.Chunks.Add(chunk);
            SoundChunkController controller = new SoundChunkController(this,chunk);
            AddNode(controller);
        }

        private void Menu_Add_WavebankChunk()
        {
            WavebankChunk chunk = new WavebankChunk();
            nsf.Chunks.Add(chunk);
            WavebankChunkController controller = new WavebankChunkController(this,chunk);
            AddNode(controller);
        }

        private void Menu_Add_SpeechChunk()
        {
            SpeechChunk chunk = new SpeechChunk();
            nsf.Chunks.Add(chunk);
            SpeechChunkController controller = new SpeechChunkController(this,chunk);
            AddNode(controller);
        }
    }
}
