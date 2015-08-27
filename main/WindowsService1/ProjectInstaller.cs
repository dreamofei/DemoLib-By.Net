using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            InitServer();
        }

        void InitServer()
        {
            this.serviceInstaller1.ServiceName = "Fei_WriteTimerTask";
            this.serviceInstaller1.DisplayName = "Fei_WriteTimerTask DisplayName";
            this.serviceInstaller1.Description = "Fei_WriteTimerTask Description";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Manual;

            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
        }
    }
}
