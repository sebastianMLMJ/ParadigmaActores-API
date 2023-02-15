using AkkaApi.Messages;
using Akka.Actor;

namespace AkkaApi.Actors
{
    public class ActorCanciones: ReceiveActor
    {

        public ActorCanciones() {

            ActorSystem sistemaLista = ActorSystem.Create("sistemaLista");
            IActorRef actorLista = sistemaLista.ActorOf<ActorLista>("actorLista");

            Receive<Cancion>(cancionrecibida =>
            {
                var listaCanciones = actorLista.Ask<List<Cancion>>(cancionrecibida);
                Sender.Tell(listaCanciones.Result);
            });

        }
    }
}
