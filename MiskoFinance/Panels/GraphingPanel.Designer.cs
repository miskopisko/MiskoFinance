namespace MiskoFinance.Panels
{
	partial class GraphingPanel
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.mChart_ = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.mChart_)).BeginInit();
			this.SuspendLayout();
			// 
			// mChart_
			// 
			this.mChart_.BackColor = System.Drawing.Color.Transparent;
			chartArea1.Name = "ChartArea1";
			this.mChart_.ChartAreas.Add(chartArea1);
			this.mChart_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mChart_.Location = new System.Drawing.Point(0, 0);
			this.mChart_.Name = "mChart_";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Legend = "Legend1";
			series1.Name = "Series";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			this.mChart_.Series.Add(series1);
			this.mChart_.Size = new System.Drawing.Size(543, 216);
			this.mChart_.TabIndex = 0;
			this.mChart_.Text = "MainChart";
			// 
			// GraphingPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mChart_);
			this.Name = "GraphingPanel";
			this.Size = new System.Drawing.Size(543, 216);
			((System.ComponentModel.ISupportInitialize)(this.mChart_)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart mChart_;
	}
}
