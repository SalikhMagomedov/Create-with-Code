using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody _playerRb;
    private Animator _animator;
    private AudioSource _playerAudio;

    private static readonly int JumpTrigger = Animator.StringToHash("Jump_trig");
    private static readonly int DeathBool = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeInt = Animator.StringToHash("DeathType_int");

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !isOnGround || gameOver) return;

        _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        _animator.SetTrigger(JumpTrigger);
        dirtParticle.Stop();
        _playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");

            _animator.SetBool(DeathBool, true);
            _animator.SetInteger(DeathTypeInt, 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}