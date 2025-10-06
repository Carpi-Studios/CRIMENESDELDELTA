
public class PatrullarComportamientoState : IComportamientoState
{

    public void enemigoEncontrado(ComportamientoEnemigoGenerico en)
    {
        en.State = new PerseguirComportamientoState();
    }

    public void enemigoPerdido(ComportamientoEnemigoGenerico en)
    {
 
    }

    public void patrullar(ComportamientoEnemigoGenerico en)
    {
        en.Transform.position = en.movimiento.moverse(en.Transform, en.Speed);
    }

    public void quieto(ComportamientoEnemigoGenerico en)
    {
      
    }
}