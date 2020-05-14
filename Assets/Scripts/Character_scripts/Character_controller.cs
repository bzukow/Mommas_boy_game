using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.IO;

public class Character_controller : MonoBehaviour
{
    public Transform target;
    public Vector3 checkpoint;
    public Animator anim;
    public Animation entry;
    public bool stunned;
    public bool umarles;
    public bool canAttack;
    public bool facingLeft;
    public bool escaped;
    public float speed = 7f;
    public float hori;
    public float touchedCount = 0f;
    public bool immortal;
    private bool eaten;

    public float coins;
    public float lives;

    public float shrimps;
    public float chilli;
    public float chicken;
    public float onions;
    public float mushrooms;
    public float limes;
    public float coconut_milk;
    public float toilet_paper;

    public float[] listOfThings;

    public float tri_poloski_sweatshirt;
    public float tri_poloski_trousers;
    public float tri_poloski_shoes;

    public GameObject throwing_machine;
    public Cigarette_attack cigarette;
    public float cigarettes;
    public float cigarette_speed = 10f;

    public float DelayBeforeReset = 1f;
    private float lastKeyPressedTime;
    private KeyCode previousKey = KeyCode.RightArrow;
    private float comboCounter = 0;

    public bool started;
    public bool lift1;
    public Transform targetToLift1;
    public bool lift2;
    public Transform targetToLift2;
    public bool lift3;
    public Transform targetToLift3;
    public bool started1;

    public float throwingTime;
    public bool rightAltDown;
    public List<GameObject> displayedLives;

    public bool canCollect;
    public NumbersSheet numbers;

    public GameObject throwing_cigarette_line;
    // Start is called beforse the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        

        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
            GameObject.FindGameObjectWithTag("Saver").GetComponent<Save_Load_Controller>().LoadGame();

        }
        else
        {
            shrimps = 10;
            chilli = 3;
            chicken = 2;
            onions = 2;
            mushrooms = 4;
            limes = 1;
            coconut_milk = 2;
            toilet_paper = 3;

            tri_poloski_sweatshirt = 1;
            tri_poloski_trousers = 1;
            tri_poloski_shoes = 1;

           
            transform.localPosition = new Vector3(0, 0, 14);
            transform.localRotation = new Quaternion(0, 180, 0, 1);

            stunned = true;
            canAttack = false;
            started = true;
            anim.SetBool("enter_the_lift", true);
            started1 = true;

            coins = 0f;
            lives = 5f;
            cigarettes = 10f;
            numbers.WaitforActualisation(shrimps, chilli, chicken, onions, mushrooms, limes, coconut_milk, toilet_paper);
        }

        displayedLives = GameObject.FindGameObjectWithTag("Lives").GetComponent<Life_display>().lives;
        LivesUpdatedAfterLoading();
        eaten = false;
        escaped = true;
        facingLeft = false;
       
        throwing_machine = GameObject.FindGameObjectWithTag("Throwing_machine");
        throwingTime = 1;

        canCollect = true;
        cigaretteAmount.text = "x " + cigarettes.ToString();
        coinAmount.text = "x " + coins.ToString();
    }
    void LivesUpdatedAfterLoading()
    {
        for(int i = displayedLives.Count; i > 0; i--)
        {
            if(i > lives)
            {

                Destroy(displayedLives[i-1].gameObject);
                displayedLives.RemoveAt(i - 1);
            }
        }
    }
    public bool isThrowing;
    public KeyCode lastClickedKey;
    // Update is called once per frame
    public bool lift1tolift2;
    void FixedUpdate()
    {
        bubbleText.transform.parent.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z - 4);
    }
    void Update()
    {
        if (started)
        {
            
            stunned = true;
            canAttack = false;
            
            if (lift1)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetToLift1.position.z), step);

                if (transform.position.z == targetToLift1.position.z)
                {
                    anim.SetBool("enter_the_lift", false);
                    transform.localRotation = new Quaternion(0, 180, 0, 1);
                    Invoke("ChangeLift1", 2f);
                    Invoke("StartEnteringTheLift", 2f);
                    lift1 = false;
                }
            }
            else if (lift2)
            {
                /*float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetToLift2.position.z - 5f), step);

                if (transform.position == new Vector3(transform.position.x, transform.position.y, -3.54f))
                {
                    anim.SetBool("enter_the_lift", false);
                    transform.Rotate(0, -90, 0);
                    started = false;
                    stunned = false;
                    canAttack = true;
                }*/
            }
            else if (started1)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, -3.54f), step);

                if (transform.position == new Vector3(transform.position.x, transform.position.y, -3.54f))
                {
                    anim.SetBool("enter_the_lift", false);
                    transform.Rotate(0, -90, 0);
                    started = false;
                    stunned = false;
                    canAttack = true;
                    started1 = false;
                    GameObject.FindGameObjectWithTag("ProductList").GetComponent<Sheet_cotroller>().switchStart = true;
                }
            }
            if (lift1tolift2)
            {

                float step1 = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, targetToLift3.position.z), step1);

                if (transform.position.z == targetToLift3.position.z)
                {
                    anim.SetBool("enter_the_lift", false);
                    transform.Rotate(0, -90, 0);
                    facingLeft = false;
                    started = false;
                    stunned = false;
                    canAttack = true;
                    lift1tolift2 = false;
                }
            }
        }
        else
        {
            Vector2 displacement;
            if (anim.GetBool("isInSmoke") && !stunned)
            {
                hori = Input.GetAxis("Horizontal") * -1;
                displacement = new Vector2()
                {
                    x = hori * Time.deltaTime * 2f,
                    y = 0

                };
                Flip(hori);
            }
            else
            {
                if (!stunned)
                {
                    hori = Input.GetAxis("Horizontal");
                    displacement = new Vector2()
                    {

                        x = hori * Time.deltaTime * speed,
                        y = 0

                    };
                    Flip(hori);
                }
                else
                {
                    displacement = new Vector2();
                }

            }

            anim.SetFloat("speed", Mathf.Abs(displacement.x));
            transform.position += (Vector3)displacement;

            if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("isJumpngInPlace") && !anim.GetBool("isInSmoke") && anim.GetBool("isGrounded") && !stunned && canAttack)
            {
                anim.SetBool("isJumpngInPlace", true);

            }
            if (Input.GetKey(KeyCode.RightAlt) && lastClickedKey != KeyCode.RightAlt && GameObject.FindGameObjectWithTag("Throwing_machine") && canAttack && anim.GetBool("isGrounded"))
            {
                if (cigarettes > 0)
                {
                    if (cigarettes == 1)
                    {
                        lastCigarette = true;
                    }
                    anim.SetBool("isCigaretteThrown", true);
                    stunned = true;
                    
                    if (throwingTime < 3.9f)
                    {
                        throwing_cigarette_line.SetActive(true);
                        throwingTime += 1 * Time.deltaTime;
                    }
                    else
                    {
                        throwingTime = 4f;
                        lastClickedKey = KeyCode.RightAlt;
                        isThrowing = true;
                    }
                   
                }
            }

            if (throwingTime >= 3.9f)
            {
                if (isThrowing)
                {
                    savedThrowingTime = throwingTime;
                    isThrowing = false;
                    throwing_cigarette_line.SetActive(false);
                    anim.SetBool("isCigaretteThrown", false);
                    anim.SetBool("releasedCigarette", true);
                }
            }
            if (Input.GetKeyUp(KeyCode.RightAlt))
            {
                savedThrowingTime = throwingTime;
                throwing_cigarette_line.SetActive(false);
                anim.SetBool("isCigaretteThrown", false);
                anim.SetBool("releasedCigarette", true);
                lastClickedKey = KeyCode.LeftAlt;
                Invoke("releasedCigaretteFalse", 0.5f);
            }
            if (Input.GetKey(KeyCode.RightControl) && !stunned)
            {
                anim.SetBool("isCreepingDown", true);
                canAttack = false;
                speed = 2f;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                print("halo");
                ChickenSoupEnding();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                HousekeeperEnding();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                UselessPastaEnding();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                SelfishEnding();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                transform.position = target.position;
            }
            else if (Input.GetKeyUp(KeyCode.RightControl))
            {
                canAttack = true;
                speed = 7f;
                anim.SetBool("isCreepingDown", false);
            }

            if (lives < 1 || displayedLives.Count == 0)
            {
                if (displayedLives.Count == 1)
                {
                    Destroy(displayedLives[displayedLives.Count - 1]);
                }
                canTakeLives = false;
                stunned = true;
                anim.SetBool("isDead", true);
                if (lastCollided != null)
                {
                    lastCollided.GetComponent<Animator>().SetBool("CharacterHasBeenCaught", false);
                }
                Invoke("InvokeDefeated", 2f);
            }

            if (lives > 0  && anim.GetBool("isParalised"))
            {
                lives -= 1 * Time.deltaTime;
            }

            //WYSZUKIWANIE BUTTONOW

            if (lastCollided != null && lastCollided.GetComponent<Animator>().GetBool("CharacterHasBeenCaught") && comboCounter < 5)
            {
                stunned = true;
                if (Input.GetKeyDown(KeyCode.LeftArrow) && previousKey == KeyCode.RightArrow)
                {
                    lastKeyPressedTime = Time.deltaTime;
                    previousKey = KeyCode.LeftArrow;
                    comboCounter++;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && previousKey == KeyCode.LeftArrow)
                {
                    lastKeyPressedTime = Time.deltaTime;
                    previousKey = KeyCode.RightArrow;
                    comboCounter++;
                }
                else if (Input.anyKeyDown || Time.deltaTime - lastKeyPressedTime > DelayBeforeReset)
                {
                    comboCounter = 0;

                }
            }
            if (comboCounter >= 5)
            {
                escaped = true;
                lastCollided.GetComponent<Animator>().SetBool("CharacterHasBeenCaught", false);
                canTakeLives = false;
                comboCounter = 0;
                Invoke("WaitForAnotherCaught", 0.5f);
            }

            if (inAir)
            {
                Vector3 vel = rb.velocity;
                vel.y -= 20 * Time.deltaTime;
                rb.velocity = vel;
            }
        }
    }
    void FirstCigarette()
    {
        if (cigarettes==9)
        {
            OpenDialogBubble("I will for sure\nneed one after\nthis trip...");
            Invoke("CloseDialogBubble", 4f);
        }
    }
    public bool lastCigarette;
    public bool canTakeLives;
    public void DisplayLessLives()
    {
        StartCoroutine(TakeLivesEmployee((int)lives, 1f));
    }
    IEnumerator TakeLivesEmployee(float duration, float blinkTime)
    {

        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            if (displayedLives.Count >=1 && canTakeLives)
            {
                Destroy(displayedLives[displayedLives.Count - 1]);
                displayedLives.RemoveAt(displayedLives.Count - 1);
            }
            yield return new WaitForSeconds(blinkTime);
        }
    }

    public Rigidbody rb;
    public void WaitForAnotherCaught()
    {
        
        lastCollided = null;

    }
    private void Flip(float hori)

    {
        if (hori < 0f)
        {
            if (!facingLeft)
            {
                if (anim.GetBool("isGrounded") && !stunned)
                {
                    hori = Input.GetAxis("Horizontal") * -1;
                    transform.Rotate(0, 180, 0);
                }
                else
                {
                    transform.Rotate(0, 180, 0);
                }
            }
            facingLeft = true;
        }
        else if (hori > 0f)
        {
            if (facingLeft)
            {
                if (anim.GetBool("isGrounded") && !stunned)
                {
                    hori = Input.GetAxis("Horizontal") * -1;
                    transform.Rotate(0, -180, 0);
                }
                else
                {
                    transform.Rotate(0, 180, 0);
                }

            }
            facingLeft = false;
        }
        else
        {
            transform.GetComponent<Rigidbody>().velocity = new Vector2(0, transform.GetComponent<Rigidbody>().velocity.y);
        }

    }



    public void SetGrounded()
    {
        anim.SetBool("isJumpngInPlace", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            touchedCount++;
            anim.SetBool("isGrounded", true);

        }
        if ((collision.transform.CompareTag("Monster") || collision.transform.CompareTag("Grandma")) && !immortal)
        {
            if (collision.transform.CompareTag("Grandma")){
                Grandma_controller gc = collision.transform.GetComponent<Grandma_controller>();
                if (gc.touchedTheTop)
                {
                    grandma_top_collider = collision.transform.GetComponent<BoxCollider>();
                    grandma_top_collider.enabled = false;
                    Invoke("GrandmaCanTouchAgain", 1f);
                }
            }
            immortal = true;
            stunned = true;
            Invoke("TakeLives", 1.0f);
            anim.SetBool("isHitted", true);

        }
    }
    BoxCollider grandma_top_collider;
    void GrandmaCanTouchAgain()
    {
        
        grandma_top_collider.enabled = true;
        grandma_top_collider.transform.GetComponent<Grandma_controller>().touchedTheTop = false;
        grandma_top_collider = null;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            touchedCount--;
            if (touchedCount == 0)
            {
                anim.SetBool("isGrounded", false);
            }
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Employee") && !anim.GetBool("isCreepingDown") && !immortal)
        {
            lastCollided = collider;
            stunned = true;
            collider.GetComponent<Animator>().SetBool("CharacterHasBeenCaught", true);

        }
        if (collider.CompareTag("Beret") && !immortal)
        {
            immortal = true;
            Invoke("TakeLives", 1.0f);
            anim.SetBool("isHitted", true);
            collider.GetComponent<Deadly_hat>().moveUp = false;
        } else if (collider.CompareTag("Beret") && immortal)
        {
            collider.GetComponent<Deadly_hat>().moveUp = false;
        }

        if (!eaten)
        {
            if (collider.CompareTag("Coin"))
            {
                //audios[0].Play();
                coins++;
                UpdateCoinAmount();
                Destroy(collider.gameObject);
                eaten = true;
                Invoke("Eaten", 0f);
            }
        }
    }
    public void UpdateCoinAmount()
    {
        coinAmount.text = "x " + coins.ToString();
    }
    public Text coinAmount;
    public Text cigaretteAmount;

    Collider lastCollided;
    public float savedThrowingTime;
    void ThrowCigarette()
    {
        throwing_cigarette_line.SetActive(false);
        anim.SetBool("isCigaretteThrown", false);
        canAttack = false;
        cigarettes--;
        FirstCigarette();
        cigaretteAmount.text = "x " + cigarettes.ToString();
        var szlg = Instantiate(cigarette, throwing_machine.transform.position, throwing_machine.transform.rotation, null);
        szlg.transform.parent = throwing_machine.transform;
        
        szlg.ThrowCigarette(savedThrowingTime);
    }

    void Jumped()
    {
        canAttack = false;
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 12, 0), ForceMode.Impulse);
    }

    public bool inAir;
    void JumpFaster()
    {
        inAir = true;
    }
    void FinishJumping()
    {
        speed = 7f;
        canAttack = true;
        inAir = false;
    }

    public void Stunned()
    {
        canAttack = false;
        stunned = true;
        anim.SetBool("isMacheteAttack", false);
        if (GameObject.FindGameObjectWithTag("Machete"))
        {
            BoxCollider[] boxcolliders = GameObject.FindGameObjectWithTag("Machete").GetComponents<BoxCollider>();
            foreach (BoxCollider bc in boxcolliders)
            {
                bc.enabled = false;
            }
        }
        anim.SetBool("isCigaretteThrown", false);
        throwing_cigarette_line.SetActive(false);
        anim.SetFloat("speed", 0f);
    }

    public void Unstunn()
    {
        stunned = false;
        canAttack = true;
    }

    public void FinishIsHitted()
    {
        //TU??? ZE WSTAJE I ZA SZYBKO IDZIE

        anim.SetBool("isHitted", false);
        //Invoke("NotImmortal", 2f);
    }

    public void FinishTheGame()
    {
        if (anim.GetBool("isDead"))
        {
            StartCoroutine(Defeated());
        }
    }

    public void TakeLives()
    {
        immortal = true;
        throwing_cigarette_line.SetActive(false);
        anim.SetBool("isCigaretteThrown", false);
        lives--;
        Destroy(displayedLives[displayedLives.Count - 1]);
        displayedLives.RemoveAt(displayedLives.Count-1);
        if (lives <= 0)
        {
            stunned = true;
            anim.SetBool("isDead", true);
            StartCoroutine(Defeated());
        }
    }

    void StopAttackingWithMachete()
    {
        stunned = false;
        canAttack = true;
        BoxCollider[] boxcolliders = GameObject.FindGameObjectWithTag("Machete").GetComponents<BoxCollider>();
        foreach (BoxCollider bc in boxcolliders)
        {
            bc.enabled = false;
        }
        anim.SetBool("isMacheteAttack", false);
    }

    void TurnOffMacheteCollider()
    {
        if (GameObject.FindGameObjectWithTag("Machete"))
        {
            GameObject.FindGameObjectWithTag("Machete").GetComponent<BoxCollider>().enabled = false;

        }

    }

    void Immortal()
    {
        immortal = true;
    }
    bool canBlink;
    void Blink()
    {
        if (!canBlink)
        {
            canBlink = true;
            Invoke("ShutBlink", 4.0f);
            StartCoroutine(DoBlinks(0.8f, 0.1f));
        }
    }
    void ShutBlink()
    {

        print("wylacza blinka");
        stunned = false;
        immortal = false;
        canBlink = false;
    }
    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        canAttack = false;
        if (GameObject.FindGameObjectWithTag("Machete"))
        {
            SkinnedMeshRenderer playerSkin = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SkinnedMeshRenderer>();
            MeshRenderer macheteSkin = GameObject.FindGameObjectWithTag("Machete").GetComponentInChildren<MeshRenderer>();
            while (duration > 0f)
            {
                duration -= Time.deltaTime;

                playerSkin.enabled = !playerSkin.enabled;
                macheteSkin.enabled = !macheteSkin.enabled;

                yield return new WaitForSeconds(blinkTime);
            }

            playerSkin.enabled = true;
            macheteSkin.enabled = true;
            canAttack = true;
            yield break;
        } else
        {
            SkinnedMeshRenderer playerSkin = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SkinnedMeshRenderer>();
            while (duration > 0f)
            {
                duration -= Time.deltaTime;
                playerSkin.enabled = !playerSkin.enabled;
                yield return new WaitForSeconds(blinkTime);
            }

            playerSkin.enabled = true;
            canAttack = true;
            yield break;
        }
        
    }

    void Eaten()
    {
        eaten = false;
    }

    void FinishEnteringTheLift()
    {
        anim.SetBool("enter_the_lift", false);
    }
    void StartEnteringTheLift()
    {
        lift1tolift2 = true;
        anim.SetBool("enter_the_lift", true);
    }
    void ChangeLift1()
    {
        transform.position = targetToLift2.position;
    }
    void releasedCigaretteFalse()
    {
        isThrowing = true;
        anim.SetBool("releasedCigarette", false);
        throwingTime = 1;
    }

    public string CheckIfEverythingIsCollected()
    {
        bool tripoloskiPack = false;
        bool thingPack = false;

        List<float> listOfTriPoloski = new List<float>()
        {
            tri_poloski_shoes, tri_poloski_sweatshirt, tri_poloski_trousers
        };
        List<float> listOfThings = new List<float>()
        {
            chilli, chicken, onions, limes, toilet_paper, coconut_milk, mushrooms, shrimps
        };

        if (listOfTriPoloski.All(o => o.Equals(true)))
        {
            print("weszlo anie powinno");
            tripoloskiPack = true;
        }
        if (listOfThings.All(o => o.Equals(true)))
        {
            print("weszlo anie powinno");
            thingPack = true;
        }

        if (tripoloskiPack && thingPack)
        {
            return "chicken_soup_is_better";
        } else if (tripoloskiPack && !thingPack)
        {
            return "selfish";
        }else if (!tripoloskiPack && thingPack)
        { 
            return "im_not_your_housekeeper"; 
        } else
        {
            return "useless_pasta";
        }
    }
    public GameObject bubbleText;
    public void OpenDialogBubble(string textInside)
    {
        bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = true;
        bubbleText.GetComponent<MeshRenderer>().enabled = true;
        bubbleText.GetComponent<TextMesh>().text = textInside;
        if (lastCigarette)
        {
            anim.SetBool("runOfCigarettes", true);
        }
    }

    public void InvokeDefeated()
    {
        StartCoroutine(Defeated());
    }

    public IEnumerator Defeated()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("LoadingScene");
    }

    public void CloseDialogBubble()
    {
        bubbleText.GetComponent<TextMesh>().text = "";
        bubbleText.GetComponent<TextMesh>().fontSize = 12;
        bubbleText.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
        bubbleText.GetComponent<MeshRenderer>().enabled = false;
    }
    public void ChangeDialogBubbleFontSize(int size)
    {
        bubbleText.GetComponent<TextMesh>().fontSize = size;
    }
    IEnumerator SelfishEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SelfishScene");
    }
    IEnumerator ChickenSoupEnding()
    {
        print("HALO");
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("ChickenSoupScene");
    }
    IEnumerator HousekeeperEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("HousekeeperScene");
    }
    IEnumerator UselessPastaEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("UselessPastaScene");
    }
}
