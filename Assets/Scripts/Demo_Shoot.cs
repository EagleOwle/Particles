using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private LayerMask unitMask;
    private GameObject currentShooter, currentTarget;

    private GameObject GetMouseTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, unitMask))
        {
            return hit.collider.gameObject;
        }

        return null;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentTarget = GetMouseTarget();
            Shoot(currentTarget);
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentShooter = GetMouseTarget();
        }

    }

    private void Shoot(GameObject target)
    {
        if (target == null) return;

        if (currentShooter == null) return;

        GameObject bullet = Instantiate(bulletPrefab, currentShooter.transform.position + Vector3.up * 2, currentShooter.transform.rotation);
        bullet.GetComponent<Demo_Bullet>().Launch(target);
    }

}
