using UnityEngine;

namespace Assets.Scripts
{
    public class GlobalTimer : MonoBehaviour
    {
        void Start()
        {
            Constants.Timer.Time = 0;
        }

        void Update()
        {
            Constants.Timer.Time += Time.deltaTime;
        }
    }
}
