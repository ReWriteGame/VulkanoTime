using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Finish instance = null; // ��������� �������


    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;

    void Start()
    {
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
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
