using UnityEditor;
using UnityEngine;

public class PointCoin : MonoBehaviour
{
    [SerializeField] CollectibleCollection cC;

    public void collect()
    {
        cC.point += 10;
        cC.UpdPoints();
        Destroy(gameObject);
    }

    void Update()
    {
        //Make coin spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}
