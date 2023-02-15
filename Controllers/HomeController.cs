using Akka.Actor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AkkaApi.Actors;
using AkkaApi.Messages;

namespace AkkaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        static ActorSystem sistemaCanciones = ActorSystem.Create("sistemaCanciones");
        static IActorRef actorCanciones = sistemaCanciones.ActorOf<ActorCanciones>("actorCanciones");




        [HttpGet]
        public async Task<string> Get()
        {
            var sistema = ActorSystem.Create("primerSistema");
            var actorPersona = sistema.ActorOf<ActorPersona>("actorPersona");
            var respuesta = await actorPersona.Ask<Persona>(new Persona("Sebas"));
            sistema.Stop(actorPersona);
            return respuesta.getNombre();
        }

        [HttpPost]
        [Route("InsertarCancion")]
        public async Task<List<Cancion>> InsertarCancion(Cancion nueva)
        {

            

            var listaCanciones = actorCanciones.Ask<List<Cancion>>(nueva);
            
            return listaCanciones.Result;
        } 

        

        
    }
}
