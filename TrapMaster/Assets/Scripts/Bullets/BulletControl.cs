using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private int damage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Enemy"))
        {
            EnemyControl enemyControl = other.gameObject.GetComponent<EnemyControl>();
            if (enemyControl != null) enemyControl.ChangeHP(-damage);
            //Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
