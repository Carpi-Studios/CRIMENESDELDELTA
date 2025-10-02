using UnityEngine;

public class FinPerseguirComportamientoState : IComportamientoState
{
    public void enemigoEncontrado(ComportamientoEnemigoGenerico en)
    {
        en.Agent.ResetPath();
        en.State = new PerseguirComportamientoState();
    }

    public void enemigoPerdido(ComportamientoEnemigoGenerico en)
    {
        en.Agent.ResetPath();
        en.State = new PatrullarComportamientoState();
    }

    public void patrullar(ComportamientoEnemigoGenerico en)
    {
        en.Agent.ResetPath();
        en.State = new PatrullarComportamientoState();
    }

    public void quieto(ComportamientoEnemigoGenerico en)
    {

    }
}