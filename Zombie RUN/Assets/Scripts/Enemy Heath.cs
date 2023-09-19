using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // Update is called once per frame
    public void TakeDamage(float damageAmount){
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageAmount;
        Debug.Log("Remaining health: " + hitPoints);
        if (hitPoints <= Mathf.Epsilon) {
            Destroy(gameObject);
        }
    }
}
