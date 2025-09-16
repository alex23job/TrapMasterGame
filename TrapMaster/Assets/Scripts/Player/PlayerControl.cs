using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private int maxHP = 100;

    private PlayerShooting shooting;

    private void Awake()
    {
        shooting = GetComponent<PlayerShooting>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("SendShootingParams", 0.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SendShootingParams()
    {
        shooting.SetEnergy(120);    //  это пока, а так из GM надо взять
    }
}
