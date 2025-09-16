using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private LevelControl levelControl;

    private PlayerShooting shooting;

    private int currentHP;

    private void Awake()
    {
        shooting = GetComponent<PlayerShooting>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("TranslateParams", 0.2f);
        currentHP = maxHP;
        ViewHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TranslateParams()
    {
        SendShootingParams();
        ViewHP();
    }

    private void SendShootingParams()
    {
        shooting.SetEnergy(120);    //  это пока, а так из GM надо взять
    }

    public void ChangeHP(int zn)
    {
        if (currentHP + zn > maxHP) currentHP = maxHP;
        else if (currentHP + zn < 0)
        {   //  наш защитник убит !!!
            currentHP = 0;
        }
        else currentHP += zn;
        ViewHP();
    }

    private void ViewHP()
    {
        if (levelControl != null) levelControl.ViewPlayerHP(currentHP);
    }
}
