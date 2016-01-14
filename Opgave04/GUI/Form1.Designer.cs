namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbAddGame = new System.Windows.Forms.GroupBox();
            this.upDownGameTypes = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGameName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.gbAddTeam = new System.Windows.Forms.GroupBox();
            this.clbPlayers = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.tbTeamName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.tbAddPlayerMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAddPlayerTag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAddPlayerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbAddMatchSolo = new System.Windows.Forms.GroupBox();
            this.btnAddSoloMatch = new System.Windows.Forms.Button();
            this.tbSoloScores = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.downUpSoloCat = new System.Windows.Forms.DomainUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.downUpSoloGame = new System.Windows.Forms.DomainUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.clSoloMembers = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddTeamMatch = new System.Windows.Forms.Button();
            this.clTeamTeams = new System.Windows.Forms.CheckedListBox();
            this.tbTeamScores = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.downUpTeamGame = new System.Windows.Forms.DomainUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.downUpTeamCat = new System.Windows.Forms.DomainUpDown();
            this.treeRankings = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeTeams = new System.Windows.Forms.TreeView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.treeGames = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.treePlayers = new System.Windows.Forms.TreeView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.treeMatches = new System.Windows.Forms.TreeView();
            this.gbAddGame.SuspendLayout();
            this.gbAddTeam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbAddMatchSolo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddGame
            // 
            this.gbAddGame.Controls.Add(this.upDownGameTypes);
            this.gbAddGame.Controls.Add(this.label2);
            this.gbAddGame.Controls.Add(this.tbGameName);
            this.gbAddGame.Controls.Add(this.label1);
            this.gbAddGame.Controls.Add(this.btnAddGame);
            this.gbAddGame.Location = new System.Drawing.Point(12, 12);
            this.gbAddGame.Name = "gbAddGame";
            this.gbAddGame.Size = new System.Drawing.Size(242, 105);
            this.gbAddGame.TabIndex = 0;
            this.gbAddGame.TabStop = false;
            this.gbAddGame.Text = "Add game";
            // 
            // upDownGameTypes
            // 
            this.upDownGameTypes.Location = new System.Drawing.Point(71, 46);
            this.upDownGameTypes.Name = "upDownGameTypes";
            this.upDownGameTypes.Size = new System.Drawing.Size(162, 20);
            this.upDownGameTypes.TabIndex = 3;
            this.upDownGameTypes.Text = "Select type...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type:";
            // 
            // tbGameName
            // 
            this.tbGameName.Location = new System.Drawing.Point(71, 19);
            this.tbGameName.Name = "tbGameName";
            this.tbGameName.Size = new System.Drawing.Size(162, 20);
            this.tbGameName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // btnAddGame
            // 
            this.btnAddGame.Location = new System.Drawing.Point(139, 72);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(94, 23);
            this.btnAddGame.TabIndex = 0;
            this.btnAddGame.Text = "Add";
            this.btnAddGame.UseVisualStyleBackColor = true;
            this.btnAddGame.Click += new System.EventHandler(this.btnAddGame_Click);
            // 
            // gbAddTeam
            // 
            this.gbAddTeam.Controls.Add(this.clbPlayers);
            this.gbAddTeam.Controls.Add(this.label7);
            this.gbAddTeam.Controls.Add(this.btnAddTeam);
            this.gbAddTeam.Controls.Add(this.tbTeamName);
            this.gbAddTeam.Controls.Add(this.label3);
            this.gbAddTeam.Location = new System.Drawing.Point(12, 307);
            this.gbAddTeam.Name = "gbAddTeam";
            this.gbAddTeam.Size = new System.Drawing.Size(239, 190);
            this.gbAddTeam.TabIndex = 1;
            this.gbAddTeam.TabStop = false;
            this.gbAddTeam.Text = "Add team";
            // 
            // clbPlayers
            // 
            this.clbPlayers.FormattingEnabled = true;
            this.clbPlayers.Location = new System.Drawing.Point(71, 45);
            this.clbPlayers.Name = "clbPlayers";
            this.clbPlayers.Size = new System.Drawing.Size(162, 109);
            this.clbPlayers.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Members:";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Location = new System.Drawing.Point(139, 160);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(94, 23);
            this.btnAddTeam.TabIndex = 10;
            this.btnAddTeam.Text = "Add";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // tbTeamName
            // 
            this.tbTeamName.Location = new System.Drawing.Point(71, 19);
            this.tbTeamName.Name = "tbTeamName";
            this.tbTeamName.Size = new System.Drawing.Size(162, 20);
            this.tbTeamName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPlayer);
            this.groupBox1.Controls.Add(this.tbAddPlayerMail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbAddPlayerTag);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbAddPlayerName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add player";
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(139, 97);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(94, 23);
            this.btnAddPlayer.TabIndex = 4;
            this.btnAddPlayer.Text = "Add";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // tbAddPlayerMail
            // 
            this.tbAddPlayerMail.Location = new System.Drawing.Point(71, 71);
            this.tbAddPlayerMail.Name = "tbAddPlayerMail";
            this.tbAddPlayerMail.Size = new System.Drawing.Size(162, 20);
            this.tbAddPlayerMail.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mail:";
            // 
            // tbAddPlayerTag
            // 
            this.tbAddPlayerTag.Location = new System.Drawing.Point(71, 45);
            this.tbAddPlayerTag.Name = "tbAddPlayerTag";
            this.tbAddPlayerTag.Size = new System.Drawing.Size(162, 20);
            this.tbAddPlayerTag.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tag:";
            // 
            // tbAddPlayerName
            // 
            this.tbAddPlayerName.Location = new System.Drawing.Point(71, 19);
            this.tbAddPlayerName.Name = "tbAddPlayerName";
            this.tbAddPlayerName.Size = new System.Drawing.Size(162, 20);
            this.tbAddPlayerName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Name:";
            // 
            // gbAddMatchSolo
            // 
            this.gbAddMatchSolo.Controls.Add(this.btnAddSoloMatch);
            this.gbAddMatchSolo.Controls.Add(this.tbSoloScores);
            this.gbAddMatchSolo.Controls.Add(this.label11);
            this.gbAddMatchSolo.Controls.Add(this.label10);
            this.gbAddMatchSolo.Controls.Add(this.downUpSoloCat);
            this.gbAddMatchSolo.Controls.Add(this.label9);
            this.gbAddMatchSolo.Controls.Add(this.downUpSoloGame);
            this.gbAddMatchSolo.Controls.Add(this.label8);
            this.gbAddMatchSolo.Controls.Add(this.clSoloMembers);
            this.gbAddMatchSolo.Location = new System.Drawing.Point(260, 15);
            this.gbAddMatchSolo.Name = "gbAddMatchSolo";
            this.gbAddMatchSolo.Size = new System.Drawing.Size(335, 238);
            this.gbAddMatchSolo.TabIndex = 3;
            this.gbAddMatchSolo.TabStop = false;
            this.gbAddMatchSolo.Text = "Add match solo";
            // 
            // btnAddSoloMatch
            // 
            this.btnAddSoloMatch.Location = new System.Drawing.Point(235, 205);
            this.btnAddSoloMatch.Name = "btnAddSoloMatch";
            this.btnAddSoloMatch.Size = new System.Drawing.Size(91, 23);
            this.btnAddSoloMatch.TabIndex = 13;
            this.btnAddSoloMatch.Text = "Add";
            this.btnAddSoloMatch.UseVisualStyleBackColor = true;
            this.btnAddSoloMatch.Click += new System.EventHandler(this.btnAddSoloMatch_Click);
            // 
            // tbSoloScores
            // 
            this.tbSoloScores.Location = new System.Drawing.Point(9, 179);
            this.tbSoloScores.Name = "tbSoloScores";
            this.tbSoloScores.Size = new System.Drawing.Size(317, 20);
            this.tbSoloScores.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Scores [X,Y,Z]:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Category:";
            // 
            // downUpSoloCat
            // 
            this.downUpSoloCat.Location = new System.Drawing.Point(67, 20);
            this.downUpSoloCat.Name = "downUpSoloCat";
            this.downUpSoloCat.Size = new System.Drawing.Size(86, 20);
            this.downUpSoloCat.TabIndex = 15;
            this.downUpSoloCat.Text = "Select type...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Game:";
            // 
            // downUpSoloGame
            // 
            this.downUpSoloGame.Location = new System.Drawing.Point(203, 17);
            this.downUpSoloGame.Name = "downUpSoloGame";
            this.downUpSoloGame.Size = new System.Drawing.Size(123, 20);
            this.downUpSoloGame.TabIndex = 4;
            this.downUpSoloGame.Text = "Select game...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Members:";
            // 
            // clSoloMembers
            // 
            this.clSoloMembers.FormattingEnabled = true;
            this.clSoloMembers.Location = new System.Drawing.Point(67, 46);
            this.clSoloMembers.Name = "clSoloMembers";
            this.clSoloMembers.Size = new System.Drawing.Size(259, 109);
            this.clSoloMembers.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddTeamMatch);
            this.groupBox2.Controls.Add(this.clTeamTeams);
            this.groupBox2.Controls.Add(this.tbTeamScores);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.downUpTeamGame);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.downUpTeamCat);
            this.groupBox2.Location = new System.Drawing.Point(260, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 238);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add match team";
            // 
            // btnAddTeamMatch
            // 
            this.btnAddTeamMatch.Location = new System.Drawing.Point(235, 209);
            this.btnAddTeamMatch.Name = "btnAddTeamMatch";
            this.btnAddTeamMatch.Size = new System.Drawing.Size(91, 23);
            this.btnAddTeamMatch.TabIndex = 21;
            this.btnAddTeamMatch.Text = "Add";
            this.btnAddTeamMatch.UseVisualStyleBackColor = true;
            this.btnAddTeamMatch.Click += new System.EventHandler(this.btnAddTeamMatch_Click);
            // 
            // clTeamTeams
            // 
            this.clTeamTeams.FormattingEnabled = true;
            this.clTeamTeams.Location = new System.Drawing.Point(55, 49);
            this.clTeamTeams.Name = "clTeamTeams";
            this.clTeamTeams.Size = new System.Drawing.Size(271, 109);
            this.clTeamTeams.TabIndex = 23;
            // 
            // tbTeamScores
            // 
            this.tbTeamScores.Location = new System.Drawing.Point(10, 185);
            this.tbTeamScores.Name = "tbTeamScores";
            this.tbTeamScores.Size = new System.Drawing.Size(316, 20);
            this.tbTeamScores.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Teams:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Scores [X,Y,Z] :";
            // 
            // downUpTeamGame
            // 
            this.downUpTeamGame.Location = new System.Drawing.Point(206, 20);
            this.downUpTeamGame.Name = "downUpTeamGame";
            this.downUpTeamGame.Size = new System.Drawing.Size(120, 20);
            this.downUpTeamGame.TabIndex = 20;
            this.downUpTeamGame.Text = "Select game...";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Category:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(162, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Game:";
            // 
            // downUpTeamCat
            // 
            this.downUpTeamCat.Location = new System.Drawing.Point(71, 20);
            this.downUpTeamCat.Name = "downUpTeamCat";
            this.downUpTeamCat.Size = new System.Drawing.Size(85, 20);
            this.downUpTeamCat.TabIndex = 25;
            this.downUpTeamCat.Text = "Select type...";
            // 
            // treeRankings
            // 
            this.treeRankings.Location = new System.Drawing.Point(6, 19);
            this.treeRankings.Name = "treeRankings";
            this.treeRankings.Size = new System.Drawing.Size(286, 250);
            this.treeRankings.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeRankings);
            this.groupBox3.Location = new System.Drawing.Point(861, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 276);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rankings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeTeams);
            this.groupBox4.Location = new System.Drawing.Point(610, 321);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 176);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Teams";
            // 
            // treeTeams
            // 
            this.treeTeams.Location = new System.Drawing.Point(6, 19);
            this.treeTeams.Name = "treeTeams";
            this.treeTeams.Size = new System.Drawing.Size(233, 150);
            this.treeTeams.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.treeGames);
            this.groupBox5.Location = new System.Drawing.Point(610, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 128);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Games";
            // 
            // treeGames
            // 
            this.treeGames.Location = new System.Drawing.Point(6, 19);
            this.treeGames.Name = "treeGames";
            this.treeGames.Size = new System.Drawing.Size(233, 103);
            this.treeGames.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.treePlayers);
            this.groupBox6.Location = new System.Drawing.Point(610, 149);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 161);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Players";
            // 
            // treePlayers
            // 
            this.treePlayers.Location = new System.Drawing.Point(6, 19);
            this.treePlayers.Name = "treePlayers";
            this.treePlayers.Size = new System.Drawing.Size(233, 136);
            this.treePlayers.TabIndex = 8;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.treeMatches);
            this.groupBox7.Location = new System.Drawing.Point(861, 15);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(298, 199);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Matches";
            // 
            // treeMatches
            // 
            this.treeMatches.Location = new System.Drawing.Point(6, 19);
            this.treeMatches.Name = "treeMatches";
            this.treeMatches.Size = new System.Drawing.Size(286, 174);
            this.treeMatches.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 508);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbAddMatchSolo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAddTeam);
            this.Controls.Add(this.gbAddGame);
            this.Name = "Form1";
            this.Text = "E-sport Ranking -Anthony Mestdach-";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbAddGame.ResumeLayout(false);
            this.gbAddGame.PerformLayout();
            this.gbAddTeam.ResumeLayout(false);
            this.gbAddTeam.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAddMatchSolo.ResumeLayout(false);
            this.gbAddMatchSolo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddGame;
        private System.Windows.Forms.GroupBox gbAddTeam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DomainUpDown upDownGameTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGameName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.CheckedListBox clbPlayers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.TextBox tbTeamName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.TextBox tbAddPlayerMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAddPlayerTag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAddPlayerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbAddMatchSolo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DomainUpDown downUpSoloGame;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clSoloMembers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DomainUpDown downUpSoloCat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddSoloMatch;
        private System.Windows.Forms.TextBox tbSoloScores;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddTeamMatch;
        private System.Windows.Forms.CheckedListBox clTeamTeams;
        private System.Windows.Forms.TextBox tbTeamScores;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DomainUpDown downUpTeamGame;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DomainUpDown downUpTeamCat;
        private System.Windows.Forms.TreeView treeRankings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TreeView treeTeams;
        private System.Windows.Forms.TreeView treeGames;
        private System.Windows.Forms.TreeView treePlayers;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TreeView treeMatches;
    }
}

