using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyfoot3._0
{
    
    public class Jeu
    {
        public int idjeu { get; set; }
        public int idJoueur1 { get; set; }
        public int idJoueur2 { get; set; }
        public int idOwner { get; set; }
        public double mise1 { get; set; }
        public double mise2 { get; set; }

        

        public Jeu()
        {
            
        }
        public Jeu(int idjeu, int idJoueur1, int idJoueur2, int idOwner, double mise1, double mise2)
        {
            this.idjeu = idjeu;
            this.idJoueur1 = idJoueur1;
            this.idJoueur2 = idJoueur2;
            this.idOwner = idOwner;
            this.mise1 = mise1;
            this.mise2 = mise2;
        }

        public double getOwnerShare()
        {
            double totalMise=mise2+mise1;
            double pourcentage = 10;
            return((totalMise*pourcentage)/100);
        }

        public double getWinnerShare()
        {
            double totalMise = mise2 + mise1;
            double owner=getOwnerShare();
            return totalMise-owner; 
        }

        public void InsertJeu(Jeu jeu, String connectionString)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Jeu (\"idJoueur1\", \"idJoueur2\", \"idOwner\", \"miseJ1\", \"miseJ2\") VALUES (@idJoueur1, @idJoueur2, @idOwner, @mise1, @mise2)";
                    cmd.Parameters.AddWithValue("idJoueur1", jeu.idJoueur1);
                    cmd.Parameters.AddWithValue("idJoueur2", jeu.idJoueur2);
                    cmd.Parameters.AddWithValue("idOwner", jeu.idOwner);
                    cmd.Parameters.AddWithValue("mise1", jeu.mise1);
                    cmd.Parameters.AddWithValue("mise2", jeu.mise2);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Jeu GetLastInsertedJeu(String connectionString)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM jeu ORDER BY idjeu DESC LIMIT 1";

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Jeu jeu = new Jeu();
                            jeu.idjeu = reader.GetInt32(reader.GetOrdinal("idjeu"));
                            jeu.idJoueur1 = reader.GetInt32(reader.GetOrdinal("idJoueur1"));
                            jeu.idJoueur2 = reader.GetInt32(reader.GetOrdinal("idJoueur2"));
                            jeu.idOwner = reader.GetInt32(reader.GetOrdinal("idOwner"));
                            jeu.mise1 = reader.GetDouble(reader.GetOrdinal("miseJ1"));
                            jeu.mise2 = reader.GetDouble(reader.GetOrdinal("miseJ2"));

                            return jeu;
                        }
                    }
                }
            }

            return null;
        }





    }
}
