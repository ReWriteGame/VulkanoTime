using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private SlotVariant slotVariant;
    [SerializeField] private List<Slot> slotMachine;
    [SerializeField] private int[] priceForWin;

    [SerializeField] private int[] numberOfMatches;
    private bool canGetWin = false;

    private void Awake()
    {
        numberOfMatches = new int[slotVariant.IconSlot.Count];
    }

    public void countMatches()
    {
        stopAllSlots();

        if (canGetWin)
        {
            for (int v = 0; v < slotVariant.IconSlot.Count; v++)
                for (int m = 0; m < slotMachine.Count; m++)
                    if (slotVariant.IconSlot[v] == slotMachine[m].CurrentIcon.sprite)
                        numberOfMatches[v]++;

            for (int n = 0; n < numberOfMatches.Length; n++)
                for (int p = 1; p < priceForWin.Length; p++)
                    if (numberOfMatches[n] == p) ScoreCounter.Instance.add(priceForWin[p - 1]);

            canGetWin = false;
        }
      
    }

    public void checkLose()
    {
        if (ScoreCounter.Instance.Score < 100)
        {
            Finish.instance.loseGame();
        }

    }

    private void clearArr()
    {
        for (int n = 0; n < numberOfMatches.Length; n++)
            numberOfMatches[n] = 0;
    }

    public void startAllSlots()
    {
        checkLose();

        foreach (Slot slot in slotMachine)
            slot.startSlot();

       
        canGetWin = true;
    }
    public void stopAllSlots()
    {
        if (canGetWin)
        { 
            foreach (Slot slot in slotMachine)
                slot.StopAllCoroutines();
        }
    }

    public IEnumerator startGameCor()
    {

        yield break;
    }

}
