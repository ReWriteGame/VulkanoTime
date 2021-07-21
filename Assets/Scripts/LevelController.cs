using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    static public LevelController Instance { get;/* private*/ set; }

    static private int passedLevels = 1;
    static private int sceneIndexForSeve = 1;
    private const string fileNameForSave = "saveFile";

    public static int PassedLevels { get => passedLevels; }


    void Start()
    {
        Instance = this;// инициализируем экземпляром класса на котором висит скрипт

        if (PlayerPrefs.HasKey(fileNameForSave))
            passedLevels = PlayerPrefs.GetInt(fileNameForSave, sceneIndexForSeve);

        if (SceneManager.GetActiveScene().buildIndex != 0)
            sceneIndexForSeve = SceneManager.GetActiveScene().buildIndex;
    }

    public void rememberLevelToSave()
    {
        sceneIndexForSeve++;// запоминаем след лвл для загрузки 
        Debug.Log("Level is remebmber");
    }

    // написать оболочку функцию для корутины
    public void loadNextLevelWrapper(float delayTime = 0)
    {
        StartCoroutine(loadNextLevelCor(delayTime));
    }
    public void loadLastLevelWrapper(float delayTime = 0)
    {
        StartCoroutine(loadLastLevelCor(delayTime));
    }
    public void reStartLevelWrapper(float delayTime = 0)
    {
        StartCoroutine(reStartLevelCor(delayTime));
    }

    public void loadLevelWrapper(int numLevel)
    {
        StartCoroutine(loadLevelCor(numLevel));
    }

    public void exitGameWrapper(float delayTime = 0)
    {
        StartCoroutine(exitCor( delayTime));
    }

    private IEnumerator loadNextLevelCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if (sceneIndexForSeve > passedLevels)
            PlayerPrefs.SetInt(fileNameForSave, sceneIndexForSeve);// сохраняем лвл

        int numberLvL = SceneManager.GetActiveScene().buildIndex;// получаем номер уровня
        if (numberLvL < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberLvL);// загрузка след уровня номер можно посмотреть через shift + ctrl + b

        yield break;
    }

    private IEnumerator loadLastLevelCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (PlayerPrefs.HasKey(fileNameForSave))
            SceneManager.LoadScene(PlayerPrefs.GetInt(fileNameForSave, sceneIndexForSeve));

        yield break;
    }

    private IEnumerator reStartLevelCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield break;
    }


    private IEnumerator loadLevelCor(int numLevel, float delayTime = 0)
    {
        yield return new WaitForSeconds(delayTime);
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(numLevel);

        yield break;
    }

    private IEnumerator exitCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Application.Quit();
        print("exit game");

        yield break;
    }
}