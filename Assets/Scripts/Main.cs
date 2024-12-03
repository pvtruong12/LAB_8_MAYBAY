using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator animator;
    public int aloneVienDan = 0;
    public GameObject prefabsViendan;
    public GameObject prefabsThienThach;
    private long LastTimeBan;
    private long LastTimeRandomTT;
    public int levelBan = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void VienDanBan()
    {
        switch(levelBan)
        {
            case 1: OneVienDan(); break;
            case 2:TwoVienDan();break;
            default:ThreeVienDan();break;

        }    
    }
    public long currentTimeMillis()
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000;
    }
    public void OneVienDan()
    {
        GameObject gameobj = Instantiate(prefabsViendan, transform.position, Quaternion.identity);
        float y1 = Mathf.Sin(90f * Mathf.Deg2Rad);
        gameobj.GetComponent<VienDan>().vector = new Vector2(0, y1);
    }
    public void TwoVienDan()
    {
        for(int i = -1; i< 2; i+= 2)
        {
            Vector3 localPostion = transform.position;
            float x = localPostion.x + i *0.1f;
            float y = localPostion.y +1;
            GameObject gameobj = Instantiate(prefabsViendan, new Vector3(x, y, 0), Quaternion.identity);
            float y1 = Mathf.Sin(90f * Mathf.Deg2Rad);
            gameobj.GetComponent<VienDan>().vector = new Vector2(0, y1);
        }
    }public void ThreeVienDan()
    {
        OneVienDan();
        for (int i = -1; i< 2; i+= 2)
        {
            Vector3 localPostion = transform.position;
            float x = localPostion.x + i *0.1f;
            float y = localPostion.y +1;
            GameObject gameobj = Instantiate(prefabsViendan, new Vector3(x, y, 0), Quaternion.identity);
            float x1 = Mathf.Cos(80f* Mathf.Deg2Rad);
            float y1 = Mathf.Sin(80f * Mathf.Deg2Rad);
            Vector2 direction = new Vector2(x1 * i, y1);
            gameobj.GetComponent<VienDan>().vector = direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gameobj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
    void FixedUpdate()
    {
        MoveMain();
        if(currentTimeMillis() - LastTimeBan >= 500)
        {
            LastTimeBan = currentTimeMillis();
            VienDanBan();
        }
        if(currentTimeMillis() - LastTimeRandomTT >= 3000)
        {
            LastTimeRandomTT = currentTimeMillis();
            float x = UnityEngine.Random.Range(-2.2f, 2.2f);
            Instantiate(prefabsThienThach, new Vector3(x, 6.5f, 0), Quaternion.identity);
        }    
    }

    void MoveMain()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 vtmove = new Vector2(x,0); 
        rb.velocity = vtmove * moveSpeed;
        AnimationManager(x);
    }

    void AnimationManager(float x)
    {
        animator.SetBool("isLeft", x < 0); 
        animator.SetBool("isRight", x > 0);
    }
}
