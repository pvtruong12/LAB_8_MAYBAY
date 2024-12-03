using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThienThach : MonoBehaviour
{
    public float HP;
    public GameObject prefabsVuno;
    void Start()
    {
        Vector3 vt = transform.localScale;
        float randoms = Random.Range(0.5f, 2f);
        transform.localScale = vt * randoms;
        HP = (randoms * 3) / 0.5f;
        
    }
    public void TakeDame(float dame)
    {
        HP -= dame;
        if(HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(prefabsVuno, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GioiHan"))
            Destroy(gameObject);
    }
}
