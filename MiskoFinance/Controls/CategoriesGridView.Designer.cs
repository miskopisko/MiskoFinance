﻿using System;
namespace MiskoFinance.Controls
{
    partial class CategoriesGridView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(Boolean disposing)
        {
            if (disposing && (components != null))
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
        	((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// CategoriesGridView
        	// 
        	this.AllowUserToAddRows = false;
        	this.AllowUserToDeleteRows = false;
        	this.AllowUserToResizeColumns = false;
        	this.AllowUserToResizeRows = false;
        	this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        	this.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.MultiSelect = false;
        	this.RowHeadersVisible = false;
        	this.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        	this.ResumeLayout(false);

        }

        #endregion
    }
}
