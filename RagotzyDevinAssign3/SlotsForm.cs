using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// DAKOTA add the files .playconfig and winners to the bin/debug folder and 
// everything will work itll work either way but it might be buggy
using System.IO; // add for stream read/write
// just so I can finish what i started
using System.Net.Http;
using Newtonsoft.Json;

/******************************************************************************************
 * Devin Ragotzy Assignment #3 
 * 04/02/19
 * ***************************************************************************************
 *
 * BUSSINES POINT OF VIEW
 *  A game app for customers to play and win prizes.  The app keeps track of all players, scores,
 *  and prizes won for each respective player.  A 'slots' like game is played firsts followed by
 *  a coin toss, the number of tosses a player gets is based on the points earned in the 'slot' game.
 *  the points scored in the coin toss game determines the points that are used towards prizes.
 * ***************************************************************************************
 * 
 * CLASSROOM POINT OF VIEW
 *  Structure of the app is simmilar to the other projects, but we will use methods with return values (functions),
 *  the Random class to create random numbers, and file system class and methods to save and read data.
 *  Controls:
 *      Button -
 *          click
 *      saveFileDialog -
 *          used to choose a name for the file that is used to fill in data about the 
 *          players in the app.
 *      ComboBox -
 *          use the items in the list, selectedIndex, and add/remove methods and properties.
 *      openFileDialog - 
 *          used to fill in the comboBox items
 *      pictureBox - 
 *          a picture (coin fli gif) that is moved on its y axis up and down as the coin flips.
 *      checkBox -
 *          when clicked the coin animation will not play to speed up the game.
 *      timer -
 *          control set on the form that keeps a "stopwatch" going.
 *  Properties:
 *      fileName -
 *          the property set when the saved dialog is completed
 *      initialDirectory -
 *          sets the location of where the open or save file dialog opens in the directory structure.
 *      selectedIndex -
 *          gets or sets the index of the selected comboBox item
 *      
 *  Event Handlers:
 *      timer_Tick -
 *          fires everytime an interval of specified length happens. Used to play the gif for 
 *          1.5 seconds and to move it 24ish times a second so "animation" is smooth.
 *      form_Close -
 *          watches for any exit event wether triggerd by the x in upper coner or the exit button.
 *  Extras:
 *      return values to be used in if statements, as variables in calculations
 *      and Date.  Use a hashSet to count number of flip matches, the set only contains
 *      unique values.  Using a struct to hold related information.  Request JSON from web of
 *      currency rates to convert points to money in any currency.  Overloaded methods to set
 *      color and open file to set the location string, read file to insert into checkbox or
 *      pass a function that gets called with the results of the read file.  The return from
 *      requesting the currency json has to be 'async' it must be awiated .  
 *      
******************************************************************************/

namespace RagotzyDevinAssign3 {
    public partial class SlotsGameForm : System.Windows.Forms.Form {

        // vars for each player
        private String nameString;
        private int numberOfPlaysInt = 0;
        private int numberOfBonusPlaysInt = 0;

        private Boolean fastPlayBool;

        private Boolean canPlayBool = false;
        private Boolean canPlayBonusBool = false;

        private List<int> flipsList = new List<int>();
        HashSet<int> matchesSet;
        private int playerScoreInt = 0;
        private int playerBonusScoreInt = 0;

        // for the prize string output and exchange turn prize points to $
        private struct PrizesStruct {
            public String PrizeString;
            public int PrizeInt;

            public PrizesStruct(String pStr, int pInt) {
                PrizeString = pStr;
                // to convert score back to number out of 12 (highest score)
                PrizeInt = pInt * 2;
            }
        };
        private PrizesStruct prizes;
        // app save vars
        private String playerFileLocationString;
        private String winnerFileLocationString;
        private Boolean didSaveBool = false;

        // DAKOTA
        // stores the json
        private dynamic currency;
        private Boolean isConnectedBool = true;
        // player write/output and read/input file handels 
        // all local vars

        // constants
        const int TOP_SCORE = 5;
        const int MID_SCORE = 3;
        const int LOW_SCORE = 0;

        // prize constants
        const String PRIZE_6 = "One Million Dollars";
        const String PRIZE_5 = "A New House";
        const String PRIZE_4 = "An almost New Car";
        const String PRIZE_3 = "A Newer Computer";
        const String PRIZE_2 = "A Newish T.V";
        const String PRIZE_1 = "One Dollar Old";
        const String PRIZE_0 = "No Prize";

        // DAKOTA location of json used in the second to last method all the way down
        const String URL = "https://api.exchangeratesapi.io/latest?base=USD";

        // ********************** form start *************************
        public SlotsGameForm() { InitializeComponent(); }

        private async void SlotsGameForm_Load(object sender, EventArgs e) {
            this.coinPictureBox.SendToBack();
            this.displayLabel.Text = "";
            this.coinPictureBox.Image = null;
            this.saveButton.Enabled = false;
            this.totalButton.Enabled = false;
            this.exchangeButton.Enabled = false;
            this.timer2.Tag = 0;

            DialogResult result = MessageBox.Show("Click YES to create a new file for the day\r\n or NO to use an old one",
                "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                try {
                    // players comboBox
                    this.playerFileLocationString = this.OpenFile(".playconfig", this.playerComboBox);

                    this.saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    this.saveFileDialog1.FileName = "*.txt";
                    DialogResult save = this.saveFileDialog1.ShowDialog();

                    if (save == DialogResult.OK) {
                        this.winnerFileLocationString = this.saveFileDialog1.FileName;
                    }
                } catch (Exception err) {
                    MessageBox.Show("Something happend tell Devin \r\n" + err.ToString(), "ERROR");
                }
            } else {
                try {
                    // for the players comboBox has to be run no matter what in try catch
                    this.playerFileLocationString = this.OpenFile(".playconfig", this.playerComboBox);

                    this.openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    this.openFileDialog1.FileName = "*.txt";
                    DialogResult open = this.openFileDialog1.ShowDialog();

                    if (open == DialogResult.OK)  {
                        this.winnerFileLocationString = this.OpenFile(this.openFileDialog1.FileName, this.winnersComboBox);
                    }
                } catch (Exception err) {
                    MessageBox.Show("Something happend tell Devin \r\n" + err.Message, "FILE ERROR");
                }
            }

            // DAKOTA these ara at the very bottom and the exchange button is not to far down
            // from here
            // load and deserialize json
            await this.LoadCurrency();
            // insert each currency into combobox
            if (this.isConnectedBool) this.SetCurrency();

            this.Activate();
        }

        // ********************** button handlers START ********************************
        private void playButton_Click(object sender, EventArgs e) {
            this.SetColor(this.label3, SystemColors.ControlText, SystemColors.Control);
            if (this.canPlayBool) {
                if (!this.fastPlayBool) this.FlipCoin();
                this.numberOfPlaysInt--;
                this.label3.Text = $"You have {this.numberOfPlaysInt} plays left";
                this.SlotsPlay();
                this.AccumScore();
                if (this.numberOfPlaysInt == 0) {
                    this.label3.Text = "Click to play the Bonus Round";
                    this.numberOfBonusPlaysInt = this.SetBonus();
                    this.canPlayBonusBool = true;
                    this.canPlayBool = false;
                }
            } else if (this.canPlayBonusBool) {
                if (!this.fastPlayBool) this.FlipCoin();
                this.numberOfBonusPlaysInt--;
                this.label3.Text = $"You have {this.numberOfBonusPlaysInt} bonus plays left";
                this.PlayBonus();
                if (this.numberOfBonusPlaysInt == 0) {
                    this.label3.Text = "Click prize totals to see\r\n   what you won";
                    this.playButton.Enabled = false;
                    this.totalButton.Enabled = true;
                    this.canPlayBonusBool = false;
                }
            } else if (this.ValidInput()) {
                this.label3.Text = "Now click play";
                this.ClearInput();
                this.didSaveBool = false;
                this.canPlayBool = true;
                this.totalButton.Enabled = false;
                this.exchangeButton.Enabled = false;
            }
        }


        private void addPlayerButton_Click(object sender, EventArgs e) {
            // reset error
            this.errorProvider1.SetError(this.addPlayerButton, "");

            String name = this.playerComboBox.Text.Trim();
            if (name != "") {
                // make sure name is not already used
                if (!this.IsDuplicateName(name)) {
                    this.playerComboBox.Items.Add(name);
                    try {
                        StreamWriter outputFile = File.AppendText(this.playerFileLocationString);
                        // use file
                        outputFile.WriteLine(this.playerComboBox.Text);
                        // close file
                        outputFile.Close();
                    } catch (Exception err) {
                        MessageBox.Show("Some thing went wrong while saving the new player"
                            + err.Message, "PLAYER SAVE ERROR");
                    }
                } else {
                    this.errorProvider1.SetError(this.addPlayerButton, "That name is already taken");
                }
            }
            else {
                this.errorProvider1.SetError(this.playerComboBox, "Enter a Name Here");
            }
        }

        // used to remove a player just rewrite the file instead of seeking and editing
        private void remPlayerButton_Click(object sender, EventArgs e) {
            //resests the error
            this.errorProvider1.SetError(this.remPlayerButton, "");
            if (this.playerComboBox.SelectedIndex > -1) {
                this.playerComboBox.Items.RemoveAt(this.playerComboBox.SelectedIndex);
                try {
                    StreamWriter outputFile = File.CreateText(this.playerFileLocationString);
                    // use file
                    for (int i = 0; i < this.playerComboBox.Items.Count; i++) {
                        String ele = (String)this.playerComboBox.Items[i];
                        outputFile.WriteLine(ele);
                    }
                    // close file
                    outputFile.Close();
                } catch (Exception err) {
                    MessageBox.Show("Something happened while editing the player name file" 
                        + err.Message, "PLAYER SAVE ERROR");
                }
            } else {
                this.errorProvider1.SetError(this.remPlayerButton, "Select a player Name");
            }
        }

        private void totalButton_Click(object sender, EventArgs e) {
            this.label3.Text = "Click Play to start another game\r\n   as a new player";

            this.SetPrizeStruct();
            String playerScoreString = $"{this.nameString}, {this.playerBonusScoreInt}, {this.prizes.PrizeString}";
            this.displayLabel.Text = $"{playerScoreString}";

            this.winnersComboBox.Items.Add(playerScoreString);

            this.fastPlayCheckBox.Checked = false;
            this.playerScoreInt = 0;
            this.playerBonusScoreInt = 0;

            this.saveButton.Enabled = true;
            this.playButton.Enabled = true;
            this.totalButton.Enabled = false;
            if (this.isConnectedBool) this.exchangeButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            try {
                this.SaveFile(this.winnerFileLocationString, this.winnersComboBox);
            } catch (Exception err){
                MessageBox.Show("Something went wrong deduct from Devins grade\r\n" + err.Message, "ERROR");
            }
            this.didSaveBool = true;
            this.winnersComboBox.Items.Clear();
            this.saveButton.Enabled = false;
        }

        private void playerReportButton_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("If you are in the middle of a game any progress will be lost",
                "CAUTION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK) {
                this.displayLabel.Text = "";
                try
                {
                    this.openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    this.openFileDialog1.FileName = "*.txt";
                    DialogResult save = this.openFileDialog1.ShowDialog();

                    if (save == DialogResult.OK)
                    {
                        this.OpenFile(this.openFileDialog1.FileName, this.winnersComboBox,
                            (List<String> data) => {
                                this.OutputPrizeTotals(data[0], data[1], data[2]);
                            });
                    }
                }
                catch (Exception err) {
                    String msg = "The file you tried to open had an error\r\n";
                    MessageBox.Show(msg + err.Message, "FILE ERROR");
                }
                this.Activate();
            }
        }

        // EXCHANGE BUTTON
        private void exchangeButton_Click(object sender, EventArgs e) {
            this.errorProvider1.SetError(this.exchangeButton, "");
            int index = this.CurrencyComboBox.SelectedIndex;
            if (index > -1) {
                try {
                    String rate = (String)this.CurrencyComboBox.Items[index];
                    Double amount = Double.Parse((String)this.currency.rates[rate]);
                    this.displayLabel.Text = ($"Score {this.prizes.PrizeInt.ToString()} x {rate} {amount.ToString("c")}\r\n"
                        + (amount * this.prizes.PrizeInt).ToString("c") + "\r\n"
                        + "Going for the big bucks I see");
                } catch (Exception err) {
                    String msg = "Either you are not online\r\nor something went wrong with number conversion";
                    MessageBox.Show(msg +  err.Message, "HTTP or double PARSE ERROR");
                }
            }
            else {
                this.errorProvider1.SetError(this.exchangeButton, "Select a Currency by country");
            }
        }

        private void testButton_Click(object sender, EventArgs e) {
            this.playerComboBox.SelectedIndex = 1;
            this.numPlaysTextBox.Text = "5";
        }

        private void exitButton_Click(object sender, EventArgs e) {
            this.Close();
        }
        // ********************** button handlers END ********************************

        // ********************* check change START **********************************
        private void fastPlayCheckBox_CheckedChanged(object sender, EventArgs e) {
            this.fastPlayBool = this.fastPlayCheckBox.Checked;
        }
        // ********************* check change END ************************************

        // ********************** event handlers START ********************************
        private void slotsForm_Closing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Do you want close this will save your data", "My Application",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                if (!didSaveBool) {
                    this.saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                    this.saveFileDialog1.FileName = "*.txt";
                    this.saveFileDialog1.Filter = "textFile(*.txt) | *.txt";
                    DialogResult save = this.saveFileDialog1.ShowDialog();

                    if (save == DialogResult.OK) {
                        try {
                            this.SaveFile(this.saveFileDialog1.FileName, this.winnersComboBox);
                        } catch (Exception err){
                            MessageBox.Show("Something went wrong deduct from Devins grade"
                                + err.Message, "FILE ERROR");
                        }
                    } else {
                        // cancel form close when cancel save
                        e.Cancel = true;
                    }
                }
            } else {
                // cancel when no to message box
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            this.coinPictureBox.Image = null;
            this.timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e) {
            int tick = (int)this.timer2.Tag;
            tick++;
            if (tick == 48) {
                this.timer2.Stop();
                tick = 0;
            } else if (tick <= 24) {
                Point point = this.coinPictureBox.Location;
                // subtract to go up 
                point.Y -= 5;
                this.coinPictureBox.Location = point;
            } else {
                Point point = this.coinPictureBox.Location;
                // add to go down
                point.Y += 5;
                this.coinPictureBox.Location = point;
            }
            this.timer2.Tag = tick;
        }
        // ********************** event handlers END *******************************

        // ********************** MY methods START *********************************
        private void ClearInput() {
            this.displayLabel.Text = "";
            this.playerComboBox.SelectedIndex = -1;
            this.numPlaysTextBox.Clear();
            this.playerComboBox.Focus();

            this.playerScoreInt = 0;
            this.playerBonusScoreInt = 0;
            this.prizes = new PrizesStruct();

            this.CurrencyComboBox.SelectedIndex = -1;
            this.fastPlayCheckBox.Checked = false;
        }

        private Boolean ValidInput() {
            Boolean isValid = false;
            if (this.playerComboBox.Text.Trim() != "") {
                this.nameString = this.playerComboBox.Text.Trim();
                try {
                    this.numberOfPlaysInt = int.Parse(this.numPlaysTextBox.Text);
                    if (this.numberOfPlaysInt > 0) {
                        isValid = true;
                    } else {
                        MessageBox.Show("Number of plays must be greater than zero", "# of PLAYS ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.numPlaysTextBox.Clear();
                        this.numPlaysTextBox.Focus();
                    }
                } catch {
                    MessageBox.Show("Number of plays must be a number", "# of PLAYS ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.numPlaysTextBox.Clear();
                    this.numPlaysTextBox.Focus();
                }
            } else {
                MessageBox.Show("You must select a name from the drop down or add your own", "NAME ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.playerComboBox.Focus();
            }
            return isValid;
        }

        private void SetColor(Label label, Color foreColor) {
            label.ForeColor = foreColor;
        }

        private void SetColor(Label label, Color foreColor, Color backColor) {
            label.ForeColor = foreColor;
            label.BackColor = backColor;
        }

        private Boolean IsDuplicateName(String name) {
            Boolean found = false;

            int i = 0;
            while (i < this.playerComboBox.Items.Count && !found) {
                if (name.ToLower() == this.playerComboBox.Items[i].ToString().Trim().ToLower()) {
                    found = true;
                }
                i++;
            }
            return found;
        }

        private void SlotsPlay() {
            Random rnd = new Random();
            for (int i = 0; i < 3; i++) {
                // adds number from 1 to 3
                this.flipsList.Add(rnd.Next(1, 4));
            }
        }

        private int GetScore() {
            // hash set removes duplicates
            this.matchesSet = new HashSet<int>(this.flipsList);
            // reset list
            this.flipsList.Clear();
            // finds number of matches by removing duplicate values from list
            switch (this.matchesSet.Count) {
                case 1:
                    return TOP_SCORE;
                case 2:
                    return MID_SCORE;
                default:
                    return LOW_SCORE;
            }
        }

        private void AccumScore() {
            int score = this.GetScore();
            this.playerScoreInt += score;
            switch (score) {
                case 5:
                    this.displayLabel.Text = "All three matches" + $"\r\nScore: {this.playerScoreInt}\r\n";
                    break;
                case 3:
                    this.displayLabel.Text = "Two matches" + $"\r\nScore: {this.playerScoreInt}\r\n";
                    break;
                default:
                    this.displayLabel.Text = "No matches" + $"\r\nScore: {this.playerScoreInt}\r\n";
                    break;
            }
        }

        private int SetBonus() {
            switch (this.playerScoreInt / 10) {
                case 0:
                    return 1;
                case 1:
                    return 4;
                //case 2: case 3:
                case int n when (n >= 2 && n <= 3):
                    return 6;
                //case 4: case 5: case 6:
                case int n when (n >= 4 && n <= 6):
                    return 8;
                default:
                    return 12;
            }
        }

        private void FlipCoin() {
            this.coinPictureBox.Image = Properties.Resources.coinflip;
            this.timer1.Start();
            this.timer2.Start();
        }

        private void PlayBonus() {
            Random rnd = new Random();
            // random from 1 to 2
            int coin = rnd.Next(1, 3);
            if (coin == 2) {
                this.playerBonusScoreInt++;
                this.displayLabel.Text += "Win!! ";
            } else {
                this.displayLabel.Text += "Lose 😢 ";
            }
        }

        private void SetPrizeStruct() {
            switch (this.playerBonusScoreInt / 2) {
                case 6:
                    this.prizes = new PrizesStruct(PRIZE_6, 6);
                    break;
                case 5:
                    this.prizes = new PrizesStruct(PRIZE_5, 5);
                    break;
                case 4:
                    this.prizes = new PrizesStruct(PRIZE_4, 4);
                    break;
                case 3:
                    this.prizes = new PrizesStruct(PRIZE_3, 3);
                    break;
                case 2:
                    this.prizes = new PrizesStruct(PRIZE_2, 2);
                    break;
                case 1:
                    this.prizes = new PrizesStruct(PRIZE_1, 1);
                    break;
                default:
                    this.prizes = new PrizesStruct(PRIZE_0, 0);
                    break;
            }
        }

        private void OutputPrizeTotals(String name, String score, String prize) {
            if (this.displayLabel.Text == "") {
                this.displayLabel.Text += "Name     Wins    Prizes\r\n";
                this.displayLabel.Text += name.PadRight(6) + score.PadLeft(7) + $"    {prize}\r\n";
            } else {
                this.displayLabel.Text += name.PadRight(6) + score.PadLeft(7) + $"    {prize}\r\n";
            }
        }

        private void AccumBonus() {
            this.SetPrizeStruct();
            String playerScoreString = $"{this.nameString}, {this.playerBonusScoreInt}, {this.prizes.PrizeString}";
            this.displayLabel.Text = $"You won a {this.prizes.PrizeString.ToUpper()}!!!";
            this.winnersComboBox.Items.Add(playerScoreString);
        }

        private String OpenFile(String location, ComboBox cBox) {
            String fileLocation = Path.IsPathRooted(location) == true
                ? location
                : Path.GetFullPath(location);
            StreamReader inputFile = File.OpenText(fileLocation);

            while (!inputFile.EndOfStream) {
                cBox.Items.Add(inputFile.ReadLine());
            }
            inputFile.Close();
            return fileLocation;
        }

        private void OpenFile(String location, ComboBox cBox, Action<List<String>> callback) {
            String fileLocation = Path.IsPathRooted(location) == true
                ? location
                : Path.GetFullPath(location);
            StreamReader inputFile = File.OpenText(fileLocation);

            while (!inputFile.EndOfStream) {
                Array chunks = inputFile.ReadLine().Split(',');
                List<String> cleaned = new List<string>();
                for (int i = 0; i < chunks.Length; i++) {
                    String word = (String)chunks.GetValue(i);
                    cleaned.Add(word.Trim());
                };
                callback(cleaned);
            }
            inputFile.Close();
        }

        private String SaveFile(String location, ComboBox cBox) {
            // if file location came from saveFileDialog its absolut else we need full path
            String fileLocation = Path.IsPathRooted(location) == true
                ? location
                : Path.GetFullPath(location);

            StreamWriter outputFile = File.CreateText(fileLocation);

            for (int i = 0; i < cBox.Items.Count; i++) {
                String ele = (String)cBox.Items[i];
                outputFile.WriteLine(ele);
            }
            outputFile.Close();
            return fileLocation;
        }

        // DAKOTA these last two
        private async Task LoadCurrency() {
           using (HttpClient client = new HttpClient()) {
                try {
                    // makes the get request
                    HttpResponseMessage response = await client.GetAsync(URL);
                    // throws if not a 200 reponse
                    response.EnsureSuccessStatusCode();
                    // fetches actual content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    this.currency = JsonConvert.DeserializeObject(responseBody);
                } catch (Exception err) {
                    this.isConnectedBool = false;
                    MessageBox.Show("You must be connected to internet to use the exchange button\r\n"
                        + err.Message, "ERROR");
                }
            }
        }

        private void SetCurrency() {
            foreach (Object rate in this.currency.rates) {
                // not sure how you could access each property name so just tostring it
                // in exchange button because i already know the property name i can just use that
                // to access the value of that property
                Array strArray = rate.ToString().Split(':');
                String country = strArray.GetValue(0).ToString().Replace('"', ' ').Trim();
                this.CurrencyComboBox.Items.Add(country);
                // this.displayLabel.Text += $"{country} {amount}\r\n";
            }
        }
        // ********************** MY methods END ********************************
    }
}
