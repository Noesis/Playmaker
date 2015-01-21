using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets a value that indicates whether the position of the mouse pointer corresponds to hit test results, which take element compositing into account")]
    public class GetIsMouseDirectlyOver : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmBool isMouseDirectlyOver;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.Control;
                    if (control != null)
                    {
                        isMouseDirectlyOver.Value = control.IsMouseDirectlyOver;
                    }
                }
            }

            Finish();
        }
    }
}
