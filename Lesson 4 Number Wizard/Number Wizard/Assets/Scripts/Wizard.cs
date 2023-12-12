using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wizard : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text textBox; // Text object for displaying messages

    int min = 1;        // Minimum number in the guessing range
    int max = 11;       // Maximum number in the guessing range, set to 11 because Random.Range is exclusive at the upper limit
    int guess;          // Current guess of the AI
    int attempts = 3;   // Number of attempts the AI has to guess correctly

    // Start is called before the first frame update
    void Start()
    {
        // Determine an initial guess
        // Random.Range is inclusive of min but exclusive of max
        guess = Random.Range(min, max);

        // Display the initial guess
        textBox.text = $"My guess is \n\n {guess}";
    }

    // Update is called once per frame
    void Update()
    {
        // Check for player input
        CheckInput();
    }

    void CheckInput()
    {
        // Detect player input to guide the AI's guess
        if (Input.GetKeyDown(KeyCode.H))
        {
            // If the player indicates the number is higher, adjust the minimum bound
            min = guess + 1;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // If the player indicates the number is lower, adjust the maximum bound
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the player indicates the guess is correct, the AI wins
            WinGame();
        }
    }

    void NextGuess()
    {
        // Decrement the number of remaining attempts
        attempts--;

        // Check if the AI has run out of attempts
        if (attempts <= 0)
        {
            // If no more attempts are left, the player wins
            LoseGame();
            return;
        }

        // Make a new guess within the updated range
        guess = Random.Range(min, max);

        // Update the text to show the new guess
        textBox.text = $"My guess is \n\n {guess}";
    }

    void WinGame()
    {
        // Display a win message if the AI guesses correctly
        textBox.text = $"I guessed it!\n\nYour number was {guess}";
    }

    void LoseGame()
    {
        // Display a lose message if the AI runs out of attempts
        textBox.text = $"I ran out of attempts.\n\nYou win!";
    }
}
