using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private SlotVariant slotVariant;
    [SerializeField] private float endSpeedShow = 0.5f;
    [SerializeField] private float startSpeedShow = 0.01f;


    private Image currentIcon;
    public Image CurrentIcon { get => currentIcon; private set => currentIcon = value; }

    private void Start()
    {
        currentIcon = GetComponent<Image>();
    }

    private IEnumerator showAnimCor()
    {
        for (float i = 0; i < endSpeedShow; i += startSpeedShow)
        {
            yield return new WaitForSeconds(i);
            currentIcon.sprite = slotVariant.IconSlot[Random.Range(0, slotVariant.IconSlot.Count)];
        }
        yield break;
    }

    public void startSlot()
    {
        StartCoroutine(showAnimCor());
    }
}
