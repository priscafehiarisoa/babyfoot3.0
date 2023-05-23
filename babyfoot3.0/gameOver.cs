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
    public partial class gameOver : Form
    {
        foot_game foot;
        Jeu jeu;
        int idwinner;
        int pointsEquipe1;
        int pointsEquipe2;
        String connectionString = "Server=localhost;Port=5432;Database=babyfoot; User Id=postgres; Password=12345678";



        public gameOver(int Equipe1, int equipe2, foot_game foot, Jeu game)
        {
            InitializeComponent();
            this.jeu = game;
            this.pointsEquipe1 = Equipe1;
            this.pointsEquipe2=equipe2;
            setwinner();
            e1.Text = Equipe1.ToString();
            e2.Text = equipe2.ToString();
            double winnerShare = this.jeu.getWinnerShare();
            double ownerShare = this.jeu.getOwnerShare();
            miseJ.Text = winnerShare.ToString();
            miseP.Text = ownerShare.ToString();
            // ajout en caisse
            if (pointsEquipe1 != pointsEquipe2)
            {
                Caisse winner = new Caisse(idwinner, winnerShare);
                Caisse proprio = new Caisse(this.jeu.idOwner, ownerShare);
                proprio.InsertCaisse(connectionString);
                winner.InsertCaisse(connectionString);    
            }




            label6.Text = "mises: "+ this.jeu.mise1 + " " + this.jeu.mise2;

            this.foot = foot;


        }

        private void setwinner()
        {
            if (pointsEquipe1 > pointsEquipe2)
            {
                idwinner = jeu.idJoueur1;
            }
            else
            {
                idwinner = jeu.idJoueur2;
            }
        }

        private void gameOver_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foot.Dispose();
            this.Dispose();
        }
    }
}
