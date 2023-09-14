using KafeinStudyCase.Core.Base.Dtos;

namespace KafeinStudyCase.Application.Handlers
{
    public class GeneralResponse : IResponse
    {
        public string Result { get; set; }
    }
}
