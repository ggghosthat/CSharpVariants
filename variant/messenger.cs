namespace Variant;

//covariant implementation
interface IMessenger<out T>
{
	T WriteMessage(string text);
}

//contrvariant implementation
interface ISender<in T>
{
	void SendMessage(T message);
}

//multivariant (contr- and co- variants) implementation
interface IChatter<in T, out K>
{
	void SendMessage(T message);
	K WriteMessage(string text);
}

class EmailMessenger: IMessenger<EmailMessage>
{
	public EmailMessage WriteMessage(string text)
	{
		return new EmailMessage($"Email: {text}");
	}
}

class SimpleSender: ISender<Message>
{
	public void SendMessage(Message message)
	{
		Console.WriteLine($"Sending message: {message.Text}");
	}
}



class AlienChatter: IChatter<Message, EmailMessage>
{
	public void SendMessage(Message message)
	{
		Console.WriteLine($"Sending alien message: {message.Text}");
	}

	public EmailMessage WriteMessage(string text)
	{
		return new EmailMessage($"Email: {text}");
	}
}