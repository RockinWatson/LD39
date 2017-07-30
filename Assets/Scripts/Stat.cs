using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Stat
    {
        [SerializeField]
        private HealthBar bar;
        [SerializeField]
        private float maxValue;
        [SerializeField]
        private float currentVal;

        public float CurrentVal
        {
            get
            {
                return currentVal;
            }

            set
            {              
                currentVal = Mathf.Clamp(value,0,MaxValue);
                bar.Value = currentVal;
            }
        }

        public float MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                bar.MaxValue = value;
                maxValue = value;
            }
        }

        public void Initialize()
        {
            this.MaxValue = maxValue;
            this.CurrentVal = currentVal;
        }
    }
}
