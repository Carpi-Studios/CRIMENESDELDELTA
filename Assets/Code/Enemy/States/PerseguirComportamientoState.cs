
public class PerseguirComportamientoState : IComportamientoState
{
    public void enemigoEncontrado(ComportamientoEnemigoGenerico en)
    {
        en.Agent.SetDestination(en.Objetivo.position);  
    }

    public void enemigoPerdido(ComportamientoEnemigoGenerico en)
    {
        en.State = new FinPerseguirComportamientoState();   
    }

    public void patrullar(ComportamientoEnemigoGenerico en)
    {
        en.State = new FinPerseguirComportamientoState(); 
    }

    public void quieto(ComportamientoEnemigoGenerico en)
    {
       // en.State = new QuietoComportamientoState();
    }
}