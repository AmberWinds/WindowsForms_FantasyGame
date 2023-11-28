using static GADE6112POE_Part1_v01.Level;

namespace GADE6112POE_Part1_v01
{
    public partial class Form1 : Form
    {
        private GameEngine game;
        public Form1()
        {
            InitializeComponent();
            game = new GameEngine(10);
            UpdateDisplay();
            UpdateHealth();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Update Display Method. This method should assign the GameEngine field’s ToString result to your display label’s text property.
        public void UpdateDisplay()
        {
            lblDisplay.Text = game.ToString();     //Displays the Game in the Label
        }

        public void UpdateHealth()
        {
            lblHeroHealth.Text = "Health: " + game.HeroStats;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //override bool ProcessCMDKey to get Key input.
        {
            //capture up arrow key
            if (keyData == Keys.Up)                 //calls triggerMovement Method, which allows the player to move.
            {
                game.TriggerMovement(Direction.Up); //Move Up with UP arrowKey
                UpdateDisplay();                    //After Each Key Press, it will Update the output to the Label.
                UpdateHealth();
                //MessageBox.Show("Press Up Key");
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                game.TriggerMovement(Direction.Down); //Move Down with down Arrow Key
                //MessageBox.Show("Press Down Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                game.TriggerMovement(Direction.Left);   //Move Left with left Arrow key
                //MessageBox.Show("Press Left Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                game.TriggerMovement(Direction.Right);  //Move Right with Right Arrow Key
                //MessageBox.Show("Press Right Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            if (keyData == Keys.W)                 //calls triggerMovement Method, which allows the player to move.
            {
                game.TriggerAttack(Direction.Up);   //Attack Up with W Key
                UpdateHealth();
                UpdateDisplay();                    //After Each Key Press, it will Update the output to the Label.
                //MessageBox.Show("Press W Key");
                return true;
            }
            if (keyData == Keys.S)
            {
                game.TriggerAttack(Direction.Down); //Attack Down with S Key
                //MessageBox.Show("Press S Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            if (keyData == Keys.A)
            {
                game.TriggerAttack(Direction.Left);   //Attack Left with left A key
                //MessageBox.Show("Press A Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            if (keyData == Keys.D)
            {
                game.TriggerAttack(Direction.Right);  //Attack Right with Right D Key
                //MessageBox.Show("Press D Key");
                UpdateDisplay();
                UpdateHealth();
                return true;
            }
            UpdateDisplay();
            UpdateHealth();
            return base.ProcessCmdKey(ref msg, keyData);

            //Above code has been altered from OriginalGriff(2017)'s original code in order to implement the above Program.
            //OriginalGriff. 2017. How do I move forms with up, down, left & right keys? Solution 1 [Source code].
            //https://www.codeproject.com/Questions/1194396/How-do-I-move-forms-with-up-down-left-right-keys (Accessed 07 September 2023).
        }//end of KeyInput Method


        private void lbl_Heading_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Key_Click(object sender, EventArgs e)
        {

        }

        private void lblHeroHealth_Click(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblAttackStat_Click(object sender, EventArgs e)
        {

        }

        private void SaveGameButton_Click_1(object sender, EventArgs e)
        {
            string filePath = "path_to_save_file.dat"; // i dont know what to replace it with 

            // Create an instance of GameEngine
            GameEngine gameEngine = new GameEngine(/* pass necessary parameters */);

            // Call SaveGame method
            gameEngine.SaveGame(filePath);
        }
    }
}