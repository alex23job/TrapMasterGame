using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private int hp;
    private int damage;
    private float radius;
    private LevelControl levelControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParams(LevelControl lc, int hp, int dmg, int rad)
    {
        levelControl = lc;
        damage = dmg;
        radius = rad;
        this.hp = hp;
    }

    public void ChangeHP(int zn)
    {
        if ((zn < 0) && ((hp + zn) <= 0))
        {   //  убит
            hp = 0;
            Destroy(gameObject);
        }
        else
        {
            hp += zn;
        }
    }
}
