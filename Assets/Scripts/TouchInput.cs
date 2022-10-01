using UnityEngine;
public class TouchInput : MonoBehaviour
{
    /*
    private float timeTouchBegan;
    private bool touchDidMove;
    private float tapTimeThreshold = 0.2f;
    public MoveFigurs move;

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            var touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                timeTouchBegan = Time.time;
                touchDidMove = false;

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), -Vector2.up, 100);
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Figure"))
                    {
                        move = hit.collider.GetComponent<MoveFigurs>();
                        move.MouseDown();
                    }
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                touchDidMove = true;
                if (move != null)
                {
                    move.MouseDrag();
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (move != null)
                {
                    float tapTime = Time.time - timeTouchBegan;
                    if (tapTime <= tapTimeThreshold && touchDidMove == false)
                    {
                        move.RotateOnTap();
                    }
                    else
                    {
                        move.MouseUp();
                    }
                    move = null;
                }
            }
        }
    }
    */
}
