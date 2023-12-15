using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] float deathLimit = -10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deathLimit) Die();
    }

    public void Die()
    {
        GameObject.FindObjectOfType<LevelLoader>().LoadGameOverScene();
    }
}
