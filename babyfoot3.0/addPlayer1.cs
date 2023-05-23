using System.Data;
using Npgsql;


namespace babyfoot3._0
{
    public partial class addPlayer1 : Form
    {
        String connectionString = "Server=localhost;Port=5432;Database=babyfoot; User Id=postgres; Password=12345678";
        Jeu jeu { get; set; }

        public addPlayer1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection(this.connectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users";

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            joueur1.DataSource = dt;
            joueur1.DisplayMember = "username";
            joueur1.ValueMember = "iduser";


            conn.Dispose();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int idJoueur1 = (int)joueur1.SelectedValue;
            double mises = Double.Parse(misej1.Text);
            addPlayer2 form2 = new addPlayer2((int)idJoueur1, mises);
            label2.Text = idJoueur1.ToString();


            form2.Show();
            


        }

        private void mise1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void joueur1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}