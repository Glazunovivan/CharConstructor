using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<Stage> games;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject background;

    private Stage currentStage;
    private int countCorrectAnswer;

    private void Start()
    {
        mainMenu.SetActive(true);
        //StartGame(0);
    }

    public void StartGame(int index)
    {
        mainMenu.SetActive(false);

        countCorrectAnswer = 0;
        currentStage = games[index];
        currentStage.StartGame();
    }

    public void CheckFinish()
    {
        if (countCorrectAnswer == currentStage.countCorrect)
        {
            Debug.Log("Конец!");
            StartCoroutine(OpenMenu());
        }
    }

    public void IncrementAnswer()
    {
        countCorrectAnswer++;
    }

    private IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(2f);
        currentStage.gameObject.SetActive(false);
        mainMenu.SetActive(true);
        background.SetActive(false);
    }
}

