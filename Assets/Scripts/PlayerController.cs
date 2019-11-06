using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public Animator anim;
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rb2D;

	private bool walking = false;

	public GameManager manager;

	public GameObject EfeitoCarne;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space)) {
			rb2D.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
		}

		if (Input.GetKey(KeyCode.A)) {
			Vector2 v = transform.position;
			v.x -= 0.1f;
			transform.position = v;
			walking = true;
			spriteRenderer.flipX = true;
		} else if (Input.GetKey(KeyCode.D)) {
			Vector2 v = transform.position;
			v.x += 0.1f;
			transform.position = v;
			walking = true;
			spriteRenderer.flipX = false;
		}

		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) ) {
			walking = false;
		}

		anim.SetBool("walking", walking);
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Player") {
			return;
		}
		
		if (collider.tag == "DeathCactus" || collider.tag == "DeathBase") {
			manager.AddLife(-1,1);
		}

		if (collider.tag == "PlataformaMovel") {
			gameObject.transform.parent = collider.transform;
		}

		if (collider.tag == "Fase2") {
			
			manager.MudarFase("Level02");
		}

		if (collider.tag == "Fase3") {
			
			manager.MudarFase("Level03");
		}

		if (collider.tag == "Fase4") {
			
			manager.MudarFase("Level04");
		}

		if (collider.tag == "NewLife") {
			Instantiate(EfeitoCarne, new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
			manager.AddLife(1,0);
		}
		
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "PlataformaMovel") {
			gameObject.transform.parent = null;
		}
	}

}
