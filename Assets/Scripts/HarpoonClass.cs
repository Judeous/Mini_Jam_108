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
    private bool _shootingDown = false;
    private bool _shootingLeft = false;
    private bool _shootingUp = false;
    [SerializeField]
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
                _rigidbody2D.AddForce(new Vector2(1, 0));
            }
            if (_shootingLeft)
            {
                _rigidbody2D.AddForce(new Vector2(-1, 0));
            }
            if (_shootingUp)
            {
                _rigidbody2D.AddForce(new Vector2(0, 1));
            }
            if (_shootingDown)
            {
                _rigidbody2D.AddForce(new Vector2(0, -1));
            }
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
        _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void IsShootingLeft()
    {
        _shootingLeft = true;
        _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 180);
    }

    public void IsShootingDown()
    {
        _shootingDown = true;
        _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, -90);
    }

    public void IsShootingUp()
    {
        _shootingUp = true;
        _harpoonGun.transform.localRotation = Quaternion.Euler(0, 0, 90);
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
