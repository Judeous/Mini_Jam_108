using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonClass : MonoBehaviour
{
    [SerializeField]
    public float _speed = 5;
    [SerializeField]
    public Rigidbody2D _rigidbody2D;
    private bool _shooting = false;
    private bool _returning = false;



    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_shooting)
        {
            //_Harpoon.transform.Translate(0, 0, Time.deltaTime * _speed);
            Shoot();
        }
        else if(_returning)
        {
            ReturnHarpoon();
        }
    }

    public void StopHarpoon()
    {
        _rigidbody2D.Sleep();
        _shooting = false;
    }

    public void ReturnHarpoon()
    {
        _rigidbody2D.AddForce(new Vector2(-_speed, 0));
    }

    public void Shoot()
    {


        _rigidbody2D.AddForce(force, ForceMode2D.Impulse);


    }

    public void IsShooting()
    {
        _shooting = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        _shooting = false;
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
