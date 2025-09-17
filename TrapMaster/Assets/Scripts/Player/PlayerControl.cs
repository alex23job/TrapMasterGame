using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private int recoverableEnergy = 1;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private LevelControl levelControl;

    private PlayerShooting shooting;

    private int currentHP;
    private float timer = 0.5f;

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
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            timer = 0.5f;
            if ((transform.position.x > -1f && transform.position.x < 1f) && (transform.position.z > -1f && transform.position.z < 1f)) shooting.ChangeEnergy(recoverableEnergy);
        }
    }

    private void TranslateParams()
    {
        SendShootingParams();
        ViewHP();
    }

    private void SendShootingParams()
    {
        shooting.SetEnergy(120);    //  ��� ����, � ��� �� GM ���� �����
    }

    public void ChangeHP(int zn)
    {
        if (currentHP + zn > maxHP) currentHP = maxHP;
        else if (currentHP + zn < 0)
        {   //  ��� �������� ���� !!!
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
