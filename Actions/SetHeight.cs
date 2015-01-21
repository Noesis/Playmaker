using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the height of the element")]
    public class SetHeight : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmFloat height;

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
                _control.Height = height.Value;
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
