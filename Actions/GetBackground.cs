using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets a brush that describes the background of a control")]
    public class GetBackground : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmColor color;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.Control;
                    if (control != null)
                    {
                        var brush = control.Background;
                        if (brush is SolidColorBrush)
                        {
                            Noesis.Color c = ((SolidColorBrush)brush).Color;
                            color.Value = new UnityEngine.Color(c.R, c.G, c.B, c.A);
                        }
                    }
                }
            }

            Finish();
        }
    }
}
