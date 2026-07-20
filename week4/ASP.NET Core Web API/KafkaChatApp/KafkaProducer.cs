using Confluent.Kafka;

namespace KafkaChatApp
{
    public class KafkaProducer
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"[Producer] Message Sent: {message}");
        }
    }
}