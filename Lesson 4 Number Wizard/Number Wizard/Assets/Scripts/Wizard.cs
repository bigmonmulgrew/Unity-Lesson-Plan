using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wizard : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textBox;

    int min = 1;
    int max = 11;   // Random.Range is exclusive so we need 1 higher than our range
    int guess;
    int attempts = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Random.Range is inclusive of min but exclusive of max
        guess = Random.Range(min, max);

        textBox.text = $"My guess is \n\n {guess}";
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            min = guess + 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            WinGame();
        }
    }

    void NextGuess()
    {
        attempts--;
        if (attempts <= 0)
        {
            LoseGame();
            return;
        }

        guess = Random.Range(min, max);

        textBox.text = $"My guess is \n\n {guess}";
    }

    void WinGame()
    {
        textBox.text = $"I guessed it!\n\nYour number was {guess}";
    }

    void LoseGame()
    {
        textBox.text = $"I ran out of attempts.\n\nYou win!";
    }
}
