using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging.Interop;

namespace KLToolWindows
{
    [Guid(WpfToolWindow.ToolWindowId)]
    public class WpfToolWindow : ToolWindowPane
    {
        internal const string ToolWindowId = "4e3dd124-064c-423f-86fd-85280d8f6aba";

        public WpfToolWindow() : this(null) { }

        public WpfToolWindow(WpfToolWindowData data) : base(null)
        {
            this.Caption = "Wpf Tool Window";
            BitmapImageMoniker = new ImageMoniker { Guid = PackageGuids.guidImages, Id = 2 };
            this.Content = new WpfToolWindowControl(data);
        }
    }
}
