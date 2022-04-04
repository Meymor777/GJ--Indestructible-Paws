using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTrigeEnemy : MonoBehaviour
{
    public Text textScore;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("CatWarrior"))
        {
            int score = System.Convert.ToInt32(textScore.text) - 1;
            textScore.text = System.Convert.ToString(score);
            if (score == 0)
            {
              //WinGame
            }
            Destroy(collision.gameObject);
        }
    }
}
