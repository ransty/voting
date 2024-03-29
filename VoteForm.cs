﻿using System;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace Voting
{
    public partial class VoteForm : Form
    {

        /**
         * Instance Variables
         **/
        static public string[] cand;
        List<Vote> VotingRoll;
        Boolean VotingOver;
        String WinningCand;
        List<String[]> rounds;
        List<int> CuttedCand;
        int[] currentVotes;
        // Declare the PrintDocument object.
        private System.Drawing.Printing.PrintDocument docToPrint =
            new System.Drawing.Printing.PrintDocument();

        /**
         * Constructor
         **/
        public VoteForm()
        {
            InitializeComponent();
            VotingRoll = new List<Vote> { };
            VotingOver = false;
            WinningCand = null;
            CuttedCand = new List<int> { };
            rounds = new List<String[]> { };
            currentVotes = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Import CSV File
        /**
         *  Uses the Import button on the menuStrip. 
         *  Opens a FileDialog for the user to select a file to import, CSV only.
         **/
        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
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
                        cand = candidates.Split(',');
                        for (int i = 0; i < cand.Length; i++)
                        {
                            cand[i].Replace("'", "");
                        }
                        int[] votes = new int[cand.Length];
                        //Console.WriteLine("Number of Cands: " + votes.Length);
                        // Now we gonna keep track of votes
                        string line;
                        // Read the stream to a string
                        while ((line = sr.ReadLine()) != null)
                        {
                            ///Grab 
                            // So if we are splitting this line, first split is cand[0], second is cand[1] etc....
                            string[] split = line.Split(',');

                            int[] VoteInt = Array.ConvertAll(split, int.Parse);

                            VotingRoll.Add(new Vote(cand, VoteInt));
                        }
                        countBtn.Enabled = true;
                        removeBtn.Enabled = true;
                        
                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show("The file could not be read:");
                    Console.WriteLine(ec.Message);
                }
            }
        }
        #endregion

        /**
         * Calculate the current round when the button COUNT is pressed.
         * Takes no parameters as it uses the Vote object that is stored when importing.
         **/
        private int cal()// Did some one win, who cuts
        {
            barChartToolStripMenuItem.Enabled = true;
            switch (cand.Length)
            {
                case 1:
                    candidateController.candLabel1.Text = cand[0];
                    break;
                case 2:
                    candidateController.candLabel2.Text = cand[1];
                    goto case 1;
                case 3:
                    candidateController.candLabel3.Text = cand[2];
                    goto case 2;
                case 4:
                    candidateController.candLabel4.Text = cand[3];
                    goto case 3;
                case 5:
                    candidateController.candLabel5.Text = cand[4];
                    goto case 4;
                case 6:
                    candidateController.candLabel6.Text = cand[5];
                    goto case 5;
                case 7:
                    candidateController.candLabel7.Text = cand[6];
                    goto case 6;
                case 8:
                    candidateController.candLabel8.Text = cand[7];
                    goto case 7;
                case 9:
                    candidateController.candLabel9.Text = cand[8];
                    goto case 8;
                case 10:
                    candidateController.candLabel10.Text = cand[9];
                    goto case 9;
                default:
                    break;
            }

            int[] totalForCand = new int[cand.Length];
            double[] percent = new double[cand.Length];
            int totalVotes = VotingRoll.Count;

            //for  each vote
            for (int i = 0; i < VotingRoll.Count; i++)
            {
                Vote Current = VotingRoll.ElementAt(i);
                if (Current.getValid())
                {
                    //Get the first vote
                    for (int index = 0; index < Current.Votes.Length; index++)
                    {
                        if (Current.Votes[index] == 1)
                        {
                            totalForCand[index] += 1;
                        }
                    }
                }
            }

            switch (cand.Length)
            {
                case 1:
                    candidateController.scoreLabel1.Text = totalForCand[0].ToString();
                    break;
                case 2:
                    candidateController.scoreLabel2.Text = totalForCand[1].ToString();
                    goto case 1;
                case 3:
                    candidateController.scoreLabel3.Text = totalForCand[2].ToString();
                    goto case 2;
                case 4:
                    candidateController.scoreLabel4.Text = totalForCand[3].ToString();
                    goto case 3;
                case 5:
                    candidateController.scoreLabel5.Text = totalForCand[4].ToString();
                    goto case 4;
                case 6:
                    candidateController.scoreLabel6.Text = totalForCand[5].ToString();
                    goto case 5;
                case 7:
                    candidateController.scoreLabel7.Text = totalForCand[6].ToString();
                    goto case 6;
                case 8:
                    candidateController.scoreLabel8.Text = totalForCand[7].ToString();
                    goto case 7;
                case 9:
                    candidateController.scoreLabel9.Text = totalForCand[8].ToString();
                    goto case 8;
                case 10:
                    candidateController.scoreLabel10.Text = totalForCand[9].ToString();
                    goto case 9;
                default:
                    break;
            }

            //
            for (int i = 0; i < totalForCand.Length; i++)
            {
                percent[i] = (totalForCand[i] * 100) / totalVotes;
                if (percent[i] > 50)
                {
                    VotingOver = true;

                    WinningCand = cand[i];
                }
            }

            int lowest = totalForCand[0];
            int lowIndex = 0;
            // cut people out if noone is a winner
            for (int i = 0; i < totalForCand.Length; i++)
            {
                if (totalForCand[i] < 0)
                {
                    continue;
                }

                if (totalForCand[i] < lowest && !CuttedCand.Contains(i))
                {
                    lowest = totalForCand[i];
                    lowIndex = i;
                }
                //
                //Console.WriteLine("Candidate " + cand[i] + " has the total percentage of Votes of: " + percent[i] + "%");
            }
            // results for round x
            String[] results = new string[cand.Length + 1]; // Round , score/ cut ++++
            results[0] = rounds.Count.ToString();

            for (int loop = 0; loop < cand.Length; loop++)
            {
                if (CuttedCand.Contains(loop) || loop == lowIndex)
                {//P if cut 
                    results[loop + 1] = "P";
                }
                else
                {
                    results[loop + 1] = totalForCand[loop].ToString();
                }
            }
            rounds.Add(results);
            currentVotes = new int[cand.Length];
            currentVotes = totalForCand;
            return lowIndex;
        }

        /**
         * Determines which candidate has to be cut from the current round
         **/
        private void CutCand(int cut)
        {
            for (int i = 0; i < VotingRoll.Count; i++)
            {
                Vote Current = VotingRoll.ElementAt(i);
                if (Current.getValid())
                {
                    Current.dropcand(cut);
                }

            }
            CuttedCand.Add(cut);
        }

        /**
         * Count button, has a saftey check to ensure that we don't cut out too many people or stop the program early
         **/
        private void button1_Click(object sender, EventArgs e)
        {
            int candToBeCut = -1;

            if (!VotingOver && cand != null)
            {
                candToBeCut = cal();
                Console.WriteLine(candToBeCut);
                if (VotingOver)
                {
                    winnerLabel.Text = "The winner is + " + WinningCand;
                    countBtn.Enabled = false;
                }
            }
            if (!VotingOver && cand != null && candToBeCut != -1)
            {
                CutCand(candToBeCut);
            }
        }

        /**
         * Export to CSV file.
         **/
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV Files|*.CSV";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {



                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(myStream);

                    string line = "Round";
                    for (int i = 0; i < cand.Length; i++)
                    {
                        line += "," + cand[i];
                    }
                    writer.WriteLine(line);
                    // 
                    string tempLine = "";

                    for (int j = 0; j < rounds.Count; j++)
                    {
                        tempLine = "";
                        String[] CurrentRound = rounds.ElementAt(j);

                        for (int eachRound = 0; eachRound < CurrentRound.Length; eachRound++)
                        {
                            if (eachRound != 0) { tempLine += ","; }
                            tempLine += CurrentRound[eachRound];
                        }
                        writer.WriteLine(tempLine);
                    }
                    writer.Close();
                    myStream.Close();
                }
            }
        }

        /**
         *  Remove invalid votes
         **/
        private void removeBtn_Click(object sender, EventArgs e)
        {

            List<Vote> toBeRemoved = new List<Vote> { };

            foreach (Vote x in VotingRoll)
            {
                if (x.getValid() == false)
                {
                    toBeRemoved.Add(x);
                }
            }
            foreach (Vote x in toBeRemoved)
            {
                VotingRoll.Remove(x);
            }
            MessageBox.Show("Removed a total of " + toBeRemoved.Count + " invalid votes", "Invalid Votes");
        }

        /**
         * Bar Chart button on menuStrip underneath Graph
         */
        private void pieChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateChart();
        }

        /**
         *  Generates a bar chart modal based on the current round
         **/
        private void generateChart()
        {
            Form f = new Form();
            Chart chart = new Chart();
            f.Width = 500;
            f.Height = 500;
            //Vertical bar chart
            //create another area and add it to the chart
            ChartArea area2 = new ChartArea("First");
            chart.ChartAreas.Add(area2);
            Series barSeries2 = new Series();
            barSeries2.Points.DataBindY(currentVotes);
            //Set the chart type, column; vertical bars
            barSeries2.ChartType = SeriesChartType.Column;
            barSeries2.ChartArea = "First";
            barSeries2.Points[0].AxisLabel = cand[0];
            barSeries2.Points[1].AxisLabel = cand[1];
            barSeries2.Points[2].AxisLabel = cand[2];
            barSeries2.Points[3].AxisLabel = cand[3];
            barSeries2.Points[4].AxisLabel = cand[4];
            barSeries2.Points[5].AxisLabel = cand[5];
            chart.Dock = DockStyle.Fill;
            //Add the series to the chart
            chart.Series.Add(barSeries2);

            f.Controls.Add(chart);
            f.ShowDialog();
        }

        #region Print
        /**
         * Print file button on menuStrip, brings up printdialog
         **/
        private void printToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.AllowSomePages = true;

            // Show the help button.
            printDialog.ShowHelp = true;
            printDialog.Document = docToPrint;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        /**
         * Method used to print the document
         **/
        private void document_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {

            string line = "Round";
            for (int i = 0; i < cand.Length; i++)
            {
                line += cand[i] + "\n";
            }
            // 
            string tempLine = "";

            for (int j = 0; j < rounds.Count; j++)
            {
                tempLine = "";
                String[] CurrentRound = rounds.ElementAt(j);

                for (int eachRound = 0; eachRound < CurrentRound.Length; eachRound++)
                {
                    if (eachRound != 0) { tempLine += ","; }
                    tempLine += CurrentRound[eachRound] + "\n";
                }
            }

            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", 35, System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(line, printFont,
                System.Drawing.Brushes.Black, 10, 10);
            e.Graphics.DrawString(tempLine, printFont, System.Drawing.Brushes.Black, 10, 10);
        }
        #endregion

        #region Print Preview
        /**
         * Unimplemented Print Preview
         **/
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        #endregion
    }
}
