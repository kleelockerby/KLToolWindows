using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using EnvDTE;

namespace KLToolWindows
{
    public partial class WpfToolWindowControl : UserControl
    {
        public WpfToolWindowControl()
        {
            this.InitializeComponent();
        }

        public WpfToolWindowControl(WpfToolWindowData data) : this()
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            EnvDTE.DTE dte = data.Dte;
            EnvDTE.Solution sln = dte.Solution;

            foreach (EnvDTE.Project project in sln.Projects)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = $"Projct Name: {project.Name}";
                lbProjects.Items.Add(item);

                ProjectItems projectItems = project.ProjectItems;
                ScanProjectItems(projectItems, 1);
            }
        }

        private void ScanProjectItems(ProjectItems projectItems, int level)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            foreach (ProjectItem projectItem in projectItems)
            {
                ListBoxItem item = new ListBoxItem();
                string itemName = "Name: " + projectItem.Name + " " + level.ToString();
                item.Content = $"\t {itemName}";
                lbProjects.Items.Add(item);

                ProjectItems projectItems2 = projectItem.ProjectItems;
                if (projectItems2 != null)
                {
                    ScanProjectItems(projectItems2, level++);
                }
            }
        }
    }
}