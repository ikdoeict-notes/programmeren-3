using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataEntities;
using LogicImplementation;
using LogicInterfaces;

namespace GUI
{
    /// <summary>
    /// Contains a basic GUI for E-sport Ranking
    /// TODO:   -Add more custom error messages
    ///         -Add more user input checks
    ///         -Make Form responsive
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // init add game gb
            upDownGameTypes.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(ParticipantTypes)))
            {
                upDownGameTypes.Items.Add(s);
            }
            // init gui
            UpdatePlayerList();
            UpdateTeamList();
            UpdateCatList();
            UpdateGameList();
            UpdateTree();
        }

        private void UpdatePlayerList()
        {
            clbPlayers.Items.Clear();
            clSoloMembers.Items.Clear();
            IPlayerManipulations playerLogic = new PlayerLogic();
            foreach (PlayerType player in playerLogic.GetPlayers())
            {
                clbPlayers.Items.Add($"Name: {player.Name}  Mail: {player.Mail}");
                clSoloMembers.Items.Add($"Name: {player.Name}  Mail: {player.Mail}");
            }
        }

        private void UpdateTeamList()
        {
            ITeamManipulations teamLogic = new TeamLogic();
            clTeamTeams.Items.Clear();
            foreach (TeamType t in teamLogic.GetTeams())
            {
                clTeamTeams.Items.Add($"Name: {t.Name} - Members: {t.Members.Count}");
            }
        }

        private void UpdateCatList()
        {
            downUpSoloCat.Items.Clear();
            downUpTeamCat.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(MatchCategories)))
            {
                downUpSoloCat.Items.Add(s);
                downUpTeamCat.Items.Add(s);
            }
        }

        private void UpdateGameList()
        {
            IGameManipulations gameLogic = new GameLogic();
            downUpSoloGame.Items.Clear();
            downUpTeamGame.Items.Clear();
            foreach (GameType g in gameLogic.GetGames())
            {
                if ((g.ParticipantType == ParticipantTypes.Solo) || (g.ParticipantType == ParticipantTypes.All))
                {
                    downUpSoloGame.Items.Add(g.Name);
                }
                if ((g.ParticipantType == ParticipantTypes.Team) || (g.ParticipantType == ParticipantTypes.All))
                {
                    downUpTeamGame.Items.Add(g.Name);
                }
            }
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
            IGameManipulations gameLogic = new GameLogic();
            try
            {
                gameLogic.AddOrUpdateGame(new GameType(tbGameName.Text, (ParticipantTypes)Enum.Parse(typeof(ParticipantTypes), upDownGameTypes.SelectedItem.ToString())));
                tbGameName.Text = "";
                UpdateGameList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Add Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateTree();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            IPlayerManipulations playerLogic = new PlayerLogic();
            if (tbAddPlayerName.Text != "")
            {
                try
                {
                    playerLogic.AddOrUpdatePlayer(new PlayerType(tbAddPlayerMail.Text, tbAddPlayerName.Text, tbAddPlayerTag.Text));
                    tbAddPlayerMail.Text = "";
                    tbAddPlayerName.Text = "";
                    tbAddPlayerTag.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error: Add Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Player needs a name.", "Error: Add Player", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdatePlayerList();
            UpdateTree();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            IPlayerManipulations playerLogic = new PlayerLogic();
            ITeamManipulations teamLogic = new TeamLogic();
            List<PlayerType> players = new List<PlayerType>();
            if (tbTeamName.Text != "")
            {
                try
                {
                    for (int i = 0; i < clbPlayers.CheckedItems.Count; i++)
                    {
                        players.Add(playerLogic.GetPlayers()[clbPlayers.Items.IndexOf(clbPlayers.CheckedItems[i])]);
                    }
                    if (players.Count > 0)
                    {
                        teamLogic.AddOrUpdateTeam(new TeamType(tbTeamName.Text, players));
                        tbTeamName.Text = "";
                        UpdateTeamList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error: Add Team", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Team needs a name.", "Error: Add Team", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateTree();
        }

        private void btnAddSoloMatch_Click(object sender, EventArgs e)
        {
            IMatchManipulations matchLogic = new MatchLogic();
            IPlayerManipulations playerLogic = new PlayerLogic();
            IGameManipulations gameLogic = new GameLogic();
            try
            {
                List<PlayerType> players = new List<PlayerType>();
                MatchCategories cat = (MatchCategories)Enum.Parse(typeof(MatchCategories), downUpSoloCat.SelectedItem.ToString());
                GameType game = gameLogic.GetGames()[downUpSoloGame.SelectedIndex];
                List<int> scores = new List<int>();
                string[] parts = tbSoloScores.Text.Split(',');
                foreach (string s in parts)
                {
                    scores.Add(int.Parse(s));
                }
                for (int i = 0; i < clSoloMembers.CheckedItems.Count; i++)
                {
                    players.Add(playerLogic.GetPlayers()[clSoloMembers.Items.IndexOf(clSoloMembers.CheckedItems[i])]);
                }
                if ((players.Count > 0) && (players.Count == scores.Count))
                {
                    matchLogic.AddOrUpdateSoloMatch(new SoloMatch(players, scores, cat, game));
                    tbSoloScores.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid scores.", "Error: Add Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Add Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateTree();
        }

        private void btnAddTeamMatch_Click(object sender, EventArgs e)
        {
            IMatchManipulations matchLogic = new MatchLogic();
            ITeamManipulations teamLogic = new TeamLogic();
            IGameManipulations gameLogic = new GameLogic();
            try
            {
                List<TeamType> teams = new List<TeamType>();
                MatchCategories cat = (MatchCategories)Enum.Parse(typeof(MatchCategories), downUpTeamCat.SelectedItem.ToString());
                GameType game = gameLogic.GetGames()[downUpTeamGame.SelectedIndex];
                List<int> scores = new List<int>();
                string[] parts = tbTeamScores.Text.Split(',');
                foreach (string s in parts)
                {
                    scores.Add(int.Parse(s));
                }
                for (int i = 0; i < clTeamTeams.CheckedItems.Count; i++)
                {
                    teams.Add(teamLogic.GetTeams()[clTeamTeams.Items.IndexOf(clTeamTeams.CheckedItems[i])]);
                }
                if ((teams.Count > 0) && (teams.Count == scores.Count))
                {
                    matchLogic.AddOrUpdateTeamMatch(new TeamMatch(cat, game, teams, scores));
                    tbTeamScores.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid scores.", "Error: Add Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Add Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateTree();
        }
        
        private void UpdateTree()
        {
            IRankingSource rankingLogic = new RankingLogic();
            IGameManipulations gameLogic = new GameLogic();
            ITeamManipulations teamLogic = new TeamLogic();
            IPlayerManipulations playerLogic = new PlayerLogic();
            IMatchManipulations matchLogic = new MatchLogic();

            List<GameType> games = gameLogic.GetGames();
            List<TeamType> teams = teamLogic.GetTeams();
            List<PlayerType> players = playerLogic.GetPlayers();

            // ranking tree
            treeRankings.BeginUpdate();
            treeRankings.Nodes.Clear();
            for (int i = 0; i < games.Count; i++)
            {
                List<PlayerGameRankingType> r = rankingLogic.GetGameRankingsAll(games[i], ParticipantTypes.All);
                treeRankings.Nodes.Add(games[i].Name);
                for (int j = 0; j < r.Count; j++)
                {
                    treeRankings.Nodes[i].Nodes.Add("Player: " + r[j].Player.Name);
                    treeRankings.Nodes[i].Nodes[j].Nodes.Add("Mail: " + r[j].Player.Mail);
                    treeRankings.Nodes[i].Nodes[j].Nodes.Add("Tag: " + r[j].Player.Tag);
                    treeRankings.Nodes[i].Nodes[j].Nodes.Add("Points: " + r[j].Points);
                    treeRankings.Nodes[i].Nodes[j].Nodes.Add("Ranking: " + r[j].Ranking);
                }
            }
            treeRankings.EndUpdate();

            // games tree
            treeGames.BeginUpdate();
            treeGames.Nodes.Clear();
            for (int i = 0; i < games.Count; i++)
            {
                treeGames.Nodes.Add(games[i].Name);
                treeGames.Nodes[i].Nodes.Add("Participant type: " + games[i].ParticipantType.ToString());
            }
            treeGames.EndUpdate();

            // teams tree
            treeTeams.BeginUpdate();
            treeTeams.Nodes.Clear();
            for (int i = 0; i < teams.Count; i++)
            {
                treeTeams.Nodes.Add(teams[i].Name);
                for (int j = 0; j < teams[i].Members.Count; j++)
                {
                    treeTeams.Nodes[i].Nodes.Add($"Player: {teams[i].Members[j].Name} - {teams[i].Members[j].Tag} - {teams[i].Members[j].Mail}");
                }
            }
            treeTeams.EndUpdate();

            // players tree
            treePlayers.BeginUpdate();
            treePlayers.Nodes.Clear();
            for (int i = 0; i < players.Count; i++)
            {
                treePlayers.Nodes.Add(players[i].Name);
                treePlayers.Nodes[i].Nodes.Add("Tag: " + players[i].Tag);
                treePlayers.Nodes[i].Nodes.Add("Mail: " + players[i].Mail);
            }
            treePlayers.EndUpdate();

            // matches tree
            treeMatches.BeginUpdate();
            treeMatches.Nodes.Clear();
            for (int i = 0; i < games.Count; i++)
            {
                List<MatchType> matches = matchLogic.GetMatchesAll(games[i]);
                treeMatches.Nodes.Add($"Matches for: {games[i].Name}");
                for (int j = 0; j < matches.Count; j++)
                {
                    if (matches[j] is SoloMatch)
                    {
                        SoloMatch s = (SoloMatch)matches[j];
                        treeMatches.Nodes[i].Nodes.Add(s.dateTime.ToString());
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Name: {s.GameID.Name}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Type: {s.GameID.ParticipantType.ToString()}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Category: {s.Category.ToString()}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add("Players & scores");
                        for (int k = 0; k < s.Players.Count; k++)
                        {
                            treeMatches.Nodes[i].Nodes[j].Nodes[3].Nodes.Add($"Player: {s.Players[k].Name} : {s.Scores[k]}");
                        }
                    }
                    else if (matches[j] is TeamMatch)
                    {
                        TeamMatch t = (TeamMatch)matches[j];
                        treeMatches.Nodes[i].Nodes.Add(t.dateTime.ToString());
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Name: {t.GameID.Name}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Type: {t.GameID.ParticipantType.ToString()}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add($"Category: {t.Category.ToString()}");
                        treeMatches.Nodes[i].Nodes[j].Nodes.Add("Teams & scores");
                        for (int k = 0; k < t.Teams.Count; k++)
                        {
                            treeMatches.Nodes[i].Nodes[j].Nodes[3].Nodes.Add($"Team: {t.Teams[k].Name} : {t.Scores[k]}");
                        }
                    }
                }
            }
            treeMatches.EndUpdate();
        }
    }
}
