using System.ComponentModel;
using System.Windows.Forms;

namespace App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.Windows.Forms.Timer CheckIdleTimer;

        private System.ComponentModel.IContainer components;

        private TextBox ipInput;
        private Label label1;
        private TextBox idleTime;
        private Label label2;
        private Button saveBtn;
        private GroupBox groupBox1;
        private Button execute;
        private Label label4;
        private Label status;
        private Label power;
        private Label label5;
        private PictureBox shellyStatus;

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
            this.CheckIdleTimer = new System.Windows.Forms.Timer(this.components);
            this.ipInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idleTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shellyStatus = new System.Windows.Forms.PictureBox();
            this.execute = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.power = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.shellyStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckIdleTimer
            // 
            this.CheckIdleTimer.Interval = 1000;
            this.CheckIdleTimer.Tick += new System.EventHandler(this.CheckIdleTimer_Tick);
            // 
            // ipInput
            // 
            this.ipInput.Location = new System.Drawing.Point(67, 19);
            this.ipInput.Name = "ipInput";
            this.ipInput.Size = new System.Drawing.Size(123, 20);
            this.ipInput.TabIndex = 1;
            this.ipInput.Text = "192.168.1.217";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shelly IP";
            // 
            // idleTime
            // 
            this.idleTime.Location = new System.Drawing.Point(83, 45);
            this.idleTime.Name = "idleTime";
            this.idleTime.Size = new System.Drawing.Size(53, 20);
            this.idleTime.TabIndex = 1;
            this.idleTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idleTime_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IDLE seconds";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(142, 45);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(74, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipInput);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.shellyStatus);
            this.groupBox1.Controls.Add(this.idleTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // shellyStatus
            // 
            this.shellyStatus.BackColor = System.Drawing.Color.Red;
            this.shellyStatus.Location = new System.Drawing.Point(196, 18);
            this.shellyStatus.Name = "shellyStatus";
            this.shellyStatus.Size = new System.Drawing.Size(20, 20);
            this.shellyStatus.TabIndex = 6;
            this.shellyStatus.TabStop = false;
            // 
            // execute
            // 
            this.execute.Enabled = false;
            this.execute.Location = new System.Drawing.Point(167, 95);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(75, 23);
            this.execute.TabIndex = 5;
            this.execute.Text = "Start";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Status";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(63, 100);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(52, 13);
            this.status.TabIndex = 8;
            this.status.Text = "Waiting...";
            // 
            // power
            // 
            this.power.AutoSize = true;
            this.power.Location = new System.Drawing.Point(63, 124);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(13, 13);
            this.power.TabIndex = 10;
            this.power.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Power";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(252, 146);
            this.Controls.Add(this.power);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "IDLE Automation - By Rick Stoit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.shellyStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
