using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using static NodeManager;
public enum states{PREP, WAVE, WIN, LOSS}

public class GameManager : MonoBehaviour
{
    public states currentState;

    void Start(){
        currentState = states.PREP;
        PreparationPhase();
    }

    // preparation phase function goes to wave phase
    public void PreparationPhase(){
        foreach(var Node in nodeManager.nodeList){
            if(nodeManager.isReachable[Node.id])
                Node.gameObject.GetComponent<Button>().enabled = true;
        }

        nodeManager.updateResources();
    }

    public void CallWaves(){
        StartCoroutine(WavePhase());
    }

    // wave phase check win condition and goes back to prep phase
    // Coroutine?
    IEnumerator WavePhase(){
        currentState = states.WAVE;
        foreach(var Node in nodeManager.nodeList){
            if(nodeManager.isReachable[Node.id])
                Node.gameObject.GetComponent<Button>().enabled = false;
        }
        
        // Enemy waves code goes here
        Debug.Log("Here come the boys");
        yield return new WaitForSeconds(10f);
        Debug.Log(("The boys are dead"));
        //

        if(nodeManager.player.health == 0) currentState = states.LOSS;
        else if(nodeManager.nodeList.Count == 10) currentState = states.WIN;

        currentState = states.PREP;
        PreparationPhase();
    }
}
