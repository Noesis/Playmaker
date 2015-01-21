using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets the brush that draws the outer border color")]
    public class GetBorderBrush : FsmStateAction
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
                        var brush = control.BorderBrush;
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
