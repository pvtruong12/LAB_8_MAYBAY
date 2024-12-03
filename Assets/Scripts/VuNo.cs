using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuNo : MonoBehaviour
{
    public float xacSuatRandom = 0.1f;
    public GameObject prefabsItem;
    public float tocdoroiItem;
    void Start()
    {
        Destroy(gameObject, 0.28f);
        if(RandomChance(xacSuatRandom))
        {
            GameObject gameobj =Instantiate(prefabsItem, transform.position, Quaternion.identity);
            gameobj.GetComponent<Rigidbody2D>().gravityScale = tocdoroiItem;
        }
    }
    bool RandomChance(float percentage)
    {
        float randomValue = Random.Range(0f, 1f);
        return randomValue <= percentage;
    }
}
