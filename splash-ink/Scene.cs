using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splash_ink
{
    public partial class Scene : Form
    {
        Painter painter;
        public Scene()
        {
            InitializeComponent();
            InitType();
        }

        private void InitType()
        {
            foreach(Painter.PaintType pt in Enum.GetValues(typeof(Painter.PaintType)))
            {
                this.cmb.Items.Add(pt.ToString());
            }
            this.cmb.SelectedIndex = 0;
        }

        private void Scene_Load(object sender, EventArgs e)
        {
            this.picMain.Image = global::Splash_ink.Properties.Resources.mainpic;
            this.picSource.Image = global::Splash_ink.Properties.Resources.sourcepic;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.SetControlStatus(false);

            painter = new Painter(picMain, picSource, this.tb.Value);
            painter.Paint(this.cmb.Text);

            this.SetControlStatus(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            painter.CanPinter = false;
            this.SetControlStatus(true);
            this.btnStop.Enabled = false;
        }
        private void btnOver_Click(object sender, EventArgs e)
        {
            painter.OverPinting = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (painter.Save())
            {
                MessageBox.Show("Save succeed!");
            }
        }

        private void btnSelectMainPic_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(this.ofd.FileName);
                this.picMain.Image = image;
            }
        }

        private void btnSelectSourcePic_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(this.ofd.FileName);
                this.picSource.Image = image;
            }
        }

        private void SetControlStatus(Boolean state)
        {
            this.btnOk.Enabled = state;
            this.btnSave.Enabled = state;
            this.btnStop.Enabled = state;
            this.btnSelectMainPic.Enabled = state;
            this.btnSelectSourcePic.Enabled = state;
        }
    }
}
