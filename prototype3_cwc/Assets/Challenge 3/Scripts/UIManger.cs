using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManger : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;

    public void ActiveGO()
    {
        gameOverText.gameObject.SetActive(true);

    }
}
