using ElandBJ.ScheduledJob.api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ElandBJ.ScheduledJob.service
{
    partial class EmailService : ServiceBase
    {
        private IEmailManager EmailManager
        {
            get
            {
                //实际：ContextRegistry.GetContext().GetObject("EmailManager");
                return new EmailManager();
            }
        }
        public EmailService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO:  在此处添加代码以启动服务。
            this.EmailManager.InitEmailScheduler();
        }

        protected override void OnStop()
        {
            // TODO:  在此处添加代码以执行停止服务所需的关闭操作。
        }
    }
}
