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
    private float stoppingDistance = 1f;

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
            // ѕровер€ем, достигли ли мы текущей точки
            if (Vector3.Distance(transform.position, target) < stoppingDistance)
            {
                NextPoint();
            }

            // ѕоворачиваем в сторону следующей точки
            LookAtWaypoint();

            // ѕеремещаем врага к текущей точке
            MoveTowardsWaypoint();
        }
    }

    /*void NextWaypoint()
    {
        // ѕереходим к следующей точке
        currentWaypointIndex = (currentWaypointIndex + 1) % points.Count;
        target = points[curIndex];
    }*/

    void LookAtWaypoint()
    {
        // ѕоворачиваем врага в сторону следующей точки
        Vector3 dir = target - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);
    }

    void MoveTowardsWaypoint()
    {
        // ѕеремещаем врага к текущей точке
        Vector3 dir = target - transform.position;
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
