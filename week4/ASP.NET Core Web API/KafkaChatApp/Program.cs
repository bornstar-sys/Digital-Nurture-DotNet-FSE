using KafkaChatApp;

Console.WriteLine("Kafka Chat Application");
Console.WriteLine("----------------------");

KafkaProducer producer = new KafkaProducer();
KafkaConsumer consumer = new KafkaConsumer();

Console.WriteLine("Type a message (type 'exit' to quit):");

while (true)
{
    Console.Write("You: ");
    string? message = Console.ReadLine();

    if (message?.ToLower() == "exit")
        break;

    producer.SendMessage(message!);
    consumer.ReceiveMessage();
}