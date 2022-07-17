using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityIndicator : MonoBehaviour
{
    private PlayerController player;
    public TextMeshProUGUI  abilityText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        UpdateAbilityText();
    }

    public void UpdateAbilityText() {
        abilityText.SetText(player.GetMovementTypeString());
    }
}
