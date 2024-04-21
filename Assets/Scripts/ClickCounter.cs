using UnityEngine;
using TMPro;

public class ClickCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int counter = 0;

    void Start()
    {
        // Set initial value of counter text
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        // Update the UI text with the current counter value
        counterText.text = counter.ToString();
    }

    public void IncrementCounter()
    {
        // Increase counter by 1 and update UI text
        counter++;
        UpdateCounterText();
    }
}
