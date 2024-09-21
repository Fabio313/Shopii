namespace Domain.Queries.v1.Messages.GetChat
{
    public class GetChatQueryResponse
    {
        public IEnumerable<MessagesResponse> Messages { get; set; }
    }

    public class MessagesResponse
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
    }
}
