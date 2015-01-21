using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the border thickness of a control")]
    public class SetBorderThickness : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmFloat left;

        [RequiredField]
        public FsmFloat top;

        [RequiredField]
        public FsmFloat right;

        [RequiredField]
        public FsmFloat bottom;

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
                _control.BorderThickness = new Noesis.Thickness(left.Value, top.Value, right.Value, bottom.Value);
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
