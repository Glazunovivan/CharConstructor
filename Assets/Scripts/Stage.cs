using System.Collections;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject stage;
    public GameObject background;
    public GameObject IncorrectElements;
    public GameObject preview;

    public int countCorrect;


    public void StartGame()
    {
        gameObject.SetActive(true);
        background.SetActive(true);
     
        StartCoroutine(ShowPreview());
    }

    private IEnumerator ShowPreview()
    {
        IncorrectElements.gameObject.SetActive(false);
        preview.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        IncorrectElements.gameObject.SetActive(true);
        preview.gameObject.SetActive(false);
    }
}