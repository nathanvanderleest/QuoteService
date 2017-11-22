﻿namespace QuoteService
{
    partial class ProjectInstaller
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

        #region Component Designer generated code
        private System.ServiceProcess.ServiceProcessInstaller ServiceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller ServiceInstaller1;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //components = new System.ComponentModel.Container();
            ServiceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            ServiceInstaller1 = new System.ServiceProcess.ServiceInstaller();

            //
            // serviceProcessInstaller1
            //
            this.ServiceProcessInstaller1.Password = null;
            this.ServiceProcessInstaller1.Username = null;
            
            //
            // serviceInstaller1
            //
            this.ServiceInstaller1.ServiceName = "QuoteService";
            this.ServiceInstaller1.DisplayName = "QuoteService";

            //
            // ProjectInstaller
            //
            this.Installers.AddRange(new System.Configuration.Install.Installer[] { this.ServiceProcessInstaller1, this.ServiceInstaller1});
        }

        #endregion
    }
}