using System;
using UnityEngine;

namespace MyCompany.RogueSmash.Prototype
{
    [RequireComponent(typeof(BoxCollider))]
    public class PickUpItem : MonoBehaviour
    {
        /// Callback to be invoked when this
        /// a trigger event is fired by Unity's collision system.

        private Action<GameObject> onPickedUp;

        /// We can't use a constructor in a monobehavior so  we instead provide a manually called Init method
        /// <param name="= "onPickedUp"> Callback to be invoked on trigger event </param>
        /// 
        
        public void Init(Action<GameObject> onPickedUp)
        {
            this.onPickedUp = onPickedUp;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other != null)
            {
                Debug.Log("ENTERED");
                if(onPickedUp != null)
                {
                    onPickedUp.Invoke(other.gameObject);
                }
            }
        }


    }


}

