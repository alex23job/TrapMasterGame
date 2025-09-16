using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private int hp;
    private int damage;
    private int price;
    private int exp;
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

    public void SetParams(LevelControl lc, int hp, int dmg, int rad, int prc, int exp)
    {
        levelControl = lc;
        damage = dmg;
        radius = rad;
        this.hp = hp;
        this.exp = exp;
        price = prc;
    }

    public void SetParams(LevelControl lc, EnemyInfo ei)
    {
        levelControl = lc;
        hp = ei.Hp;
        exp = ei.Exp;
        radius = ei.Radius;
        damage = ei.Damage;
        price = ei.Price;
    }

    public void ChangeHP(int zn)
    {
        if ((zn < 0) && ((hp + zn) <= 0))
        {   //  убит
            hp = 0;
            levelControl.EnemyDestroy(price, exp);
            Destroy(gameObject);
        }
        else
        {
            hp += zn;
        }
    }
}

[Serializable]
public class EnemyInfo
{
    private string nameEnemy;
    private int hp;
    private int damage;
    private int price;
    private int exp;
    private float radius;

    public string NameEnemy { get => nameEnemy; }
    public int Hp { get => hp; }
    public int Damage { get => damage; }
    public int Price { get => price; }
    public int Exp { get => exp; }
    public float Radius { get => radius; }

    public EnemyInfo() { }
    public EnemyInfo(string nm, int hp, int dmg, int prc, int exp, float rad)
    {
        nameEnemy = nm;
        this.hp = hp;
        this.damage = dmg;
        this.price = prc;
        this.exp = exp;
        this.radius = rad;
    }
}
