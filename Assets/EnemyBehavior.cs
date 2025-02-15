using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float enemySpeed = 4.0f;
    GameObject[] enemyTargets;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            float step = Time.deltaTime * enemySpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject closest = null;
        enemyTargets = GameObject.FindGameObjectsWithTag("Player");
        Vector3 position = transform.position;
        float distance = Mathf.Infinity;

        foreach (GameObject target in enemyTargets) 
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance) 
            {
                closest = target;
                distance = curDistance;
            }
        }
        return closest;
    }
}
