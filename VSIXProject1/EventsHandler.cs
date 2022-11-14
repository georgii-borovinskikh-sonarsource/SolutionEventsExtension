using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio;
using EnvDTE;
using System.Threading;

namespace SolutionEventsExtension
{
    internal class EventsHandler :
        IVsSolutionEvents3,
        IVsSolutionEvents4,
        IVsSolutionEvents5,
        IVsSolutionEvents6,
        IVsSolutionEvents7,
        IVsSolutionEvents8
    {
        private readonly IVsSolution solution;
        private uint eventsSubscriptionCookie = VSConstants.VSCOOKIE_NIL;
        private readonly IVsOutputWindowPane outputWindowPane;

        public EventsHandler(IVsSolution solution, IVsOutputWindowPane outputWindowPane)
        {
            this.solution = solution;
            this.outputWindowPane = outputWindowPane;
        }

        public void SubscribeToEvents()
        {
            if (eventsSubscriptionCookie != VSConstants.VSCOOKIE_NIL) 
                return;
            ThreadHelper.ThrowIfNotOnUIThread();
            solution.AdviseSolutionEvents(this, out eventsSubscriptionCookie);
        }

        public void UnsubscribeFromEvents()
        {
            if (eventsSubscriptionCookie == VSConstants.VSCOOKIE_NIL)
                return;
            ThreadHelper.ThrowIfNotOnUIThread();
            solution.UnadviseSolutionEvents(eventsSubscriptionCookie);
            eventsSubscriptionCookie = VSConstants.VSCOOKIE_NIL;
        }

        int IVsSolutionEvents.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded) =>
            PrintEventMessageAndReturnOk("Project opened");

        int IVsSolutionEvents3.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project closing queried");

        int IVsSolutionEvents3.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved) =>
            PrintEventMessageAndReturnOk("Project about to close");

        int IVsSolutionEvents3.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy) =>
            PrintEventMessageAndReturnOk("Project loaded");

        int IVsSolutionEvents3.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project unloading queried");

        int IVsSolutionEvents3.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy) =>
            PrintEventMessageAndReturnOk("Project about to unload");

        int IVsSolutionEvents3.OnAfterOpenSolution(object pUnkReserved, int fNewSolution) =>
            PrintEventMessageAndReturnOk("Solution opened");

        int IVsSolutionEvents3.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Solution closing queried");

        int IVsSolutionEvents3.OnBeforeCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution about to close");

        int IVsSolutionEvents3.OnAfterCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution closed");

        int IVsSolutionEvents3.OnAfterMergeSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution merged");

        public int OnBeforeOpeningChildren(IVsHierarchy pHierarchy) =>
            PrintEventMessageAndReturnOk("About to open children");

        public int OnAfterOpeningChildren(IVsHierarchy pHierarchy) => PrintEventMessageAndReturnOk("Opened children");

        public int OnBeforeClosingChildren(IVsHierarchy pHierarchy) =>
            PrintEventMessageAndReturnOk("Children about to close");

        public int OnAfterClosingChildren(IVsHierarchy pHierarchy) => PrintEventMessageAndReturnOk("Children closed");

        int IVsSolutionEvents3.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded) =>
            PrintEventMessageAndReturnOk("Project opened");

        int IVsSolutionEvents2.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project closing queried");

        int IVsSolutionEvents2.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved) =>
            PrintEventMessageAndReturnOk("Project about to close");

        int IVsSolutionEvents2.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy) =>
            PrintEventMessageAndReturnOk("Project loaded");

        int IVsSolutionEvents2.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project unloading queried");

        int IVsSolutionEvents2.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy) =>
            PrintEventMessageAndReturnOk("Project about to unload");

        int IVsSolutionEvents2.OnAfterOpenSolution(object pUnkReserved, int fNewSolution) =>
            PrintEventMessageAndReturnOk("Solution opened");

        int IVsSolutionEvents2.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Solution closing queried");

        int IVsSolutionEvents2.OnBeforeCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution about to close");

        int IVsSolutionEvents2.OnAfterCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution closed");

        int IVsSolutionEvents2.OnAfterMergeSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution merged");

        int IVsSolutionEvents2.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded) =>
            PrintEventMessageAndReturnOk("Project opened");

        int IVsSolutionEvents.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project closing queried");

        int IVsSolutionEvents.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved) =>
            PrintEventMessageAndReturnOk("Project about to close");

        int IVsSolutionEvents.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy) =>
            PrintEventMessageAndReturnOk("Project loaded");

        int IVsSolutionEvents.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project unloading queried");

        int IVsSolutionEvents.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy) =>
            PrintEventMessageAndReturnOk("Project about to unload");

        int IVsSolutionEvents.OnAfterOpenSolution(object pUnkReserved, int fNewSolution) =>
            PrintEventMessageAndReturnOk("Solution opened");

        int IVsSolutionEvents.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Solution closing queried");

        int IVsSolutionEvents.OnBeforeCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution about to close");

        int IVsSolutionEvents.OnAfterCloseSolution(object pUnkReserved) =>
            PrintEventMessageAndReturnOk("Solution closed");

        public int OnAfterRenameProject(IVsHierarchy pHierarchy) => PrintEventMessageAndReturnOk("Project renamed");

        public int OnQueryChangeProjectParent(IVsHierarchy pHierarchy, IVsHierarchy pNewParentHier, ref int pfCancel) =>
            PrintEventMessageAndReturnOk("Project parent change queried");

        public int OnAfterChangeProjectParent(IVsHierarchy pHierarchy) =>
            PrintEventMessageAndReturnOk("Project parent changed");

        public int OnAfterAsynchOpenProject(IVsHierarchy pHierarchy, int fAdded) =>
            PrintEventMessageAndReturnOk("Project opened asynchronously");

        public void OnBeforeOpenProject(ref Guid guidProjectID, ref Guid guidProjectType, string pszFileName) =>
            PrintEventMessage("Project about to open");

        public int OnBeforeProjectRegisteredInRunningDocumentTable(Guid projectID, string projectFullPath) =>
            PrintEventMessageAndReturnOk("Project about to be registered");

        public int OnAfterProjectRegisteredInRunningDocumentTable(Guid projectID, string projectFullPath,
            uint docCookie) =>
            PrintEventMessageAndReturnOk("Project registered");

        public void OnAfterOpenFolder(string folderPath) => PrintEventMessage("Folder opened");

        public void OnBeforeCloseFolder(string folderPath) => PrintEventMessage("Folder about to be closed");

        public void OnQueryCloseFolder(string folderPath, ref int pfCancel) =>
            PrintEventMessage("Folder closing queried");

        public void OnAfterCloseFolder(string folderPath) => PrintEventMessage("Folder closed");

        public void OnAfterLoadAllDeferredProjects() => PrintEventMessage("Deferred projects loaded");

        public void OnAfterRenameSolution(string oldName, string newName) => PrintEventMessage("Solution renamed");

        private void PrintEventMessage(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            outputWindowPane.OutputStringThreadSafe(message + "\r\n");
        }

        private int PrintEventMessageAndReturnOk(string message)
        {
            PrintEventMessage(message);
            return 0;
        }
    }
}