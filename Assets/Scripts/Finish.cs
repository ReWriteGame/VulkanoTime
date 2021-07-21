using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Finish instance = null; // Экземпляр объекта


    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;

    void Start()
    {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }
    }


    public void loseGame()
    {
        lose.SetActive(true);
    }
    public void winGame()
    {
        win.SetActive(true);
    }

   
}
