
using UnityEngine;
using MyCompany.GameFramework.Physics.Interfaces;

namespace MyCompany.RogueSmash.Weapons.Scripts
{
    public class PistolProjectileCollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            ICollisionEnterHandler[] handlers = 
                collision.gameObject.GetComponents<ICollisionEnterHandler>();
            if(handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(this.gameObject, collision);
                    
                }
            }

            Destroy(gameObject);
        }
    }
}

