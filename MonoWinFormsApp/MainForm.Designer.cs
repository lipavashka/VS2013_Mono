namespace MonoWinFormsApp
{
    partial class MainForm
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
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.pictureBox_IntelGalileoBoard = new System.Windows.Forms.PictureBox();
            this.tabPage_TSP_UDP = new System.Windows.Forms.TabPage();
            this.textBox_Tab_TSP_UDP_Send = new System.Windows.Forms.TextBox();
            this.textBox_Tab_TSP_UDP_Rx = new System.Windows.Forms.TextBox();
            this.groupBox_ConnectToServer = new System.Windows.Forms.GroupBox();
            this.button_Tab_TSP_UDP_Connect = new System.Windows.Forms.Button();
            this.button_Tab_TSP_UDP_Send = new System.Windows.Forms.Button();
            this.groupBox_SendMsgToServer = new System.Windows.Forms.GroupBox();
            this.button_Send_Serialized_Obj = new System.Windows.Forms.Button();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IntelGalileoBoard)).BeginInit();
            this.tabPage_TSP_UDP.SuspendLayout();
            this.groupBox_ConnectToServer.SuspendLayout();
            this.groupBox_SendMsgToServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_Main);
            this.tabControl_Main.Controls.Add(this.tabPage_TSP_UDP);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(819, 385);
            this.tabControl_Main.TabIndex = 1;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.pictureBox_IntelGalileoBoard);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Main.Size = new System.Drawing.Size(811, 359);
            this.tabPage_Main.TabIndex = 0;
            this.tabPage_Main.Text = "MAIN";
            this.tabPage_Main.UseVisualStyleBackColor = true;
            // 
            // pictureBox_IntelGalileoBoard
            // 
            this.pictureBox_IntelGalileoBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_IntelGalileoBoard.Image = global::MonoWinFormsApp.Properties.Resources.IntelGalileo_fabD_Front_450px;
            this.pictureBox_IntelGalileoBoard.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_IntelGalileoBoard.Name = "pictureBox_IntelGalileoBoard";
            this.pictureBox_IntelGalileoBoard.Size = new System.Drawing.Size(805, 353);
            this.pictureBox_IntelGalileoBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_IntelGalileoBoard.TabIndex = 1;
            this.pictureBox_IntelGalileoBoard.TabStop = false;
            // 
            // tabPage_TSP_UDP
            // 
            this.tabPage_TSP_UDP.Controls.Add(this.groupBox_SendMsgToServer);
            this.tabPage_TSP_UDP.Controls.Add(this.textBox_Tab_TSP_UDP_Rx);
            this.tabPage_TSP_UDP.Controls.Add(this.groupBox_ConnectToServer);
            this.tabPage_TSP_UDP.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TSP_UDP.Name = "tabPage_TSP_UDP";
            this.tabPage_TSP_UDP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TSP_UDP.Size = new System.Drawing.Size(811, 359);
            this.tabPage_TSP_UDP.TabIndex = 1;
            this.tabPage_TSP_UDP.Text = "TSP_UDP";
            this.tabPage_TSP_UDP.UseVisualStyleBackColor = true;
            // 
            // textBox_Tab_TSP_UDP_Send
            // 
            this.textBox_Tab_TSP_UDP_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Tab_TSP_UDP_Send.Location = new System.Drawing.Point(119, 39);
            this.textBox_Tab_TSP_UDP_Send.Name = "textBox_Tab_TSP_UDP_Send";
            this.textBox_Tab_TSP_UDP_Send.Size = new System.Drawing.Size(659, 20);
            this.textBox_Tab_TSP_UDP_Send.TabIndex = 4;
            this.textBox_Tab_TSP_UDP_Send.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Tab_TSP_UDP_Send_KeyDown);
            // 
            // textBox_Tab_TSP_UDP_Rx
            // 
            this.textBox_Tab_TSP_UDP_Rx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Tab_TSP_UDP_Rx.Location = new System.Drawing.Point(8, 103);
            this.textBox_Tab_TSP_UDP_Rx.Multiline = true;
            this.textBox_Tab_TSP_UDP_Rx.Name = "textBox_Tab_TSP_UDP_Rx";
            this.textBox_Tab_TSP_UDP_Rx.ReadOnly = true;
            this.textBox_Tab_TSP_UDP_Rx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Tab_TSP_UDP_Rx.Size = new System.Drawing.Size(795, 169);
            this.textBox_Tab_TSP_UDP_Rx.TabIndex = 3;
            // 
            // groupBox_ConnectToServer
            // 
            this.groupBox_ConnectToServer.Controls.Add(this.button_Send_Serialized_Obj);
            this.groupBox_ConnectToServer.Controls.Add(this.button_Tab_TSP_UDP_Connect);
            this.groupBox_ConnectToServer.Location = new System.Drawing.Point(8, 6);
            this.groupBox_ConnectToServer.Name = "groupBox_ConnectToServer";
            this.groupBox_ConnectToServer.Size = new System.Drawing.Size(563, 91);
            this.groupBox_ConnectToServer.TabIndex = 2;
            this.groupBox_ConnectToServer.TabStop = false;
            this.groupBox_ConnectToServer.Text = "Connect To the Server";
            // 
            // button_Tab_TSP_UDP_Connect
            // 
            this.button_Tab_TSP_UDP_Connect.Location = new System.Drawing.Point(18, 43);
            this.button_Tab_TSP_UDP_Connect.Name = "button_Tab_TSP_UDP_Connect";
            this.button_Tab_TSP_UDP_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Tab_TSP_UDP_Connect.TabIndex = 0;
            this.button_Tab_TSP_UDP_Connect.Text = "Connect";
            this.button_Tab_TSP_UDP_Connect.UseVisualStyleBackColor = true;
            this.button_Tab_TSP_UDP_Connect.Click += new System.EventHandler(this.button_Tab_TSP_UDP_Connect_Click);
            // 
            // button_Tab_TSP_UDP_Send
            // 
            this.button_Tab_TSP_UDP_Send.Location = new System.Drawing.Point(26, 39);
            this.button_Tab_TSP_UDP_Send.Name = "button_Tab_TSP_UDP_Send";
            this.button_Tab_TSP_UDP_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Tab_TSP_UDP_Send.TabIndex = 1;
            this.button_Tab_TSP_UDP_Send.Text = "Send";
            this.button_Tab_TSP_UDP_Send.UseVisualStyleBackColor = true;
            this.button_Tab_TSP_UDP_Send.Click += new System.EventHandler(this.button_Tab_TSP_UDP_Send_Click);
            // 
            // groupBox_SendMsgToServer
            // 
            this.groupBox_SendMsgToServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_SendMsgToServer.Controls.Add(this.textBox_Tab_TSP_UDP_Send);
            this.groupBox_SendMsgToServer.Controls.Add(this.button_Tab_TSP_UDP_Send);
            this.groupBox_SendMsgToServer.Location = new System.Drawing.Point(8, 278);
            this.groupBox_SendMsgToServer.Name = "groupBox_SendMsgToServer";
            this.groupBox_SendMsgToServer.Size = new System.Drawing.Size(797, 73);
            this.groupBox_SendMsgToServer.TabIndex = 5;
            this.groupBox_SendMsgToServer.TabStop = false;
            this.groupBox_SendMsgToServer.Text = "Send Message to the Server";
            // 
            // button_Send_Serialized_Obj
            // 
            this.button_Send_Serialized_Obj.Location = new System.Drawing.Point(119, 43);
            this.button_Send_Serialized_Obj.Name = "button_Send_Serialized_Obj";
            this.button_Send_Serialized_Obj.Size = new System.Drawing.Size(141, 23);
            this.button_Send_Serialized_Obj.TabIndex = 1;
            this.button_Send_Serialized_Obj.Text = "Send Serialized Object";
            this.button_Send_Serialized_Obj.UseVisualStyleBackColor = true;
            this.button_Send_Serialized_Obj.Click += new System.EventHandler(this.button_Send_Serialized_Obj_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 385);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "MainForm";
            this.Text = "Mono App. for Intel Galileo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_IntelGalileoBoard)).EndInit();
            this.tabPage_TSP_UDP.ResumeLayout(false);
            this.tabPage_TSP_UDP.PerformLayout();
            this.groupBox_ConnectToServer.ResumeLayout(false);
            this.groupBox_SendMsgToServer.ResumeLayout(false);
            this.groupBox_SendMsgToServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.PictureBox pictureBox_IntelGalileoBoard;
        private System.Windows.Forms.TabPage tabPage_TSP_UDP;
        private System.Windows.Forms.Button button_Tab_TSP_UDP_Connect;
        private System.Windows.Forms.Button button_Tab_TSP_UDP_Send;
        private System.Windows.Forms.TextBox textBox_Tab_TSP_UDP_Send;
        private System.Windows.Forms.TextBox textBox_Tab_TSP_UDP_Rx;
        private System.Windows.Forms.GroupBox groupBox_ConnectToServer;
        private System.Windows.Forms.GroupBox groupBox_SendMsgToServer;
        private System.Windows.Forms.Button button_Send_Serialized_Obj;

    }
}

