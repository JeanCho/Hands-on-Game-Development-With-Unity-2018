using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCompany.RogueSmash.Player;
using MyCompany.GameFramework.InputManagement;
using MyCompany.RogueSmash.Weapons;
using MyCompany.RogueSmash.Achievements;
using MyCompany.GameFramework.Physics.Interfaces;

namespace MyCompany.RogueSmash.InputManagement
{
    public class SampleCharacterController : MonoBehaviour
    {
        [Header("Data Templates")]
        [SerializeField] private CharacterDataTemplate characterDataTemplate;
        [SerializeField] private WeaponDataTemplate weaponDataTemplate;

        [Header("Other")]
        private InputManager inputManager;
        private IWeapon weapon;
        [SerializeField] private Transform weaponBarrel;
        private AchievemenTracker tracker;
        private Rigidbody rigidBody;


        void Awake()
        {
            tracker = FindObjectOfType<AchievemenTracker>();
            rigidBody = GetComponent<Rigidbody>();

            inputManager = new InputManager(new SampleBindings(), new RadialMouseInputHandler());
            inputManager.AddActionToBinding("shoot", Shoot);
            weapon = new Pistol(weaponDataTemplate.WeaponData, weaponBarrel.gameObject);
        }
        public IWeapon Weapon
        {
            get { return weapon; }
        }
        void Start()
        {
            
        }

        void FixedUpdate()
        {
            CheckForInput();
        }


        private void OnCollisionEnter(Collision collision)
        {
            ICollisionEnterHandler[] handlers =
                collision.gameObject.GetComponents<ICollisionEnterHandler>();
            if (handlers != null)
            {
                foreach (var handler in handlers)
                {
                    handler.Handle(this.gameObject, collision);

                }
            }

            //Destroy(gameObject);
        }

        private void CheckForInput()
        {
            inputManager.CheckForInput();
            Vector2 mouseInput = inputManager.GetMouseVector();
            Quaternion lookRotation = Quaternion.Euler(mouseInput);
            transform.rotation = lookRotation;

            Vector3 input = Vector3.zero;
            input.x = inputManager.GetAxis("Horizontal");
            input.z = inputManager.GetAxis("Vertical");
            //transform.Translate(input * Time.deltaTime * characterDataTemplate.Data.MovementSpeed, Space.World);
            rigidBody.velocity = input * characterDataTemplate.Data.MovementSpeed;
        }

        private void Shoot()
        {
           if( weapon.Shoot())
            {
                tracker.ReportProgress("shots_fired", 1.0f);
            }
        }

    }

}
