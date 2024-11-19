using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject Stop;
    private bool isPause;

    private void Start()
    {
        isPause = false;
    }

    public void OnPause()
    {
        if (!isPause)
        {
            isPause = true;
            Stop.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnResume()
    {
        if (isPause)
        {
            isPause = false;
            Stop.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
