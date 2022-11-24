using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft;
using SolutionEventsExtension;
using Task = System.Threading.Tasks.Task;

namespace VSIXProject1
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class EventsTrackingControlCommand
    {
        private bool isTrackingEnabled;
        private readonly EventsHandler eventsHandler;

        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("142bfb60-7c3b-4734-87c7-d5feb56121df");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsTrackingControlCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private EventsTrackingControlCommand(AsyncPackage package, OleMenuCommandService commandService,
            EventsHandler eventsHandler)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
            menuItem.BeforeQueryStatus += OnBeforeQueryStatus;
            commandService.AddCommand(menuItem);

            this.eventsHandler = eventsHandler;
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static EventsTrackingControlCommand Instance { get; private set; }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package, EventsHandler eventsHandler)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService =
                await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new EventsTrackingControlCommand(package, commandService, eventsHandler);
        }

        private void OnBeforeQueryStatus(object sender, EventArgs args)
        {
            var cmd = sender as OleMenuCommand;
            Assumes.Present(cmd);
            const string en = "En";
            const string dis = "Dis";
            var prefix = isTrackingEnabled ? dis : en;
            cmd.Text = $"{prefix}able solution events tracking";
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (isTrackingEnabled)
                eventsHandler.UnsubscribeFromEvents();
            else
                eventsHandler.SubscribeToEvents();

            isTrackingEnabled = !isTrackingEnabled;
        }
    }
}