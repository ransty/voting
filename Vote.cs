﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting
{
    class Vote
    {
        int VoteSize;
        String[] candidates;
        int[] votes;
        Boolean isValid;

        public int[] Votes
        {
            get
            {
                return votes;
            }

        }

        public Vote(String[] cand, int[] voting)
        {

            candidates = cand;
            votes = voting;
            VoteSize = votes.Length;
            isValid = vaildTest();

        }

        private bool vaildTest()
        {
            //double number
            for (int index = 0; index < votes.Length; index++)
            {
                for (int compare = index + 1; compare < votes.Length; compare++)
                {
                    if (votes[index] == votes[compare])
                    {
                        return false;
                    }
                }
            }

            // number all used 
            var NumberList = Enumerable.Range(1, VoteSize).ToList();
            for (int index = 0; index < votes.Length; index++)
            {
                if (votes[index] <= VoteSize)
                {
                    if (NumberList.Contains(votes[index]))
                    {
                        NumberList.Remove(votes[index]);
                    }
                }
                else { return false; }

            }
            if (NumberList.Count != 0)
            {
                return false;
            }

            return true;
        }

        public void dropcand(int index3)
        {
            //Changing votes
            int Current = votes[index3];
            votes[index3] = -1;
            while (Current < VoteSize)
            {
                for (int index = 0; index < votes.Length; index++)//1,2,3,4,6 should be 5
                {
                    if (votes[index] == Current + 1)
                    {
                        votes[index] = Current;
                        Current = Current + 1;
                    }
                }

                
            }
            VoteSize -= 1;

        }


        public void dropcand(String name)
        {

            int indexOfCand = -1;

            //find cand
            if (VoteForm.cand.Contains(name))
            {
                for (int index = 0; index < VoteForm.cand.Length; index++)
                {
                    if (VoteForm.cand[index].Equals(name))
                    {
                        indexOfCand = index;
                    }
                }
            }
            dropcand(indexOfCand);
        }

        public bool getValid()
        {

            return isValid;
        }

        ///Loop cand
        ///x = can
        ///x
        ///


        // [1,2,3,4,5]
        // [-1,1,2,3,4]
    }
}
