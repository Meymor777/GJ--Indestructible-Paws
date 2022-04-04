using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnTrigerBomb : MonoBehaviour
{
    private int every5shoot = 0;
    public Text textScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Flour")
        {
            OnDestroy();
        }
        else if(collision.gameObject.name.Contains("PVOShoot"))
        {
            int score = System.Convert.ToInt32(textScore.text);
            if (score < 5)
            {
                every5shoot++;
                if (every5shoot == 5)
                {
                    textScore.text = System.Convert.ToString(score + 1);
                    every5shoot = 0;
                }
            }


            OnDestroy();
        }
        else  if (collision.gameObject.name != "EnemyHitBox")
        {
            OnDestroy();
        }

    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
