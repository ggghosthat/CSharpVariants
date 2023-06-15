namespace Variant;
class Message
{
	public string Text {get; set;}

	public Message(string text) => Text = text;
}

class EmailMessage : Message
{
	public EmailMessage(string text): base(text){}
}