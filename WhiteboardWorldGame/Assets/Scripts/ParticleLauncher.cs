using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour {

    [SerializeField]
    private ParticleSystem m_particleLauncer;
    [SerializeField]
    private ParticleSystem m_splatterparticles;
    [SerializeField]
    private GameObject m_Whiteboard;

    public DecalPool decalPool;

    private List<ParticleCollisionEvent> m_collisionEvents; //To store the results of OnParticleCollsion
    private bool m_CanDraw = false;

    private void Start()
    {
        m_collisionEvents = new List<ParticleCollisionEvent>();
    }

    void Update () {

        m_CanDraw = m_Whiteboard.GetComponent<WhiteboardObjects>().penOverWhiteboard;
        
        if ((Input.GetButton("Fire1")) && (m_CanDraw == true))
        {
            //In Future, move pen down to draw and then emit
            m_particleLauncer.Emit(1);
        }
        //In Future, when the above is false, pen moves back to original position
    }//End Update

    private void OnParticleCollision(GameObject other)//Checks where the particles hit
    {
        ParticlePhysicsExtensions.GetCollisionEvents(m_particleLauncer, other, m_collisionEvents); //To store the results of OnParticleCollsion

        for(int i = 0; i < m_collisionEvents.Count; i++)
        {
            if ((m_collisionEvents[i].colliderComponent.tag == "Start") || (m_collisionEvents[i].colliderComponent.tag == "Finish") || (m_collisionEvents[i].colliderComponent.tag == "NextDecal"))
            {
                decalPool.PlaceDecal(m_collisionEvents[i]); //Places Ink
                EmitAtLocatin(m_collisionEvents[i]); //Places the splatter
            }
        }
    }//End Particle Collision Event

    //This moves the particle emitter to the location of the collision using the collision event
    private void EmitAtLocatin(ParticleCollisionEvent _particleCollision)
    {
        m_splatterparticles.transform.position = _particleCollision.intersection;
        m_splatterparticles.transform.rotation = Quaternion.LookRotation(_particleCollision.normal);
        m_splatterparticles.Emit(1);
    }

}
