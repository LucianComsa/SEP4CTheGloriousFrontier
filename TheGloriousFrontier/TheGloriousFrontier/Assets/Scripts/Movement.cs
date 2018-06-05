using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    float rotationalSpeed;

    [SerializeField]
    float moveSpeed;

    private float vertical;
    private float horizontal;
    private bool jump;
    private Animator anim;
    private Rigidbody rb;
    private bool grounded;
    public bool shouldAnimate;

    private void Awake() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        shouldAnimate = true;
        vertical = 1;
        horizontal = 0;
    }

    void Update() {
        // vertical = Input.GetAxis("Vertical");
        // horizontal = Input.GetAxis("Horizontal");
        // jump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate() {
        anim.SetFloat("Speed", shouldAnimate ? 1 : 0);

        if (!shouldAnimate) return;

        if (jump && !anim.GetCurrentAnimatorStateInfo(0).IsName("BaseLayer.Jump")) {
            anim.SetTrigger("Jump");
        }

        rb.MovePosition(transform.position + transform.forward * vertical * moveSpeed * 0.01f);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, 1 * rotationalSpeed, 0f)));
    }
}
