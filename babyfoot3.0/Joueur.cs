using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyfoot3._0
{
    public class Joueur : PictureBox
    {
        private int width { get; set; }
        private int height { get; set; }
        int speed { get; set; }
        bool canmoove { get; set; }

        int pos_x { get; set; }
        int pos_y { get; set; }
        public bool owntheball { get;set; }

        public Joueur(int pos_x, int pos_y, Color couleur)
        {
            this.Tag = "joueur";
            this.pos_x = pos_x;

            this.pos_y = pos_y;
            this.Top = this.pos_y;
            this.Left = this.pos_x;
            this.BackColor = couleur;
            this.Size = new Size(50, 50);
            this.owntheball = false;


        }

        public static List<Joueur> setEquipe(int widthTerrain, int heightTerrain, Color couleur,bool isEquipe1)
        {

            List<PositionPlayer> positions = new List<PositionPlayer>();
            if(isEquipe1 )
            {
                positions = getPositionEquipe1(widthTerrain, heightTerrain);

            }
            else
            {
                positions = getPositionEquipe2(widthTerrain, heightTerrain);

            }
            List<Joueur> equipe=new List<Joueur> ();
                for (int i=0; i<positions.Count();i++)
                {

                equipe.Add(new Joueur(positions[i].x, positions[i].y,couleur));
                }
            return equipe;
        }

        public static List<PositionPlayer> getPositionEquipe1(int width, int height)
        {
            List<PositionPlayer > list = new List<PositionPlayer>();

            // goal
                list.Add(new PositionPlayer(150,height/2));

            // defenseurs centrale 2

            list.Add(new PositionPlayer(400, (height/2)-150));
            list.Add(new PositionPlayer(400, (height / 2) + 150));

            // arrieres 2
            list.Add(new PositionPlayer(450, (height / 2) - 350));
            list.Add(new PositionPlayer(450, (height / 2) + 350));

            //milieu 3
            list.Add(new PositionPlayer((width / 2) - 300, (height / 2)));

            list.Add(new PositionPlayer((width/2)-250, (height / 2) - 350));
            list.Add(new PositionPlayer((width / 2) - 250, (height / 2) + 350));

            // avant centre 3
            list.Add(new PositionPlayer((width / 2) -80, (height / 2)));
            list.Add(new PositionPlayer((width / 2) - 150, (height / 2) - 250));
            list.Add(new PositionPlayer((width / 2) - 150, (height / 2) +250));


            return list;
        }
        public static List<PositionPlayer> getPositionEquipe2(int width, int height)
        {
            List<PositionPlayer> list = new List<PositionPlayer>();

            // goal
            list.Add(new PositionPlayer(width-200, height / 2));

            // defenseurs centrale 2

            list.Add(new PositionPlayer(width -400, (height / 2) - 150));
            list.Add(new PositionPlayer(width -400, (height / 2) + 150));
                                        
            list.Add(new PositionPlayer(width -450, (height / 2) - 350));
            list.Add(new PositionPlayer(width -450, (height / 2) + 350));
                 
            //milieu 
            list.Add(new PositionPlayer(width -((width / 2) - 300), (height / 2)));
                                       
            list.Add(new PositionPlayer(width -((width / 2) - 250), (height / 2) - 350));
            list.Add(new PositionPlayer(width -((width / 2) - 250), (height / 2) + 350));
                                        
            // avant centre 3           
            list.Add(new PositionPlayer(width - ((width / 2) -80), (height / 2)));
            list.Add(new PositionPlayer(width -((width / 2) -150), (height / 2) - 250));
            list.Add(new PositionPlayer(width -((width / 2) -150), (height / 2) + 250));


            return list;
        }

        public static int getPositionSelectPlayer(List<Joueur> joueur,int positionActuelle)
        {
            int max=joueur.Count;
            int pos = positionActuelle;
            if (positionActuelle == max - 1){
                pos = 0;
            }
            else
            {
                pos = pos + 1;
            }
            return pos;
        }

    }
}
