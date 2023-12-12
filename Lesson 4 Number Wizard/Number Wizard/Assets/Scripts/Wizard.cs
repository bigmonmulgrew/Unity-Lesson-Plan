using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wizard : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text textBox;

    int min = 1;
    int max = 10;
    int guess;
    int attempts = 3;

    // Start is called before the first frame update
    void Start()
    {
        guess = Random.Range(min, max + 1);

        textBox.text = $"My guess is \n\n {guess}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
