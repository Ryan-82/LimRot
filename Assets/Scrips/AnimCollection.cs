using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimClip", menuName = "Tachy/Animation Clip")]
public class AnimCollection : ScriptableObject
{
    public List<Texture2D> textures;
    public bool loop = false;
    public int fps = 12;

    private float timer = 0;
    private int index = 0;

    public AnimState AnimUpdate(float delta)
    {
        timer += delta;
        
        if (timer * fps > 1)
        {
            timer = 0;
            //animIndex = (animIndex + 1) % textures.Count;
            index++;
            if (!loop) {
                if (index >= textures.Count)
                    return AnimState.loopend;
            }

            index %= textures.Count;
            return AnimState.changed;
        }
        return AnimState.unchanged;
    }

    public Texture GetTexture()
    {
        if (index > textures.Count)
            return textures[index - 1];
        return textures[index];
    }
}

public enum AnimState
{
    unchanged,
    changed,
    loopend,
}