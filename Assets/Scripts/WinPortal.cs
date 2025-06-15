using UnityEngine;

public class WinPortal : MonoBehaviour

{
    [SerializeField] CollectibleCollection collectibleCollections;

    private void OnTriggerEnter(Collider other)
    {
        collectibleCollections.Win(other.gameObject);
    }
}
