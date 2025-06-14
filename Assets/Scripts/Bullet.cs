using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Send a message to the player to apply damage
            other.SendMessage("ApplyBulletDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }

        if (other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}
