using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace babyfoot3._0
{



    public partial class MainGame : Form

    {
        public List<PictureBox> barre1;
        public List<PictureBox> barre2;
        public MainGame()
        {
            InitializeComponent();

        }

        private void key_is_pressed(object sender, KeyPressEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Left = 30;
            LeftRightAlignment t= new LeftRightAlignment();
            panel1.Scale(45);
            
        }
    }


}
