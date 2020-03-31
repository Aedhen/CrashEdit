﻿using Crash;
using System;
using System.Windows.Forms;

namespace CrashEdit
{
    public partial class Crash3AnimationSelector : UserControl
    {
        private NSF nsf;
        private AnimationEntry anim;
        private Frame frame;
        private Control rewardcontrol;

        public Crash3AnimationSelector(AnimationEntry anim, NSF nsf)
        {
            this.nsf = nsf;
            this.anim = anim;
            this.frame = null;
            rewardcontrol = null;

            Dock = DockStyle.Fill;
            InitializeComponent();

            if (Program.C3AnimLinks.ContainsKey(anim.EID))
            {
                txtEName.Text = Entry.EIDToEName(Program.C3AnimLinks[anim.EID]);
                OnKeyDown_Func(null, new KeyEventArgs(Keys.Enter));
            }

            txtEName.KeyDown += new KeyEventHandler(OnKeyDown_Func);
        }

        public Crash3AnimationSelector(Frame frame, NSF nsf)
        {
            this.nsf = nsf;
            this.anim = null;
            this.frame = frame;
            rewardcontrol = null;



            Dock = DockStyle.Fill;
            InitializeComponent();

            txtEName.KeyDown += new KeyEventHandler(OnKeyDown_Func);
        }

        private void OnKeyDown_Func(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && rewardcontrol == null)
            {
                lblEIDErr.Text = Entry.CheckEIDErrors(txtEName.Text, false);
                if (lblEIDErr.Text == string.Empty)
                {
                    ModelEntry modelentry = nsf.FindEID<ModelEntry>(Entry.ENameToEID(txtEName.Text));
                    if (modelentry != null)
                    {
                        if (anim != null)
                        {
                            foreach (Frame f in anim.Frames)
                            {
                                if (f.Vertices.Count != modelentry.VertexCount)
                                {
                                    lblEIDErr.Visible = true;
                                    lblEIDErr.Text = "Invalid Model: wrong vertex count";
                                    return;
                                }
                            }
                        }
                        else if (frame.Vertices.Count != modelentry.VertexCount)
                        {
                            lblEIDErr.Visible = true;
                            lblEIDErr.Text = "Invalid Model: wrong vertex count";
                            return;
                        }
                    }
                    foreach (Control control in Controls)
                    {
                        control.Visible = control.Enabled = false;
                    }
                    if (modelentry != null)
                    {
                        TextureChunk[] texturechunks = new TextureChunk[modelentry.TPAGCount];
                        for (int i = 0; i < texturechunks.Length; ++i)
                        {
                            texturechunks[i] = nsf.FindEID<TextureChunk>(BitConv.FromInt32(modelentry.Info,0xC+i*4));
                        }
                        if (anim != null)
                        {
                            if (sender != null)
                            {
                                Program.C3AnimLinks.Add(anim.EID, modelentry.EID);
                            }
                            rewardcontrol = new UndockableControl(new AnimationEntryViewer(anim.Frames,modelentry,texturechunks));
                        }
                        else
                        {
                            rewardcontrol = new UndockableControl(new AnimationEntryViewer(frame,modelentry,texturechunks));
                        }
                    }
                    else
                    {
                        if (anim != null)
                        {
                            rewardcontrol = new UndockableControl(new AnimationEntryViewer(anim.Frames,null,null));
                        }
                        else
                        {
                            rewardcontrol = new UndockableControl(new AnimationEntryViewer(frame,null,null));
                        }
                    }
                    rewardcontrol.Dock = DockStyle.Fill;
                    Controls.Add(rewardcontrol);
                }
                else
                {
                    lblEIDErr.Visible = true;
                }
            }
            else if (rewardcontrol != null && e.KeyCode == Keys.Enter)
            {
                Controls.Remove(rewardcontrol);
                rewardcontrol.Dispose();
                rewardcontrol = null;
                foreach (Control control in Controls)
                {
                    control.Visible = control.Enabled = true;
                }
                lblEIDErr.Text = Entry.CheckEIDErrors(txtEName.Text, false);
                lblEIDErr.Visible = lblEIDErr.Text != string.Empty;
            }
        }

        private void txtEName_TextChanged(object sender, EventArgs e)
        {
            lblEIDErr.Text = Entry.CheckEIDErrors(txtEName.Text, false);
            lblEIDErr.Visible = lblEIDErr.Text != string.Empty;
        }
    }
}
