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
        private EventLog eventLog;
        public QuoteService()
        {
            InitializeComponent();
            //this.quoteServer = new QuoteServer(AppDomain.CurrentDomain.BaseDirectory + "quotes.txt", 4567);
            this.eventLog = new EventLog("MyNewLog");
        }

        protected override void OnStart(string[] args)
        {

            try
            {
                //  if(!EventLog.SourceExists("MySource"))
                //{
                //EventLog.CreateEventSource("MySource","MyNewLog");
                //    Console.WriteLine("Event Source Created");
                //    Console.WriteLine("Exiting, execute the app again use the Source");
                //}
                //this.eventLog = new EventLog("MyNewLog");
                eventLog.Source = "MyOnStartSource";
                this.eventLog.WriteEntry("QuoteService writing to the MySource source", EventLogEntryType.Information);
                quoteServer = new QuoteServer(AppDomain.CurrentDomain.BaseDirectory + "quotes.txt", 4567);
                quoteServer.Start();
                this.eventLog.WriteEntry("QuoteService Successfully Started...", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
              this.eventLog.WriteEntry("Log: " + eventLog.Log + ", Source: " + eventLog.Source + ": " + ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            try
            {
                //this.eventLog = new EventLog("MyNewLog");
                this.eventLog.Source = "MyOnStopSource";
                this.eventLog.WriteEntry("QuoteService is stopping...", EventLogEntryType.Information);
                //this.quoteServer = new QuoteServer(); // this is not currently installed/deployed
                this.quoteServer.Stop();
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry("Log: " + eventLog.Log + ", Source: " + eventLog.Source + ": " + ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                this.eventLog.Dispose();
            }
        }

        protected override void OnPause()
        {
            try
            {
                //this.eventLog = new EventLog("MyNewLog");
                this.eventLog.Source = "MyOnPauseSource";
                this.eventLog.WriteEntry("QuoteService OnPause: service is suspended...", EventLogEntryType.Information);
                this.quoteServer.Suspend();
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry("Log: " + eventLog.Log + ", Source: " + eventLog.Source + ": " + ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                this.eventLog.Dispose();
            }
        }

        protected override void OnContinue()
        {
            try
            {
                //this.eventLog = new EventLog("MyNewLog");
                this.eventLog.Source = "MyOnContinueSource";
                this.eventLog.WriteEntry("QuoteService OnContinue: service is resuming...", EventLogEntryType.Information);
                this.quoteServer.Resume();
            }
            catch (Exception ex)
            {
                this.eventLog.WriteEntry("Log: " + eventLog.Log + ", Source: " + eventLog.Source + ": " + ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                this.eventLog.Dispose();
            }
        }

        public const int commandRefresh = 128;
        protected override void OnCustomCommand(int command)
        {
            switch(command)
            {
                case commandRefresh:
                    this.quoteServer.RefreshQuotes();
                    break;

                default:
                    break;
            }
        }
    }
}
