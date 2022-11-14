using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace VSIXProject1
{
    internal class EventsHandler : 
        IVsSolutionEvents3,
        IVsSolutionEvents4,
        IVsSolutionEvents5,
        IVsSolutionEvents6,
        IVsSolutionEvents7,
        IVsSolutionEvents8
    {
        private readonly IVsOutputWindowPane vsOutputWindowPane;

        public EventsHandler(IVsOutputWindowPane vsOutputWindowPane)
        {
            this.vsOutputWindowPane = vsOutputWindowPane;
        }

        int IVsSolutionEvents.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            PrintEventMessage("Project opened");
            return 0;
        }

        int IVsSolutionEvents3.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            PrintEventMessage("Project closing queried");
            return 0;
        }

        int IVsSolutionEvents3.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            PrintEventMessage("Project about to close");
            return 0;
        }

        int IVsSolutionEvents3.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            PrintEventMessage("Project loaded");
            return 0;
        }

        int IVsSolutionEvents3.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            PrintEventMessage("Project unloading queried");
            return 0;
        }

        int IVsSolutionEvents3.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            PrintEventMessage("Project about to unload");
            return 0;
        }

        int IVsSolutionEvents3.OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            PrintEventMessage("Solution opened");
            return 0;
        }

        int IVsSolutionEvents3.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            PrintEventMessage("Solution closing queried");
            return 0;
        }

        int IVsSolutionEvents3.OnBeforeCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution about to close");
            return 0;
        }

        int IVsSolutionEvents3.OnAfterCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution closed");
            return 0;
        }

        int IVsSolutionEvents3.OnAfterMergeSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution merged");
            return 0;
        }

        public int OnBeforeOpeningChildren(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("About to open children");
            return 0;
        }

        public int OnAfterOpeningChildren(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("Opened children");
            return 0;
        }

        public int OnBeforeClosingChildren(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("Children about to close");
            return 0;
        }

        public int OnAfterClosingChildren(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("Children closed");
            return 0;
        }

        int IVsSolutionEvents3.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            PrintEventMessage("Project opened");
            return 0;
        }

        int IVsSolutionEvents2.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            PrintEventMessage("Project closing queried");
            return 0;
        }

        int IVsSolutionEvents2.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            PrintEventMessage("Project about to close");
            return 0;
        }

        int IVsSolutionEvents2.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            PrintEventMessage("Project loaded");
            return 0;
        }

        int IVsSolutionEvents2.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            PrintEventMessage("Project unloading queried");
            return 0;
        }

        int IVsSolutionEvents2.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            PrintEventMessage("Project about to unload");
            return 0;
        }

        int IVsSolutionEvents2.OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            PrintEventMessage("Solution opened");
            return 0;
        }

        int IVsSolutionEvents2.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            PrintEventMessage("Solution closing queried");
            return 0;
        }

        int IVsSolutionEvents2.OnBeforeCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution about to close");
            return 0;
        }

        int IVsSolutionEvents2.OnAfterCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution closed");
            return 0;
        }

        int IVsSolutionEvents2.OnAfterMergeSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution merged");
            return 0;
        }

        int IVsSolutionEvents2.OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            PrintEventMessage("Project opened");
            return 0;
        }

        int IVsSolutionEvents.OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
        {
            PrintEventMessage("Project closing queried");
            return 0;
        }

        int IVsSolutionEvents.OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
        {
            PrintEventMessage("Project about to close");
            return 0;
        }

        int IVsSolutionEvents.OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
        {
            PrintEventMessage("Project loaded");
            return 0;
        }

        int IVsSolutionEvents.OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
        {
            PrintEventMessage("Project unloading queried");
            return 0;
        }

        int IVsSolutionEvents.OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
        {
            PrintEventMessage("Project about to unload");
            return 0;
        }

        int IVsSolutionEvents.OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
        {
            PrintEventMessage("Solution opened");
            return 0;
        }

        int IVsSolutionEvents.OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
        {
            PrintEventMessage("Solution closing queried");
            return 0;
        }

        int IVsSolutionEvents.OnBeforeCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution about to close");
            return 0;
        }

        int IVsSolutionEvents.OnAfterCloseSolution(object pUnkReserved)
        {
            PrintEventMessage("Solution closed");
            return 0;
        }

        public int OnAfterRenameProject(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("Project renamed");
            return 0;
        }

        public int OnQueryChangeProjectParent(IVsHierarchy pHierarchy, IVsHierarchy pNewParentHier, ref int pfCancel)
        {
            PrintEventMessage("Project parent change queried");
            return 0;
        }

        public int OnAfterChangeProjectParent(IVsHierarchy pHierarchy)
        {
            PrintEventMessage("Project parent changed");
            return 0;
        }

        public int OnAfterAsynchOpenProject(IVsHierarchy pHierarchy, int fAdded)
        {
            PrintEventMessage("Project opened asynchronously");
            return 0;
        }

        public void OnBeforeOpenProject(ref Guid guidProjectID, ref Guid guidProjectType, string pszFileName)
        {
            PrintEventMessage("Project about to open");
        }

        public int OnBeforeProjectRegisteredInRunningDocumentTable(Guid projectID, string projectFullPath)
        {
            PrintEventMessage("Project about to be registered");
            return 0;
        }

        public int OnAfterProjectRegisteredInRunningDocumentTable(Guid projectID, string projectFullPath, uint docCookie)
        {
            PrintEventMessage("Project registered");
            return 0;
        }

        public void OnAfterOpenFolder(string folderPath)
        {
            PrintEventMessage("Folder opened");
        }

        public void OnBeforeCloseFolder(string folderPath)
        {
            PrintEventMessage("Folder about to be closed");
        }

        public void OnQueryCloseFolder(string folderPath, ref int pfCancel)
        {
            PrintEventMessage("Folder closing queried");
        }

        public void OnAfterCloseFolder(string folderPath)
        {
            PrintEventMessage("Folder closed");
        }

        public void OnAfterLoadAllDeferredProjects()
        {
            PrintEventMessage("Deferred projects loaded");
        }

        public void OnAfterRenameSolution(string oldName, string newName)
        {
            PrintEventMessage("Solution renamed");
        }

        private void PrintEventMessage(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            vsOutputWindowPane.OutputStringThreadSafe(message + "\r\n");
        }
    }
}
