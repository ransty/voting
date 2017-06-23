using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace Voting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Import CSV File
        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files|*.CSV";
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        // According to CSV rules, first line will always have the candidates, so lets track that
                        string candidates = sr.ReadLine();
                        string[] cand = candidates.Split(',');
                        int[] votes = new int[cand.Length];
                        Console.WriteLine("Number of Cands: " + votes.Length);
                        // Now we gonna keep track of votes
                        string line;
                            // Read the stream to a string
                            while ((line = sr.ReadLine()) != null)
                            {
                            // So if we are splitting this line, first split is cand[0], second is cand[1] etc....
                            string[] split = line.Split(',');
                            for (int i = 0; i < votes.Length; i++)
                            {
                                if (split[i].Equals("1"))
                                {
                                    votes[i] += Int32.Parse(split[i]);
                                }
                            }

                            }

                        // Check who won
                        double[] percent = new double[votes.Length];
                        int totalVotes = votes.Sum();
                        for (int i = 0; i < votes.Length; i++)
                        {
                            cand[i] = cand[i].Replace("\"", "");
                            percent[i] = (votes[i] * 100) / totalVotes;
                            Console.WriteLine("Candidate " + cand[i] + " has the total percentage of Votes of: " + percent[i] + "%");

                        }

                        // Now check who got that 50% or gr8er
                        if (percent.Contains(50))
                        {
                            Console.WriteLine("TRUE");
                        } else
                        {
                            Console.WriteLine("FALSE, we got a tie break, pick a winner from the equal votes");
                            Console.WriteLine("Picking a random candidate to be the winner :)");

                        }


                    }
                }
                catch (Exception ec)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ec.Message);
                }
            }
        }
        #endregion

    }
}
