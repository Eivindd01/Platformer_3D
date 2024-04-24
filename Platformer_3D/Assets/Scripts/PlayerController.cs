using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    [SerializeField]
    public float moveSpeed = 10;

    [SerializeField]
    public float strafSpeed = 5;

    [SerializeField]
    Camera cam;

    [SerializeField]
    Animator animator;

    [SerializeField]
    private AudioClip audioJump = null;

    Vector3 inputDir;

    float currentVelocity;
    float smoothTime = 0.05f;

    private AudioSource player_AudioSource;

    bool _jump;

    private void Awake()
    {
        player_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir.Normalize(); //Normalize reset à 1
        if (Input.GetButtonDown("Jump") && isGrounded()) _jump = true;

    }

    void FixedUpdate()
    {
        Move();
        UpdateAnimation(inputDir);
        Debug.Log(isGrounded());

        if (_jump && isGrounded()) Jump();

    }

    bool isGrounded()
    {
        //Debug.Log(rb.velocity);
        if (transform.parent == null)
        {
            return Mathf.Abs(rb.velocity.y) < 0.25f; //Si au dessus de la valeur f alors considéré en Jump
        }
        else
        {
            float yvelocity = Mathf.Abs(rb.velocity.y - transform.parent.GetComponent<Rigidbody>().velocity.y);
            return Mathf.Abs(yvelocity) < 0.25f;
        }
        //return Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.2f); //Pareil que Mathf mais en raycast
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
        StartCoroutine(JumpCorout());
        player_AudioSource.PlayOneShot(audioJump);
    }

    IEnumerator JumpCorout()
    {
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.01f);

        while (!isGrounded())
        {
            yield return null;
        }

        animator.SetBool("Jump", false);
        _jump = false;
    }

    void Move()
    {
        Vector3 forwardDir = transform.forward * inputDir.z;
        forwardDir.Normalize();
        forwardDir *= moveSpeed;

        Vector3 strafDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafDir.Normalize();
        strafDir *= strafSpeed;

        Vector3 finalDir = forwardDir + strafDir;

        rb.MovePosition(rb.position + (finalDir * Time.deltaTime));

        float targetRotation = cam.transform.eulerAngles.y;
        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref currentVelocity, smoothTime);

        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);
    }

    private void UpdateAnimation(Vector3 dir)
    {
        animator.SetFloat("Forward", dir.z);
        animator.SetFloat("Straf", dir.x);
    }

}
