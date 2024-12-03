using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemMap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GioiHan"))
            Destroy(gameObject);
        if (collision.CompareTag("Main"))
        {
            collision.gameObject.GetComponent<Main>().levelBan++;
            Destroy(gameObject);
        }
    }
}
