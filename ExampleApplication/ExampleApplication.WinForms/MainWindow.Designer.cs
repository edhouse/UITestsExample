namespace ExampleApplication.WinForms
{
    partial class MainWindow
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
            this.ListBox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Label_FirstName = new System.Windows.Forms.Label();
            this.Label_LastName = new System.Windows.Forms.Label();
            this.Label_Description = new System.Windows.Forms.Label();
            this.TextBox_FirstName = new System.Windows.Forms.TextBox();
            this.TextBox_LastName = new System.Windows.Forms.TextBox();
            this.TextBox_Description = new System.Windows.Forms.TextBox();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplicationMenu = new System.Windows.Forms.MenuStrip();
            this.ApplicationMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.ListBox.FormattingEnabled = true;
            this.ListBox.ItemHeight = 15;
            this.ListBox.Location = new System.Drawing.Point(0, 27);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(150, 334);
            this.ListBox.TabIndex = 0;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // Label_FirstName
            // 
            this.Label_FirstName.AutoSize = true;
            this.Label_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.Label_FirstName.Location = new System.Drawing.Point(156, 41);
            this.Label_FirstName.Name = "Label_FirstName";
            this.Label_FirstName.Size = new System.Drawing.Size(81, 15);
            this.Label_FirstName.TabIndex = 3;
            this.Label_FirstName.Text = "First Name:";
            this.Label_FirstName.Visible = false;
            // 
            // Label_LastName
            // 
            this.Label_LastName.AutoSize = true;
            this.Label_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.Label_LastName.Location = new System.Drawing.Point(156, 89);
            this.Label_LastName.Name = "Label_LastName";
            this.Label_LastName.Size = new System.Drawing.Size(80, 15);
            this.Label_LastName.TabIndex = 4;
            this.Label_LastName.Text = "Last Name:";
            this.Label_LastName.Visible = false;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.Label_Description.Location = new System.Drawing.Point(156, 139);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_Description.Size = new System.Drawing.Size(84, 15);
            this.Label_Description.TabIndex = 5;
            this.Label_Description.Text = "Description:";
            this.Label_Description.Visible = false;
            // 
            // TextBox_FirstName
            // 
            this.TextBox_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.TextBox_FirstName.Location = new System.Drawing.Point(159, 57);
            this.TextBox_FirstName.Name = "TextBox_FirstName";
            this.TextBox_FirstName.Size = new System.Drawing.Size(201, 21);
            this.TextBox_FirstName.TabIndex = 6;
            this.TextBox_FirstName.Visible = false;
            this.TextBox_FirstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // TextBox_LastName
            // 
            this.TextBox_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.TextBox_LastName.Location = new System.Drawing.Point(159, 107);
            this.TextBox_LastName.Name = "TextBox_LastName";
            this.TextBox_LastName.Size = new System.Drawing.Size(201, 21);
            this.TextBox_LastName.TabIndex = 7;
            this.TextBox_LastName.Visible = false;
            this.TextBox_LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(238)));
            this.TextBox_Description.Location = new System.Drawing.Point(159, 155);
            this.TextBox_Description.Multiline = true;
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.Size = new System.Drawing.Size(201, 95);
            this.TextBox_Description.TabIndex = 8;
            this.TextBox_Description.Visible = false;
            this.TextBox_Description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // Button_Add
            // 
            this.Button_Add.Location = new System.Drawing.Point(159, 299);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(39, 24);
            this.Button_Add.TabIndex = 9;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Add_Button_MouseClick);
            // 
            // Button_Remove
            // 
            this.Button_Remove.Enabled = false;
            this.Button_Remove.Location = new System.Drawing.Point(204, 299);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(55, 24);
            this.Button_Remove.TabIndex = 10;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Remove_Button_MouseClick);
            // 
            // Edit
            // 
            this.EditMenuItem.AccessibleName = "Edit";
            this.EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // Items
            // 
            this.ItemsMenuItem.AccessibleName = "Items";
            this.ItemsMenuItem.Name = "ItemsMenuItem";
            this.ItemsMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ItemsMenuItem.Text = "Items";
            this.ItemsMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Items_DropDownItemClicked);
            // 
            // ApplicationMenu
            // 
            this.ApplicationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMenuItem,
            this.ItemsMenuItem});
            this.ApplicationMenu.Location = new System.Drawing.Point(0, 0);
            this.ApplicationMenu.Name = "ApplicationMenu";
            this.ApplicationMenu.Size = new System.Drawing.Size(366, 24);
            this.ApplicationMenu.TabIndex = 1;
            this.ApplicationMenu.Text = "menuStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(366, 360);
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.TextBox_LastName);
            this.Controls.Add(this.TextBox_FirstName);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.Label_LastName);
            this.Controls.Add(this.Label_FirstName);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.ApplicationMenu);
            this.MainMenuStrip = this.ApplicationMenu;
            this.Name = "MainWindow";
            this.Text = "MainWindow - WinForms";
            this.ApplicationMenu.ResumeLayout(false);
            this.ApplicationMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Label_FirstName;
        private System.Windows.Forms.Label Label_LastName;
        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.TextBox TextBox_FirstName;
        private System.Windows.Forms.TextBox TextBox_LastName;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip ApplicationMenu;
        public System.Windows.Forms.ToolStripMenuItem ItemsMenuItem;
    }
}

