using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sync_Task2
{
    public class Election
    {
        private Candidate[] candidates;

        public Election(int numCandidates)
        {
            candidates = new Candidate[numCandidates];
        }

        public void AddCandidate(int index, string name)
        {
            candidates[index] = new Candidate { Name = name, Votes = 0 };
        }

        public void Vote(int index)
        {
            candidates[index].Votes++;
        }

        public void DisplayCandidates(ListBox lb)
        {
            foreach (Candidate c in candidates)
            {
                lb.Items.Add(c.Name + ": " + c.Votes);
            }
        }

        public void DisplayWinner(Label winnerLabel)
        {
            //Candidate winner = candidates[0];
            int maxVotes = 0;
            string winner = "";
            bool isDraw = false;

            foreach (var candidate in candidates)
            {
                if (candidate.Votes > maxVotes)
                {
                    maxVotes = candidate.Votes;
                    winner = candidate.Name;
                    isDraw = false;
                }
                else if (candidate.Votes == maxVotes)
                {
                    isDraw = true;
                }
            }
            if (isDraw)
            {
                winnerLabel.Text = "It's a draw!";
            }
            else
            {
                winnerLabel.Text = "The winner is " + winner + " with " + maxVotes + " votes!";
            }
        }
    }
}
