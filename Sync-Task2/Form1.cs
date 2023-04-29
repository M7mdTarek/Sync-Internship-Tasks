using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Sync_Task2
{
    public partial class Form1 : Form
    {
        private Election election;
        ListBox candidateListBox = new ListBox();
        Label winnerLabel = new Label();
        public Form1()
        {
            InitializeComponent();
            election = new Election(3); // 3 candidates
            election.AddCandidate(0, "Candidate 1");
            election.AddCandidate(1, "Candidate 2");
            election.AddCandidate(2, "Candidate 3");
            election.DisplayCandidates(candidateListBox);
        }
        private void voteButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = candidateListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                election.Vote(selectedIndex);
                candidateListBox.Items.Clear();
                election.DisplayCandidates(candidateListBox);
                election.DisplayWinner(winnerLabel);
            }
        }

        
    }
}
