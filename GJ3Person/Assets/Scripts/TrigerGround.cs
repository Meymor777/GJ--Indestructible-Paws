using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrigerGround : MonoBehaviour
{
    public Text textScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int score = System.Convert.ToInt32(textScore.text) - 1;
        textScore.text = System.Convert.ToString(score);
        if (score == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

}
