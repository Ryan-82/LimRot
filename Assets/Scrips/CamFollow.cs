using UnityEngine;
using UnityEngine.UIElements;

public class CamFollow : MonoBehaviour
{
    Vector3 PositionFromPlayer;
    [SerializeField] float converganceRate = 1f;
    void Start()
    {
        PositionFromPlayer = transform.position - GlobalUtils.player.position; 
    }

    void Update()
    {
        Vector3 target = PositionFromPlayer + GlobalUtils.player.position;

        Vector3 delta = target - transform.position;

        Vector3 normal = delta.normalized;

        float mag = delta.magnitude;

        if (mag < Time.deltaTime * converganceRate) {
            transform.position = target;
            return;
        }

        transform.position += converganceRate * mag * mag * Time.deltaTime * normal;
    }
}
