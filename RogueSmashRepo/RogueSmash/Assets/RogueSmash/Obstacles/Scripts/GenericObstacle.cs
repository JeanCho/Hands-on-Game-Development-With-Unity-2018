using MyCompany.GameFramework.Physics.Interfaces;
using UnityEngine;


namespace MyCompany.RogueSmash.Obstacles
{
    public class GenericObstacle : MonoBehaviour, ICollisionEnterHandler
    {
       public void Handle(GameObject instigator, Collision collision)
        {
            //TODO Implement damage code
            //TODO Implement KnockBack code

            Debug.Log(string.Format("Game object entered: {0}", instigator.name));
        }
    }
}

