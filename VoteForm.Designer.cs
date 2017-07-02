namespace Voting
{
    partial class VoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoteForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countBtn = new System.Windows.Forms.Button();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.removeBtn = new System.Windows.Forms.Button();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidateController = new Voting.CandidateController();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.graphToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.printToFileToolStripMenuItem,
            this.printPreviewToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.importToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // printToFileToolStripMenuItem
            // 
            this.printToFileToolStripMenuItem.Name = "printToFileToolStripMenuItem";
            this.printToFileToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToFileToolStripMenuItem.Text = "Print to File";
            this.printToFileToolStripMenuItem.Click += new System.EventHandler(this.printToFileToolStripMenuItem_Click);
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barChartToolStripMenuItem});
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphToolStripMenuItem.Text = "Graph";
            // 
            // barChartToolStripMenuItem
            // 
            this.barChartToolStripMenuItem.Enabled = false;
            this.barChartToolStripMenuItem.Name = "barChartToolStripMenuItem";
            this.barChartToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.barChartToolStripMenuItem.Text = "Bar Chart";
            this.barChartToolStripMenuItem.Click += new System.EventHandler(this.pieChartToolStripMenuItem_Click);
            // 
            // countBtn
            // 
            this.countBtn.Enabled = false;
            this.countBtn.Location = new System.Drawing.Point(223, 342);
            this.countBtn.Name = "countBtn";
            this.countBtn.Size = new System.Drawing.Size(75, 23);
            this.countBtn.TabIndex = 1;
            this.countBtn.Text = "Count";
            this.countBtn.UseVisualStyleBackColor = true;
            this.countBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Location = new System.Drawing.Point(203, 301);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(0, 13);
            this.winnerLabel.TabIndex = 4;
            // 
            // removeBtn
            // 
            this.removeBtn.Enabled = false;
            this.removeBtn.Location = new System.Drawing.Point(13, 342);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 5;
            this.removeBtn.Text = "Remove Invalid";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog1";
            this.printPreviewDialog.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // candidateController
            // 
            this.candidateController.Location = new System.Drawing.Point(175, 27);
            this.candidateController.Name = "candidateController";
            this.candidateController.Size = new System.Drawing.Size(159, 271);
            this.candidateController.TabIndex = 3;
            // 
            // VoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 377);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.winnerLabel);
            this.Controls.Add(this.candidateController);
            this.Controls.Add(this.countBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VoteForm";
            this.Text = "Vote Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Button countBtn;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barChartToolStripMenuItem;
        private CandidateController candidateController;
        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ToolStripMenuItem printToFileToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    }
}

