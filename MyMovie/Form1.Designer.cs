namespace MyMovie
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblLent = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottomSpacer = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.lblHP = new System.Windows.Forms.LinkLabel();
            this.lblTrailer = new System.Windows.Forms.LinkLabel();
            this.flpScreenshots = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbActor = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOrgTitel = new System.Windows.Forms.TextBox();
            this.tbGenre = new System.Windows.Forms.TextBox();
            this.tbRegi = new System.Windows.Forms.TextBox();
            this.tbJahr = new System.Windows.Forms.TextBox();
            this.lblOrgTitel = new System.Windows.Forms.Label();
            this.cbWish = new System.Windows.Forms.CheckBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cbSeen = new System.Windows.Forms.CheckBox();
            this.starRating1 = new MantusStarRating.StarRating();
            this.lblAddDate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.ilsIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.image = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.pnlContainer);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups1"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups2"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups3"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups4"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups5"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups6"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups7"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups8"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups9"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups10"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups11"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups12"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups13"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups14"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups15"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups16"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups17"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups18"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups19"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups20"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups21"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups22"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups23"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups24"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups25"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups26"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups27"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups28"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups29"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups30"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups31"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups32"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups33"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups34"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups35"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups36"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("listView1.Groups37")))});
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // pnlContainer
            // 
            resources.ApplyResources(this.pnlContainer, "pnlContainer");
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Controls.Add(this.lblLent);
            this.pnlContainer.Controls.Add(this.lblPrice);
            this.pnlContainer.Controls.Add(this.label7);
            this.pnlContainer.Controls.Add(this.lblDCount);
            this.pnlContainer.Controls.Add(this.label6);
            this.pnlContainer.Controls.Add(this.lblMType);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.pnlBottomSpacer);
            this.pnlContainer.Controls.Add(this.label8);
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Controls.Add(this.cbWish);
            this.pnlContainer.Controls.Add(this.pbImage);
            this.pnlContainer.Controls.Add(this.cbSeen);
            this.pnlContainer.Controls.Add(this.starRating1);
            this.pnlContainer.Controls.Add(this.lblAddDate);
            this.pnlContainer.Name = "pnlContainer";
            // 
            // lblLent
            // 
            resources.ApplyResources(this.lblLent, "lblLent");
            this.lblLent.ForeColor = System.Drawing.Color.Red;
            this.lblLent.Name = "lblLent";
            // 
            // lblPrice
            // 
            resources.ApplyResources(this.lblPrice, "lblPrice");
            this.lblPrice.Name = "lblPrice";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblDCount
            // 
            resources.ApplyResources(this.lblDCount, "lblDCount");
            this.lblDCount.Name = "lblDCount";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lblMType
            // 
            resources.ApplyResources(this.lblMType, "lblMType");
            this.lblMType.Name = "lblMType";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // pnlBottomSpacer
            // 
            resources.ApplyResources(this.pnlBottomSpacer, "pnlBottomSpacer");
            this.pnlBottomSpacer.Name = "pnlBottomSpacer";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Name = "label8";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.lblHP);
            this.panel1.Controls.Add(this.lblTrailer);
            this.panel1.Controls.Add(this.flpScreenshots);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.rtbDesc);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbOrgTitel);
            this.panel1.Controls.Add(this.tbGenre);
            this.panel1.Controls.Add(this.tbRegi);
            this.panel1.Controls.Add(this.tbJahr);
            this.panel1.Controls.Add(this.lblOrgTitel);
            this.panel1.Name = "panel1";
            // 
            // btnView
            // 
            resources.ApplyResources(this.btnView, "btnView");
            this.btnView.Name = "btnView";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblHP
            // 
            resources.ApplyResources(this.lblHP, "lblHP");
            this.lblHP.Name = "lblHP";
            // 
            // lblTrailer
            // 
            resources.ApplyResources(this.lblTrailer, "lblTrailer");
            this.lblTrailer.Name = "lblTrailer";
            // 
            // flpScreenshots
            // 
            resources.ApplyResources(this.flpScreenshots, "flpScreenshots");
            this.flpScreenshots.MaximumSize = new System.Drawing.Size(575, 0);
            this.flpScreenshots.Name = "flpScreenshots";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // rtbDesc
            // 
            this.rtbDesc.BackColor = System.Drawing.Color.White;
            this.rtbDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDesc.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.rtbDesc, "rtbDesc");
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rtbActor);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // rtbActor
            // 
            this.rtbActor.BackColor = System.Drawing.Color.White;
            this.rtbActor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.rtbActor, "rtbActor");
            this.rtbActor.ForeColor = System.Drawing.Color.Black;
            this.rtbActor.Name = "rtbActor";
            this.rtbActor.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblTitel
            // 
            resources.ApplyResources(this.lblTitel, "lblTitel");
            this.lblTitel.BackColor = System.Drawing.Color.Transparent;
            this.lblTitel.Name = "lblTitel";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SeaShell;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.SeaShell;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SeaShell;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tbOrgTitel
            // 
            this.tbOrgTitel.BackColor = System.Drawing.Color.LightYellow;
            this.tbOrgTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbOrgTitel, "tbOrgTitel");
            this.tbOrgTitel.ForeColor = System.Drawing.Color.Black;
            this.tbOrgTitel.Name = "tbOrgTitel";
            // 
            // tbGenre
            // 
            this.tbGenre.BackColor = System.Drawing.Color.White;
            this.tbGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbGenre, "tbGenre");
            this.tbGenre.ForeColor = System.Drawing.Color.Black;
            this.tbGenre.Name = "tbGenre";
            // 
            // tbRegi
            // 
            this.tbRegi.BackColor = System.Drawing.Color.White;
            this.tbRegi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbRegi, "tbRegi");
            this.tbRegi.ForeColor = System.Drawing.Color.Black;
            this.tbRegi.Name = "tbRegi";
            // 
            // tbJahr
            // 
            this.tbJahr.BackColor = System.Drawing.Color.White;
            this.tbJahr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbJahr, "tbJahr");
            this.tbJahr.ForeColor = System.Drawing.Color.Black;
            this.tbJahr.Name = "tbJahr";
            // 
            // lblOrgTitel
            // 
            this.lblOrgTitel.BackColor = System.Drawing.Color.SeaShell;
            this.lblOrgTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblOrgTitel, "lblOrgTitel");
            this.lblOrgTitel.Name = "lblOrgTitel";
            // 
            // cbWish
            // 
            resources.ApplyResources(this.cbWish, "cbWish");
            this.cbWish.AutoCheck = false;
            this.cbWish.ForeColor = System.Drawing.Color.Black;
            this.cbWish.Name = "cbWish";
            this.cbWish.TabStop = false;
            this.cbWish.UseVisualStyleBackColor = true;
            // 
            // pbImage
            // 
            resources.ApplyResources(this.pbImage, "pbImage");
            this.pbImage.BackColor = System.Drawing.Color.White;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Name = "pbImage";
            this.pbImage.TabStop = false;
            // 
            // cbSeen
            // 
            resources.ApplyResources(this.cbSeen, "cbSeen");
            this.cbSeen.AutoCheck = false;
            this.cbSeen.ForeColor = System.Drawing.Color.Black;
            this.cbSeen.Name = "cbSeen";
            this.cbSeen.TabStop = false;
            this.cbSeen.UseVisualStyleBackColor = true;
            // 
            // starRating1
            // 
            this.starRating1.BackColor = System.Drawing.Color.Transparent;
            this.starRating1.ControlLayout = MantusStarRating.StarRating.Layouts.Horizontal;
            this.starRating1.isEditable = false;
            resources.ApplyResources(this.starRating1, "starRating1");
            this.starRating1.Name = "starRating1";
            this.starRating1.Rating = 0;
            this.starRating1.WrapperPanelBorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // lblAddDate
            // 
            resources.ApplyResources(this.lblAddDate, "lblAddDate");
            this.lblAddDate.Name = "lblAddDate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMovie,
            this.optionenToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // addMovie
            // 
            this.addMovie.Name = "addMovie";
            resources.ApplyResources(this.addMovie, "addMovie");
            this.addMovie.Click += new System.EventHandler(this.addMovie_Click);
            // 
            // ilsIcons
            // 
            this.ilsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsIcons.ImageStream")));
            this.ilsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsIcons.Images.SetKeyName(0, "search-32.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.image,
            this.status});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // image
            // 
            resources.ApplyResources(this.image, "image");
            this.image.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.image.Name = "image";
            this.image.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            resources.ApplyResources(this.status, "status");
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            resources.ApplyResources(this.optionenToolStripMenuItem, "optionenToolStripMenuItem");
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMovie;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList ilsIcons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.RichTextBox rtbActor;
        private System.Windows.Forms.RichTextBox rtbDesc;
        private System.Windows.Forms.TextBox tbJahr;
        private System.Windows.Forms.TextBox tbRegi;
        private System.Windows.Forms.TextBox tbGenre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblAddDate;
        private System.Windows.Forms.Label lblOrgTitel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripStatusLabel image;
        private MantusStarRating.StarRating starRating1;
        private System.Windows.Forms.TextBox tbOrgTitel;
        private System.Windows.Forms.CheckBox cbSeen;
        private System.Windows.Forms.CheckBox cbWish;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.FlowLayoutPanel flpScreenshots;
        private System.Windows.Forms.LinkLabel lblTrailer;
        private System.Windows.Forms.Panel pnlBottomSpacer;
        private System.Windows.Forms.Label lblDCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLent;
        private System.Windows.Forms.LinkLabel lblHP;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
    }
}

