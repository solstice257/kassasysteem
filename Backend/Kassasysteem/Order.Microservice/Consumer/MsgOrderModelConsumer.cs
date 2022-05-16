using MassTransit;
using SharedLibrary;

namespace Order.Microservice.Consumer
{
    public class MsgOrderModelConsumer : IConsumer<MsgOrderModel>
    {
        private ILogger<MsgOrderModelConsumer> _logger;

        public MsgOrderModelConsumer(ILogger<MsgOrderModelConsumer> _logger)
        {
            this._logger = _logger;
        }

        public async Task Consume(ConsumeContext<MsgOrderModel> context)
        {
            _logger.LogInformation($"Got a new log {context.Message.orderID}");
        }
    }
}
