using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float movementSpeed = 5f;
    private float rotationSpeed = 5f;
    private Vector3 target;
    private bool isMove = false;

    private List<Vector3> points = new List<Vector3>();
    private int curIndex = 0;
    private Rigidbody rb;
    private float stoppingDistance = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            // ���������, �������� �� �� ������� �����
            Vector2 pos = new Vector2(transform.position.x, transform.position.z);
            Vector2 tg = new Vector2(target.x, target.z);
            //if (Vector3.Distance(transform.position, target) < stoppingDistance)
            if (Vector3.Distance(pos, tg) < stoppingDistance)
            {
                NextPoint();
            }
            else
            {
                // ������������ � ������� ��������� �����
                LookAtWaypoint();

                // ���������� ����� � ������� �����
                MoveTowardsWaypoint();
            }
        }
    }

    /*void NextWaypoint()
    {
        // ��������� � ��������� �����
        currentWaypointIndex = (currentWaypointIndex + 1) % points.Count;
        target = points[curIndex];
    }*/

    void LookAtWaypoint()
    {
        // ������������ ����� � ������� ��������� �����
        Vector3 dir = target - transform.position;dir.y = 0f;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);
    }

    void MoveTowardsWaypoint()
    {
        // ���������� ����� � ������� �����
        Vector3 dir = target - transform.position;dir.y = 0f;
        rb.MovePosition(transform.position + dir.normalized * movementSpeed * Time.deltaTime);
    }

    private void NextPoint()
    {
        if (curIndex < points.Count)
        {
            target = points[curIndex];
            curIndex++;
        }
        else isMove = false;
    }

    public void SetPath(List<Vector3> path)
    {
        points.Clear();
        points.AddRange(path);
        curIndex = 0;
        target = points[curIndex];
        isMove = true;
    }
}
