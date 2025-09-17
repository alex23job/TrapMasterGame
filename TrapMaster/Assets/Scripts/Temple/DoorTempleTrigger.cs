using UnityEngine;

public class DoorTempleTrigger : MonoBehaviour
{
    [SerializeField] private string doorID;
    private Animator anim;
    private string openTrigger, closeTrigger;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (doorID != "R")
        {
            openTrigger = "DLOpenTrigger";
            closeTrigger = "DLCloseTrigger";
        }
        if (doorID != "L")
        {
            openTrigger = "DROpenTrigger";
            closeTrigger = "DRCloseTrigger";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //anim.SetTrigger(openTrigger);
            //anim.SetTrigger(openTrigger);
            anim.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //anim.SetTrigger(closeTrigger);
            //anim.SetTrigger(closeTrigger);
            anim.SetBool("IsOpen", false);
        }
    }
}
