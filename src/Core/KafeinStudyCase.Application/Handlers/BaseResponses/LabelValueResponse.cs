namespace KafeinStudyCase.Handlers.BaseResponses
{
    public class LabelValueResponse
    {
        public Guid Value { get; init; }
        public string Label { get; set; } = null!;

    }
}
