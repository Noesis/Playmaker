using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using HutongGames.PlayMaker;
using Noesis;

[CustomEditor(typeof(PlaymakerNoesisProxy))]
public class PlaymakerNoesisProxyInspector: Editor
{
    public override void OnInspectorGUI()
    {
        PlaymakerNoesisProxy proxy = (PlaymakerNoesisProxy)target;

        if (proxy.GetComponent<NoesisGUIPanel>() == null)
        {
            ErrorFeedbackGui("NoesisGUIPanel component not found");
            return;
        }

        proxy.fsmOption = (OwnerDefaultOption)EditorGUILayout.EnumPopup("FSM", proxy.fsmOption);
        if (proxy.fsmOption == OwnerDefaultOption.SpecifyGameObject)
        {
            EditorGUI.indentLevel++;
            proxy.fsm = (PlayMakerFSM)EditorGUILayout.ObjectField("Game Object", proxy.fsm, typeof(PlayMakerFSM), true);
            EditorGUI.indentLevel--;
        }
        else
        {
            proxy.fsm = proxy.gameObject.GetComponent<PlayMakerFSM>();
        }

        if (proxy.fsm == null)
        {
            ErrorFeedbackGui("PlayMakerFSM component not found");
            return;
        }

        proxy.x_Name = EditorGUILayout.TextField("x:Name", proxy.x_Name);

        var sources = GetSources(proxy);
        var targets = GetTargets(proxy.fsm);

        EditorGUILayout.Space();

        for (int i = 0; i < proxy.handlers.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            var handler = proxy.handlers[i];

            int sourceIndex = Math.Max(0, Array.IndexOf<string>(sources, handler.source));
            handler.source = sources[EditorGUILayout.Popup(sourceIndex, sources)];

            int targetIndex = Math.Max(0, Array.IndexOf<string>(targets, handler.target));
            handler.target = targets[EditorGUILayout.Popup(targetIndex, targets)];

            proxy.handlers[i] = handler;

            if (GUILayout.Button("X"))
            {
                proxy.handlers.Remove(handler);
            }

            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Handler"))
        {
            var handler = new PlaymakerNoesisProxy.Handler() { source = "", target = "" };
            proxy.handlers.Add(handler);
        }
    }

    private string[] GetSources(PlaymakerNoesisProxy proxy)
    {
        List<string> sources = new List<string>();
        sources.Add("None");

        sources.Add("UIElement/MouseEnter");
        sources.Add("UIElement/MouseDown");
        sources.Add("UIElement/MouseLeftButtonDown");
        sources.Add("UIElement/MouseRightButtonDown");
        sources.Add("UIElement/MouseUp");
        sources.Add("UIElement/MouseLeftButtonUp");
        sources.Add("UIElement/MouseRightButtonDown");
        sources.Add("UIElement/MouseWheel");
        sources.Add("UIElement/MouseLeave");
        sources.Add("UIElement/TouchEnter");
        sources.Add("UIElement/TouchDown");
        sources.Add("UIElement/TouchUp");
        sources.Add("UIElement/TouchLeave");

        sources.Add("FrameworkElement/Loaded");
        sources.Add("FrameworkElement/Unloaded");
        sources.Add("FrameworkElement/SizeChanged");

        sources.Add("Control/MouseDoubleClick");

        sources.Add("TextBoxBase/SelectionChanged");
        sources.Add("TextBoxBase/TextChanged");

        sources.Add("ButtonBase/Click");

        sources.Add("ToggleButton/Checked");
        sources.Add("ToggleButton/Indeterminate");
        sources.Add("ToggleButton/Unchecked");

        sources.Add("Expander/Collapsed");
        sources.Add("Expander/Expanded");

        sources.Add("ListBoxItem/Selected");
        sources.Add("ListBoxItem/Unselected");

        sources.Add("ScrollViewer/ScrollChanged");

        sources.Add("ToolTip/Closed");
        sources.Add("ToolTip/Opened");

        sources.Add("ContextMenu/Closed");
        sources.Add("ContextMenu/Opened");

        sources.Add("MenuItem/Checked");
        sources.Add("MenuItem/Click");
        sources.Add("MenuItem/SubmenuClosed");
        sources.Add("MenuItem/SubmenuOpened");
        sources.Add("MenuItem/Unchecked");

        sources.Add("TreeViewItem/Collapsed");
        sources.Add("TreeViewItem/Expanded");
        sources.Add("TreeViewItem/Selected");
        sources.Add("TreeViewItem/Unselected");

        sources.Add("Selector/SelectionChanged");

        sources.Add("TreeView/SelectedItemChanged");

        sources.Add("PasswordBox/PasswordChanged");

        sources.Add("RangeBase/ValueChanged");

        sources.Add("ScrollBar/Scroll");

        return sources.ToArray();
    }

    private string[] GetTargets(PlayMakerFSM fsm)
    {
        List<string> events = new List<string>();
        events.Add("None");

        foreach (var e in fsm.FsmEvents)
        {
            events.Add(e.Name);
        }

        return events.ToArray();
    }
    void ErrorFeedbackGui(string error)
    {
        GUILayout.Space(5);
        GUILayout.Label(error, "flow node 5", GUILayout.ExpandWidth(true), GUILayout.Height(24));
        GUILayout.Space(5);
    }
}
