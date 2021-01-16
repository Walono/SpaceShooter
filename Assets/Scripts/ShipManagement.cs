using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    private static ShipManagement _instance;
    public static ShipManagement Instance { get { return _instance; } }

    [SerializeField]
    private int _life = 1;

    private bool _isInvulnerable = false;
    private float _invulDuration = 2f;
    private float _invulEndTime;

    [SerializeField]
    private MunitionManagement munitionManager;

    private float _shootCooldown;

    [SerializeField]
    private SwapScene _sceneSwaper;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        if (_isInvulnerable)
        {
        }
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            munitionManager.Fire();
        }

        if (_isInvulnerable && Time.time > _invulEndTime)
        {
            _isInvulnerable = false;
        }
    }

    public void HitSpaceShip()
    {
        if (_isInvulnerable)
        {
            return;
        }
        _isInvulnerable = true;
        _invulEndTime = Time.time + _invulDuration;
        _life--;

        if (_life == 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
        _sceneSwaper.SwapToScene("GameOver");
    }
}