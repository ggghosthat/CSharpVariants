using System;

namespace Variant;

public class Program
{
	public static void Main(string[] args)
	{
		IMessenger<Message> outlook = new EmailMessenger();
		Message message = outlook.WriteMessage("Hello World");
		Console.WriteLine(message.Text);

		IMessenger<EmailMessage> emailClient = new EmailMessenger();
		IMessenger<Message> messenger = emailClient;
		Message emailMessage = messenger.WriteMessage("Hi!");
		Console.WriteLine(emailMessage.Text);


		Console.WriteLine();
		Console.WriteLine("-----------------");


		ISender<EmailMessage> outlook1 = new SimpleSender();
		outlook1.SendMessage(new EmailMessage("Hi from 1!"));

		ISender<Message> telegram = new SimpleSender();
		ISender<EmailMessage> emailClient1 = telegram;
		emailClient1.SendMessage(new EmailMessage("Hello from 1st email client!"));


		Console.WriteLine();
		Console.WriteLine("-----------------");

		IChatter<Message, EmailMessage> chatter = new AlienChatter();
		Message messageAlien1 = chatter.WriteMessage("Hello beautifull World from DEF-16");
		Console.WriteLine(messageAlien1.Text);
		chatter.SendMessage(new EmailMessage("Welcome to our World aliens from DEF-16"));

	}
}