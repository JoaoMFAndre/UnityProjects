using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVDetection : MonoBehaviour
{
    public Transform player;
    EnemyTactics enemyTactics;

    public float maxAngle;
    public bool isInFOV = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyTactics = GetComponent<EnemyTactics>();
    }

    // Update is called once per frame
    void Update()
    {
        isInFOV = inFOV(transform, player, maxAngle, enemyTactics.lookRadius);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyTactics.lookRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * enemyTactics.lookRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * enemyTactics.lookRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFOV)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * enemyTactics.lookRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * enemyTactics.lookRadius);
    }

    public static bool inFOV (Transform checkinObject, Transform target, float maxAngle, float maxRadius)
    {
        
        Collider[] overlaps = new Collider[999];
        int count = Physics.OverlapSphereNonAlloc(checkinObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkinObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkinObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {

                        Ray ray = new Ray(checkinObject.position, target.position - checkinObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        
        return false;
    }
}
