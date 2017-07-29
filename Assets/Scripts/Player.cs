using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public float yPos;

    private Vector3 target;

    private float _outterRowY = 2.85f;
    private float _secondRowY = 1.44f;
    private float _middleRowY = 0f;

    private float _firstLineY = 3.61f;
    private float _secondLineY = 2.16f;
    private float _thirdLineY = 0.71f;

    // Update is called once per frame
    void Update () {
        #region Player Movement Y
        //Player Movement Y
        if (transform.position.y < _outterRowY && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y + yPos), speed * Time.deltaTime);
        }
        if (transform.position.y > -_outterRowY && Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x, transform.position.y - yPos), speed * Time.deltaTime);
        }

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
    }
}
