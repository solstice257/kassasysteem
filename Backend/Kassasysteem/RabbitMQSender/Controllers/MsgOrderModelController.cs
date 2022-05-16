using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;

namespace RabbitMQSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MsgOrderModelController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        public MsgOrderModelController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        [HttpPost()]
        public async Task <ActionResult> Create(MsgOrderModel msgOrderModel)
        {
            await publishEndpoint.Publish<MsgOrderModel>(msgOrderModel);
            return Ok();
        }
    }
}