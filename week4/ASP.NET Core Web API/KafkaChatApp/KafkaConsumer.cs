using Confluent.Kafka;

namespace KafkaChatApp
{
    public class KafkaConsumer
    {
        public void ReceiveMessage()
        {
            Console.WriteLine("[Consumer] Message Received Successfully");
        }
    }
}