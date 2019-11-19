namespace WatchDog
{
    partial class Installer1
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WatchDogWatcherService = new System.ServiceProcess.ServiceInstaller();
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.service11 = new WatchDog.Service1();
            // 
            // WatchDogWatcherService
            // 
            this.WatchDogWatcherService.DisplayName = "WatchDog";
            this.WatchDogWatcherService.ServiceName = "WatchDog";
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // service11
            // 
            this.service11.ExitCode = 0;
            this.service11.ServiceName = "WatchDog";
            // 
            // Installer1
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.WatchDogWatcherService});

        }

        #endregion

        private Service1 service11;
        private System.ServiceProcess.ServiceInstaller WatchDogWatcherService;
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
    }
}