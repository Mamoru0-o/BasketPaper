using UnityEngine;

public class LiveTrigger : GoalScore
{
    [SerializeField] private GameObject Heart;
    [SerializeField] private Transform Canvas;
    [SerializeField] private GameObject EndMenu;
    [SerializeField] private GameObject PaperBall;
    private GameObject SaveHeart;
    private GameObject[] Hearts = new GameObject[MaxLives];
    private void Start()
    {
        EndMenu.SetActive(false);
        Hearts[0] = gameObject;
        for (int i = 1; i < MaxLives; i++)
        {
            SaveHeart = GameObject.Instantiate(Heart, new Vector3(- 500 + (50*i), -25, 0), Quaternion.identity);
            SaveHeart.name = $"Heart{i}";
            SaveHeart.transform.SetParent(Canvas, false);
            Hearts[i] = SaveHeart;
        }
    }

    void Update()
    {
        try
        {
            Hearts[Lives - 1].SetActive(true);
        }
        catch { Hearts[0].SetActive(false); }
        try {
            Hearts[Lives].SetActive(false);
        } catch { }

        if (Lives <= 0)
        {
            EndMenu.SetActive(true);
            Time.timeScale = 0f;
            PaperBall.SetActive(false);
        }
    }
}
