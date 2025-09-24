
public class QuietoComportamientoState : IComportamientoState
{
    public void enemigoEncontrado(ComportamientoEnemigoGenerico en)
    {
        en.State = new PerseguirComportamientoState();
    }

    public void enemigoPerdido(ComportamientoEnemigoGenerico en)
    {
        en.State = new FinPerseguirComportamientoState();
    }

    public void patrullar(ComportamientoEnemigoGenerico en)
    {
        en.State = new PatrullarComportamientoState();
    }

    public void quieto(ComportamientoEnemigoGenerico en)
    {
        en.inicializar();
    }
}