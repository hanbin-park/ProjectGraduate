using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Move : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float fireball_Rate;

    public GameObject Fireball_Hit;  // hit prefab�� ���� ���� ������Ʈ ����

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }


    //�浹�� �Ѿ˵� �ƴϰ� �÷��̾ �ƴ� ���. �̰��� �� ���� �浹�ϴ��� Ȯ���ϴ� ���̹Ƿ� ���� �ο� ����
    private bool collided;

    private void OnCollisionEnter(Collision co)
    {
        //speed = 0;

        //Destroy(gameObject);

        

        // ���� gameobject.tag�� Bullet�� �ƴϰ� Player�� �ƴ� ��� (�⺻������ �÷��̾� �� �ٸ� �߻�ü�� �浹�ϴ� ���� ������ ����)
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;         // �ϴ� �浹�ϸ� true

            // co.contacts[0].point�� �浹 ��ġ���� �ν��Ͻ�ȭ. 0�� �ε���?�� ù ��° �浹��. Quaternion.identity = prefab ȸ��   /  as GameObject : ���� ������Ʈ���� Ȯ��
            var impact = Instantiate(Fireball_Hit, co.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(impact, 2);

            Destroy(gameObject);
        }

    }


    // OnCollisionenter �Լ� �̿�
    //private void OnCollisionEnter(Collision co)
    //{
    //   speed = 0;

        /*
         ContactPoint contact = co.contacts[0];
         Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
         Vector3 pos = contact.point;

         if (hitPrefab != null)
         {
             var hitVFX = Instantiate(hitPrefab, pos, rot);

             var psHit = hitVFX.GetComponent<ParticleSystem>();
             if (psHit != hitVFX)
                 Destroy(hitVFX, psHit.main.duration);
             else
             {
                 var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                 Destroy(hitVFX, psChild.main.duration);
             }

         }

         */

     //   Destroy(gameObject);

    //}

    /*
    // OnTriggerEnter �Լ� �̿�
    // ���̾�� �Ѿ˿� ������ destroy
    private void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.tag == "vfx_Projectile_Tutorial �±� �̸�")
        {
            speed = 0;

            Destroy(this.gameObject);

        }
    }
     */
}
