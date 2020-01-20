using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour
{

    private float timer;

    public GameObject[] mummy;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = 6f;
        //animator.SetBool("Raise", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.y <= 20)
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
            
        }

        if (timer <= 4)
        {
            RaiseMummies();
        }
        
        if (timer <= 0)
        {
            Destroy(gameObject);
        } 
    }
    
    public void RaiseMummies()
    {
        mummy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < mummy.Length; i++)
        {
            mummy[i].SendMessage("Arise");
        }
    }
}
