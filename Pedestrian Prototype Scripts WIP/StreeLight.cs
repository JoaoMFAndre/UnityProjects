using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreeLight : MonoBehaviour
{
    
    #region Singleton

    public static StreeLight instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject streetLight;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
