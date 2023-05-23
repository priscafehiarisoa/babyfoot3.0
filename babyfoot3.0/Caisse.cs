using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyfoot3._0
{
    public class Caisse
    {
        int iduser{ get; set; }
        double montant { get; set; }
        public Caisse() { }

        public Caisse(int iduser, double montant)
        {
            this.iduser=iduser;
            this.montant=montant;
            
        }

        public void InsertCaisse( String connectionString)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO caisse (iduser, montant) VALUES (@iduser, @montant)";
                    cmd.Parameters.AddWithValue("iduser", this.iduser);
                    cmd.Parameters.AddWithValue("montant", this.montant);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public double getCaisseJoueur(int idJoueur)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("connection string"))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT SUM(montant) FROM caisse WHERE iduser = @userId";
                    cmd.Parameters.AddWithValue("userId", idJoueur);

                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return Convert.ToDouble(result);
                    }
                }
            }
            return 0;
        }
    }
}
