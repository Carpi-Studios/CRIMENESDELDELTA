using UnityEngine;
public interface IComportamientoState
{
    void enemigoEncontrado(ComportamientoEnemigoGenerico en);
    void enemigoPerdido(ComportamientoEnemigoGenerico en);
    void patrullar(ComportamientoEnemigoGenerico en);
    void quieto(ComportamientoEnemigoGenerico en);
}