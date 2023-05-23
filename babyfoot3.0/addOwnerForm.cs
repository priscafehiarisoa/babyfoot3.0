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
    public partial class addOwnerForm : Form
    {
        String connectionString = "Server=localhost;Port=5432;Database=babyfoot; User Id=postgres; Password=12345678";

        Jeu game;
        public addOwnerForm(Jeu jeu)
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection(this.connectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users";

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "username";
            comboBox1.ValueMember = "iduser";


            conn.Dispose();
            conn.Close();
            game = jeu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.idOwner = (int)comboBox1.SelectedValue;


            // save the game datas 
            game.InsertJeu(game, this.connectionString);
            // load the game field
            this.Dispose();
            foot_game main = new foot_game();
            main.Show();
        }

    }
}
