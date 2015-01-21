using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets the border thickness of a control")]
    public class GetBorderThickness : FsmStateAction
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
                        var thickness = control.BorderThickness;
                        left.Value = thickness.Left;
                        top.Value = thickness.Top;
                        right.Value = thickness.Right;
                        bottom.Value = thickness.Bottom;
                    }
                }
            }

            Finish();
        }
    }
}
