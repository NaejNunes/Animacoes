using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGirlController : MonoBehaviour
{
    public float velocidade, forcaPulo;

     private bool verificaChao;

    public Transform chaoVerificador;

    public Transform spritePlayer;

    private Animator animador;

    public bool estaNoChao;

    public float movimentacao = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animador = spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();

        animador.SetBool("chao", estaNoChao);
        animador.SetFloat("movimento", movimentacao);
    }

    public void Movimentacao()
    {
        verificaChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Chao"));

        if (Input.GetAxisRaw("Horizontal2") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal2") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump2") && verificaChao)
        {

            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }
}
