using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuffer : MonoBehaviour
{
    public GameObject player, mainCam, realEnemy, weedEnemy;
    private Image loadingScreen;
    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LevelTransition").GetComponent<Image>();
        canvas = GameObject.Find("Canvas");
        StartCoroutine(Buffer());
    }

    private IEnumerator Buffer()
    {
        yield return new WaitForSeconds(3);
        GameObject mc = Instantiate(mainCam, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        mc.name = "Main Camera";
        GameObject pl = Instantiate(player, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        pl.name = "Player";
        for(int y = 0; y < 20; y++)
        {
            for(int x = 0; x < 20; x++) {
                if (GetComponent<LevelGenerator>().house[x, y] != null && (x != 9 && y != 9)) 
                {
                    switch (Random.Range(0, 4))
                    {
                        case 0:
                            Instantiate(realEnemy, new Vector3(x * 20 - 180, -2.7f, y * 20 - 180), Quaternion.Euler(0, 0, 0));
                            break;
                        case 1:
                            Instantiate(weedEnemy, new Vector3(x * 20 - 180, -2.7f, y * 20 - 180), Quaternion.Euler(0, 0, 0));
                            break;
                    }
                }
            }
        }

        while(loadingScreen.fillAmount > 0)
        {
            loadingScreen.fillAmount -= 0.05f;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
