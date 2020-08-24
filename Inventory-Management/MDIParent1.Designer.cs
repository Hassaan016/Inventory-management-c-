namespace Inventory_Management
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeSaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.userToolStripMenuItem,
                this.unitToolStripMenuItem,
                this.productToolStripMenuItem,
                this.dealerToolStripMenuItem,
                this.salesToolStripMenuItem,
                this.reportToolStripMenuItem
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(982, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            //
            // userToolStripMenuItem
            //
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.newUserToolStripMenuItem
            });
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.userToolStripMenuItem.Text = "User";
            //
            // newUserToolStripMenuItem
            //
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.newUserToolStripMenuItem.Text = "Add New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            //
            // unitToolStripMenuItem
            //
            this.unitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.addNewUnitToolStripMenuItem
            });
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.unitToolStripMenuItem.Text = "Unit";
            //
            // addNewUnitToolStripMenuItem
            //
            this.addNewUnitToolStripMenuItem.Name = "addNewUnitToolStripMenuItem";
            this.addNewUnitToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.addNewUnitToolStripMenuItem.Text = "Add New Unit";
            this.addNewUnitToolStripMenuItem.Click += new System.EventHandler(this.addNewUnitToolStripMenuItem_Click);
            //
            // productToolStripMenuItem
            //
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.addProductNameToolStripMenuItem,
                this.purchaseProductToolStripMenuItem
            });
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.productToolStripMenuItem.Text = "Product";
            //
            // addProductNameToolStripMenuItem
            //
            this.addProductNameToolStripMenuItem.Name = "addProductNameToolStripMenuItem";
            this.addProductNameToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.addProductNameToolStripMenuItem.Text = "Add Product Name";
            this.addProductNameToolStripMenuItem.Click += new System.EventHandler(this.addProductNameToolStripMenuItem_Click);
            //
            // purchaseProductToolStripMenuItem
            //
            this.purchaseProductToolStripMenuItem.Name = "purchaseProductToolStripMenuItem";
            this.purchaseProductToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.purchaseProductToolStripMenuItem.Text = "Purchase Product";
            this.purchaseProductToolStripMenuItem.Click += new System.EventHandler(this.purchaseProductToolStripMenuItem_Click);
            //
            // dealerToolStripMenuItem
            //
            this.dealerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.dealerInfoToolStripMenuItem
            });
            this.dealerToolStripMenuItem.Name = "dealerToolStripMenuItem";
            this.dealerToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.dealerToolStripMenuItem.Text = "Dealer";
            //
            // dealerInfoToolStripMenuItem
            //
            this.dealerInfoToolStripMenuItem.Name = "dealerInfoToolStripMenuItem";
            this.dealerInfoToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.dealerInfoToolStripMenuItem.Text = "Add New Dealer";
            this.dealerInfoToolStripMenuItem.Click += new System.EventHandler(this.dealerInfoToolStripMenuItem_Click);
            //
            // salesToolStripMenuItem
            //
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.makeSaleToolStripMenuItem
            });
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.salesToolStripMenuItem.Text = "Sales";
            //
            // makeSaleToolStripMenuItem
            //
            this.makeSaleToolStripMenuItem.Name = "makeSaleToolStripMenuItem";
            this.makeSaleToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.makeSaleToolStripMenuItem.Text = "Make Sale";
            this.makeSaleToolStripMenuItem.Click += new System.EventHandler(this.makeSaleToolStripMenuItem_Click);
            //
            // reportToolStripMenuItem
            //
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.purchaseReportToolStripMenuItem
            });
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            //
            // purchaseReportToolStripMenuItem
            //
            this.purchaseReportToolStripMenuItem.Name = "purchaseReportToolStripMenuItem";
            this.purchaseReportToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.purchaseReportToolStripMenuItem.Text = "Purchase Report";
            this.purchaseReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseReportToolStripMenuItem_Click_1);
            //
            // statusStrip
            //
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.toolStripStatusLabel
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 527);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(982, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            //
            // toolStripStatusLabel
            //
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inventory Management System";
            //
            // MDIParent1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MDIParent1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dealerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeSaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReportToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}



