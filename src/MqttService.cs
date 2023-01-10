using MQTTnet;
using MQTTnet.Client;

namespace Sample.Service.WindowsService;

public class MqttService
{
    private readonly ILogger<MqttService> _logger;

    public MqttService(ILogger<MqttService> logger) =>
    _logger = logger;

    public async Task RunAsync(string message)
    {
        MqttClientOptions clientOptions = new MqttClientOptionsBuilder()
            .WithClientId("Dev.To")
            .WithTcpServer("127.0.0.1", 1883)
            .Build();

        MqttApplicationMessage appMessage = new MqttApplicationMessageBuilder()
            .WithTopic("test")
            .WithPayload(message)
            .Build();

        using (IMqttClient _mqttClient = new MqttFactory().CreateMqttClient())
        {
            _mqttClient.ConnectingAsync += async e => await LogInfo("Connecting to MQTT server.");
            _mqttClient.ConnectedAsync += async e => await LogInfo("Successfully connected.");
            _mqttClient.DisconnectedAsync += async e => await LogInfo("Successfully disconnected.");
            _mqttClient.ApplicationMessageReceivedAsync += async e => await LogInfo("Message received.");
        
            await _mqttClient.ConnectAsync(clientOptions, CancellationToken.None);
            await _mqttClient.PublishAsync(appMessage, CancellationToken.None);
            await _mqttClient.DisconnectAsync();
        };
    }

    private async Task LogInfo(string message)
    {
        await Task.Run(()=>_logger.LogInformation(message));
    } 
    

}
