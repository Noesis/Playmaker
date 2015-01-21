using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Sets the password currently held by the PasswordBox")]
    public class SetPassword : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        public FsmString password;

        public bool everyFrame;

        private Noesis.PasswordBox _control;

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
                _control.Password = password.Value;
            }
        }

        private void GetControl()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    _control = ((SystemObject)element.Value).Object as Noesis.PasswordBox;
                }
            }
        }
    }
}
