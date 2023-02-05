using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static NodeManager;

public class TuberEffect : MonoBehaviour
{
    private Player player;
    [SerializeField]private Node node;

    void Awake(){
        player = GameObject.Find("/Plant").GetComponent<Player>();
        player.storedSap += (1/3) * node.amountResource;
    }

    void LeafLevelUp(){
        player.storedSap += (nodeManager.nodeLevels[node.id] / 3) * node.amountResource;
    }
}
