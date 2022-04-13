using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Bullet : MonoBehaviour
{
    [SerializeField] private float liveTime;
    [SerializeField] private float angleSpeed = 100;
    [SerializeField] private float speed = 1;
    private float VerticalMove;

    private GameObject target;

    void Start()
    {
        Invoke(nameof(SelfDestroy), liveTime);

        VerticalMove = Vector3.Distance(transform.position, target.transform.position);
    }

    

    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized * speed * Time.deltaTime;
        transform.position += direction;
        transform.RotateAround(target.transform.position, Vector3.up, angleSpeed * Time.deltaTime);
    }

    public void Launch(GameObject target)
    {
        this.target = target;
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

}
