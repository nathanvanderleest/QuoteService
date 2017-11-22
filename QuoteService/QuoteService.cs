using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WinServices;

namespace WinServices
{
    public partial class QuoteService : ServiceBase
    {
        private QuoteServer quoteServer;
        public QuoteService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            quoteServer = new QuoteServer("quotes.txt", 4567);
            quoteServer.Start();
        }

        protected override void OnStop()
        {
            quoteServer.Stop();
        }

        protected override void OnPause()
        {
            quoteServer.Suspend();
        }

        protected override void OnContinue()
        {
            quoteServer.Resume();
        }

        public const int commandRefresh = 128;
        protected override void OnCustomCommand(int command)
        {
            switch(command)
            {
                case commandRefresh:
                    quoteServer.RefreshQuotes();
                    break;

                default:
                    break;
            }
        }
    }
}
