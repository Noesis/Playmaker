using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the highest possible Value of the range element")]
    public class SetRangeMaximum : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmFloat maximum;

        public bool everyFrame;

        private Noesis.RangeBase _control;

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
                _control.Maximum = maximum.Value;
            }
        }

        private void GetControl()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    _control = ((SystemObject)element.Value).Object as Noesis.RangeBase;
                }
            }
        }
    }
}
