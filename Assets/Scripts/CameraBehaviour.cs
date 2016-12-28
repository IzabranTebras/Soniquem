using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    private PlayerController player = null;
    private Rigidbody playerRigid = null;
    private Vector2 origin = Vector2.zero;
    private float time = 0.2f;
    private bool up = true;

    void Awake()
    {
        player = transform.root.GetComponent<PlayerController>();
        playerRigid = transform.root.GetComponent<Rigidbody>();
        origin = transform.localPosition;
    }

	void Update ()
    {
	    if(player.inGround && !player.stop && !player.falling)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                time = 0.2f;
                up = !up;
            }

            if (up)
            {
                float y = Mathf.Lerp(transform.localPosition.y, origin.y + 0.1f, 0.005f);
                transform.localPosition = new Vector2(transform.localPosition.x, y);
            }
            else
            {
                float y = Mathf.Lerp(transform.localPosition.y, origin.y - 0.1f, 0.005f);
                transform.localPosition = new Vector2(transform.localPosition.x, y);
            }
        }
        else
        {
            up = true;
            time = 0.2f;
            float y = Mathf.Lerp(transform.localPosition.y, origin.y, 0.1f);
            transform.localPosition = new Vector2(origin.x, y);
        }
	}
}
