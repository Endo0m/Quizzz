
using TMPro;
using UnityEngine;

public class TaskDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text taskText;

    public void SetTask(string text)
    {
        taskText.text = text;
    }
}