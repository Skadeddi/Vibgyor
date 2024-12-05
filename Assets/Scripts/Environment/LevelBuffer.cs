using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LevelBuffer : MonoBehaviour
{
    public GameObject player, mainCam, realEnemy, weedEnemy, colorInvertController;
    private Image loadingScreen;
    private GameObject pl;
    private VariableDeclarations vars;
    public int enemyCount;
    public TextMeshProUGUI enemyCounter;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LevelTransition").GetComponent<Image>();
        StartCoroutine(Buffer());
    }

    private IEnumerator Buffer()
    {
        yield return new WaitForSeconds(3);
        GameObject mc = Instantiate(mainCam, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        mc.name = "Main Camera";
        pl = Instantiate(player, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        pl.name = "Player";
        vars = Variables.Scene(SceneManager.GetActiveScene());
        vars.Set("PlayerTransform", pl.transform);
        GameObject cic = Instantiate(colorInvertController, this.transform);
        Variables.Object(cic).Set("Camera", mc);
        for(int y = 0; y < 20; y++)
        {
            for(int x = 0; x < 20; x++) 
            {
                if (GetComponent<LevelGenerator>().house[x, y] != null && !(x == 9 && y == 9)) 
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            Instantiate(realEnemy, new Vector3(x * 20 - 180, -2.7f, y * 20 - 180), Quaternion.Euler(0, 0, 0));
                            enemyCount++;
                            break;
                        case 1:
                            Instantiate(weedEnemy, new Vector3(x * 20 - 180, -2.7f, y * 20 - 180), Quaternion.Euler(0, 0, 0));
                            enemyCount++;
                            break;
                    }
                }
            }
            /*vars.Set("EnemyCount", enemyCount);
            vars.Set("EnemyTotal", enemyCount);
            enemyCounter.text = enemyCount.ToString() + "/" + vars.Get("EnemyTotal");*/
        }

        while(loadingScreen.fillAmount > 0)
        {
            loadingScreen.fillAmount -= 0.05f;
            yield return new WaitForSeconds(0.025f);
        }
    }

    private void Update()
    {
        enemyCounter.text = vars.Get("EnemyCount").ToString();
    }
}
