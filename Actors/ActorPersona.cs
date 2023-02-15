using Akka.Actor;
using AkkaApi.Messages;
namespace AkkaApi.Actors
{
    public class ActorPersona : ReceiveActor
    {
        public ActorPersona()
        {
            
            Receive<Persona>(personarecibida =>
            {
                personarecibida.AgregarApellido("Milian");
                Sender.Tell(personarecibida);
            });

           
        }
    }
}
