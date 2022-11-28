using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Animator animator;

    public void Highlight()
    {
        animator.SetTrigger("highlight");
    }

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }
}
