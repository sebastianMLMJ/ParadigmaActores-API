using AkkaApi.Messages;
using Akka.Actor;
namespace AkkaApi.Actors
{
    public class ActorLista: ReceiveActor
    {
        List<Cancion> canciones;
        public ActorLista()
        {
            canciones = new List<Cancion>();

            Receive<Cancion>(cancionrecibida =>
            {
                canciones.Add(cancionrecibida);
                Sender.Tell(canciones);
            });

        }
    }
}
