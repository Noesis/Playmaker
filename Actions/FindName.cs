using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Finds an element that has the provided identifier name")]
    public class FindName : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(NoesisGUIPanel))]
        [Tooltip("The GameObject with the NoesisGUIPanel component")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("The name of the requested element")]
        public FsmString name;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            var noesisGUI = go.GetComponent<NoesisGUIPanel>();
            if (noesisGUI == null)
            {
                return;
            }

            var root = noesisGUI.GetContent();
            if (root == null)
            {
                return;
            }

            element.Value = new SystemObject() { Object = root.FindName(name.Value) };
            Finish();
        }
    }
}
