using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class DrainEffect : MonoBehaviour
{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();
        node.amountResource += 2;
    }

    void DrainLevelUp(){
        node.amountResource += 2 * nodeManager.nodeLevels[node.id];
    }
}
