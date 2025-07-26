using UnityEngine;

public class MonumentManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator pyramid_anim;
    public Animator totem_anim;
    public Animator stonehenge_anim;
    public Animator obelisk_anim;
    public Animator sundial_anim;


    public void OnPyramidBuild()
    {
        pyramid_anim.SetTrigger("Build");
    }
    public void OnTotemBuild()
    {
        totem_anim.SetTrigger("Build");
    }
    public void OnStoneHengeBuild()
    {
        stonehenge_anim.SetTrigger("Build");
    }
    public void OnObeliskBuild()
    {
        obelisk_anim.SetTrigger("Build");
    }
    public void OnSundialBuild()
    {
        sundial_anim.SetTrigger("Build");
    }
    public void OnResetProgress()
    {
        pyramid_anim.SetTrigger("Destroy");
        totem_anim.SetTrigger("Destroy");
        stonehenge_anim.SetTrigger("Destroy");
        obelisk_anim.SetTrigger("Destroy");
        sundial_anim.SetTrigger("Destroy");
    }
}
