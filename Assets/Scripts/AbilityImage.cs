using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityImage : MonoBehaviour
{
    private PlayerController player;
    public Image abilityImg;

    [Space(10)]
    public Sprite jumpImg;
    public Sprite slingImg;
    public Sprite flapImg;
    public Sprite jetPackImg;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        UpdateAbilityImg();
    }

    public void UpdateAbilityImg() {
        switch(player.GetMovementTypeString()) {
            case "Jump":
                abilityImg.sprite = jumpImg;
                break;
            case "Sling":
                abilityImg.sprite = slingImg;
                break;
            case "Flap":
                abilityImg.sprite = flapImg;
                break;
            case "JetPack":
                abilityImg.sprite = jetPackImg;
                break;
            default:
                Debug.Log("Unknown ability text. Can't render ability image");
                break;
        }
    }
}
