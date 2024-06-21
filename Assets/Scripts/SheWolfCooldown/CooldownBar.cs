using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Image totalCooldownBar;
    [SerializeField] private Image currentCooldownBar;
    [SerializeField] private TransformacionShakira transformacionShakira;

    private void Start()
    {
        totalCooldownBar.fillAmount = 1; // La barra de cooldown total siempre está llena
    }

    private void Update()
    {
        if (transformacionShakira != null)
        {
            currentCooldownBar.fillAmount = transformacionShakira.GetCooldownNormalized();
        }
    }
}
