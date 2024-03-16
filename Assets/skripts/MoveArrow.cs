using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveArrow : MonoBehaviour
{
    public float speed = 100f;
    private float Vector = 1;
    public GameObject PowerBar;
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown("space")){
            PowerBar.SetActive(true);
        }
        if (PowerBar.active)
        {
            speed = 0f;
        }
        else
        {
            speed = 100f;
        }
        Move();
        transform.Rotate(0, Vector * speed * Time.deltaTime, 0);

    }

    public void Move()
    {
        if (15 <= transform.eulerAngles.y && transform.eulerAngles.y <= 40)
        {
            Vector = 1;
        }
        if (145 <= transform.eulerAngles.y && transform.eulerAngles.y <= 165)
        {
            Vector = -1;
        }
    }
}
