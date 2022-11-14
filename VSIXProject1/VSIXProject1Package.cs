using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell.Events;
using Task = System.Threading.Tasks.Task;
using static Microsoft.VisualStudio.VSConstants;
using Microsoft;

namespace VSIXProject1
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(VSIXProject1Package.PackageGuidString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionOpening_string, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class VSIXProject1Package : AsyncPackage, IDisposable
    {
        private IVsOutputWindowPane vsOutputWindowPane;

        /// <summary>
        /// VSIXProject1Package GUID string.
        /// </summary>
        public const string PackageGuidString = "4957da3a-6252-4bbf-acc1-17c1c80577f9";

        private uint cookie = VSConstants.VSCOOKIE_NIL;
        private IVsSolution solution;

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            vsOutputWindowPane = (IVsOutputWindowPane) await GetServiceAsync(typeof(SVsGeneralOutputWindowPane));
            Assumes.Present(vsOutputWindowPane);
            solution = (IVsSolution) await GetServiceAsync(typeof(SVsSolution));
            Assumes.Present(solution);
            solution.AdviseSolutionEvents(new EventsHandler(vsOutputWindowPane), out cookie);

            //SolutionEvents.OnAfterRenameProject += (sender, args) => args.Hierarchy.;
            //SolutionEvents.OnAfterAsynchOpenProject += (sender, args) => PrintEventMessage("Opened project");
            //SolutionEvents.OnAfterChangeProjectParent += (sender, args) => PrintEventMessage("Moved project");
            //SolutionEvents.OnAfterCloseFolder += (sender, args) => PrintEventMessage("Folder closed");
            //SolutionEvents.OnAfterCloseSolution += (sender, args) => PrintEventMessage("Solution closed");
            //SolutionEvents.OnAfterClosingChildren += (sender, args) => PrintEventMessage("Nested projects closed");
            //SolutionEvents.OnAfterLoadAllDeferredProjects += (sender, args) => PrintEventMessage("Deferred projects loaded"); // not supported in vs22
            //SolutionEvents.OnAfterLoadProject += (sender, args) => PrintEventMessage("Project loaded");
            //SolutionEvents.OnAfterMergeSolution += (sender, args) => PrintEventMessage("Merged solution");
            //SolutionEvents.OnAfterOpenFolder += (sender, args) => PrintEventMessage("Folder opened");
            //SolutionEvents.OnAfterOpenProject += (sender, args) => PrintEventMessage("Project opened");
            //SolutionEvents.OnAfterOpenSolution += (sender, args) => PrintEventMessage("Solution opened");
            //SolutionEvents.OnAfterOpeningChildren += (sender, args) => PrintEventMessage("Children opened");


        }

        #endregion

        public void Dispose()
        {
            if (cookie != VSCOOKIE_NIL)
            {
                solution.UnadviseSolutionEvents(cookie);
                solution = null;
                cookie = VSCOOKIE_NIL;
            }
        }
    }
}
