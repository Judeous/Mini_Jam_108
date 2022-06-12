using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovementBehavior : MonoBehaviour
{
    [SerializeField] public GameObject Target;

    private Rigidbody2D _rigidbody;

    private float _speed;


    private bool _strafing;
    private float _timeStrafing;
    private float _strafeTimeDuration;
    private bool _strafingRight;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        //Get a random speed
        _speed = Random.Range(0.2f, .9f);

        //Get an initial strafe duration and direction
        _strafing = Random.Range(0f, 1f) > .5f;
        _strafeTimeDuration = Random.Range(1f, 3f);
        _timeStrafing = _strafeTimeDuration;
        _strafingRight = Random.Range(0f, 1f) > .5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate the direction to the target
        Vector2 toTarget = (Target.transform.position - transform.position).normalized;
        Vector2 direction = new Vector2();

        //If the crab is strafing
        if (_strafing)
        {
            //Decrement strafing time
            _timeStrafing -= Time.deltaTime;
            //If the strafe time ran out
            if (_timeStrafing <= 0)
            {
                //Stop strafing, and reset the duration
                _strafing = false;
                _strafeTimeDuration = Random.Range(1f, 3f);
                _timeStrafing = _strafeTimeDuration;
            }
            //If there is still strafe time left
            else
            {
                //If strafing right, move right relative to the target. If not, move left relative to the target
                Vector2 perp = _strafingRight ? new Vector2(toTarget.y, -1 * toTarget.x) : new Vector2(-1 * toTarget.y, toTarget.x);
                direction = perp;
            }
        }
        else
        {
            //Decrement strafing time
            _timeStrafing -= Time.deltaTime;
            //If the strafe time ran out
            if (_timeStrafing <= 0)
            {
                //Start strafing and choose a direction to strafe
                _strafing = true;
                _strafingRight = !_strafingRight;
                //Reset the Strafe duration
                _strafeTimeDuration = Random.Range(0.5f, 2.3f);
                _timeStrafing = _strafeTimeDuration;
            }
            direction = toTarget;
        }
        //Apply the vector to the velocity
        //_rigidbody.velocity = direction * _speed;
        _rigidbody.AddForce(direction * _speed, ForceMode2D.Force);
    }
}
