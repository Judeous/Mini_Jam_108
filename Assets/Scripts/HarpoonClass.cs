using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonClass : MonoBehaviour
{
    private InputHandler _input;
    [SerializeField]
    public float _speed = 5;
    [SerializeField]
    public Rigidbody2D _rigidbody2D;
    private bool _shootingDown = false;
    private bool _shootingLeft = false;
    private bool _shootingUp = false;
    private bool _shootingRight = false;
    private bool _returning = false;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_shootingRight)
        {
            _rigidbody2D.AddForce(new Vector2(_speed, 0));
        }
        else if (_returning)
        {
            _rigidbody2D.AddForce(new Vector2(-_speed, 0));
        }

        if (_shootingLeft)
        {
            _rigidbody2D.AddForce(new Vector2(-_speed, 0));
        }
        else if (_returning)
        {
            _rigidbody2D.AddForce(new Vector2(_speed, 0));
        }

        if (_shootingUp)
        {
            _rigidbody2D.AddForce(new Vector2(0, _speed));
        }
        else if (_returning)
        {
            _rigidbody2D.AddForce(new Vector2(0, -_speed));
        }

        if (_shootingDown)
        {
            _rigidbody2D.AddForce(new Vector2(0, -_speed));
        }
        else if (_returning)
        {
            _rigidbody2D.AddForce(new Vector2(0, _speed));
        }
    }

    public void StopHarpoon()
    {
        _rigidbody2D.Sleep();
        _shootingRight = false;
        _shootingUp = false;
        _shootingLeft = false;
        _shootingDown = false;
    }

    public void IsShootingRight()
    {
        _shootingRight = true;
    }

    public void IsShootingLeft()
    {
        _shootingLeft = true;
    }

    public void IsShootingDown()
    {
        _shootingDown = true;
    }

    public void IsShootingUp()
    {
        _shootingUp = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        _shootingRight = false;
        if (other.gameObject.CompareTag("HarpoonGun"))
        {
            _returning = false;
            StopHarpoon();
            return;
        }
        _returning = true;


        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }


}
