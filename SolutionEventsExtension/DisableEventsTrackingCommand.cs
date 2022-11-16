using Microsoft;
using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using Task = System.Threading.Tasks.Task;

namespace SolutionEventsExtension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class DisableEventsTrackingCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 256;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("d23c8923-ff96-4656-88da-e59a23c5aff9");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        private readonly EventsHandler eventsHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisableEventsTrackingCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        /// <param name="eventsHandler"></param>
        private DisableEventsTrackingCommand(AsyncPackage package, OleMenuCommandService commandService,
            EventsHandler eventsHandler)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            this.eventsHandler = eventsHandler;
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(this.Execute, menuCommandID);
            menuItem.BeforeQueryStatus += OnBeforeQueryStatus;
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static DisableEventsTrackingCommand Instance { get; private set; }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider => this.package;

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="eventsHandler"></param>
        public static async Task InitializeAsync(AsyncPackage package, EventsHandler eventsHandler)
        {
            // Switch to the main thread - the call to AddCommand in DisableEventsTrackingCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            Instance = new DisableEventsTrackingCommand(package, commandService, eventsHandler);
        }

        private void OnBeforeQueryStatus(object sender, EventArgs args)
        {
            var cmd = sender as OleMenuCommand;
            Assumes.Present(cmd);
            cmd.Visible = cmd.Enabled = eventsHandler.IsEnabled;
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
            eventsHandler.UnsubscribeFromEvents();
        }
    }
}
