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

    public partial class foot_game : Form
    {
        int x_Origin = 102;
        int y_Origin = 68;
        int y_end = 1068-68;
        int x_end = 1667-102;

        int widthT { get; set; }
        int heightT { get; set; }
        List<Joueur> joueurs1 { get; set; }
        List<Joueur> joueurs2 { get; set; }

        bool ballinMoove = false;
        int ballSpeed = 8;
        bool ballGoleft = true;
        bool ballGoRight = false;
        bool ballOwned = false;

        bool shootingLeft = false;
        bool shootingRight = false;

        List<Keys> equipe1Keys { get; set; }
        List<Keys> equipe2Keys { get; set; }

        List<PositionPlayer> directionBalle;
        List<String> labelDirection;
        int indexDirection;

        //donnees dur la base de donnees 
        Jeu currentGame { get;set; }
        int idJeu { get;set; }
        int idEquipe1 { get;set; }
        int idEquipe2 { get; set; }
        //donnees sur les points 
        int pointsEquipe1 { get; set; }
        int pointsEquipe2
        { get; set; }
        //connection string 
        String connectionString = "Server=localhost;Port=5432;Database=babyfoot; User Id=postgres; Password=12345678";

        //nombre de tours et apres game over

        int Tours
        { get;set; }

        bool loadGameOVER=false;

        // gestion du jeu 
        bool loadGame { get; set; }

        int positionSelectEquipe1 { get; set; }
        int positionSelectEquipe2 { get; set; }
        public foot_game()
        {

            InitializeComponent();
            startGame();

        }

        public void startGame()
        {
            Color[] c = new Color[10];
            c[0] = Color.Red;
            c[1] = Color.Gold;
            c[2] = Color.Gray;
            c[3] = Color.Green;
            c[4] = Color.Yellow;
            c[5] = Color.Magenta;
            c[6] = Color.Maroon;
            c[7] = Color.Blue;
            c[8] = Color.BlueViolet;
            c[9] = Color.Pink;
            //initialisation jeu 
           

            this.currentGame = (new Jeu()).GetLastInsertedJeu(connectionString);
            idJeu = currentGame.idjeu;
            idEquipe1 = currentGame.idJoueur1;
            idEquipe2 = currentGame.idJoueur2;

            //initialisation points
            pointsEquipe1 = 0; pointsEquipe2=0;
            scoreE1.Text = pointsEquipe1.ToString();
            scoreE2.Text = pointsEquipe2.ToString();

            //set nombre de tours
            Tours = 3;

            //load game
            loadGame = true;

            // set keys :
            List<Keys> E1 = new List<Keys>() { Keys.O, Keys.K, Keys.L, Keys.Oem1, Keys.P };
            //E1.Append(Keys.I);//up->0
            //E1.Append(Keys.J);//left->1
            //E1.Append(Keys.K);//down->2
            //E1.Append(Keys.L);//right->3
            //E1.Append(Keys.P);//change de joueur->4

            this.equipe1Keys = E1;



            List<Keys> E2 = new List<Keys>() { Keys.W, Keys.A, Keys.S, Keys.D, Keys.Q };
            //Keys W = Keys.W;
            //E2.Append(Keys.W);//up->0
            //E2.Append(Keys.A);//left->1
            //E2.Append(Keys.S);//down->2
            //E2.Append(Keys.D);//right->3
            //E2.Append(Keys.Q);//change de joueurs->4

            this.equipe2Keys = E2;


            label1.Text = E2.Count().ToString();

             
            this.ballGoleft = true;
            this.widthT = this.Width; this.heightT = this.Height;
            this.joueurs1 = Joueur.setEquipe(x_end, y_end, c[7], true);
            this.joueurs2 = Joueur.setEquipe(x_end, y_end, c[1], false);
            this.positionSelectEquipe1 = 8;
            this.positionSelectEquipe2 = 8;
            this.joueurs1[this.positionSelectEquipe1].Tag = "main1";
            this.joueurs2[this.positionSelectEquipe2].Tag = "main2";

            this.joueurs1[this.positionSelectEquipe1].BackColor = Color.Aquamarine;

            this.joueurs2[this.positionSelectEquipe2].BackColor = Color.LightYellow;

            //position de la balle 
            balle.Left = x_end / 2;
            balle.Top = y_end / 2;

            // set directions de la balle

            this.directionBalle = new List<PositionPlayer>() { new PositionPlayer(10,0), // go right
                                                                new PositionPlayer(10,-10),// go 45 % top-right
                                                                    new PositionPlayer(0,-10), // go top
                                                                    new PositionPlayer(-10,-10), //go top left
                                                                    new PositionPlayer(-10,0), // go left
                                                                    new PositionPlayer(-10,10), // go bottom-left
                                                                    new PositionPlayer(0,10),// go bottom
                                                                     new PositionPlayer(10,10)};// go bottom-right
            //label direction 
            this.labelDirection = new List<string>() { "go right", "top-right", "top", "top-Left", "left", "bottom-left", "bottom", "bottom-right" };
            // set index-direction
            this.indexDirection = 0;
            label3.Text = labelDirection[indexDirection];


            for (int i = 0; i < joueurs1.Count; i++)
            {
                this.gamePanel.Controls.Add(this.joueurs1[i]);
            }
            for (int i = 0; i < joueurs2.Count; i++)
            {
                this.gamePanel.Controls.Add(this.joueurs2[i]);
            }

        }




        private void mainGameTimer(object sender, EventArgs e)
        {
            if(Tours==0)
            {
                loadGame = false;
            }
            if(!loadGame && !loadGameOVER)
            {
                gameOver go=new gameOver(pointsEquipe1,pointsEquipe2,this,this.currentGame);
                go.Top = gamePanel.Height / 3;
                go.Left = gamePanel.Width / 3;
                go.Show();
                loadGameOVER = true;

            }
            if (ballinMoove)
            {
                mooveTheBall();
            }
            else if (shootingLeft)
            {
                balle.Left -= 20;
            }
            else if (shootingRight)
            {
                balle.Left += 20;
            }
            buuuts();


            if (this.joueurs1[this.positionSelectEquipe1].Bounds.IntersectsWith(this.joueurs2[this.positionSelectEquipe2].Bounds))
            {
                label1.Text = "collision";
            }

            foreach (Control x in this.Controls)
            {
                if ((String)x.Tag == "balle")
                {
                    x.BackColor = Color.Pink;
                    if (this.joueurs1[this.positionSelectEquipe1].Bounds.IntersectsWith(x.Bounds))
                    {
                        label1.Text = "touche la balle";

                    }
                }

                else if ((String)x.Tag == "joueur")
                {
                    if (this.joueurs1[this.positionSelectEquipe1].Bounds.IntersectsWith(x.Bounds))
                    {
                        label1.Text = "collision autre joueurs";
                    }
                }


            }


        }

        private void foot_game_Load(object sender, EventArgs e)
        {

        }

        private void key_isPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals("A"))
            {
                this.joueurs1[this.positionSelectEquipe1].Left += 10;
            }
        }

        private void key_is_up(object sender, KeyEventArgs e)
        {
            label2.Text = e.KeyCode.ToString()+ " "+ ballinMoove;


            if (loadGame)
            {
                // manova an'le joueur mihetsika @ equipe1
                if (e.KeyCode == equipe1Keys[4])
                {
                    this.joueurs1[this.positionSelectEquipe1].BackColor = Color.Blue;
                    this.joueurs1[this.positionSelectEquipe1].Tag = "joueur";
                    this.positionSelectEquipe1 = Joueur.getPositionSelectPlayer(this.joueurs1, this.positionSelectEquipe1);
                    label1.Text = this.positionSelectEquipe1.ToString();
                    this.joueurs1[this.positionSelectEquipe1].BackColor = Color.Aquamarine;
                    this.joueurs1[this.positionSelectEquipe1].Tag = "main1";

                }
                // manova an'le joueur mihetsika @ equipe2
                else if (e.KeyCode == equipe2Keys[4])
                {
                    this.joueurs2[this.positionSelectEquipe2].BackColor = Color.Gold;
                    this.joueurs2[this.positionSelectEquipe2].Tag = "joueur";
                    this.positionSelectEquipe2 = Joueur.getPositionSelectPlayer(this.joueurs2, this.positionSelectEquipe2);
                    label1.Text = this.positionSelectEquipe2.ToString();
                    this.joueurs2[this.positionSelectEquipe2].BackColor = Color.LightYellow;
                    this.joueurs2[this.positionSelectEquipe2].Tag = "main2";

                }

                /*else if (e.KeyCode == Keys.C)
                {
                    ballinMoove = false;
                    label1.Text = "1 eh";
                    this.shootingLeft = true;
                    // ballinMoove = true;
                }
                else if (e.KeyCode == Keys.M)
                {
                    ballinMoove = false;
                    label1.Text = "1 eh";
                    this.shootingRight = true;
                    // ballinMoove = true;
                }*/

                else if (e.KeyCode == Keys.M)
                {
                    this.joueurs1[this.positionSelectEquipe1].BackColor = Color.Blue;
                    this.joueurs1[this.positionSelectEquipe1].Tag = "joueur";
                    positionSelectEquipe1 = 0;
                    this.joueurs1[this.positionSelectEquipe1].BackColor = Color.Aquamarine;
                    this.joueurs1[this.positionSelectEquipe1].Tag = "main1";
                }
                else if (e.KeyCode == Keys.C)
                {
                    this.joueurs2[this.positionSelectEquipe2].BackColor = Color.Gold;
                    this.joueurs2[this.positionSelectEquipe2].Tag = "joueur";
                    positionSelectEquipe2 = 0;
                    this.joueurs2[this.positionSelectEquipe2].BackColor = Color.LightYellow;
                    this.joueurs2[this.positionSelectEquipe2].Tag = "main2";
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode==Keys.Capital) && ballOwned)
                {
                    if (ballinMoove)
                    {
                        ballinMoove = false;
                    }
                    else if (!ballinMoove)
                    {
                        ballinMoove = true;

                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    setIndexdirection();
                    label3.Text = labelDirection[indexDirection];
                }
            }
            

        }

        private void key_is_down(object sender, KeyEventArgs e)
        {
            if(loadGame)
            {
                /*
                if ((this.joueurs2[positionSelectEquipe2].Bounds.IntersectsWith(balle.Bounds) || this.joueurs1[positionSelectEquipe1].Bounds.IntersectsWith(balle.Bounds)))
                {
                    ballinMoove = false;
                    if (this.joueurs1[positionSelectEquipe1].Bounds.IntersectsWith(balle.Bounds))
                    {
                    
                        mooveWithBallEquipe1(e, balle);
                        mooveEquipe2(e);

                    }
                    else if (this.joueurs2[positionSelectEquipe2].Bounds.IntersectsWith(balle.Bounds) )
                    {
                    
                        mooveWithBallEquipe2(e, balle);
                        mooveEquipe1(e);
                    }

                   
                }*/

                /*if ((this.joueurs2[positionSelectEquipe2].Bounds.IntersectsWith(balle.Bounds) || this.joueurs1[positionSelectEquipe1].Bounds.IntersectsWith(balle.Bounds)))
                {*/
                    
                    if (this.joueurs1[positionSelectEquipe1].Bounds.IntersectsWith(balle.Bounds) )
                    {
                    ballinMoove = false;
                    ballOwned = true;
                    mooveWithBallEquipe1(e, balle);
                        mooveEquipe2(e);

                    }
                    else if (this.joueurs2[positionSelectEquipe2].Bounds.IntersectsWith(balle.Bounds))
                    {
                    ballOwned = true;
                    label1.Text = "mety rty ah ";
                    ballinMoove = true;
                    Thread.SpinWait(10);
                    ballinMoove = false;
                    mooveWithBallEquipe2(e, balle);
                        mooveEquipe1(e);
                    }


               // }

                else
                {
                    ballOwned = false;
                    this.moove(e);

                }
            }





        }

        private void moove(KeyEventArgs e)
        {
            // equipe 1
            if (e.KeyCode == equipe1Keys[0] && this.joueurs1[this.positionSelectEquipe1].Top - 10 >= y_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Top -= 10;
            }
            else if (e.KeyCode == equipe1Keys[2] && this.joueurs1[this.positionSelectEquipe1].Bottom + 10 < y_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Top += 10;

            }
            else if ((e.KeyCode == equipe1Keys[1]) && this.joueurs1[this.positionSelectEquipe1].Left - 10 >= x_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Left -= 10;

            }
            else if ((e.KeyCode == equipe1Keys[3]) && this.joueurs1[this.positionSelectEquipe1].Right + 10 < x_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Left += 10;

            }


            //equipe 2

            if (e.KeyCode == equipe2Keys[0] )
            {
                this.joueurs2[this.positionSelectEquipe2].Top -= 10;
            }
            else if (e.KeyCode == equipe2Keys[2] )
            {
                this.joueurs2[this.positionSelectEquipe2].Top += 10;

            }
            else if ((e.KeyCode == equipe2Keys[1]) )
            {
                this.joueurs2[this.positionSelectEquipe2].Left -= 10;

            }
            else if ((e.KeyCode == equipe2Keys[3]) )
            {
                this.joueurs2[this.positionSelectEquipe2].Left += 10;

            }
        }

        public void mooveEquipe1(KeyEventArgs e)
        {
            if (e.KeyCode == equipe1Keys[0] && this.joueurs1[this.positionSelectEquipe1].Top - 10 >= y_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Top -= 10;
            }
            else if (e.KeyCode == equipe1Keys[2] && this.joueurs1[this.positionSelectEquipe1].Bottom + 10 < y_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Top += 10;

            }
            else if ((e.KeyCode == equipe1Keys[1]) && this.joueurs1[this.positionSelectEquipe1].Left - 10 >= x_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Left -= 10;

            }
            else if ((e.KeyCode == equipe1Keys[3]) && this.joueurs1[this.positionSelectEquipe1].Right + 10 < x_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Left += 10;

            }
        }

        public void mooveEquipe2(KeyEventArgs e)
        {
            if (e.KeyCode == equipe2Keys[0] && this.joueurs2[this.positionSelectEquipe2].Top - 10 >= y_Origin)
            {
                this.joueurs2[this.positionSelectEquipe2].Top -= 10;
            }
            else if (e.KeyCode == equipe2Keys[2] && this.joueurs2[this.positionSelectEquipe2].Bottom + 10 < y_end)
            {
                this.joueurs2[this.positionSelectEquipe2].Top += 10;

            }
            else if ((e.KeyCode == equipe2Keys[1]) && this.joueurs2[this.positionSelectEquipe2].Left - 10 >= x_Origin)
            {
                this.joueurs2[this.positionSelectEquipe2].Left -= 10;

            }
            else if ((e.KeyCode == equipe2Keys[3]) && this.joueurs2[this.positionSelectEquipe2].Right + 10 < x_end)
            {
                this.joueurs2[this.positionSelectEquipe2].Left += 10;

            }
        }

        public void mooveWithBallEquipe1(KeyEventArgs e, Control balle)
        {
            if (e.KeyCode == equipe1Keys[0] && this.joueurs1[this.positionSelectEquipe1].Top - 10 >= y_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Top -= 10;
                balle.Top -= 20;
            }
            else if (e.KeyCode == equipe1Keys[2] && this.joueurs1[this.positionSelectEquipe1].Bottom + 10 < y_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Top += 10;
                balle.Top += 20;

            }
            else if ((e.KeyCode == equipe1Keys[1]) && this.joueurs1[this.positionSelectEquipe1].Left - 10 >= x_Origin)
            {
                this.joueurs1[this.positionSelectEquipe1].Left -= 10;
                balle.Left -= 20;

            }
            else if ((e.KeyCode == equipe1Keys[3]) && this.joueurs1[this.positionSelectEquipe1].Right + 10 < x_end)
            {
                this.joueurs1[this.positionSelectEquipe1].Left += 10;
                balle.Left += 20;
            }
        }

        public void mooveWithBallEquipe2(KeyEventArgs e, Control balle)
        {
            if (e.KeyCode == equipe2Keys[0] && this.joueurs2[this.positionSelectEquipe2].Top - 10 >= y_Origin)
            {
                this.joueurs2[this.positionSelectEquipe2].Top -= 10;
                balle.Top -= 10;
            }
            else if (e.KeyCode == equipe2Keys[2] && this.joueurs2[this.positionSelectEquipe2].Bottom + 10 < y_end)
            {
                this.joueurs2[this.positionSelectEquipe2].Top += 10;
                balle.Top += 10;

            }
            else if ((e.KeyCode == equipe2Keys[1]) && this.joueurs2[this.positionSelectEquipe2].Left - 10 >= x_Origin)
            {
                this.joueurs2[this.positionSelectEquipe2].Left -= 10;
                balle.Left -= 10;

            }
            else if ((e.KeyCode == equipe2Keys[3]) && this.joueurs2[this.positionSelectEquipe2].Right + 10 < x_end)
            {
                this.joueurs2[this.positionSelectEquipe2].Left += 10;
                balle.Left += 10;
            }
        }

        public void mooveTheBall()
        {
            PositionPlayer pos = directionBalle[indexDirection];
            int ballSpeedX = pos.x; // Horizontal speed
            int ballSpeedY = pos.y; // Vertical speed

            // Update the ball's position
            balle.Left += ballSpeedX;
            balle.Top += ballSpeedY;
           
        }

        private void balle_Click(object sender, EventArgs e)
        {

        }

        private void tir(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                while (balle.Left < y_Origin)
                {
                    balle.Left -= 15;
                }

            }
        }

        private void buuuts()
        {
            Points pE1 = new Points(this.idEquipe1, this.idJeu);
            Points pE2 = new Points(this.idEquipe2, this.idJeu);

            if (balle.Bounds.IntersectsWith(butsEquipe1.Bounds))
            {
                scoreE2.Text = (this.pointsEquipe2 + 1).ToString();
                label1.Text = "oueee equipe2";
                pE1.savepoints(this.connectionString);
                this.pointsEquipe2 = this.pointsEquipe2 + 1;
                balle.Left = gamePanel.Width / 2;
                balle.Top=gamePanel.Height / 2;
                this.ballinMoove = false;
                Tours -= 1;


            }
            else if (balle.Bounds.IntersectsWith(butsEquipe2.Bounds))
            {
                scoreE1.Text = (this.pointsEquipe1 + 1).ToString();

                label1.Text = this.pointsEquipe2.ToString();
                
                pE2.savepoints(connectionString);

                this.pointsEquipe1 = this.pointsEquipe1 + 1;
                balle.Left = gamePanel.Width / 2;
                balle.Top = gamePanel.Height / 2;
                this.ballinMoove = false;
                Tours -= 1;
            }

            //
            if (balle.Left <= 0)
            {
                ballinMoove = false;
                label1.Text = "la balle est sortie";
                balle.Left =  5;



            }
            else if (balle.Left >= gamePanel.Width)
            {
                ballinMoove = false;
                label1.Text = "la balle est sortie";
                balle.Left = gamePanel.Width - 10;
            }
            else if (balle.Top <= 0)
            {
                ballinMoove = false;
                label1.Text = "la balle est sortie";
                balle.Top= 5;
            }
            else if (balle.Top >= gamePanel.Height)
            {
                ballinMoove = false;
                label1.Text = "la balle est sortie";
                balle.Top=gamePanel.Height -10;
            }

        }

        private void setIndexdirection()
        {
            int i = this.indexDirection;
            if (i == labelDirection.Count - 1)
            {
                i = 0;
            }
            else
            {
                i = i + 1;
            }
            this.indexDirection = i;
        }

        private void E2_Click(object sender, EventArgs e)
        {

        }
    }
}
