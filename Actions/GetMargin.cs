using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets the outer margin of an element")]
    public class GetMargin : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat left;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat top;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat right;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmFloat bottom;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.Control;
                    if (control != null)
                    {
                        left.Value = control.Margin.Left;
                        top.Value = control.Margin.Top;
                        right.Value = control.Margin.Right;
                        bottom.Value = control.Margin.Bottom;
                    }
                }
            }

            Finish();
        }
    }
}
