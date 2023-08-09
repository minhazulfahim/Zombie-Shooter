using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        GetComponent<Animation>().Play("Z_Walk_InPlace");
    }

    // Update is called once per frame
    void Update()
    {
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
      

    }

    // zombie_dead script
    public void Zombie_dead()
    {
        agent.isStopped = true;
        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("Z_FallingBack");
        Destroy(gameObject, 3);
        GameObject zombie = Instantiate(Resources.Load("Zombie", typeof(GameObject))) as GameObject;
        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        while (Vector3.Distance(zombie.transform.position,
        Camera.main.transform.position) <= 10)
        {
            randomX = UnityEngine.Random.Range(-64f, 64f);
            randomZ = UnityEngine.Random.Range(30f, 120f);
            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }
    }
        // Call the gun animation
        public void Call_Gun()
        {
            StartCoroutine(GunAnimationCoroutine());
        }
        private IEnumerator GunAnimationCoroutine()
        {
            // Play gun animation
            GetComponent<Animation>().Play("New Gun Animation");
            // Wait for the gun animation to finish

            yield return new

            WaitForSeconds(GetComponent<Animation>()["New Gun Animation"].length);

            // Resume zombie animation
            GetComponent<Animation>().Play("Z_Walk_InPlace");
        }
    

}
