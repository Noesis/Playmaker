using UnityEngine;
using HutongGames.PlayMaker;
using Noesis;

namespace HutongGames.PlayMaker.Actions.NoesisGUI
{
    [ActionCategory("NoesisGUI")]
    [Tooltip("Gets a value that represents the order on the z-plane in which an element appears")]
    public class GetZIndex : FsmStateAction
    {
        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmObject element;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt zIndex;

        public override void OnEnter()
        {
            if (element != null)
            {
                if (element.Value is SystemObject)
                {
                    var control = ((SystemObject)element.Value).Object as Noesis.DependencyObject;
                    if (control != null)
                    {
                        zIndex.Value = Noesis.Panel.GetZIndex(control);
                    }
                }
            }

            Finish();
        }
    }
}
