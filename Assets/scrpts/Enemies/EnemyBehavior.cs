using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    //Variables de movimiento
    public List<Transform> waypoints = new List<Transform>();
    public float movementSpeed;
    public float rotationSpeed;

    public int TargetIndex = 1;
    private Animator animator;
    private bool finalWaypoint;
    public float destroyTime;


    //Variables de vida
    public float maxLife;
    public Image fillImage;

    private float currentLife;
    public bool isDead;
    private Transform canvasRoot;
    private Quaternion lifeRotation;

    public float damage;


    void Awake()
    {
        canvasRoot = fillImage.transform.parent.parent;
        lifeRotation = canvasRoot.rotation;
        //El animator accede al componente para poder manipular los booleanos
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        canvasRoot.transform.rotation = lifeRotation;
        Movement();
        LookAt();

        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(10);
        }
        */
        if (finalWaypoint && !isDead)
        {
            BaseHP.instance.TakeDamage(damage * Time.deltaTime);
        }

    }
 
    #region Movement;
    private void Movement()
    {
        if (isDead)
        {
            animator.SetBool("IsDead", true);
            return;
        }
        //Move towards el waypoint siguiente
        transform.position = Vector3.MoveTowards(transform.position, waypoints[TargetIndex].position, movementSpeed * Time.deltaTime);
        //Variable para calcular la distancia entre el personaje y waypoint
        var distance = Vector3.Distance(transform.position, waypoints[TargetIndex].position);

        //Se cambia de waypoint una vez está cerca del waypoint actual
        if (distance <= 0.1f)
        {
            //Como es una lista que empieza en 0 el último es waypoint -1
            if (TargetIndex >= waypoints.Count - 1)
            {
                Debug.Log("El enemigo llegó al final");
                animator.SetBool("IsAttacking", true);
                finalWaypoint = true;
                return;
            }
            else
            {
                //Si aun no llega al final se va al siguiente punto
                TargetIndex++;
            }
        }
    }

    private void LookAt()
    {
        if (isDead)
        {
            return;
        }
        //Metodo brusco
        //transform.LookAt(waypoints[TargetIndex]);

        //metodo mas suave
        //Cuando llega al último punto ya no necesita rotar
        if (!finalWaypoint)
        {
            var dir = waypoints[TargetIndex].position - transform.position;
            var rootTarget = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
        }
    }
    #endregion

    #region Life
    public void TakeDamage(float damage)
    {
        var newLife = currentLife - damage;
        if (newLife <= 0 && !isDead)
        {
            onDead();
        }
        else
        {
            currentLife = newLife;
            var fillValue = currentLife * 1 / maxLife;
            fillImage.fillAmount = fillValue;
        }

    }

    public void onDead()
    {
        isDead = true;
        animator.SetBool("IsDead", true);
        currentLife = 0;
        fillImage.fillAmount = 0;
        Destroy(gameObject, destroyTime);
        GameManager.instance.IsLevelCleared();
    }

    public void test()
    {
        Debug.Log("test");
    }

    #endregion
}
