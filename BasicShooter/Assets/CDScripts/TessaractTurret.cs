using UnityEngine;
using System.Collections;

public class TessaractTurret : MonoBehaviour {

    public Vector3 RotateAmount;
    private LineRenderer line;
    bool LineEnabled = true;
    ParticleSystem endEffect = null;
    Transform endEffectTransform;
    Vector3[] position;
    int maxLength = 25;
    int length;

    

    public int damagePerHit = 1;

	// Use this for initialization
	void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = true;

      /*  endEffect = GetComponentInChildren<ParticleSystem>();
        if (endEffect)
        {
            endEffectTransform = endEffect.transform;
        }*/


	}
	
	// Update is called once per frame
	void Update () {
    //    transform.Rotate(RotateAmount * Time.deltaTime);
    }

    void FixedUpdate()
    {
        FireRay();
    
        transform.Rotate(RotateAmount * Time.deltaTime * Random.value);
        
    }

    void FireRay()
    {
       RaycastHit[] hit;
        hit = Physics.RaycastAll(transform.position, transform.forward, maxLength);
       
        int i = 0;
        while (i < hit.Length)
        {
            //Check to make sure we aren't hitting triggers but colliders
            if (!hit[i].collider.isTrigger)
            {
                
                if (hit[i].collider.tag == "Player")
                {
                    doDamage();
                }
                else
                {
                    length = (int)Mathf.Round(hit[i].distance) + 2;
                    position = new Vector3[length];
                    //Move our End Effect particle system to the hit point and start playing it
                    if (endEffect)
                    {
                        endEffectTransform.position = hit[i].point;
                        if (!endEffect.isPlaying)
                            endEffect.Play();
                    }
                    line.SetVertexCount(length);

                }

                //return;
            }
            i++;

        }

        if (endEffect)
        {
            if (endEffect.isPlaying)
                endEffect.Stop();
        }
        

        Ray ray = new Ray(transform.position, transform.forward);

        if (LineEnabled)
        {
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, ray.GetPoint(maxLength));

         
          
        }

       /* length = (int)maxLength;
        position = new Vector3[length];
        line.SetVertexCount(length);
        */



    }

    private void doDamage()
    {
        HealthController h = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<HealthController>();

        if (h!= null)
        {
            h.doDamage(damagePerHit);
        }

    }
}
