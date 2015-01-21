using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Applies the animations associated with a Storyboard to their targets and initiates them")]
    public class BeginStoryboard : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmString storyboardName;

        [Tooltip("Event to raise when the animation has completely finished playing")]
        public FsmEvent completedEvent;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.FrameworkElement;
                    if (control != null)
                    {
                        var animation = (Noesis.Storyboard)control.FindResource(storyboardName.Value);
                        animation.Begin(control, control, true);
                        animation.Completed += animation_Completed;
                    }
                }
            }
        }

        private void animation_Completed(object sender, TimelineEventArgs e)
        {
            if (completedEvent != null)
            {
                Fsm.Event(completedEvent);
            }
            Finish();
        }
    }
}
