using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrails : MonoBehaviour
{
    ParticleSystem ps;
    private float trailLifeMax = 0.05f;
    public float trailDivisor = 10;
    public float simSpeedIncrease = 1;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var trails = ps.trails;
        var main = ps.main;
        trails.lifetime = 0;
        main.simulationSpeed = simSpeedIncrease;
        ps.Pause();
        StartCoroutine(Delay(3));



        return;
    }
    private void Update()
    {

        if (GameManager.instance.state == GameManager.eState.RESULTS)
        {
            var trails = ps.trails;
            trails.lifetime = 0;
            StartCoroutine(Delay(0.01f));
            ps.Pause();

        }
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        ps.Play();
    }
    // Update is called once per frame
    public void IncreaseTrail()
    {
        trailDivisor--;
        simSpeedIncrease++;
        var trails = ps.trails;
        var main = ps.main;
        trails.lifetime = trailLifeMax / trailDivisor;
        main.simulationSpeed = simSpeedIncrease;
    }
}
