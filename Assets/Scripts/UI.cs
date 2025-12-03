using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public void StartGame()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
}
