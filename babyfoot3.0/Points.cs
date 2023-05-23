using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace babyfoot3._0
{
    public class Points
    {
        int idEquipe { get; set; }
        int idjeu { get; set; }
        int nbpoints { get; set; }
        DateTime datepoints { get; set; }

        public Points(int idEquipe, int idJeu)
        {
            this.idEquipe = idEquipe;
            this.idjeu = idJeu;
            this.nbpoints = 1;
        }

        public void savepoints(String connectionString)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO points (idEquipe, idjeu, nbpoints) VALUES (@idEquipe, @idjeu, @nbpoints)";

                    // Set the parameter values
                    command.Parameters.AddWithValue("idEquipe", idEquipe);
                    command.Parameters.AddWithValue("idjeu", idjeu);
                    command.Parameters.AddWithValue("nbpoints", nbpoints);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
