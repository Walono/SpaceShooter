using UnityEngine;
using UnityEngine.UI;

public class ShipManagement : MonoBehaviour
{
    private static ShipManagement _instance;
    public static ShipManagement Instance { get { return _instance; } }

    [SerializeField]
    private int _life = 1;

    private bool _isInvulnerable = false;
    private float _invulDuration = 1f;
    private float _invulEndTime;

    [SerializeField]
    private MunitionManagement munitionManager;

    private float _shootCooldown;

    [SerializeField]
    private SwapScene _sceneSwaper;

    [SerializeField]
    private SpriteRenderer _spaceShipRenderer;

    private Color _initialColor;

    private int _swapAlpha = 0;
    private const int _swapFrames = 5;

    [SerializeField]
    private Text _lifeTextUI;

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
        _initialColor = _spaceShipRenderer.color;

        _lifeTextUI.text = "x" + _life.ToString();
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
            _spaceShipRenderer.color = new Color(_initialColor.r, _initialColor.g, _initialColor.b, _initialColor.a);
        }

        if (_isInvulnerable)
        {
            if (_swapAlpha % _swapFrames == 0)
            {
                float alpha = _spaceShipRenderer.color.a > 0 ? 0 : 125;
                _spaceShipRenderer.color = new Color(_initialColor.r, _initialColor.g, _initialColor.b, alpha);
                _swapAlpha = 0;
            }
            _swapAlpha++;
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
        _lifeTextUI.text = "x" + _life.ToString();

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