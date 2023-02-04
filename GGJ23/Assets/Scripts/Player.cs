using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Player : MonoBehaviour
{
    private int health = 100;
    // Esses não vão ser serializados
    private int totalLeafs;
    private int totalSpikes; 

    public int sap;
    // Esses não vão ser serializados
    [SerializeField] private int sun = 0;
    [SerializeField] private int water = 0;
    [SerializeField] private int minerals = 0;

    [SerializeField] private Canvas resourcesUI;

    private void Start() {
        sap = 10; // alterar se necessário
    }

    public void ChangeValues(){
        resourcesUI.transform.Find("Sap total").GetComponent<TextMeshProUGUI>().text = sap.ToString();
        resourcesUI.transform.Find("Health total").GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    void Update(){
        // Tirar essas coisas do update quando der
        sap += sun*water*minerals + sun*water + sun*minerals + water*minerals + sun + water + minerals;
    }
}
