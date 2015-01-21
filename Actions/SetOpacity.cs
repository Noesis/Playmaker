using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the opacity factor applied to the entire element when it is rendered")]
    public class SetOpacity : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmFloat opacity;

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
                _control.Opacity = opacity.Value;
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
