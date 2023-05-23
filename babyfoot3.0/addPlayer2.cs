using Npgsql;
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
    public partial class addPlayer2 : Form
    {
        String connectionString = "Server=localhost;Port=5432;Database=babyfoot; User Id=postgres; Password=12345678";

        Jeu game;
        public addPlayer2(int idj1, double misej1)
        {
            InitializeComponent();
            game = new Jeu();
            misej2.Text = idj1.ToString();
            game.idJoueur1 = idj1;
            game.mise1 = misej1;
            NpgsqlConnection conn = new NpgsqlConnection(this.connectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users";

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            joueur2.DataSource = dt;
            joueur2.DisplayMember = "username";
            joueur2.ValueMember = "iduser";


            conn.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.idJoueur2 = (int)joueur2.SelectedValue;
            game.mise2 = Double.Parse(misej2.Text);
            this.Dispose();
            addOwnerForm owners=new addOwnerForm(game);
            owners.Show();
        }
    }
}
