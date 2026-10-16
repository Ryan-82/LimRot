using System.Linq;
using UnityEngine;


public class AnimationHandler : MonoBehaviour
{
    public AnimCollection[] anim = null;
    private int animIndex = 0;
    private Renderer rend;
    private bool running = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        RunAnimation(0);
    }

    public void RunAnimation(int index)
    {
        if (anim.Length == 0)
            return;
        animIndex = index % anim.Length;
        running = true;
    }


    void Update()
    {
        if (anim.Length == 0)
            return;
        if (!running)
            return;

        AnimState state = anim[animIndex].AnimUpdate(Time.deltaTime);

        if (state == AnimState.loopend) {
            running = false;
            return;
        }
        if (state == AnimState.changed) {
            rend.material.mainTexture = anim[animIndex].GetTexture();
        }
    }
}
