namespace School.Core.Features.Ins_SubjectFeature.Query.Responses
{
    public class GetSubjectsAttatchedWithInstractorResponse
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int? Period { get; set; }
    }
}
