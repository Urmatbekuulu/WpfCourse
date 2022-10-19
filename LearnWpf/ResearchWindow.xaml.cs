using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace LearnXAML; 

public partial class ResearchWindow : Window {
    private object? HoveredSource { get; set; }
    public event Action<object, MouseEventArgs> ElementHovered;
    public ResearchWindow() {
        InitializeComponent();
    }
    private void UIElement_OnPreviewMouseMove(object sender, MouseEventArgs e) {
        if(e.OriginalSource.Equals(HoveredSource)) return;
        HoveredSource = e.OriginalSource;
        //Debugger.Log(0,null,$"\nSource: {e.OriginalSource}");
        ElementHovered.Invoke(sender,e);
    }
}