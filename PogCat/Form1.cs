using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace PogCat
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

       

        bool Maximized = false;
        bool mouseDown;
        private Point offset;
        public int CLICKS;
        private readonly string _path =  System.AppDomain.CurrentDomain.BaseDirectory + "\\JSONData\\allClicks.json";
        string jsonFromFile;
        Color UserTier;
        
         public static JSONFileData DataJson;
         
       
       

        

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Maximized = !Maximized;
            this.WindowState = FormWindowState.Maximized;

            if (Maximized == true)
            {
                panel1.Width = this.Width;
            }

            else
            {


                this.WindowState = FormWindowState.Normal;
                panel1.Width = this.Width;
         
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //LOAD FORM AREA


        private void Form1_Load(object sender, EventArgs e)
        {
            
            readData();
            setUpForm();
            RefreshTier();
            shopMenu1.Hide();
        }


        private void setUpForm()
        {
            GreetingBox.Text = "Hello " + DataJson.userName;
            clickCounter.ForeColor = UserTier;
            GreetingBox.ForeColor = UserTier;
        }

        private void RefreshTier()
        {
            if ((DataJson.clicks > 500) && (DataJson.clicks < 5000))
            {
                UserTier = Color.Red;
                DataJson.userTier = "Tier1";
                pictureBox2.Image = Properties.Resources.TierOne;
                setUpForm();
            }

            else if ((DataJson.clicks > 5000) && (DataJson.clicks < 15000))
            {
                UserTier = Color.Brown;
                DataJson.userTier = "Tier2";
                pictureBox2.Image = Properties.Resources.TierTwo;
                setUpForm();
            }

            else if ((DataJson.clicks > 15000) && (DataJson.clicks < 40000))
            {
                UserTier = Color.Blue;
                DataJson.userTier = "Tier3";
                pictureBox2.Image = Properties.Resources.TierThree;
                setUpForm();
            }
            else if ((DataJson.clicks > 40000))
            {
                UserTier = Color.Gold;
                DataJson.userTier = "Tier4";
                pictureBox2.Image = Properties.Resources.TierFour;
                shopButton.BringToFront();
                setUpForm();
            }
        }





        private void readData()
        {

            try
            {
                
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();

                }

                 DataJson = JsonConvert.DeserializeObject<JSONFileData>(jsonFromFile);
                
            }

            catch
            {
                // Nothing
            }
            
        }

        private void registerClicks()
        {

            if (DataJson.userTier == "Tier0")
            {
                Form1.DataJson.CPS = 1 + Form1.DataJson.SHOPCPS;
            }
            else if (DataJson.userTier == "Tier1")
            {
                Form1.DataJson.CPS = Form1.DataJson.CPS1 + Form1.DataJson.SHOPCPS;
            }
            else if (DataJson.userTier == "Tier2")
            {
                Form1.DataJson.CPS = Form1.DataJson.CPS2 + Form1.DataJson.SHOPCPS;
            }
            else if (DataJson.userTier == "Tier3")
            {
                Form1.DataJson.CPS = Form1.DataJson.CPS3 + Form1.DataJson.SHOPCPS; 
            }
            else if (DataJson.userTier == "Tier4")
            {
                Form1.DataJson.CPS = Form1.DataJson.CPS4 + Form1.DataJson.SHOPCPS;
            }
            
        }
        
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
            
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {

                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X,currentScreenPos.Y - offset.Y);



            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        
        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
          

            
            }


                 public class JSONFileData
                    {

                     public int clicks { get; set; }
                     public string userName { get; set; }
                     public int CPS { get; set; }
                     public string userTier { get; set; }
                     public int CPS1 { get; set; }
                     public int CPS2 { get; set; }
                     public int CPS3 { get; set; }
                     public int CPS4 { get; set; }
                     public int SHOPCPS { get; set; }
                    }

                 private void button5_Click(object sender, EventArgs e)
                 {
                     registerClicks();
                     DataJson.clicks += Form1.DataJson.CPS;
                     string output = JsonConvert.SerializeObject(DataJson, Newtonsoft.Json.Formatting.Indented);
                     File.WriteAllText(_path, output);
                     clickCounter.Text = "Your clicks: " + DataJson.clicks.ToString();
                     RefreshTier();
                     setUpForm();
                 }

                 private void button4_Click_2(object sender, EventArgs e)
                 {
                     DataJson.userName = userNameInput.Text;
                     setUpForm();
                 }

                 private void shopButton_Click(object sender, EventArgs e)
                 {
                     shopMenu1.Show();  
                     shopMenu1.BringToFront();
                     hideClickArea();
                 }

                 private void shopMenu1_Load(object sender, EventArgs e)
                 {
                   
                 }

                 private void hideClickArea()
                 {
                     pictureBox2.Hide();
                     GreetingBox.Hide();
                     clickCounter.Hide();
                     clickButton.Hide();

                 }

                 private void showClickArea()
                 {
                     pictureBox2.Show();
                     GreetingBox.Show();
                     clickCounter.Show();
                     clickButton.Show();

                 }

                 private void button5_Click_1(object sender, EventArgs e)
                 {
                     showClickArea();
                     shopMenu1.Hide();
                 }

                 private void button6_Click(object sender, EventArgs e)
                 {
                     if (DataJson.clicks > 3000000)
                     {
                         MessageBox.Show("Congrats You're Such a Champion!\nI've just Redirected you to my personal webpage\nJust go to the contact section at the end of the page\nAnd send me this 'IamAChampionHurricanyApp'\nAnd you might win a prize!");
                         System.Diagnostics.Process.Start("https://molhamsyr.github.io/");
                     }
                     else
                     {
                         MessageBox.Show("Sorry but You're not qualified yet!\nMaybe try next time with 3 Mil clicks");
                     }
                 }

        }

    



  






    }


