using DevExpress.Mvvm.UI.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SnoopToolLibrary {
    public class SnoopToolBehavior:Behavior<Window> {
        SnoopWindow? SnoopWindow { get; set; }
        protected override void OnAttached() {
            AssociatedObject.ContentRendered += AssociatedObject_Initialized;
            AssociatedObject.Closed += AssociatedObject_Closed;
        }
        private void AssociatedObject_Initialized(object? sender, EventArgs e) {
            var window = sender as Window;
            SnoopWindow = new SnoopWindow(window);
            SnoopWindow.Show();
        }

        private void AssociatedObject_Closed(object? sender, EventArgs e) {
            SnoopWindow?.Close();
        }
    }
}
