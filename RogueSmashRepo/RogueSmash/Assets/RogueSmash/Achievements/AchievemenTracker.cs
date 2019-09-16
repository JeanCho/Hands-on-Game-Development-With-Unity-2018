using System.Collections.Generic;
using MyCompany.GameFramework.ProgressSystem;
using MyCompany.GameFramework.SaveSystem;
using UnityEngine;

namespace MyCompany.RogueSmash.Achievements
{
    public class AchievemenTracker : MonoBehaviour
    {
       public struct Achievement
        {
            /// Value reuquired to trigger the achievement.

            private float reuquiredValue;

            // Message to display when achievemnt is earned

            private string message;

            public Achievement(float requiredValue, string message) : this()
            {
                this.reuquiredValue = requiredValue;
                this.message = message;
            }

            public string Message
            {
                get { return message; }
            }

            public float RequiredValue
            {
                get { return reuquiredValue; }
            }
       
    
        }

        private ProgressTracker progressTracker;
        private SaveSystem saveSystem;
        private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

        public void Awake()
        {
            progressTracker = new ProgressTracker();
            saveSystem = new SaveSystem();
            progressTracker.onValueChanged += OnProgressUpdated;
        }

        public void Start()
        {
            Achievement cheev = new Achievement(10, "Shots Fired!");
            achievements["shots_fired"] = cheev;
            progressTracker.RegisterIncrementalTrackable("shots_fired");
        }
        public void ReportProgress(string id, float value)
        {
            progressTracker.ReportIncrementalProgress(id, value);
        }

        public void OnProgressUpdated(string id, float value)
        {
            if(achievements.ContainsKey(id))
            {
                if(value >= achievements[id].RequiredValue)
                {
                    Debug.Log(string.Format("ACHIEVEMENT EARNED: {0}", achievements[id].Message));
                    achievements.Remove(id);
                }
            }
        }
    }
}

