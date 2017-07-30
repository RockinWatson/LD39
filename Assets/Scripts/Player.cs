using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat health;

    private bool _keyUp() { return (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)); }
    private bool _keyDown() { return (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)); }
    private bool _keyShoot() { return Input.GetKeyDown(KeyCode.Space); }

    public GameObject bullet;

    public float speed;
    public float yPos;
    public float shootTimer;

    private Vector3 target;

    private float _outterRowY = 2.85f;
    private float _secondRowY = 1.44f;
    private float _middleRowY = 0f;

    private float _firstLineY = 3.61f;
    private float _secondLineY = 2.16f;
    private float _thirdLineY = 0.71f;

    private float _waitForNext = 0;

    private GlobalTimer gTimer;

    private void Awake()
    {
        health.MaxValue = 100;
        health.Initialize();    
    }

    // Update is called once per frame
    void Update () {
        #region Player Movement Y
        UpdatePlayerMovement();

        #region Player Realign to Row
        //realign Top row
        if (transform.position.y < _firstLineY && transform.position.y > _secondLineY)
        {
            transform.position = new Vector3(transform.position.x, _outterRowY);
        }
        //realign Second top Row
        if (transform.position.y < _secondLineY && transform.position.y > _thirdLineY)
        {           
            transform.position = new Vector3(transform.position.x, _secondRowY);
        }
        //realign Middle Row
        if (transform.position.y < _thirdLineY && transform.position.y > -_thirdLineY)
        {
            transform.position = new Vector3(transform.position.x, _middleRowY);
        }
        //realign Second bottom Row
        if (transform.position.y > -_secondLineY && transform.position.y < -_thirdLineY)
        {
            transform.position = new Vector3(transform.position.x, -_secondRowY);
        }
        //realign Bottom row
        if (transform.position.y > -_firstLineY && transform.position.y < -_secondLineY)
        {
            transform.position = new Vector3(transform.position.x, -_outterRowY);
        }
        #endregion
        #endregion

        //Bullet
        _waitForNext -= Time.deltaTime;
        if (_keyShoot() && _waitForNext <= 0)
        {
            health.CurrentVal -= 10;
            var pos = new Vector2(transform.position.x + 1f, transform.position.y - 0.1f);
            Instantiate(bullet, pos, transform.rotation);
            _waitForNext = shootTimer;
        }
    }

    private void UpdatePlayerMovement()
    {
        //Player Movement Y
        if (transform.position.y < _outterRowY && _keyUp())
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + yPos), speed * Time.deltaTime);
        }
        if (transform.position.y > -_outterRowY && _keyDown())
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y - yPos), speed * Time.deltaTime);
        }
    }
}
