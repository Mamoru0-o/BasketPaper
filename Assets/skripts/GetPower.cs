using UnityEngine;
using UnityEngine.UI;

public class GetPower : MonoBehaviour
{
    public Image PowerImage;
    public Rigidbody Paper;
    public Transform VectorMove;

    private float powerScale;
    private float givePower = 0.015f;
    public static bool JumpKey = true;
    public static float VectorPower = 45f;
    public bool power = false;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        VectorPower = VectorMove.localEulerAngles.y;
        if (power)
        {
            if (powerScale <= 0)
            {
                givePower = 0.015f;
            }
            else if (powerScale >= 1)
            {
                givePower = -0.015f;
            }
            powerScale += givePower;
            PowerImage.fillAmount = powerScale;
        }
        
        if (Input.GetKeyDown("space"))
        {
            if (power && gameObject)
            {
                power = false;
                Paper.isKinematic = false;
                if (JumpKey)
                {
                    JumpKey = false;
                    Paper.AddForce((powerScale * 15 / 90) * VectorPower, powerScale * 7f, (powerScale * 15 / 90) * (90 - VectorPower), ForceMode.Impulse);
                }
            }
            else {
                if (Paper.isKinematic) 
                {
                    power = true;
                }
            }
        }
    }
}
