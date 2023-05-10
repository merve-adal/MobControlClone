using UnityEngine;

public class GateMovement : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform gateRightLimit;
    [SerializeField] private Transform gateLeftLimit;
    private float gateRightLimitX => gateRightLimit.localPosition.x;
    private float gateLeftLimitX => gateLeftLimit.localPosition.x;

    private Vector3 startPoint;
    private bool isLeft;


    private void Awake()
    {
        startPoint = sideMovementRoot.position;
        if (Random.value < 0.5f)
        {
            isLeft = true;
        }
    }

    private void Update()
    {
        SideMovement();
    }

    private void SideMovement()
    {
        if (isLeft)
        {
            var time = Time.time;
            var pingPong = Mathf.PingPong(time, 1f);
            var minMax = Mathf.Lerp(gateLeftLimitX, gateRightLimitX, Mathf.SmoothStep(0.0f, 1f, pingPong));
            var gateMove = minMax * Vector3.left;
            sideMovementRoot.position = startPoint + gateMove;
        }
        else
        {
            var time = Time.time;
            var pingPong = Mathf.PingPong(time, 1f);
            var minMax = Mathf.Lerp(gateLeftLimitX, gateRightLimitX, Mathf.SmoothStep(0.0f, 1f, pingPong));
            var gateMove = minMax * Vector3.right;
            sideMovementRoot.position = startPoint + gateMove;
        }
    }
}