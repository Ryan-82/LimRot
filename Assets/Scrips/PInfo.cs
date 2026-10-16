using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Tachy/PlayerInfo")]
public class PInfo: ScriptableObject
{

    //y axis
    [SerializeField] public float jumpForce = 13;
    
    [SerializeField] public float YAccel = -30;

    [SerializeField] public float maxYVel = -20;

    //x axis
    [SerializeField] public float moveAccelT = 0.2f;
    [SerializeField] public float maxMoveVel = 10;

    //drag
    [SerializeField] public float GroundDragT = 0.3f;
    [SerializeField] public float AirDragT = 1.3f;
}