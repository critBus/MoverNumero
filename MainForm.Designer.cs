/*
 * Created by SharpDevelop.
 * User: Rene
 * Date: 9/1/2022
 * Time: 09:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MoverNumero
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox checkBox4;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button5 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(21, 32);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(30, 23);
			this.button5.TabIndex = 15;
			this.button5.Text = "...";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(57, 36);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(512, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(21, 13);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(109, 17);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Text = "Carpetas Internas";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Bold);
			this.button1.Location = new System.Drawing.Point(21, 62);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(272, 31);
			this.button1.TabIndex = 17;
			this.button1.Text = "Mover Numero Adelante";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Forte", 12F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(217, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 23);
			this.label1.TabIndex = 16;
			this.label1.Text = "Separador ->";
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Bold);
			this.button2.Location = new System.Drawing.Point(315, 62);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(254, 31);
			this.button2.TabIndex = 18;
			this.button2.Text = "Quitar Numero Delante";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(489, 13);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 17);
			this.checkBox2.TabIndex = 19;
			this.checkBox2.Text = "Para Anime";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(392, 13);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(91, 17);
			this.checkBox3.TabIndex = 20;
			this.checkBox3.Text = "Solo Archivos";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(338, 9);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(31, 20);
			this.textBox2.TabIndex = 21;
			this.textBox2.Text = "+";
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Checked = true;
			this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox4.Location = new System.Drawing.Point(136, 13);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(85, 17);
			this.checkBox4.TabIndex = 22;
			this.checkBox4.Text = "No 1ra Tem ";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 117);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.checkBox1);
			this.Name = "MainForm";
			this.Text = "MoverNumero";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
