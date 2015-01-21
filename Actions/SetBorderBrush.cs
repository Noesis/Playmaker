using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the brush that draws the outer border color")]
    public class SetBorderBrush : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmColor color;

        public bool everyFrame;

        private Noesis.Control _control;

        public override void OnEnter()
        {
            GetControl();
            Update();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            Update();
        }

        private void Update()
        {
            if (_control != null)
            {
                var c = new Noesis.Color(color.Value.r, color.Value.g, color.Value.b, color.Value.a);
                _control.BorderBrush = new SolidColorBrush(c);
            }
        }

        private void GetControl()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    _control = ((SystemObject)element.Value).Object as Noesis.Control;
                }
            }
        }
    }
}
