using System;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class OnTargetHitEvent : UnityEvent<int,GameObject>
    {
    }

    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;

        public OnTargetHitEvent onTargetHit;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
                
                onTargetHit = new OnTargetHitEvent();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}