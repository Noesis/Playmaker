using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Resumes a paused storyboard")]
    public class ResumeStoryboard : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmString storyboardName;

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
                        animation.Resume(control);
                    }
                }
            }

            Finish();
        }
    }
}
