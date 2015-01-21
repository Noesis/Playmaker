using UnityEngine;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using Noesis;

public class PlaymakerNoesisProxy: MonoBehaviour
{
    public OwnerDefaultOption fsmOption;
    public PlayMakerFSM fsm;
    public string x_Name;

    [System.Serializable]
    public struct Handler
    {
        public string source;
        public string target;
    }

    public List<Handler> handlers = new List<Handler>();

    #region MonoBehavior
    void Start()
    {
        var noesisGUI = GetComponent<NoesisGUIPanel>();
        if (noesisGUI != null)
        {
            var root = noesisGUI.GetContent();
            if (root != null)
            {
                var element = root.FindName(x_Name);
                if (element != null)
                {
                    foreach (var handler in handlers)
                    {
                        HookEvent(handler.source, handler.target, element);
                    }
                }
            }
        }
    }

    private void SendEvent(string target, object sender)
    {
        Fsm.EventData.ObjectData = new SystemObject() { Object = sender };
        fsm.SendEvent(target); 
    }

    private void HookEvent(string source, string target, object element)
    {
        if (source == "None" || target == "None")
        {
            return;
        }

        // UIElement
        if (element is Noesis.UIElement)
        {
            if (source == "UIElement/MouseEnter")
            {
                ((Noesis.UIElement)element).MouseEnter += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseDown")
            {
                ((Noesis.UIElement)element).MouseDown += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseLeftButtonDown")
            {
                ((Noesis.UIElement)element).MouseLeftButtonDown += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseRightButtonDown")
            {
                ((Noesis.UIElement)element).MouseRightButtonDown += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseUp")
            {
                ((Noesis.UIElement)element).MouseUp += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseLeftButtonUp")
            {
                ((Noesis.UIElement)element).MouseLeftButtonUp += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseRightButtonDown")
            {
                ((Noesis.UIElement)element).MouseRightButtonDown += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseWheel")
            {
                ((Noesis.UIElement)element).MouseWheel += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/MouseLeave")
            {
                ((Noesis.UIElement)element).MouseLeave += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/TouchEnter")
            {
                ((Noesis.UIElement)element).TouchEnter += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/TouchDown")
            {
                ((Noesis.UIElement)element).TouchDown += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/TouchUp")
            {
                ((Noesis.UIElement)element).TouchUp += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "UIElement/TouchLeave")
            {
                ((Noesis.UIElement)element).TouchLeave += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // FrameworkElement
        if (element is Noesis.FrameworkElement)
        {
            if (source == "FrameworkElement/Loaded")
            {
                ((Noesis.FrameworkElement)element).Loaded += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "FrameworkElement/Unloaded")
            {
                ((Noesis.FrameworkElement)element).Unloaded += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "FrameworkElement/SizeChanged")
            {
                ((Noesis.FrameworkElement)element).SizeChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        if (element is Noesis.Control)
        {
            if (source == "Control/MouseDoubleClick")
            {
                ((Noesis.Control)element).MouseDoubleClick += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // TextBoxBase
        if (element is Noesis.TextBoxBase)
        {
            if (source == "TextBoxBase/SelectionChanged")
            {
                ((Noesis.TextBoxBase)element).SelectionChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "TextBoxBase/TextChanged")
            {
                ((Noesis.TextBoxBase)element).TextChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ButtonBase
        if (element is Noesis.ButtonBase)
        {
            if (source == "ButtonBase/Click")
            {
                ((Noesis.ButtonBase)element).Click += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ToggleButton
        if (element is Noesis.ToggleButton)
        {
            if (source == "ToggleButton/Checked")
            {
                ((Noesis.ToggleButton)element).Checked += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "ToggleButton/Indeterminate")
            {
                ((Noesis.ToggleButton)element).Indeterminate += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "ToggleButton/Unchecked")
            {
                ((Noesis.ToggleButton)element).Unchecked += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // Expander
        if (element is Noesis.Expander)
        {
            if (source == "Expander/Collapsed")
            {
                ((Noesis.Expander)element).Collapsed += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "Expander/Expanded")
            {
                ((Noesis.Expander)element).Expanded += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ListBoxItem
        if (element is Noesis.ListBoxItem)
        {
            if (source == "ListBoxItem/Selected")
            {
                ((Noesis.ListBoxItem)element).Selected += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "Expander/Unselected")
            {
                ((Noesis.ListBoxItem)element).Unselected += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ScrollViewer
        if (element is Noesis.ScrollViewer)
        {
            if (source == "ScrollViewer/ScrollChanged")
            {
                ((Noesis.ScrollViewer)element).ScrollChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ToolTip
        if (element is Noesis.ToolTip)
        {
            if (source == "ToolTip/Closed")
            {
                ((Noesis.ToolTip)element).Closed += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "ToolTip/Opened")
            {
                ((Noesis.ToolTip)element).Opened += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ContextMenu
        if (element is Noesis.ContextMenu)
        {
            if (source == "ContextMenu/Closed")
            {
                ((Noesis.ContextMenu)element).Closed += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "ContextMenu/Opened")
            {
                ((Noesis.ContextMenu)element).Opened += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // MenuItem
        if (element is Noesis.MenuItem)
        {
            if (source == "MenuItem/Checked")
            {
                ((Noesis.MenuItem)element).Checked += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "MenuItem/Click")
            {
                ((Noesis.MenuItem)element).Click += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "MenuItem/SubmenuClosed")
            {
                ((Noesis.MenuItem)element).SubmenuClosed += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "MenuItem/SubmenuOpened")
            {
                ((Noesis.MenuItem)element).SubmenuOpened += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "MenuItem/Unchecked")
            {
                ((Noesis.MenuItem)element).Unchecked += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // MenuItem
        if (element is Noesis.TreeViewItem)
        {
            if (source == "TreeViewItem/Collapsed")
            {
                ((Noesis.TreeViewItem)element).Collapsed += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "TreeViewItem/Expanded")
            {
                ((Noesis.TreeViewItem)element).Expanded += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "TreeViewItem/Selected")
            {
                ((Noesis.TreeViewItem)element).Selected += (sender, args) => { SendEvent(target, sender); };
                return;
            }
            if (source == "TreeViewItem/Unselected")
            {
                ((Noesis.TreeViewItem)element).Unselected += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // Selector
        if (element is Noesis.Selector)
        {
            if (source == "Selector/SelectionChanged")
            {
                ((Noesis.Selector)element).SelectionChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // TreeView
        if (element is Noesis.TreeView)
        {
            if (source == "TreeView/SelectedItemChanged")
            {
                ((Noesis.TreeView)element).SelectedItemChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // PasswordBox
        if (element is Noesis.PasswordBox)
        {
            if (source == "PasswordBox/PasswordChanged")
            {
                ((Noesis.PasswordBox)element).PasswordChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // RangeBase
        if (element is Noesis.RangeBase)
        {
            if (source == "RangeBase/ValueChanged")
            {
                ((Noesis.RangeBase)element).ValueChanged += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }

        // ScrollBar
        if (element is Noesis.ScrollBar)
        {
            if (source == "ScrollBar/Scroll")
            {
                ((Noesis.ScrollBar)element).Scroll += (sender, args) => { SendEvent(target, sender); };
                return;
            }
        }
    }
    #endregion
}