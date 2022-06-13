using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonClass : MonoBehaviour
{
    //[SerializeField] private HarpoonGunClass _harpoonGun;
    [SerializeField]
    public float _speed = 10;
    [SerializeField]
    public Rigidbody2D _rigidbody2D;
    [SerializeField]
    public GameObject _harpoonGun;
    public GameObject Launcher;
    private bool _shooting = false;
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
        if ((transform.position - Launcher.transform.position).magnitude > 20)
            _returning = true;

        if (_returning)
        {
            Vector2 toTarget = (Launcher.transform.position - transform.position);
            _rigidbody2D.AddForce(toTarget.normalized * _speed * 2, ForceMode2D.Force);
        }
        else
        {
            if (_shootingRight)
            {
                _rigidbody2D.AddForce(new Vector2(_speed, 0));
            }
            if (_shootingLeft)
            {
                _rigidbody2D.AddForce(new Vector2(-_speed, 0));
            }
            if (_shootingUp)
            {
                _rigidbody2D.AddForce(new Vector2(0, _speed));
            }
            if (_shootingDown)
            {
                _rigidbody2D.AddForce(new Vector2(0, -_speed));
            }
        }
    }

    public void StopHarpoon()
    {
        _rigidbody2D.Sleep();
        _shooting = false;
        _shootingRight = false;
        _shootingUp = false;
        _shootingLeft = false;
        _shootingDown = false;
    }

    public void IsShootingRight()
    {
        if (!_shooting)
        {
            _shootingRight = true;
            _rigidbody2D.AddForce(new Vector2(_speed, 0), ForceMode2D.Impulse);
            _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 0);
            _shooting = true;
        }
    }

    public void IsShootingLeft()
    {
        if (!_shooting)
        {
            _shootingLeft = true;
            _rigidbody2D.AddForce(new Vector2(-_speed, 0), ForceMode2D.Impulse);
            _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 180);
            _shooting = true;
        }
    }

    public void IsShootingDown()
    {
        if (!_shooting)
        {
            _shootingDown = true;
            _rigidbody2D.AddForce(new Vector2(0, -_speed), ForceMode2D.Impulse);
            _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, -90);
            _shooting = true;
        }
    }

    public void IsShootingUp()
    {
        if (!_shooting)
        {
            _shootingUp = true;
            _rigidbody2D.AddForce(new Vector2(0, _speed), ForceMode2D.Impulse);
            _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 90);
            _shooting = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        _shootingRight = false;
        _shootingLeft = false;
        _shootingDown = false;
        _shootingUp = false;
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
