using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBuffer : MonoBehaviour
{
    public GameObject player, mainCam;
    private Image loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen = GameObject.Find("LevelTransition").GetComponent<Image>();
        StartCoroutine(Buffer());
    }

    private IEnumerator Buffer()
    {
        yield return new WaitForSeconds(3);
        Instantiate(mainCam, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

        while(loadingScreen.fillAmount > 0)
        {
            loadingScreen.fillAmount -= 0.05f;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
