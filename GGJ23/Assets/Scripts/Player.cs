using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int health;
    public int absorption;
    public int attack;
    public int totalSpikes; 
    public int totalLeafs;

    public int sap;
    public int storedSap;

    [SerializeField] private Canvas resourcesUI;

    private void Start() {
        health = 20;
        absorption = 0;
        sap = 10; // change if needed
    }

    public void ChangeValues(){
        resourcesUI.transform.Find("Sap total").GetComponent<TextMeshProUGUI>().text = sap.ToString();
        resourcesUI.transform.Find("Health total").GetComponent<TextMeshProUGUI>().text = health.ToString();
    }
}
