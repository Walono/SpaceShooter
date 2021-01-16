using UnityEngine;

public class ShipManagement : MonoBehaviour
{
    private static ShipManagement _instance;
    public static ShipManagement Instance { get { return _instance; } }

    [SerializeField]
    private int _life = 1;

    private bool _isInvulnerable = false;

    [SerializeField]
    private MunitionManagement munitionManager;

    private float shootCooldown;

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
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            munitionManager.Fire();
        }
    }

    public void HitSpaceShip()
    {
        if (_isInvulnerable)
        {
            return;
        }

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