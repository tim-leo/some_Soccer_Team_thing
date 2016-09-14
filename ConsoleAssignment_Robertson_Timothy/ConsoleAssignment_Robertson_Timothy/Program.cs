/*
 *          THIS PROJECT HAS BEEN MADE BY TIMOTHY LEO ROBERTSON
 *                              DATE: 09/13/2016
 *                              TEAM: 2-9 (team "a")
 * DESCRIPTION: this is a soccer team simulator that when given the amount of teams playing,  
 *      team name and point total will output in descending order who won. It also throws errors if the data entry type is incorrect.
 *      I gold plated this by adding in sound clip files for each error message that pops up in its own window
*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
//importing the stuff the program needs
namespace ConsoleAssignment_Robertson_Timothy
{

    //here are the classes that the code uses
    //first is the Team class, this is the parent class
    class Team
    {
        public string name;
        public int wins;
        public int loss;
    }
    //inherits the parent class
    class SoccerTeam : Team
    {
        public int draw;
        public int goalsFor;
        public int goalsAgainst;
        public int differential;
        public int points;
        //most of these are unused attributes
        //this is the constructor
        public SoccerTeam(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
    //this is the class for the sound files
    class Hank
    {
        //this method calls the function
        public static void bwah()
        {
            playaudio();
        }
        //this method is to define the audio and pull it from its source file in the program
        public static void playaudio() 
        {
            SoundPlayer audio = new SoundPlayer(ConsoleAssignment_Robertson_Timothy.Properties.Resources.hank1); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Play();
        }
        //repeat but for sound bit two
        public static void doh()
        {
            playaudio1(); // calling the function
        }

        public static void playaudio1() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(ConsoleAssignment_Robertson_Timothy.Properties.Resources.doh); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
            audio.Play();
        }

    }
    //game class but it is unused
    class Game
    {

    }




    //main class
    class Program
    {

        //this is the main method
        static void Main(string[] args)
        {

            //variables
            int iTeams = 0;
            bool bError = false;
            //instantiation of the list of objects
            List<SoccerTeam> TeamList = new List<SoccerTeam>();
            Console.WriteLine("To more fully enjoy this program... Make sure your speakers aren't muted!\n\n");
            //try catch for the # of teams
            while (bError == false)
            {

                try
                {
                    Console.Write("How many teams?" + "\t");
                    iTeams = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    bError = true;
                }
                catch (Exception)
                {
                    //this is the sound file that was embedded
                    Hank.bwah();
                    //displays a message box as well 
                    MessageBox.Show("Use a number!", "DANG IT BOBBY!");
                }
            }        

            //for loop that will load up the soccerteam list
            for (int iCount = 1; iCount <= iTeams; iCount++)
            {
                
                string sName;
                int iPoints = 0;
                bool bError1 = false;
              
                //asks for team name
                
                Console.Write("Enter Team " + iCount + "'s name: " + "\t");
                sName = UppercaseFirst(Console.ReadLine());

                //try catch for entering the team points
                while (bError1 == false)
                {
                    try
                    {
                        Console.Write("Enter " + sName + "'s points: " + "\t");
                        iPoints = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        bError1 = true;
                    }
                    catch
                    {
                        //same as before
                        Hank.doh();

                        MessageBox.Show("Use a number!", "BAAAAART!");
                    }


                }

                //this adds the info to the teamlist
               TeamList.Add(new SoccerTeam(sName, iPoints));

            }

            //this displays the table headers
            Console.WriteLine("Here is the sorted list: \n");
            Console.WriteLine("Position" + "\tName" + "\t\t\tPoints");
            Console.WriteLine("--------" + "\t----" + "\t\t\t------");

   
            //sorts the teamlist into a sortedteam list
            List<SoccerTeam> sortedTeams = TeamList.OrderByDescending(team => team.points).ToList();

            //loop to display all the teams
            foreach (SoccerTeam team in sortedTeams)
            {
                Console.Write((sortedTeams.IndexOf(team) + 1) + "\t\t");
                Console.Write(Convert.ToString(team.name).PadRight(25, ' '));
                Console.Write(team.points + "\n");



            }

            Console.ReadLine();
        }
       

        //this is the uppercase method left here so we don't have to create another class
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
