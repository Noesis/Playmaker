using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets the index of the first item in the current selection or returns negative one (-1) if the selection is empty")]
    public class GetSelectedIndex : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt index;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.Selector;
                    if (control != null)
                    {
                        index.Value = control.SelectedIndex;
                    }
                }
            }

            Finish();
        }
    }
}
