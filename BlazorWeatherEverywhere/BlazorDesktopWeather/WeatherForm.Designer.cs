using System.Drawing;

namespace BlazorDesktopWeather
{
    partial class WeatherForm
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
            this.WeatherIcon = new System.Windows.Forms.PictureBox();
            this.Temperature = new System.Windows.Forms.Label();
            this.GradLabel = new System.Windows.Forms.Label();
            this.Updated = new System.Windows.Forms.Label();
            this.WeatherText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.Label();
            this.WeatherDetailsBlazorWebView = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            ((System.ComponentModel.ISupportInitialize)(this.WeatherIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // WeatherIcon
            // 
            this.WeatherIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.WeatherIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WeatherIcon.ErrorImage = null;
            this.WeatherIcon.InitialImage = null;
            this.WeatherIcon.Location = new System.Drawing.Point(69, 228);
            this.WeatherIcon.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.WeatherIcon.Name = "WeatherIcon";
            this.WeatherIcon.Size = new System.Drawing.Size(325, 221);
            this.WeatherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WeatherIcon.TabIndex = 0;
            this.WeatherIcon.TabStop = false;
            // 
            // Temperature
            // 
            this.Temperature.Font = new System.Drawing.Font("Segoe UI", 92.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Temperature.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Temperature.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Temperature.Location = new System.Drawing.Point(87, 99);
            this.Temperature.Margin = new System.Windows.Forms.Padding(0);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(724, 355);
            this.Temperature.TabIndex = 2;
            this.Temperature.Text = "71";
            this.Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GradLabel
            // 
            this.GradLabel.AutoSize = true;
            this.GradLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GradLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GradLabel.Location = new System.Drawing.Point(728, 188);
            this.GradLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GradLabel.Name = "GradLabel";
            this.GradLabel.Size = new System.Drawing.Size(44, 51);
            this.GradLabel.TabIndex = 3;
            this.GradLabel.Text = "o";
            // 
            // Updated
            // 
            this.Updated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Updated.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Updated.ForeColor = System.Drawing.Color.SpringGreen;
            this.Updated.Location = new System.Drawing.Point(0, 602);
            this.Updated.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Updated.Name = "Updated";
            this.Updated.Size = new System.Drawing.Size(773, 84);
            this.Updated.TabIndex = 11;
            this.Updated.Text = "Updated at 12:36:11 AM";
            this.Updated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeatherText
            // 
            this.WeatherText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.WeatherText.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WeatherText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WeatherText.Location = new System.Drawing.Point(35, 434);
            this.WeatherText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.WeatherText.Name = "WeatherText";
            this.WeatherText.Size = new System.Drawing.Size(711, 124);
            this.WeatherText.TabIndex = 12;
            this.WeatherText.Text = "Sunny";
            this.WeatherText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(54)))), ((int)(((byte)(170)))));
            this.label1.Location = new System.Drawing.Point(0, 686);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(773, 93);
            this.label1.TabIndex = 13;
            this.label1.Text = "Powered by .NET with 💜";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // City
            // 
            this.City.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.City.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.City.Location = new System.Drawing.Point(35, 22);
            this.City.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(711, 118);
            this.City.TabIndex = 14;
            this.City.Text = "Redmond";
            this.City.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeatherDetailsBlazorWebView
            // 
            this.WeatherDetailsBlazorWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WeatherDetailsBlazorWebView.Location = new System.Drawing.Point(26, 139);
            this.WeatherDetailsBlazorWebView.Name = "WeatherDetailsBlazorWebView";
            this.WeatherDetailsBlazorWebView.Size = new System.Drawing.Size(732, 444);
            this.WeatherDetailsBlazorWebView.TabIndex = 20;
            this.WeatherDetailsBlazorWebView.Visible = false;
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(68)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(770, 778);
            this.Controls.Add(this.WeatherIcon);
            this.Controls.Add(this.WeatherText);
            this.Controls.Add(this.City);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Updated);
            this.Controls.Add(this.GradLabel);
            this.Controls.Add(this.Temperature);
            this.Controls.Add(this.WeatherDetailsBlazorWebView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(796, 849);
            this.Name = "WeatherForm";
            this.Text = "Weather Now";
            ((System.ComponentModel.ISupportInitialize)(this.WeatherIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WeatherIcon;
        private System.Windows.Forms.Label Temperature;
        private System.Windows.Forms.Label GradLabel;
        private System.Windows.Forms.Label Updated;
        private System.Windows.Forms.Label WeatherText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label City;
        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView WeatherDetailsBlazorWebView;
    }
}

